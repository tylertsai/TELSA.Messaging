using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TELSA.Messaging.LINE.Messages;

namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// LINE Messaging API Client.
    /// </summary>
    public class MessagingApiClient
    {
        private HttpClient _httpClient;
        private JsonSerializerSettings _settings;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="channelAccessToken">Channel Access Token.</param>
        /// <param name="apiUrl">LINE API Url.</param>
        public MessagingApiClient(string channelAccessToken, string apiUrl = "https://api.line.me/v2/bot/")
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(apiUrl)
            };

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", channelAccessToken);

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            _settings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };
        }

        /// <summary>
        /// Send a HTTP request as an asynchronous operation.
        /// </summary>
        /// <param name="request">HTTP request.</param>
        /// <returns>Messaging API response.</returns>
        /// <exception cref="LineMessagingException"></exception>
        private async Task<MessagingApiResponse> SendAsync(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<LineMessagingError>(await response.Content.ReadAsStringAsync());

                throw new LineMessagingException(response.StatusCode, error.Message, error);
            }

            return new MessagingApiResponse(response);
        }

        /// <summary>
        /// POST message to API.
        /// </summary>
        /// <param name="api">API.</param>
        /// <returns>Messaging API response.</returns>
        private async Task<MessagingApiResponse> GetAsync(string api)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, api);

            return await SendAsync(request);
        }
        
        /// <summary>
        /// POST message to API.
        /// </summary>
        /// <param name="api">API.</param>
        /// <param name="json">JSON.</param>
        /// <returns>Messaging API response.</returns>
        private async Task<MessagingApiResponse> PostAsync(string api, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, api)
            {
                Content = content
            };

            return await SendAsync(request);
        }

        /// <summary>
        /// Sends a reply message in response to an event from a user, group, or room.
        /// </summary>
        /// <param name="replyMessage">Reply message.</param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>
        /// To send reply messages, you must have a reply token which is included in a webhook event object.<br/><br/>
        /// <a href="https://developers.line.biz/en/reference/messaging-api/#webhooks">Webhooks</a> are used to notify you when an event occurs.For events that you can respond to, a reply token is issued for replying to messages.<br/><br/>
        /// Because the reply token becomes invalid after a certain period of time, responses should be sent as soon as a message is received.Reply tokens can only be used once.<br/><br/>
        /// See <a href="https://developers.line.biz/en/reference/messaging-api/#send-reply-message">Here</a>.
        /// </remarks>
        public async Task<MessagingApiResponse> SendReplyMessageAsync(string replyMessage)
        {
            return await PostAsync("message/reply", replyMessage);
        }

        /// <summary>
        /// Sends a reply message in response to an event from a user, group, or room.
        /// </summary>
        /// <param name="replyMessage">Reply message.</param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>
        /// To send reply messages, you must have a reply token which is included in a webhook event object.<br/><br/>
        /// <a href="https://developers.line.biz/en/reference/messaging-api/#webhooks">Webhooks</a> are used to notify you when an event occurs.For events that you can respond to, a reply token is issued for replying to messages.<br/><br/>
        /// Because the reply token becomes invalid after a certain period of time, responses should be sent as soon as a message is received.Reply tokens can only be used once.<br/><br/>
        /// See <a href="https://developers.line.biz/en/reference/messaging-api/#send-reply-message">Here</a>.
        /// </remarks>
        public async Task<MessagingApiResponse> SendReplyMessageAsync(ReplyMessage replyMessage)
        {
            var json = JsonConvert.SerializeObject(replyMessage, _settings);

            return await SendReplyMessageAsync(json);
        }

        /// <summary>
        /// Sends a push message to a user, group, or room at any time.
        /// </summary>
        /// <param name="pushMessage">Push message.</param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-push-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendPushMessageAsync(string pushMessage)
        {
            return await PostAsync("message/push", pushMessage);
        }

        /// <summary>
        /// Sends a push message to a user, group, or room at any time.
        /// </summary>
        /// <param name="pushMessage">Push message.</param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-push-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendPushMessageAsync(PushMessage pushMessage)
        {
            var json = JsonConvert.SerializeObject(pushMessage, _settings);

            return await SendPushMessageAsync(json);
        }

        /// <summary>
        /// Sends push messages to multiple users at any time. Messages cannot be sent to groups or rooms.
        /// </summary>
        /// <param name="multicastMessage">Multicast Message.</param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-multicast-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendMulticastMessageAsync(string multicastMessage)
        {
            return await PostAsync("message/multicast", multicastMessage);
        }

        /// <summary>
        /// Sends push messages to multiple users at any time. Messages cannot be sent to groups or rooms.
        /// </summary>
        /// <param name="multicastMessage">Multicast Message.</param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-multicast-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendMulticastMessageAsync(MulticastMessage multicastMessage)
        {
            var json = JsonConvert.SerializeObject(multicastMessage, _settings);

            return await SendMulticastMessageAsync(json);
        }

        /// <summary>
        /// Sends a push message to multiple users. You can specify recipients using attributes (such as age, gender, OS, and region) or by retargeting (audiences). Messages cannot be sent to groups or rooms.
        /// </summary>
        /// <param name="narrowcastMessage">Narrowcast message.</param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-narrowcast-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendNarrowcastMessageAsync(string narrowcastMessage)
        {
            return await PostAsync("message/narrowcast", narrowcastMessage);
        }
        
        /// <summary>
        /// Sends a push message to multiple users. You can specify recipients using attributes (such as age, gender, OS, and region) or by retargeting (audiences). Messages cannot be sent to groups or rooms.
        /// </summary>
        /// <param name="narrowcastMessage">Narrowcast message.</param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-narrowcast-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendNarrowcastMessageAsync(NarrowcastMessage narrowcastMessage)
        {
            var json = JsonConvert.SerializeObject(narrowcastMessage, _settings);

            return await SendNarrowcastMessageAsync(json);
        }

        /// <summary>
        /// Gets the status of a narrowcast message.
        /// </summary>
        /// <param name="requestId">The narrowcast message's request ID. Each Messaging API request has a request ID. Find it in the <a href="https://developers.line.biz/en/reference/messaging-api/#response-headers">response headers</a>.</param>
        /// <returns></returns>
        /// <remarks>
        /// Notice: Messages must have a minimum number of recipients<br/><br/>
        /// Narrowcast messages cannot be sent when the number of recipients is below a certain minimum amount, to prevent someone from guessing the recipients' attributes. The minimum number of recipients is a private value defined by the LINE Platform.<br/><br/>
        /// <br/><br/>
        /// Notice: Window of availability for status requests<br/><br/>
        /// You can get the status of a narrowcast message for up to 7 days after you have requested that it be sent.<br/><br/>
        /// <br/><br/>
        /// See <a href="https://developers.line.biz/en/reference/messaging-api/#get-narrowcast-progress-status">Here</a>.
        /// </remarks>
        public async Task<RequestProgress> GetNarrowcastMessageStatusAsync(string requestId)
        {
            var response = await GetAsync($"message/progress/narrowcast?requestId={requestId}");
            var json = await response.HttpResponseMessage.Content.ReadAsStringAsync();
            var requestProgress = JsonConvert.DeserializeObject<RequestProgress>(json);

            return requestProgress;
        }

        /// <summary>
        /// Sends push messages to multiple users at any time.
        /// </summary>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-broadcast-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendBroadcastMessageAsync(string broadcastMessage)
        {
            return await PostAsync("message/broadcast", broadcastMessage);
        }
        
        /// <summary>
        /// Sends push messages to multiple users at any time.
        /// </summary>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-broadcast-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendBroadcastMessage(BroadcastMessage broadcastMessage)
        {
            var json = JsonConvert.SerializeObject(broadcastMessage, _settings);

            return await SendBroadcastMessageAsync(json);
        }
        
        /// <summary>
        /// Gets images, videos, audio, and files sent by users.
        /// </summary>
        /// <param name="messageId">Message ID</param>
        /// <returns>
        /// Messaging API response.<br/><br/>
        /// Returns status code 200 and the content in binary.<br/><br/>
        /// <br/><br/>
        /// Content is automatically deleted after a certain period from when the message was sent. There is no guarantee for how long content is stored.
        /// </returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#get-content">Here</a>.</remarks>
        public async Task<MessagingApiResponse> GetContent(string messageId)
        {
            return await GetAsync($"https://api-data.line.me/v2/bot/message/{messageId}/content");
        }
    }
}

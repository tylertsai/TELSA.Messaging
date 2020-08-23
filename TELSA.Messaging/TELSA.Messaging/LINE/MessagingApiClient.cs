using System;
using System.Net;
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
        /// POST message to API.
        /// </summary>
        /// <param name="api">API.</param>
        /// <param name="json">JSON.</param>
        /// <returns>Task.</returns>
        private async Task PostAsync(string api, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, api)
            {
                Content = content
            };

            var response = await _httpClient.SendAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var error = JsonConvert.DeserializeObject<LineMessagingError>(await response.Content.ReadAsStringAsync());

                throw new LineMessagingException(response.StatusCode, error.Message, error);
            }
        }

        /// <summary>
        /// Sends a reply message in response to an event from a user, group, or room.
        /// </summary>
        /// <param name="replyMessage">Reply message.</param>
        /// <returns>Task.</returns>
        /// <remarks>
        /// To send reply messages, you must have a reply token which is included in a webhook event object.<br/><br/>
        /// <a href="https://developers.line.biz/en/reference/messaging-api/#webhooks">Webhooks</a> are used to notify you when an event occurs.For events that you can respond to, a reply token is issued for replying to messages.<br/><br/>
        /// Because the reply token becomes invalid after a certain period of time, responses should be sent as soon as a message is received.Reply tokens can only be used once.
        /// </remarks>
        public async Task SendReplyMessageAsync(string replyMessage)
        {
            await PostAsync("message/reply", replyMessage);
        }

        /// <summary>
        /// Sends a reply message in response to an event from a user, group, or room.
        /// </summary>
        /// <param name="replyMessage">Reply message.</param>
        /// <returns>Task.</returns>
        /// <remarks>
        /// To send reply messages, you must have a reply token which is included in a webhook event object.<br/><br/>
        /// <a href="https://developers.line.biz/en/reference/messaging-api/#webhooks">Webhooks</a> are used to notify you when an event occurs.For events that you can respond to, a reply token is issued for replying to messages.<br/><br/>
        /// Because the reply token becomes invalid after a certain period of time, responses should be sent as soon as a message is received.Reply tokens can only be used once.
        /// </remarks>
        public async Task SendReplyMessageAsync(ReplyMessage replyMessage)
        {
            var json = JsonConvert.SerializeObject(replyMessage, _settings);

            await SendReplyMessageAsync(json);
        }

        /// <summary>
        /// Sends a push message to a user, group, or room at any time.
        /// </summary>
        /// <param name="pushMessage">Push message.</param>
        /// <returns>Task.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-push-message">Here</a>.</remarks>
        public async Task SendPushMessageAsync(string pushMessage)
        {
            await PostAsync("message/push", pushMessage);
        }

        /// <summary>
        /// Sends a push message to a user, group, or room at any time.
        /// </summary>
        /// <param name="pushMessage">Push message.</param>
        /// <returns>Task.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-push-message">Here</a>.</remarks>
        public async Task SendPushMessageAsync(PushMessage pushMessage)
        {
            var json = JsonConvert.SerializeObject(pushMessage, _settings);

            await SendPushMessageAsync(json);
        }
    }
}

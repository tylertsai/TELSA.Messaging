using System;
using System.Collections.Generic;
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
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerSettings _settings;

        #region Constructors
        
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

        #endregion
        
        #region Message
        
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
        /// <param name="headers">Request headers.</param>
        /// <returns>Messaging API response.</returns>
        private async Task<MessagingApiResponse> PostAsync(string api, string json, IEnumerable<KeyValuePair<string, string>> headers = null)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, api)
            {
                Content = content
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

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
        /// Send message.
        /// </summary>
        /// <param name="api">API Url.</param>
        /// <param name="message">Message.</param>
        /// <param name="retryKey">
        /// * The retry key lets you retry a request while preventing the same request from being accepted in duplicate. For more information, see Retrying a failed API request.<br/>
        /// * The retry key is valid for 24 hours after attempting the first request.<br/>
        /// See <a href="https://developers.line.biz/en/reference/messaging-api/#retry-api-request">Here</a>.
        /// </param>
        /// <returns></returns>
        private async Task<MessagingApiResponse> SendMessageAsync(string api, string message, Guid? retryKey = null)
        {
            List<KeyValuePair<string, string>> headers = null;
            if (retryKey != null)
            {
                headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("X-Line-Retry-Key", retryKey.ToString())
                };
            }

            return await PostAsync(api, message, headers);
        }

        /// <summary>
        /// Sends a push message to a user, group, or room at any time.
        /// </summary>
        /// <param name="pushMessage">Push message.</param>
        /// <param name="retryKey">
        /// * The retry key lets you retry a request while preventing the same request from being accepted in duplicate. For more information, see Retrying a failed API request.<br/>
        /// * The retry key is valid for 24 hours after attempting the first request.<br/>
        /// See <a href="https://developers.line.biz/en/reference/messaging-api/#retry-api-request">Here</a>.
        /// </param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-push-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendPushMessageAsync(string pushMessage, Guid? retryKey = null)
        {
            return await SendMessageAsync("message/push", pushMessage, retryKey);
        }

        /// <summary>
        /// Sends a push message to a user, group, or room at any time.
        /// </summary>
        /// <param name="pushMessage">Push message.</param>
        /// <param name="retryKey">
        /// * The retry key lets you retry a request while preventing the same request from being accepted in duplicate. For more information, see Retrying a failed API request.<br/>
        /// * The retry key is valid for 24 hours after attempting the first request.<br/>
        /// See <a href="https://developers.line.biz/en/reference/messaging-api/#retry-api-request">Here</a>.
        /// </param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-push-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendPushMessageAsync(PushMessage pushMessage, Guid? retryKey = null)
        {
            var json = JsonConvert.SerializeObject(pushMessage, _settings);

            return await SendPushMessageAsync(json, retryKey);
        }

        /// <summary>
        /// Sends push messages to multiple users at any time. Messages cannot be sent to groups or rooms.
        /// </summary>
        /// <param name="multicastMessage">Multicast Message.</param>
        /// <param name="retryKey">
        /// * The retry key lets you retry a request while preventing the same request from being accepted in duplicate. For more information, see Retrying a failed API request.<br/>
        /// * The retry key is valid for 24 hours after attempting the first request.<br/>
        /// See <a href="https://developers.line.biz/en/reference/messaging-api/#retry-api-request">Here</a>.
        /// </param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-multicast-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendMulticastMessageAsync(string multicastMessage, Guid? retryKey = null)
        {
            return await SendMessageAsync("message/multicast", multicastMessage, retryKey);
        }

        /// <summary>
        /// Sends push messages to multiple users at any time. Messages cannot be sent to groups or rooms.
        /// </summary>
        /// <param name="multicastMessage">Multicast Message.</param>
        /// <param name="retryKey">
        /// * The retry key lets you retry a request while preventing the same request from being accepted in duplicate. For more information, see Retrying a failed API request.<br/>
        /// * The retry key is valid for 24 hours after attempting the first request.<br/>
        /// See <a href="https://developers.line.biz/en/reference/messaging-api/#retry-api-request">Here</a>.
        /// </param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-multicast-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendMulticastMessageAsync(MulticastMessage multicastMessage, Guid? retryKey = null)
        {
            var json = JsonConvert.SerializeObject(multicastMessage, _settings);

            return await SendMulticastMessageAsync(json, retryKey);
        }

        /// <summary>
        /// Sends a push message to multiple users. You can specify recipients using attributes (such as age, gender, OS, and region) or by retargeting (audiences). Messages cannot be sent to groups or rooms.
        /// </summary>
        /// <param name="narrowcastMessage">Narrowcast message.</param>
        /// <param name="retryKey">
        /// * The retry key lets you retry a request while preventing the same request from being accepted in duplicate. For more information, see Retrying a failed API request.<br/>
        /// * The retry key is valid for 24 hours after attempting the first request.<br/>
        /// See <a href="https://developers.line.biz/en/reference/messaging-api/#retry-api-request">Here</a>.
        /// </param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-narrowcast-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendNarrowcastMessageAsync(string narrowcastMessage, Guid? retryKey)
        {
            return await SendMessageAsync("message/narrowcast", narrowcastMessage, retryKey);
       }

        /// <summary>
        /// Sends a push message to multiple users. You can specify recipients using attributes (such as age, gender, OS, and region) or by retargeting (audiences). Messages cannot be sent to groups or rooms.
        /// </summary>
        /// <param name="narrowcastMessage">Narrowcast message.</param>
        /// <param name="retryKey">
        /// * The retry key lets you retry a request while preventing the same request from being accepted in duplicate. For more information, see Retrying a failed API request.<br/>
        /// * The retry key is valid for 24 hours after attempting the first request.<br/>
        /// See <a href="https://developers.line.biz/en/reference/messaging-api/#retry-api-request">Here</a>.
        /// </param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-narrowcast-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendNarrowcastMessageAsync(NarrowcastMessage narrowcastMessage, Guid? retryKey = null)
        {
            var json = JsonConvert.SerializeObject(narrowcastMessage, _settings);

            return await SendNarrowcastMessageAsync(json, retryKey);
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
        /// <param name="broadcastMessage">Broadcast message.</param>
        /// <param name="retryKey">
        /// * The retry key lets you retry a request while preventing the same request from being accepted in duplicate. For more information, see Retrying a failed API request.<br/>
        /// * The retry key is valid for 24 hours after attempting the first request.<br/>
        /// See <a href="https://developers.line.biz/en/reference/messaging-api/#retry-api-request">Here</a>.
        /// </param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-broadcast-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendBroadcastMessageAsync(string broadcastMessage, Guid? retryKey = null)
        {
            return await SendMessageAsync("message/broadcast", broadcastMessage, retryKey);
        }

        /// <summary>
        /// Sends push messages to multiple users at any time.
        /// </summary>
        /// <param name="broadcastMessage">Broadcast message.</param>
        /// <param name="retryKey">
        /// * The retry key lets you retry a request while preventing the same request from being accepted in duplicate. For more information, see Retrying a failed API request.<br/>
        /// * The retry key is valid for 24 hours after attempting the first request.<br/>
        /// See <a href="https://developers.line.biz/en/reference/messaging-api/#retry-api-request">Here</a>.
        /// </param>
        /// <returns>Messaging API response.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#send-broadcast-message">Here</a>.</remarks>
        public async Task<MessagingApiResponse> SendBroadcastMessage(BroadcastMessage broadcastMessage, Guid? retryKey = null)
        {
            var json = JsonConvert.SerializeObject(broadcastMessage, _settings);

            return await SendBroadcastMessageAsync(json, retryKey);
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

        /// <summary>
        /// Gets the target limit for additional messages in the current month.<br/><br/>
        /// <br/><br/>
        /// The number of messages retrieved by this operation includes the number of messages sent from LINE Official Account Manager.<br/><br/>
        /// <br/><br/>
        /// Set a target limit with LINE Official Account Manager. For the procedures, refer to the LINE Official Account Manager manual.
        /// </summary>
        /// <returns>Message quota information.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#get-quota">Here</a>.</remarks>
        public async Task<MessageQuota> GetTheTargetLimitForAdditionalMessages()
        {
            var response = await GetAsync("message/quota");
            var json = await response.HttpResponseMessage.Content.ReadAsStringAsync();
            var quota = JsonConvert.DeserializeObject<MessageQuota>(json);

            return quota;
        }
        
        /// <summary>
        /// Gets the number of messages sent in the current month.<br/>
        /// <br/>
        /// The number of messages retrieved by this operation includes the number of messages sent from LINE Official Account Manager.<br/>
        /// <br/>
        /// The number of messages retrieved by this operation is approximate. To get the correct number of sent messages, use LINE Official Account Manager or execute API operations for getting the number of sent messages.
        /// </summary>
        /// <returns>The number of sent messages in the current month.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#get-consumption">Here</a>.</remarks>
        public async Task<long> GetNumberOfMessagesSentThisMonth()
        {
            var response = await GetAsync("message/quota/consumption");
            var json = await response.HttpResponseMessage.Content.ReadAsStringAsync();
            var type = new {totalUsage = 0L};
            var obj = JsonConvert.DeserializeAnonymousType(json, type);

            return obj.totalUsage;
        }

        /// <summary>
        /// Get information of sent messages.
        /// </summary>
        /// <param name="api">API url.</param>
        /// <param name="date">Date the messages were sent. Timezone: UTC+9.</param>
        /// <returns>Information of sent messages.</returns>
        private async Task<SentMessagesInfo> GetSentMessagesInfo(string api, DateTime date)
        {
            var response = await GetAsync($"{api}?date={date:yyyyMMdd}");
            var json = await response.HttpResponseMessage.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<SentMessagesInfo>(json);
        }
        
        /// <summary>
        /// Gets the number of messages sent with the /bot/message/reply endpoint.<br/>
        /// <br/>
        /// The number of messages retrieved by this operation does not include the number of messages sent from LINE Official Account Manager.<br/>
        /// </summary>
        /// <param name="date">Date the messages were sent. Timezone: UTC+9.</param>
        /// <returns>Information of Sent reply messages.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#get-number-of-reply-messages">Here</a>.</remarks>
        public async Task<SentMessagesInfo> GetNumberOfSentReplyMessages(DateTime date)
        {
            return await GetSentMessagesInfo("message/delivery/reply", date);
        }

        /// <summary>
        /// Gets the number of messages sent with the /bot/message/push endpoint.<br/>
        /// <br/>
        /// The number of messages retrieved by this operation does not include the number of messages sent from LINE Official Account Manager.
        /// </summary>
        /// <param name="date">Date the messages were sent. Timezone: UTC+9</param>
        /// <returns>Information of Sent push messages.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#get-number-of-push-messages">Here</a>.</remarks>
        public async Task<SentMessagesInfo> GetNumberOfSentPushMessages(DateTime date)
        {
            return await GetSentMessagesInfo("message/delivery/push", date);
        }
        
        /// <summary>
        /// Gets the number of messages sent with the /bot/message/multicast endpoint.<br/>
        /// <br/>
        /// The number of messages retrieved by this operation does not include the number of messages sent from LINE Official Account Manager.
        /// </summary>
        /// <param name="date">Date the messages were sent. Timezone: UTC+9</param>
        /// <returns>Information of Sent push messages.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#get-number-of-multicast-messages">Here</a>.</remarks>
        public async Task<SentMessagesInfo> GetNumberOfSentMulticastMessages(DateTime date)
        {
            return await GetSentMessagesInfo("message/delivery/multicast", date);
        }
        
        /// <summary>
        /// Gets the number of messages sent with the /bot/message/broadcast endpoint.<br/>
        /// <br/>
        /// The number of messages retrieved by this operation does not include the number of messages sent from LINE Official Account Manager.
        /// </summary>
        /// <param name="date">Date the messages were sent. Timezone: UTC+9</param>
        /// <returns>Information of Sent push messages.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#get-number-of-broadcast-messages">Here</a>.</remarks>
        public async Task<SentMessagesInfo> GetNumberOfSentBroadcastMessages(DateTime date)
        {
            return await GetSentMessagesInfo("message/delivery/broadcast", date);
        }
        
        #endregion
        
        #region Users

        /// <summary>
        /// Get the profile information of users who have added your LINE Official Account as a friend.<br/>
        /// <br/>
        /// Profile information of group members and chat room members:<br/>
        /// Use the following APIs to get profile information of group members or chat room members. With these APIs, you can get profile information of members who have not added your LINE Official Account as a friend or blocked your LINE Official Account.<br/>
        /// <br/>
        /// <a href="https://developers.line.biz/en/reference/messaging-api/#get-group-member-profile">Get Profile Information of Group Members</a><br/>
        /// <a href="https://developers.line.biz/en/reference/messaging-api/#get-room-member-profile">Get Profile Information of Chat Room Members</a>
        /// </summary>
        /// <param name="userId">User ID that is returned in a <a href="https://developers.line.biz/en/reference/messaging-api/#webhook-event-objects">webhook event object</a>. Do not use the LINE ID found on LINE.</param>
        /// <returns>LINE User Profile.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#get-profile">Here</a>.</remarks>
        public async Task<UserProfile> GetProfile(string userId)
        {
            var response = await GetAsync($"profile/{userId}");
            var json = await response.HttpResponseMessage.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<UserProfile>(json);
        }

        /// <summary>
        /// Gets the <a href="https://developers.line.biz/en/glossary/#user-id">User ID</a> of users who have added your LINE Official Account as a friend.<br/>
        ///<br/>
        /// Note:<br/>
        /// This feature is available only for verified or premium accounts. For more information about account types, see the <a href="https://www.linebiz.com/jp-en/service/line-official-account/account-type/">Account Types of LINE Official Accout</a> page on LINE for Business.
        /// </summary>
        /// <param name="start">Value of the continuation token found in the next property of the JSON object returned in the <a href="https://developers.line.biz/en/reference/messaging-api/#get-follower-ids-response">response</a>. Include this parameter to get the next array of user IDs.</param>
        /// <returns>Follower IDs.</returns>
        /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#get-follower-ids">Here</a>.</remarks>
        public async Task<FollowerIds> GetFollowerIds(string start = null)
        {
            var response = await GetAsync($"followers/ids?start={start}");
            var json = await response.HttpResponseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FollowerIds>(json);
        }

        #endregion
    }
}

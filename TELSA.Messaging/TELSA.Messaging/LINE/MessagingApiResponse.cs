using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// Define Messaging API response.
    /// </summary>
    public class MessagingApiResponse
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="response">HTTP response message.</param>
        public MessagingApiResponse(HttpResponseMessage response)
        {
            HttpResponseMessage = response;
            Headers = new MessagingApiResponseHeaders(response.Headers);
        }
        
        /// <summary>
        /// HTTP response.
        /// </summary>
        public HttpResponseMessage HttpResponseMessage { get; }

        /// <summary>
        /// Response headers.
        /// </summary>
        public MessagingApiResponseHeaders Headers { get; }
    }
    
    /// <summary>
    /// Define Messaging API response.
    /// </summary>
    public class MessagingApiResponse<TContent>:MessagingApiResponse
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="response">HTTP response message.</param>
        public MessagingApiResponse(HttpResponseMessage response)
            : base(response)
        {
        }

        private TContent _content;

        /// <summary>
        /// Read the content of HTTP response message.
        /// </summary>
        /// <returns>Content.</returns>
        public async Task<TContent> ReadContentAsync()
        {
            if (_content == null)
            {
                var json = await HttpResponseMessage.Content.ReadAsStringAsync();

                _content = JsonConvert.DeserializeObject<TContent>(json);
            }

            return _content;
        }
    }
}

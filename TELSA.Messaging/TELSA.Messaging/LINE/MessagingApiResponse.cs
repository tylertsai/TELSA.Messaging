using System.Net.Http;

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
            Headers = new MessagingApiResponseHeaders(response.Headers);
        }
        
        /// <summary>
        /// Response headers.
        /// </summary>
        public MessagingApiResponseHeaders Headers { get; }
    }
}

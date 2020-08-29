using System.Linq;
using System.Net.Http.Headers;

namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// Define Messaging API response headers.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#response-headers">Here</a>.
    /// </remarks>
    public class MessagingApiResponseHeaders
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="headers">HTTP response headers.</param>
        public MessagingApiResponseHeaders(HttpResponseHeaders headers)
        {
            headers.TryGetValues("X-Line-Request-Id", out var requestIds);
            headers.TryGetValues("X-Line-Accepted-Request-Id", out var acceptedRequestId);

            RequestId = requestIds?.FirstOrDefault();
            AcceptedRequestId = acceptedRequestId?.FirstOrDefault();
        }
        
        /// <summary>
        /// Request ID. A unique ID is generated for each request.
        /// </summary>
        public string RequestId { get; }
        
        /// <summary>
        /// If the request has already been accepted using the same retry key, the x-line-request-id of the accepted request is shown.
        /// </summary>
        public string AcceptedRequestId { get; }
    }
}
using System;
using System.Net;

namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// Define an error of LINE Messaging API.
    /// </summary>
    public class LineMessagingException : ApplicationException
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="statusCode">HTTP Status Code.</param>
        /// <param name="message">Error Message.</param>
        /// <param name="error">Error content.</param>
        public LineMessagingException(HttpStatusCode statusCode, string message, LineMessagingError error = null)
            : base(message)
        {
            StatusCode = statusCode;
            Error = error;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="statusCode">HTTP Status Code.</param>
        /// <param name="message">Error Message.</param>
        /// <param name="innerException">Inner Exception.</param>
        /// <param name="error">Error content.</param>
        public LineMessagingException(HttpStatusCode statusCode, string message, Exception innerException, LineMessagingError error = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// HTTP Status Code.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Error content.
        /// </summary>
        public LineMessagingError Error { get; }
    }
}

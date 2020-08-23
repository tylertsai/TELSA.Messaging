using System.Collections.Generic;

namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// LINE Messaging API error.
    /// </summary>
    public class LineMessagingError
    {
        /// <summary>
        /// Detail.
        /// </summary>
        public class Detail
        {
            /// <summary>
            /// Message.
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// Property.
            /// </summary>
            public string Property { get; set; }
        }

        /// <summary>
        /// Message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Details.
        /// </summary>
        public IEnumerable<Detail> Details { get; set; }
    }
}

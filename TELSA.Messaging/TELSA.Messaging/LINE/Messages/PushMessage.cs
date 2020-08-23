using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Define a push message.
    /// </summary>
    public class PushMessage : SendMessage
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="to"><see cref="To"/></param>
        /// <param name="messages"><see cref="Messages"/></param>
        public PushMessage(string to, IList<IMessage> messages)
            : base(messages)
        {
            To = to;
        }

        /// <summary>
        /// ID of the target recipient. Use a userId, groupId, or roomId value returned in a <a href="https://developers.line.biz/en/reference/messaging-api/#common-properties">webhook event object</a>. Do not use the LINE ID found on LINE.
        /// </summary>
        public string To { get; set; }
    }
}

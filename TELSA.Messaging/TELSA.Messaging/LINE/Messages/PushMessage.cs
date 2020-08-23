using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Define a push message.
    /// </summary>
    public class PushMessage
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="to"><see cref="To"/></param>
        /// <param name="messages"><see cref="Messages"/></param>
        public PushMessage(string to, IList<IMessage> messages)
        {
            To = to;
            Messages = messages;
        }

        /// <summary>
        /// ID of the target recipient. Use a userId, groupId, or roomId value returned in a <a href="https://developers.line.biz/en/reference/messaging-api/#common-properties">webhook event object</a>. Do not use the LINE ID found on LINE.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Messages to send<br/>
        /// Max: 5
        /// </summary>
        public IList<IMessage> Messages { get; }

        /// <summary>
        /// * true: The user doesn't receive a push notification when the message is sent.<br/>
        /// * false: The user receives a push notification when the message is sent(unless they have disabled push notifications in LINE and/or their device).<br/>
        /// Default: false
        /// </summary>
        public bool NotificationDisabled { get; set; }
    }
}

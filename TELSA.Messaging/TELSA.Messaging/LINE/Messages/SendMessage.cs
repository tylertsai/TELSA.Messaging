using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Define a message to send.
    /// </summary>
    public abstract class SendMessage
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="messages"><see cref="Messages"/></param>
        public SendMessage(IList<IMessage> messages)
        {
            Messages = messages;
        }

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

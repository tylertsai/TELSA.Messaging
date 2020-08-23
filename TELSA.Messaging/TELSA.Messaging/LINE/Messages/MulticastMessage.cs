using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Define MulticastMessage.
    /// </summary>
    public class MulticastMessage : SendMessage
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="to"><see cref="To"/></param>
        /// <param name="messages"><see cref="Messages"/></param>
        public MulticastMessage(IList<string> to, IList<IMessage> messages)
            : base(messages)
        {
            To = to;
        }

        /// <summary>
        /// Array of user IDs. Use userId values which are returned in webhook event objects. Do not use LINE IDs found on LINE.<br/><br/>
        /// Max: 500 user IDs
        /// </summary>
        public IList<string> To { get; }
    }
}

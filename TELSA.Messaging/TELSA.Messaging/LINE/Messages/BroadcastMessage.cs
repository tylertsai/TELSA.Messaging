using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Define BroadcastMessage.
    /// </summary>
    public class BroadcastMessage : SendMessage
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="messages"><see cref="Messages"/></param>
        public BroadcastMessage(IList<IMessage> messages)
            : base(messages)
        {
        }
    }
}

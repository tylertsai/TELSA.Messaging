using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Define ReplyMessage.
    /// </summary>
    public class ReplyMessage : SendMessage
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="replyToken"><see cref="ReplyToken"/></param>
        /// <param name="messages"><see cref="Messages"/></param>
        public ReplyMessage(string replyToken, IList<IMessage> messages)
            : base(messages)
        {
            ReplyToken = replyToken;
        }

        /// <summary>
        /// Reply token.
        /// </summary>
        public string ReplyToken { get; set; }
    }
}

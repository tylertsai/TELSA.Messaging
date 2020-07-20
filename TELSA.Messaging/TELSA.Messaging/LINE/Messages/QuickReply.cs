using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// These properties are used for the quick reply feature. Supported on LINE 8.11.0 and later for iOS and Android. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/using-quick-reply/">Using quick replies</a>.
    /// </summary>
    /// <remarks>
    /// If the user receives multiple <a href="https://developers.line.biz/en/reference/messaging-api/#message-objects">message objects</a>, the quickReply property of the last message object is displayed.<br/>
    /// <br/>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#quick-reply">Here</a>.
    /// </remarks>
    public class QuickReply
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="items"><see cref="Items"/></param>
        public QuickReply(IList<QuickReplyButton> items)
        {
            Items = items;
        }

        /// <summary>
        /// This is a container that contains quick reply buttons. Max: 13 objects.
        /// </summary>
        public IList<QuickReplyButton> Items { get; }
    }
}

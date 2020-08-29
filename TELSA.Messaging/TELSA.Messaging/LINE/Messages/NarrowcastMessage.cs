using System.Collections.Generic;
using TELSA.Messaging.LINE.Messages.Narrowcast;

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Define NarrowcastMessage.
    /// </summary>
    /// <remarks>
    /// Notice: Messages must have a minimum number of recipients<br/><br/>
    /// Narrowcast messages cannot be sent when the number of recipients is below a certain minimum amount, to prevent someone from guessing the recipients' attributes. The minimum number of recipients is a private value defined by the LINE Platform.<br/><br/>
    ///
    /// Notice: Message delivery caps<br/><br/>
    /// When you send a narrowcast message, the number of individual messages scheduled for delivery is temporarily calculated as if every single friend will receive them regardless of the values you have set for the recipient and filter.demographic properties. If the number of messages scheduled for delivery exceeds your soft limit for the month, you won't be able to send the narrowcast message.<br/><br/>
    /// However, if the maximum number of outgoing messages set in limit.max is under your soft limit for the month, you will be able to send the narrowcast message.
    /// </remarks>
    public class NarrowcastMessage : SendMessage
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="messages"><see cref="Messages"/></param>
        public NarrowcastMessage(IList<IMessage> messages)
            : base(messages)
        {
        }
        
        /// <summary>
        /// <see cref="Narrowcast.Recipient"/> object. You can specify recipients of the message using up to 10 audiences.
        /// If this is omitted, messages will be sent to all users who have added your LINE Official Account as a friend.
        /// </summary>
        public Recipient Recipient { get; set; }
        
        /// <summary>
        /// <a href="https://developers.line.biz/en/reference/messaging-api/#narrowcast-demographic-filter">Demographic filter object</a>. You can use friends' attributes to filter the list of recipients.
        /// If this is omitted, messages are sent to everyone—including users with attribute values of "unknown".
        /// </summary>
        public Filter Filter { get; set; }
        
        /// <summary>
        /// The maximum number of narrowcast messages to send. Use this parameter to limit the number of narrowcast messages sent. The recipients will be chosen at random.
        /// </summary>
        public Limit Limit { get; set; }
    }
}

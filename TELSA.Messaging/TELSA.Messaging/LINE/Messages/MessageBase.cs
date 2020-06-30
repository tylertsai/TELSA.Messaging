namespace TELSA.Messaging.LINE.Messages
{
    /// <inheritdoc/>
    public abstract class MessageBase : IMessage
    {
        /// <inheritdoc/>
        public abstract string Type { get; }

        /// <inheritdoc/>
        public QuickReply QuickReply { get; set; }

        /// <inheritdoc/>
        public Sender Sender { get; set; }
    }
}

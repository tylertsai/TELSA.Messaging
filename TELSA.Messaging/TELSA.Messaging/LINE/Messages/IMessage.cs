namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// LINE message
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#message-common-properties">Here</a>.
    /// </remarks>
    public interface IMessage
    {
        /// <summary>
        /// Message type.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// These properties are used for the quick reply feature. Supported on LINE 8.11.0 and later for iOS and Android. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/using-quick-reply/">Using quick replies</a>.
        /// </summary>
        QuickReply QuickReply { get; set; }

        /// <summary>
        /// Change icon and display name
        /// </summary>
        Sender Sender { get; set; }
    }
}

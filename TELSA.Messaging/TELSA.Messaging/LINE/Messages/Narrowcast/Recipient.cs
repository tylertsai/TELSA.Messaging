namespace TELSA.Messaging.LINE.Messages.Narrowcast
{
    /// <summary>
    /// Recipient objects represent audiences. You can specify recipients based on a combination of criteria using logical operator objects. You can specify up to 10 recipient objects per request.
    /// </summary>
    /// <remarks>See <a href="https://developers.line.biz/en/reference/messaging-api/#narrowcast-recipient">Here</a>.</remarks>
    public abstract class Recipient
    {
        /// <summary>
        /// The type of recipient.
        /// </summary>
        public abstract string Type { get; }
    }
}
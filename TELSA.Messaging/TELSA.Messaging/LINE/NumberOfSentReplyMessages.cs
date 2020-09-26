namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// Information of Sent reply messages.
    /// </summary>
    public class SentReplyMessagesInfo
    {
        /// <summary>
        /// Status of the counting process.
        /// </summary>
        public CountingProcess Status { get; set; }
        
        /// <summary>
        /// The number of messages sent with the Messaging API on the date specified in date. The response has this property only when the value of status is ready.
        /// </summary>
        public long Success { get; set; }
    }
}
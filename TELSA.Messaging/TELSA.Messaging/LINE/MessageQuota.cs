namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// Message quota.
    /// </summary>
    public class MessageQuota
    {
        /// <summary>
        /// One of the following values to indicate whether a target limit is set or not.
        /// </summary>
        public QuotaType Type { get; set; }
        
        /// <summary>
        /// The target limit for additional messages in the current month. This property is returned when the type property has a value of limited.
        /// </summary>
        public long Value { get; set; }
    }
}
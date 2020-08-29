namespace TELSA.Messaging.LINE.Messages.Narrowcast
{
    /// <summary>
    /// Define Limit object.
    /// </summary>
    public class Limit
    {
        /// <summary>
        /// The maximum number of narrowcast messages to send. Use this parameter to limit the number of narrowcast messages sent. The recipients will be chosen at random.
        /// </summary>
        public int Max { get; set; }
    }
}
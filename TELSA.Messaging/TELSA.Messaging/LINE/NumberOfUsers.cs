namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// Define the number of users in a room or group.
    /// </summary>
    public class NumberOfUsers
    {
        /// <summary>
        /// The count of members in the room. The number returned excludes the LINE Official Account.
        /// </summary>
        public long Count { get; set; }
    }
}
namespace TELSA.Messaging.LINE.Messages.Narrowcast.Filters
{
    /// <summary>
    /// This lets you filter recipients with a given range of friendship durations.
    /// </summary>
    public class FriendshipDurationFilter : DemographicFilter
    {
        /// <summary>
        /// Constructor.<br/><br/>
        /// * Be sure to specify either gte, lt, or both.
        /// </summary>
        /// <param name="gte"><see cref="Gte"/></param>
        /// <param name="lt"><see cref="Lt"/></param>
        public FriendshipDurationFilter(FriendshipDuration? gte = null, FriendshipDuration? lt = null)
        {
            Gte = gte;
            Lt = lt;
        }
        
        /// <inheritdoc />
        public override string Type => "subscriptionPeriod";

        /// <summary>
        /// Send messages to users who have been friends of yours for at least the specified number of days..
        /// </summary>
        public FriendshipDuration? Gte { get; set; }

        /// <summary>
        /// Send messages to users who have been friends of yours for less than the specified number of days. You can specify the same values as for the gte property.
        /// </summary>
        public FriendshipDuration? Lt { get; set; }
    }
}
namespace TELSA.Messaging.LINE.Messages.Narrowcast.Filters
{
    /// <summary>
    /// This lets you filter recipients with a given age range.
    /// </summary>
    public class AgeFilter : DemographicFilter
    {
        /// <summary>
        /// Constructor.<br/><br/>
        /// * Be sure to specify either gte, lt, or both.
        /// </summary>
        /// <param name="gte"><see cref="Gte"/></param>
        /// <param name="lt"><see cref="Lt"/></param>
        public AgeFilter(Age? gte = null, Age? lt = null)
        {
            Gte = gte;
            Lt = lt;
        }
        
        /// <inheritdoc />
        public override string Type => "age";

        /// <summary>
        /// Send messages to users at least as old as the specified age.
        /// </summary>
        public Age? Gte { get; set; }

        /// <summary>
        /// Send messages to users younger than the specified age. You can specify the same values as for the gte property.
        /// </summary>
        public Age? Lt { get; set; }
    }
}
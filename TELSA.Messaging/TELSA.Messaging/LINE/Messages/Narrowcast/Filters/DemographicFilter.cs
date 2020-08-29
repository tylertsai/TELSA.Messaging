namespace TELSA.Messaging.LINE.Messages.Narrowcast.Filters
{
    /// <summary>
    /// Demographic filter objects represent criteria (e.g. age, gender, OS, region, and friendship duration) on which to filter the list of recipients. You can filter recipients based on a combination of different criteria using logical operator objects.
    /// </summary>
    /// <remarks>
    ///  Notice: Using attribute data<br/><br/>
    /// * The attribute data used for demographic filters is always 3 days old.<br/><br/>
    /// * If you don't specify any attributes, messages are sent to everyone—even users with attribute values of "unknown".<br/><br/>
    /// * Your "<a href="https://developers.line.biz/en/glossary/#target-reach">Target reach</a>" number must be at least 20 to retrieve demographic information.<br/><br/>
    /// <br/><br/>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#narrowcast-demographic-filter">Here</a>.
    /// </remarks>
    public abstract class DemographicFilter
    {
        /// <summary>
        /// Type of demographic filter.
        /// </summary>
        public abstract string Type { get; }
    }
}
using TELSA.Messaging.LINE.Messages.Narrowcast.Filters;

namespace TELSA.Messaging.LINE.Messages.Narrowcast
{
    /// <summary>
    /// Define filter.
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// <a href="https://developers.line.biz/en/reference/messaging-api/#narrowcast-demographic-filter">Demographic filter</a> object. You can use friends' attributes to filter the list of recipients.<br/><br/>
        /// If this is omitted, messages are sent to everyone—including users with attribute values of "unknown".
        /// </summary>
        public DemographicFilter Demographic { get; set; }
    }
}
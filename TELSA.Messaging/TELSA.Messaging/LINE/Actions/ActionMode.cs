using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Actions
{
    /// <summary>
    /// Action mode
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActionMode
    {
        /// <summary>
        /// Pick date
        /// </summary>
        Date,

        /// <summary>
        /// Pick time
        /// </summary>
        Time,

        /// <summary>
        /// Pick date and time
        /// </summary>
        Datetime
    }
}
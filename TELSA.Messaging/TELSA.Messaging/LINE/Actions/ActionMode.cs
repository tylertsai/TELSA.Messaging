using System.Runtime.Serialization;
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
        [EnumMember(Value = "date")]
        Date,

        /// <summary>
        /// Pick time
        /// </summary>
        [EnumMember(Value = "time")]
        Time,

        /// <summary>
        /// Pick date and time
        /// </summary>
        [EnumMember(Value = "datetime")]
        Datetime
    }
}
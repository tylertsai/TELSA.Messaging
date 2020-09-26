using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// Message quota type.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuotaType
    {
        /// <summary>
        /// This indicates that a target limit is not set.
        /// </summary>
        [EnumMember(Value = "none")]
        None,
        
        /// <summary>
        /// This indicates that a target limit is set.
        /// </summary>
        [EnumMember(Value = "limited")]
        Limited
    }
}
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// Font weight.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FontWeight
    {
        /// <summary>
        /// Regular
        /// </summary>
        [EnumMember(Value = "regular")]
        Regular,

        /// <summary>
        /// Bold
        /// </summary>
        [EnumMember(Value = "bold")]
        Bold
    }
}
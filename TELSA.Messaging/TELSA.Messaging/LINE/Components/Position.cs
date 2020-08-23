using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// Reference position for placing this box.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Position
    {
        /// <summary>
        /// Use the previous box as reference.
        /// </summary>
        [EnumMember(Value = "relative")]
        Relative,

        /// <summary>
        /// Use the top left of parent element as reference.
        /// </summary>
        [EnumMember(Value = "absolute")]
        Absolute
    }
}
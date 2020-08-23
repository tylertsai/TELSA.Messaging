using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// Alignment in horizontal direction
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HorizontalAlignment
    {
        /// <summary>
        /// Left-aligned
        /// </summary>
        [EnumMember(Value = "start")]
        Start,

        /// <summary>
        /// Right-aligned
        /// </summary>
        [EnumMember(Value = "end")]
        End,

        /// <summary>
        /// Center-aligned (default value)
        /// </summary>
        [EnumMember(Value = "center")]
        Center
    }
}
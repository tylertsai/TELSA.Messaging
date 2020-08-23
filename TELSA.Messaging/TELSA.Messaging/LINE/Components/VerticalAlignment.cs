using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// Alignment in vertical direction<br/>
    /// <br/>
    /// Note: This property is ignored in a baseline box.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VerticalAlignment
    {
        /// <summary>
        /// Top-aligned (default value)
        /// </summary>
        [EnumMember(Value = "top")]
        Top,

        /// <summary>
        /// Bottom-aligned
        /// </summary>
        [EnumMember(Value = "bottom")]
        Bottom,

        /// <summary>
        /// Center-aligned
        /// </summary>
        [EnumMember(Value = "center")]
        Center
    }
}
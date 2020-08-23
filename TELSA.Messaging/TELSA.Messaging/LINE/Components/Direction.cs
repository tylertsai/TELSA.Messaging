using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// Text directionality and the direction of placement of components in horizontal boxes.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Direction
    {
        /// <summary>
        /// The text is left-to-right horizontal writing, and the components are placed from left to right
        /// </summary>
        [EnumMember(Value = "ltr")]
        LTR,

        /// <summary>
        /// The text is right-to-left horizontal writing, and the components are placed from right to left
        /// </summary>
        [EnumMember(Value = "rtl")]
        RTL
    }
}
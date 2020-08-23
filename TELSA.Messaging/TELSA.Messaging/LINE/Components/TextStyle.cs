using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// Style of the text.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TextStyle
    {
        /// <summary>
        /// Normal
        /// </summary>
        [EnumMember(Value = "normal")]
        Normal,

        /// <summary>
        /// Italic
        /// </summary>
        [EnumMember(Value = "italic")]
        Italic
    }
}
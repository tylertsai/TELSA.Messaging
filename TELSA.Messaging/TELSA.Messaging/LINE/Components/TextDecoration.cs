using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// Decoration of the text.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TextDecoration
    {
        /// <summary>
        /// No decoration
        /// </summary>
        [EnumMember(Value = "none")]
        None,

        /// <summary>
        /// Underline
        /// </summary>
        [EnumMember(Value = "underline")]
        Underline,

        /// <summary>
        /// Strikethrough
        /// </summary>
        [EnumMember(Value = "line-through")]
        LineThrough
    }
}
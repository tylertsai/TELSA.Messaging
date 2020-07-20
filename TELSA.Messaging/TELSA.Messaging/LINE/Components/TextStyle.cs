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
        Normal,

        /// <summary>
        /// Italic
        /// </summary>
        Italic
    }
}
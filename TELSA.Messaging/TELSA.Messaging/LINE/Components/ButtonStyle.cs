using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// Style of the button.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ButtonStyle
    {
        /// <summary>
        /// Style for dark color buttons
        /// </summary>
        Primary,

        /// <summary>
        /// Style for light color buttons
        /// </summary>
        Secondary,

        /// <summary>
        /// HTML link style
        /// </summary>
        Link
    }
}
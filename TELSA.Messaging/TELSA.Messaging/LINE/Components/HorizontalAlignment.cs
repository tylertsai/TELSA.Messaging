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
        Start,

        /// <summary>
        /// Right-aligned
        /// </summary>
        End,

        /// <summary>
        /// Center-aligned (default value)
        /// </summary>
        Center
    }
}
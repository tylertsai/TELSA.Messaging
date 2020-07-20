using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// Alignment in vertical direction
    /// </summary>
    /// <remarks>
    /// Note: This property is ignored in a baseline box.
    /// </remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VerticalAlignment
    {
        /// <summary>
        /// Top-aligned (default value)
        /// </summary>
        Top,

        /// <summary>
        /// Bottom-aligned
        /// </summary>
        Bottom,

        /// <summary>
        /// Center-aligned
        /// </summary>
        Center
    }
}
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Containers
{
    /// <summary>
    /// The size of the bubble.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BubbleSize
    {
        /// <summary>
        /// Nano
        /// </summary>
        Nano,

        /// <summary>
        /// Micro
        /// </summary>
        Micro,

        /// <summary>
        /// Kilo
        /// </summary>
        Kilo,

        /// <summary>
        /// Mega
        /// </summary>
        Mega,

        /// <summary>
        /// Giga
        /// </summary>
        Giga
    }
}
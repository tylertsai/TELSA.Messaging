using System.Runtime.Serialization;
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
        [EnumMember(Value = "nano")]
        Nano,

        /// <summary>
        /// Micro
        /// </summary>
        [EnumMember(Value = "micro")]
        Micro,

        /// <summary>
        /// Kilo
        /// </summary>
        [EnumMember(Value = "kilo")]
        Kilo,

        /// <summary>
        /// Mega
        /// </summary>
        [EnumMember(Value = "mega")]
        Mega,

        /// <summary>
        /// Giga
        /// </summary>
        [EnumMember(Value = "giga")]
        Giga
    }
}
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// Font weight.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FontWeight
    {
        /// <summary>
        /// Regular
        /// </summary>
        Regular,

        /// <summary>
        /// Bold
        /// </summary>
        Bold
    }
}
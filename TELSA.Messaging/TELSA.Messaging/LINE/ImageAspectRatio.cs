using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// Aspect ratio of the image.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImageAspectRatio
    {
        /// <summary>
        /// 1.51:1
        /// </summary>
        Rectangle,

        /// <summary>
        /// 1:1
        /// </summary>
        Square
    }
}

﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Templates
{
    /// <summary>
    /// Size of the image.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImageSize
    {
        /// <summary>
        /// The image fills the entire image area. Parts of the image that do not fit in the area are not displayed.
        /// </summary>
        [EnumMember(Value = "cover")]
        Cover,

        /// <summary>
        /// The entire image is displayed in the image area. A background is displayed in the unused areas to the left and right of vertical images and in the areas above and below horizontal images.
        /// </summary>
        [EnumMember(Value = "contain")]
        Contain
    }
}

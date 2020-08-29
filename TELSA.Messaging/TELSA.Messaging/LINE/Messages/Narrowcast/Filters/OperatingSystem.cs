using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Messages.Narrowcast.Filters
{
    /// <summary>
    /// Operating system.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperatingSystem
    {
        /// <summary>
        /// iOS.
        /// </summary>
        [EnumMember(Value = "ios")]
        IOS,
        
        /// <summary>
        /// Android.
        /// </summary>
        [EnumMember(Value = "android")]
        Android
    }
}
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Messages.Narrowcast.Filters
{
    /// <summary>
    /// Friendship duration.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FriendshipDuration
    {
        /// <summary>
        /// 7 days.
        /// </summary>
        [EnumMember(Value = "day_7")]
        Day7,

        /// <summary>
        /// 30 days.
        /// </summary>
        [EnumMember(Value = "day_30")] 
        Day30,

        /// <summary>
        /// 90 days.
        /// </summary>
        [EnumMember(Value = "day_90")] 
        Day90,

        /// <summary>
        /// 180 days.
        /// </summary>
        [EnumMember(Value = "day_180")] 
        Day180,

        /// <summary>
        /// 365 days.
        /// </summary>
        [EnumMember(Value = "day_365")] 
        Day365
    }
}
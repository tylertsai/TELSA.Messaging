using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// Status of the counting process.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CountingProcess
    {
        /// <summary>
        /// You can get the number of messages.
        /// </summary>
        [EnumMember(Value = "ready")]
        Ready,
        
        /// <summary>
        /// The message counting process for the date specified in date has not been completed yet. Retry your request later. Normally, the counting process is completed within the next day.
        /// </summary>
        [EnumMember(Value = "unready")]
        Unready,
        
        /// <summary>
        /// The date specified in date is earlier than March 31, 2018, when the operation of the counting system started.
        /// </summary>
        [EnumMember(Value = "out_of_service")]
        OutOfService
    }
}
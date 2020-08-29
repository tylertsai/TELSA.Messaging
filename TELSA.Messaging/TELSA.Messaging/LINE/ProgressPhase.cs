using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// Progress phase.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProgressPhase
    {
        /// <summary>
        /// Messages are not yet ready to be sent. They are currently being filtered or processed in some way.
        /// </summary>
        [EnumMember(Value = "waiting")]
        Waiting,
        
        /// <summary>
        /// Messages are currently being sent.
        /// </summary>
        [EnumMember(Value = "sending")]
        Sending,
        
        /// <summary>
        /// Messages were sent successfully. This may not mean the messages were successfully received.
        /// </summary>
        [EnumMember(Value = "succeeded")]
        Succeeded,
        
        /// <summary>
        /// Messages failed to be sent.
        /// </summary>
        [EnumMember(Value = "failed")]
        Failed
    }
}
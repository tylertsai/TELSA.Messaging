using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Messages.Narrowcast.Filters
{
    /// <summary>
    /// Age.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Age
    {
        /// <summary>
        /// 15.
        /// </summary>
        [EnumMember(Value = "age_15")]
        Age15,
        
        /// <summary>
        /// 20.
        /// </summary>
        [EnumMember(Value = "age_20")]
        Age20,
        
        /// <summary>
        /// 25.
        /// </summary>
        [EnumMember(Value = "age_25")]
        Age25,
        
        /// <summary>
        /// 30.
        /// </summary>
        [EnumMember(Value = "age_30")]
        Age30,
        
        /// <summary>
        /// 35.
        /// </summary>
        [EnumMember(Value = "age_35")]
        Age35,
        
        /// <summary>
        /// 40.
        /// </summary>
        [EnumMember(Value = "age_40")]
        Age40,
        
        /// <summary>
        /// 45.
        /// </summary>
        [EnumMember(Value = "age_45")]
        Age45,
        
        /// <summary>
        /// 50.
        /// </summary>
        [EnumMember(Value = "age_50")]
        Age50
    }
}
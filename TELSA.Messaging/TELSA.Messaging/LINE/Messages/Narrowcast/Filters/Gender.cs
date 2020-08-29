using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Messages.Narrowcast.Filters
{
    /// <summary>
    /// Gender.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gender
    {
        /// <summary>
        /// Male.
        /// </summary>
        [EnumMember(Value = "male")]
        Male,
        
        /// <summary>
        /// Female.
        /// </summary>
        [EnumMember(Value = "female")]
        Female
    }
}
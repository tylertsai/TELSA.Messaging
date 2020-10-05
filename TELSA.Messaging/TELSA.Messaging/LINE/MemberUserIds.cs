using System.Collections.Generic;

namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// Member user IDs.
    /// </summary>
    public class MemberUserIds
    {
        /// <summary>
        /// List of user IDs of the members in the room. Only users of LINE for iOS and LINE for Android are included in memberIds. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/user-consent/">User consent</a>.<br/>
        /// Max: 100 user IDs<br/>
        /// </summary>
        public IEnumerable<string> MemberIds { get; set; }
        
        /// <summary>
        /// A continuation token to get the next array of user IDs of the members in the room. Returned only when there are remaining user IDs that were not returned in memberIds in the original request.
        /// </summary>
        public string Next { get; set; }
    }
}
using System.Collections.Generic;

namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// Followers IDs.
    /// </summary>
    public class FollowerIds
    {
        /// <summary>
        /// List of user IDs of users that have added the LINE Official Account as a friend. Only users of LINE for iOS and LINE for Android are included in userIds. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/user-consent/">User consent</a>.
        /// Max: 300 user IDs
        /// </summary>
        public IEnumerable<string> UserIds { get; set; }
        
        /// <summary>
        /// A continuation token to get the next array of user IDs. Returned only when there are remaining user IDs that were not returned in userIds in the original request. The number of user IDs in the userIds element does not have to reach 300 for the next property to be included in the response.
        /// </summary>
        public string Next { get; set; }
    }
}
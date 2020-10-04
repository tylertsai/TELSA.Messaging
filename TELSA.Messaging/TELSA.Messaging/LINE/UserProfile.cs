namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// LINE User profile.
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// User's display name
        /// </summary>
        public string DisplayName { get; set; }
        
        /// <summary>
        /// User ID
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// User's language, as a <a href="https://tools.ietf.org/html/bcp47">BCP 47</a> language tag. Example: en for English. The language property is returned only in the following situations:<br/>
        /// * User has a LINE account created in Japan and has agreed to the Privacy Policy of LINE version 8.0.0 or later<br/>
        /// * User has a LINE account created in Taiwan, Thailand, or Indonesia and has agreed to the Privacy Policy of LINE version 8.9.0 or later
        /// </summary>
        public string Language { get; set; }
        
        /// <summary>
        /// Profile image URL. "https" image URL. Not included in the response if the user doesn't have a profile image.
        /// </summary>
        public string PictureUrl { get; set; }
        
        /// <summary>
        /// User's status message. Not included in the response if the user doesn't have a status message.
        /// </summary>
        public string StatusMessage { get; set; }
    }
}
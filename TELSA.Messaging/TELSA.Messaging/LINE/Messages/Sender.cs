namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Change icon and display name<br/>
    /// <br/>
    /// When sending a message from the LINE Official Account, you can specify the sender.name and the sender.iconUrl properties in <a href="https://developers.line.biz/en/reference/messaging-api/#message-objects">Message objects</a>.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#icon-nickname-switch">Here</a>.
    /// </remarks>
    public class Sender
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"><seealso cref="Name"/></param>
        /// <param name="iconUrl">b<see cref="IconUrl"/></param>
        public Sender(string name = null, string iconUrl = null)
        {
            Name = name;
            IconUrl = iconUrl;
        }

        /// <summary>
        /// Display name. Certain words such as LINE may not be used.<br/>
        /// Max character limit: 20
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// URL of the image to display as an icon when sending a message<br/>
        /// * Max character limit: 1000<br/>
        /// * URL scheme: https
        /// </summary>
        public string IconUrl { get; set; }
    }
}

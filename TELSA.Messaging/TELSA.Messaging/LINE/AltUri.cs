namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// URI opened on LINE for macOS and Windows when the action is performed (Max character limit: 1000)
    /// If the altUri.desktop property is set, the uri property is ignored on LINE for macOS and Windows.
    /// The available schemes are http, https, line, and tel.For more information about the LINE URL scheme, see <a href="https://developers.line.biz/en/docs/messaging-api/using-line-url-scheme/">Using LINE features with the LINE URL scheme</a>.This property is supported on the following version of LINE.
    /// * LINE 5.12.0 or later for macOS and Windows
    /// </summary>
    public class AltUri
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="desktop"><see cref="Desktop"/></param>
        public AltUri(string desktop = null)
        {
            Desktop = desktop;
        }

        /// <summary>
        /// The altUri.desktop property is supported only when you set URI actions in Flex Messages.
        /// </summary>
        public string Desktop { get; set; }
    }
}

namespace TELSA.Messaging.LINE.Actions
{
    /// <summary>
    /// When a control associated with this action is tapped, the URI specified in the uri property is opened.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#uri-action">Here</a>.
    /// </remarks>
    public class UriAction : IAction
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="uri"><see cref="Uri"/></param>
        /// <param name="label"><see cref="Label"/></param>
        /// <param name="altUri"><see cref="AltUri"/></param>
        public UriAction(string uri, string label = null, AltUri altUri = null)
        {
            Uri = uri;
            Label = label;
            AltUri = altUri;
        }

        /// <inheritdoc/>
        public string Type { get => "uri"; }

        /// <summary>
        /// Label for the action
        /// * Required for templates other than image carousel.Max character limit: 20
        /// * Optional for image carousel templates.Max character limit: 12
        /// * Optional for rich menus.Spoken when the accessibility feature is enabled on the client device.Max character limit: 20. Supported on LINE 8.2.0 and later for iOS.
        /// * Required for the button of Flex Message.This property can be specified for the box, image, and text but its value is not displayed. Max character limit: 20
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// URI opened when the action is performed (Max character limit: 1000)
        /// The available schemes are http, https, line, and tel.For more information about the LINE URL scheme, see <a href="https://developers.line.biz/en/docs/messaging-api/using-line-url-scheme/">Using LINE features with the LINE URL scheme</a>.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// URI opened on LINE for macOS and Windows when the action is performed (Max character limit: 1000)
        /// If the altUri.desktop property is set, the uri property is ignored on LINE for macOS and Windows.
        /// The available schemes are http, https, line, and tel.For more information about the LINE URL scheme, see <a href="https://developers.line.biz/en/docs/messaging-api/using-line-url-scheme/">Using LINE features with the LINE URL scheme</a>.This property is supported on the following version of LINE.
        /// * LINE 5.12.0 or later for macOS and Windows
        /// 
        /// Note: The altUri.desktop property is supported only when you set URI actions in Flex Messages.
        /// </summary>
        public AltUri AltUri { get; set; }
    }
}

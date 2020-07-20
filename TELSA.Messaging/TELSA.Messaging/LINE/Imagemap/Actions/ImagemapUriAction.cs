namespace TELSA.Messaging.LINE.Imagemap.Actions
{
    /// <summary>
    /// When an area is tapped, the user is redirected to the URI specified in uri.
    /// </summary>
    public class ImagemapUriAction : IImagemapAction
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="area"><see cref="ImagemapArea"/></param>
        /// <param name="linkUri"><see cref="LinkUri"/></param>
        public ImagemapUriAction(ImagemapArea area, string linkUri)
        {
            Area = area;
            LinkUri = linkUri;
        }

        /// <inheritdoc/>
        public string Type { get => "uri"; }

        /// <summary>
        /// Label for the action. Spoken when the accessibility feature is enabled on the client device.<br/>
        /// Max character limit: 50<br/>
        /// Supported on LINE 8.2.0 and later for iOS.
        /// </summary>
        public string Label { get; set; }

        /// <inheritdoc/>
        public ImagemapArea Area { get; set; }

        /// <summary>
        /// Webpage URL<br/>
        /// Max character limit: 1000<br/>
        /// The available schemes are http, https, line, and tel.For more information about the LINE URL scheme, see <a href="https://developers.line.biz/en/docs/messaging-api/using-line-url-scheme/">Using LINE features with the LINE URL scheme</a>.
        /// </summary>
        public string LinkUri { get; set; }
    }
}

namespace TELSA.Messaging.LINE.Imagemap
{
    /// <summary>
    /// Defined a link.
    /// </summary>
    public class ImagemapExternalLink
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="linkUri"><see cref="LinkUri"/></param>
        /// <param name="label"><see cref="Label"/></param>
        public ImagemapExternalLink(string linkUri, string label)
        {
            LinkUri = linkUri;
            Label = label;
        }

        /// <summary>
        /// Webpage URL. Called when the label displayed after the video is tapped.
        /// Max character limit: 1000
        /// The available schemes are http, https, line, and tel.For more information about the LINE URL scheme, see <a href="https://developers.line.biz/en/docs/messaging-api/using-line-url-scheme/">Using LINE features with the LINE URL scheme</a>.
        /// </summary>
        public string LinkUri { get; set; }

        /// <summary>
        /// Label. Displayed after the video is finished.
        /// Max character limit: 30
        /// </summary>
        public string Label { get; set; }
    }
}

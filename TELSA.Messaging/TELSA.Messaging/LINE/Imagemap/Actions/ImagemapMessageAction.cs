namespace TELSA.Messaging.LINE.Imagemap.Actions
{
    /// <summary>
    /// When an area is tapped, the message specified in message is sent.
    /// </summary>
    public class ImagemapMessageAction : IImagemapAction
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="area"><see cref="ImagemapArea"/></param>
        /// <param name="text"><see cref="Text"/></param>
        public ImagemapMessageAction(ImagemapArea area, string text)
        {
            Area = area;
            Text = text;
        }

        /// <inheritdoc/>
        public string Type { get => "message"; }

        /// <summary>
        /// Label for the action. Spoken when the accessibility feature is enabled on the client device.<br/>
        /// Max character limit: 50<br/>
        /// Supported on LINE 8.2.0 and later for iOS.
        /// </summary>
        public string Label { get; set; }

        /// <inheritdoc/>
        public ImagemapArea Area { get; set; }

        /// <summary>
        /// Message to send<br/>
        /// Max character limit: 400<br/>
        /// Supported on LINE for iOS and Android only.
        /// </summary>
        public string Text { get; set; }
    }
}

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Image message.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#image-message">Here</a>.
    /// </remarks>
    public class ImageMessage : MessageBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="originalContentUrl"><see cref="OriginalContentUrl"/></param>
        /// <param name="previewImageUrl"><see cref="PreviewImageUrl"/></param>
        public ImageMessage(string originalContentUrl, string previewImageUrl)
        {
            OriginalContentUrl = originalContentUrl;
            PreviewImageUrl = previewImageUrl;
        }

        /// <inheritdoc/>
        public override string Type { get => "image"; }

        /// <summary>
        /// Image URL (Max character limit: 1000)
        /// HTTPS over TLS 1.2 or later
        /// JPG, JPEG, or PNG
        /// Max image size: No limits
        /// Max file size: 10 MB
        /// </summary>
        public string OriginalContentUrl { get; set; }

        /// <summary>
        /// Preview image URL (Max character limit: 1000)
        /// HTTPS over TLS 1.2 or later
        /// JPG, JPEG or PNG
        /// Max image size: No limits
        /// Max file size: 1 MB
        /// </summary>
        public string PreviewImageUrl { get; set; }
    }
}

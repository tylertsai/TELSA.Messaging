namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Video message.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#video-message">Here</a>.
    /// </remarks>
    public class VideoMessage : MessageBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="originalContentUrl"><see cref="OriginalContentUrl"/></param>
        /// <param name="previewImageUrl"><see cref="PreviewImageUrl"/></param>
        public VideoMessage(string originalContentUrl, string previewImageUrl)
        {
            OriginalContentUrl = originalContentUrl;
            PreviewImageUrl = previewImageUrl;
        }

        /// <inheritdoc/>
        public override string Type { get => "video"; }

        /// <summary>
        /// URL of video file (Max character limit: 1000)
        /// HTTPS over TLS 1.2 or later
        /// mp4
        /// Max file size: 200 MB
        /// 
        /// A very wide or tall video may be cropped when played in some environments.
        /// </summary>
        public string OriginalContentUrl { get; set; }

        /// <summary>
        /// URL of preview image (Max character limit: 1000)
        /// HTTPS over TLS 1.2 or later
        /// JPEG or PNG
        /// Max file size: 1 MB
        /// </summary>
        public string PreviewImageUrl { get; set; }
    }
}

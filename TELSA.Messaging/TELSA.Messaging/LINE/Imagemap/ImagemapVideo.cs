namespace TELSA.Messaging.LINE.Imagemap
{
    /// <summary>
    /// Defined an Imagemap video.
    /// </summary>
    /// <remarks>
    /// If the video isn't playing properly, make sure the video is a supported file type and the HTTP server hosting the video supports HTTP partial requests (range request).
    /// </remarks>
    public class ImagemapVideo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="originalContentUrl"><see cref="OriginalContentUrl"/></param>
        /// <param name="previewImageUrl"><see cref="PreviewImageUrl"/></param>
        /// <param name="area"><see cref="Area"/></param>
        /// <param name="externalLink"><see cref="ExternalLink"/></param>
        public ImagemapVideo(string originalContentUrl, string previewImageUrl, ImagemapVideoArea area, ImagemapExternalLink externalLink)
        {
            OriginalContentUrl = originalContentUrl;
            PreviewImageUrl = previewImageUrl;
            Area = area;
            ExternalLink = externalLink;
        }

        /// <summary>
        /// URL of the video file (Max character limit: 1000)
        /// HTTPS over TLS 1.2 or later
        /// mp4
        /// Max length: No limit Max file size: 200 MB
        /// </summary>
        /// <remarks>A very wide or tall video may be cropped when played in some environments.</remarks>
        public string OriginalContentUrl { get; set; }

        /// <summary>
        /// URL of the preview image (Max character limit: 1000)
        /// HTTPS over TLS 1.2 or later
        /// JPG, JPEG, or PNG
        /// Max image size: No limits
        /// Max file size: 1 MB
        /// </summary>
        public string PreviewImageUrl { get; set; }

        /// <summary>
        /// Area of the video.
        /// </summary>
        public ImagemapVideoArea Area { get; set; }

        /// <summary>
        /// This property is required if you set a video to play and a label to display after the video on the imagemap.
        /// </summary>
        public ImagemapExternalLink ExternalLink { get; set; }
    }
}

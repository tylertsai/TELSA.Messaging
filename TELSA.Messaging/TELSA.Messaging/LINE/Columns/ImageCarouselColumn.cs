using TELSA.Messaging.LINE.Actions;

namespace TELSA.Messaging.LINE.Columns
{
    /// <summary>
    /// Column object for image carousel
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#column-object-for-image-carousel">Here</a>.
    /// </remarks>
    public class ImageCarouselColumn
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="imageUrl"><see cref="ImageUrl"/></param>
        /// <param name="action"><see cref="Action"/></param>
        public ImageCarouselColumn(string imageUrl, IAction action)
        {
            ImageUrl = imageUrl;
            Action = action;
        }

        /// <summary>
        /// Image URL (Max character limit: 1,000)
        /// HTTPS over TLS 1.2 or later
        /// JPEG or PNG
        /// Aspect ratio: 1:1
        /// Max width: 1024px
        /// Max file size: 1 MB
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Action when image is tapped
        /// </summary>
        public IAction Action { get; set; }
    }
}
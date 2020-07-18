using System.Collections.Generic;
using TELSA.Messaging.LINE.Actions;

namespace TELSA.Messaging.LINE.Columns
{
    /// <summary>
    /// Column object for carousel
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#column-object-for-carousel">Here</a>.
    /// </remarks>
    public class CarouselColumn
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="text"><see cref="Text"/></param>
        /// <param name="actions"><see cref="Actions"/></param>
        public CarouselColumn(string text, IList<IAction> actions)
        {
            Text = text;
            Actions = actions;
        }

        /// <summary>
        /// Image URL (Max character limit: 1,000)
        /// HTTPS over TLS 1.2 or later
        /// JPEG or PNG
        /// Aspect ratio: 1:1.51
        /// Max width: 1024px
        /// Max file size: 1 MB
        /// </summary>
        public string ThumbnailImageUrl { get; set; }

        /// <summary>
        /// Background color of the image. Specify a RGB color value. The default value is #FFFFFF (white).
        /// </summary>
        public string ImageBackgroundColor { get; set; }

        /// <summary>
        /// Title
        /// Max character limit: 40
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Message text
        /// Max character limit: 120 (no image or title)
        /// Max character limit: 60 (message with an image or title)
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Action when image, title or text area is tapped.
        /// </summary>
        public IAction DefaultAction { get; set; }

        /// <summary>
        /// Action when tapped
        /// Max objects: 3
        /// </summary>
        public IList<IAction> Actions { get; set; }
    }
}
using System.Collections.Generic;
using TELSA.Messaging.LINE.Columns;

namespace TELSA.Messaging.LINE.Templates
{
    /// <summary>
    /// Template with multiple images which can be cycled like a carousel. The images are shown in order when scrolling horizontally.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#image-carousel">Here</a>.
    /// </remarks>
    public class ImageCarouselTemplate : ITemplate
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="columns"><see cref="Columns"/></param>
        public ImageCarouselTemplate(IList<ImageCarouselColumn> columns)
        {
            Columns = columns;
        }

        /// <inheritdoc/>
        public string Type { get => "image_carousel"; }

        /// <summary>
        /// Array of columns
        /// Max columns: 10
        /// </summary>
        public IList<ImageCarouselColumn> Columns { get; set; }
    }
}

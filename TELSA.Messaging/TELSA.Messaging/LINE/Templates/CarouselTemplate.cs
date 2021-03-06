﻿using System.Collections.Generic;
using TELSA.Messaging.LINE.Columns;

namespace TELSA.Messaging.LINE.Templates
{
    /// <summary>
    /// Template with multiple columns which can be cycled like a carousel. The columns are shown in order when scrolling horizontally.
    /// </summary>
    /// <remarks>
    /// Because of the height limitation for carousel template messages, the lower part of the text display area will get cut off if the height limitation is exceeded. For this reason, depending on the character width, the message text may not be fully displayed even when it is within the character limits.<br/>
    /// Keep the number of actions consistent for all columns.If you use an image or title for a column, make sure to do the same for all other columns.<br/>
    /// <br/>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#carousel">Here</a>.
    /// </remarks>
    public class CarouselTemplate : ITemplate
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="columns"><see cref="Columns"/></param>
        public CarouselTemplate(IList<CarouselColumn> columns)
        {
            Columns = columns;
        }

        /// <inheritdoc/>
        public string Type { get => "carousel"; }

        /// <summary>
        /// Image URL (Max character limit: 1,000)<br/>
        /// HTTPS over TLS 1.2 or later<br/>
        /// JPEG or PNG<br/>
        /// Max width: 1024px<br/>
        /// Max file size: 1 MB
        /// </summary>
        public string ThumbnailImageUrl { get; set; }

        /// <summary>
        /// Array of columns<br/>
        /// Max columns: 10
        /// </summary>
        public IList<CarouselColumn> Columns { get; }

        /// <summary>
        /// Aspect ratio of the image.<br/>
        /// <br/>
        /// Default: rectangle
        /// </summary>
        public ImageAspectRatio? ImageAspectRatio { get; set; }

        /// <summary>
        /// Size of the image.<br/>
        /// Default: <see cref="ImageSize.Cover"/>
        /// </summary>
        public ImageSize? ImageSize { get; set; }
    }
}

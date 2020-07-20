using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Containers
{
    /// <summary>
    /// A carousel is a container that contains multiple bubbles as child elements. Users can scroll horizontally through the bubbles.<br/>
    /// The maximum size of JSON data that defines a carousel is 50 KB.
    /// </summary>
    /// <remarks>
    /// Bubble width:<br/>
    /// A carousel cannot contain bubbles of different widths (size property). Each bubble in a carousel should have the same width.<br/>
    /// <br/>
    /// Bubble height:<br/>
    /// The body of each bubble will stretch to match the bubble with the greatest height in the carousel. However, bubbles with no body will not change height.<br/>
    /// <br/>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#f-carousel">Here</a>.
    /// </remarks>
    public class CarouselContainer : IContainer
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="contents"><see cref="Contents"/></param>
        public CarouselContainer(IList<BubbleContainer> contents)
        {
            Contents = contents;
        }

        /// <inheritdoc/>
        public string Type { get => "carousel"; }

        /// <summary>
        /// <see cref="BubbleContainer"/> in the carousel. Max: 10 b
        /// </summary>
        public IList<BubbleContainer> Contents { get; }
    }
}

using TELSA.Messaging.LINE.Actions;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// This component renders an image.
    /// </summary>
    /// <remarks>
    /// About the drawing area
    /// Specify the max width of the image with the size property and the aspect ratio(horizontal-to-vertical ratio) of the image with the aspectRatio property.The rectangular area determined by the size and aspectRatio properties is called the drawing area.The image is rendered in this drawing area.
    /// * If the image width specified by the flex property is larger than that calculated from the <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#component-width-and-height">size property</a>, the width of the drawing area is scaled down to the width of the component.
    /// * If the aspect ratio of the image and that specified by the aspectRatio property do not match, the image is displayed according to the aspectMode property. The default value is fit.
    /// ** If the value of aspectMode is cover: The image fills the entire drawing area.Parts of the image that do not fit in the drawing area are not displayed.
    /// ** If the value of aspectMode is fit: The entire image is displayed in the drawing area.A background is displayed in the unused areas to the left and right of vertical images and in the areas above and below horizontal images.
    ///
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#f-image">Here</a>.
    /// </remarks>
    public class ImageComponent : IComponent
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url"><see cref="Url"/></param>
        public ImageComponent(string url)
        {
            Url = url;
        }

        /// <inheritdoc/>
        public string Type { get => "image"; }

        /// <summary>
        /// Image URL
        /// Protocol: HTTPS over TLS 1.2 or later
        /// Image format: JPEG or PNG
        /// Maximum image size: 1024×1024 pixels
        /// Maximum data size: 1 MB
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The ratio of the width or height of this component within the parent box. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#component-width-and-height">Width and height of components</a>.
        /// </summary>
        public int Flex { get; set; }

        /// <summary>
        /// Minimum space between this component and the previous component in the parent element. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#margin-property">margin property of the component</a> in the API documentation.
        /// </summary>
        public string Margin { get; set; }

        /// <summary>
        /// Reference for offsetTop, offsetBottom, offsetStart, and offsetEnd. Specify one of the following values:
        /// * relative: Use the previous box as reference.
        /// * absolute: Use the top left of parent element as reference.
        ///
        /// The default value is relative.For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#component-offset">Offset</a> in the API documentation.
        /// </summary>
        public Position? Position { get; set; }

        /// <summary>
        /// The top offset. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#component-offset">Offset</a> in the API documentation.
        /// </summary>
        public string OffsetTop { get; set; }

        /// <summary>
        /// The bottom offset. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#component-offset">Offset</a> in the API documentation.
        /// </summary>
        public string OffsetBottom { get; set; }

        /// <summary>
        /// The left offset. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#component-offset">Offset</a> in the API documentation.
        /// </summary>
        public string OffsetStart { get; set; }

        /// <summary>
        /// The right offset. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#component-offset">Offset</a> in the API documentation.
        /// </summary>
        public string OffsetEnd { get; set; }

        /// <summary>
        /// Alignment style in horizontal direction. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#align-property">Alignment in horizontal direction</a> in the API documentation.
        /// </summary>
        public HorizontalAlignment? Align { get; set; }

        /// <summary>
        /// Alignment style in vertical direction. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#gravity-property">Alignment in vertical direction</a> in the API documentation.
        /// </summary>
        public VerticalAlignment? Gravity { get; set; }

        /// <summary>
        /// Maximum size of the image width. You can specify one of the following values: xxs, xs, sm, md, lg, xl, xxl, 3xl, 4xl, 5xl, or full. The size increases in the order of listing. The default value is md.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Aspect ratio of the image. {width}:{height} format. Specify the value of {width} and {height} in the range from 1 to 100000. However, you cannot set {height} to a value that is more than three times the value of {width}. The default value is 1:1.
        /// </summary>
        public string AspectRatio { get; set; }

        /// <summary>
        /// The display style of the image if the aspect ratio of the image and that specified by the aspectRatio property do not match. For more information, see <a href="https://developers.line.biz/en/reference/messaging-api/#drawing-area">About the drawing area</a>.
        /// </summary>
        public string AspectMode { get; set; }

        /// <summary>
        /// Background color of the image. Use a hexadecimal color code.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Action performed when this image is tapped. Specify an <a href="https://developers.line.biz/en/reference/messaging-api/#action-objects">action object</a>.
        /// </summary>
        public IAction Action { get; set; }
    }
}
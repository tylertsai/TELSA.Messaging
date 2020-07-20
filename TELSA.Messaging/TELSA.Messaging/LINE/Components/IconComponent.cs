using TELSA.Messaging.LINE.Actions;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// This component renders an icon for decorating the adjacent text.<br/>
    /// This component can be used only in a <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#baseline-box">baseline box</a>.<br/>
    /// <br/>
    /// Note: The icon's flex property is fixed to 0.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#icon">Here</a>.
    /// </remarks>
    public class IconComponent : IComponent
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url"><see cref="Url"/></param>
        public IconComponent(string url)
        {
            Url = url;
        }

        /// <inheritdoc/>
        public string Type { get => "icon"; }

        /// <summary>
        /// Image URL
        /// Protocol: HTTPS over TLS 1.2 or later<br/>
        /// Image format: JPEG or PNG<br/>
        /// Maximum image size: 1024×1024 pixels<br/>
        /// Maximum data size: 1 MB<br/>
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Minimum space between this component and the previous component in the parent element. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#margin-property">margin property of the component</a> in the API documentation.
        /// </summary>
        public string Margin { get; set; }

        /// <summary>
        /// Reference for offsetTop, offsetBottom, offsetStart, and offsetEnd. Specify one of the following values:<br/>
        /// * relative: Use the previous box as reference.<br/>
        /// * absolute: Use the top left of parent element as reference.<br/>
        /// <br/>
        /// The default value is relative.For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#component-offset">Offset</a> in the API documentation.<br/>
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
        /// Maximum size of the icon width. You can specify one of the following values: xxs, xs, sm, md, lg, xl, xxl, 3xl, 4xl, or 5xl. The size increases in the order of listing. The default value is md.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Aspect ratio of the icon. {width}:{height} format. The values of {width} and {height} must be in the range 1–100000. {height} can't be more than three times the value of {width}. The default value is 1:1.
        /// </summary>
        public string AspectRatio { get; set; }
    }
}
using System.Collections.Generic;
using TELSA.Messaging.LINE.Actions;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// This component renders a text string in one row. You can specify font color, size, and weight.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#f-text">Here</a>.
    /// </remarks>
    public class TextComponent : IComponent
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="text"><see cref="Text"/></param>
        public TextComponent(string text)
        {
            Text = text;
        }

        /// <inheritdoc/>
        public string Type { get => "text"; }

        /// <summary>
        /// Text Be sure to set either one of the text property or contents property. If you set the contents property, text is ignored.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Array of <see cref="SpanComponent"/>. Be sure to set either one of the text property or contents property. If you set the contents property, text is ignored.
        /// </summary>
        public IList<SpanComponent> Contents { get; set; }

        /// <summary>
        /// The ratio of the width or height of this component within the parent box. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#component-width-and-height">Width and height of components</a>.
        /// </summary>
        public int Flex { get; set; }

        /// <summary>
        /// Minimum space between this component and the previous component in the parent element. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#margin-property">margin property of the component</a> in the API documentation.
        /// </summary>
        public string Margin { get; set; }

        /// <summary>
        /// Reference for offsetTop, offsetBottom, offsetStart, and offsetEnd. Specify one of the following values:<br/>
        /// * relative: Use the previous box as reference.<br/>
        /// * absolute: Use the top left of parent element as reference.<br/>
        /// <br/>
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
        /// Font size. You can specify one of the following values: xxs, xs, sm, md, lg, xl, xxl, 3xl, 4xl, or 5xl. The size increases in the order of listing. The default value is md.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Alignment style in horizontal direction. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#align-property">Alignment in horizontal direction</a> in the API documentation.
        /// </summary>
        public HorizontalAlignment? Align { get; set; }

        /// <summary>
        /// Alignment style in vertical direction. The default value is top. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#gravity-property">Alignment in vertical direction</a> in the API documentation.
        /// </summary>
        public VerticalAlignment? Gravity { get; set; }

        /// <summary>
        /// true to wrap text. The default value is false. If set to true, you can use a new line character (\n) to begin on a new line. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-elements/#text-wrap">Wrapping text</a> in the API documentation.
        /// </summary>
        public bool? Wrap { get; set; }

        /// <summary>
        /// Max number of lines. If the text does not fit in the specified number of lines, an ellipsis (…) is displayed at the end of the last line. If set to 0, all the text is displayed. The default value is 0. This property is supported on the following versions of LINE.<br/>
        /// <br/>
        /// LINE for iOS and Android: 8.11.0 and later
        /// </summary>
        public int? MaxLines { get; set; }

        /// <summary>
        /// Font weight. You can specify one of the following values: regular or bold. Specifying bold makes the font bold. The default value is regular.
        /// </summary>
        public FontWeight? Weight { get; set; }

        /// <summary>
        /// Font color. Use a hexadecimal color code.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Action performed when this image is tapped. Specify an <see cref="IAction"/> object.
        /// </summary>
        public IAction Action { get; set; }

        /// <summary>
        /// Style of the text. Specify one of the following values:<br/>
        /// * normal: Normal<br/>
        /// * italic: Italic<br/>
        /// <br/>
        /// The default value is normal.
        /// </summary>
        public TextStyle? Style { get; set; }

        /// <summary>
        /// Decoration of the text. Specify one of the following values:<br/>
        /// * none: No decoration<br/>
        /// * underline: Underline<br/>
        /// * line-through: Strikethrough<br/>
        /// <br/>
        /// The default value is none.
        /// </summary>
        public TextDecoration? Decoration { get; set; }
    }
}
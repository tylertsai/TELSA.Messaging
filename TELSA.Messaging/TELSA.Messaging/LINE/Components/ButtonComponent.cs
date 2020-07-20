using TELSA.Messaging.LINE.Actions;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// This component renders a button. When the user taps a button, a specified action is performed.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#button">Here</a>.
    /// </remarks>
    public class ButtonComponent : IComponent
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="action"><see cref="Action"/></param>
        public ButtonComponent(IAction action)
        {
            Action = action;
        }

        /// <inheritdoc/>
        public string Type { get => "button"; }

        /// <summary>
        /// Action performed when this button is tapped. Specify an <see cref="IAction"/> object.
        /// </summary>
        public IAction Action { get; set; }

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
        /// Height of the button. You can specify sm or md. The default value is md.
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// Style of the button. Specify one of the following values:<br/>
        /// * primary: Style for dark color buttons<br/>
        /// * secondary: Style for light color buttons<br/>
        /// * link: HTML link style<br/>
        /// <br/>
        /// The default value is link.
        /// </summary>
        public ButtonStyle? Style { get; set; }

        /// <summary>
        /// Character color when the style property is link. Background color when the style property is primary or secondary. Use a hexadecimal color code.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Alignment style in vertical direction. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#gravity-property">Alignment in vertical direction</a> in the API documentation.
        /// </summary>
        public VerticalAlignment? Gravity { get; set; }
    }
}
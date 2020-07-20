using System.Collections.Generic;
using TELSA.Messaging.LINE.Actions;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// This is a component that defines the layout of child components. You can also include a box in a box.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#box">Here</a>.
    /// </remarks>
    public class BoxComponent : IComponent
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="layout"><see cref="Layout"/></param>
        /// <param name="contents"><see cref="Contents"/></param>
        public BoxComponent(LayoutType layout, IList<IComponent> contents)
        {
            Layout = layout;
            Contents = contents;
        }

        /// <inheritdoc/>
        public string Type { get => "box"; }

        /// <summary>
        /// The layout style of components in this box. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#box-layout-types">Direction of placing components</a> in the API documentation.
        /// </summary>
        public LayoutType Layout { get; set; }

        /// <summary>
        /// Components in this box. Here are the types of components available:<br/>
        /// * When the layout property is horizontal or vertical: <see cref="BoxComponent"/>, <see cref="ButtonComponent"/>, <see cref="ImageComponent"/>, <see cref="TextComponent"/>, <see cref="SeparatorComponent"/>, and <see cref="FillerComponent"/><br/>
        /// * When the layout property is baseline: <see cref="IconComponent"/>, <see cref="TextComponent"/>, and <see cref="FillerComponent"/><br/>
        /// <br/>
        /// Components are rendered in the order specified in the array.
        /// </summary>
        public IList<IComponent> Contents { get; }

        /// <summary>
        /// Background color of the block. In addition to the RGB color, an alpha channel (transparency) can also be set. Use a hexadecimal color code. (Example:#RRGGBBAA) The default value is #00000000.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Color of box border. Use a hexadecimal color code.
        /// </summary>
        public string BorderColor { get; set; }

        /// <summary>
        /// Width of box border. You can specify a value in pixels or any one of none, light, normal, medium, semi-bold, or bold. none does not render a border while the others become wider in the order of listing.
        /// </summary>
        public string BorderWidth { get; set; }

        /// <summary>
        /// Radius at the time of rounding the corners of the border. You can specify a value in pixels or any one of none, xs, sm, md, lg, xl, or xxl. none does not round the corner while the others increase in radius in the order of listing. The default value is none.
        /// </summary>
        public string CornerRadius { get; set; }

        /// <summary>
        /// Width of the box. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#box-width">Width of a box</a> in the API documentation.
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// Height of the box. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#box-height">Height of a box</a> in the API documentation.
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// The ratio of the width or height of this component within the parent box. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#component-width-and-height">Width and height of components</a>.
        /// </summary>
        public int? Flex { get; set; }

        /// <summary>
        /// Minimum space between components in this box. The default value is none. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#spacing-property">spacing property of the box</a> in the API documentation.
        /// </summary>
        public string Spacing { get; set; }

        /// <summary>
        /// Minimum space between this component and the previous component in the parent element. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#margin-property">margin property of the component</a> in the API documentation.
        /// </summary>
        public string Margin { get; set; }

        /// <summary>
        /// Free space between the borders of this box and the child element. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#padding-property">Box padding</a> in the API documentation.
        /// </summary>
        public string PaddingAll { get; set; }

        /// <summary>
        /// Free space between the border at the upper end of this box and the upper end of the child element. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#padding-property">Box padding</a> in the API documentation.
        /// </summary>
        public string PaddingTop { get; set; }

        /// <summary>
        /// Free space between the border at the lower end of this box and the lower end of the child element. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#padding-property">Box padding</a> in the API documentation.
        /// </summary>
        public string PaddingBottom { get; set; }

        /// <summary>
        /// Free space between the border at the left end of this box and the left end of the child element. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#padding-property">Box padding</a> in the API documentation.
        /// </summary>
        public string PaddingStart { get; set; }

        /// <summary>
        /// Free space between the border at the right end of this box and the right end of the child element. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#padding-property">Box padding</a> in the API documentation.
        /// </summary>
        public string PaddingEnd { get; set; }

        /// <summary>
        /// Reference position for placing this box. Specify one of the following values:<br/>
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
        /// Action performed when this image is tapped. Specify an action object. This property is supported on the following versions of LINE.<br/>
        /// <br/>
        /// * LINE for iOS and Android: 8.11.0 and later
        /// </summary>
        public IAction Action { get; set; }
    }
}
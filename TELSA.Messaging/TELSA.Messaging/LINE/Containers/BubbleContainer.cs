using TELSA.Messaging.LINE.Actions;
using TELSA.Messaging.LINE.Components;

namespace TELSA.Messaging.LINE.Containers
{
    /// <summary>
    /// This is a container that contains one message bubble. It can contain four blocks: header, hero, body, and footer. For more information about using each block, see Block in the API documentation.<br/>
    /// <br/>
    /// The maximum size of JSON data that defines a bubble is 10 KB.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#bubble">Here</a>.
    /// </remarks>
    public class BubbleContainer : IContainer
    {
        /// <inheritdoc/>
        public string Type { get => "bubble"; }

        /// <summary>
        /// The size of the bubble. You can specify one of the following values: nano, micro, kilo, mega, or giga. The default value is mega.
        /// </summary>
        public BubbleSize? Size { get; set; }

        /// <summary>
        /// Text directionality and the direction of placement of components in horizontal boxes. Specify one of the following values:<br/>
        /// ltr: The text is left-to-right horizontal writing, and the components are placed from left to right<br/>
        /// rtl: The text is right-to-left horizontal writing, and the components are placed from right to left<br/>
        /// The default value is ltr.
        /// </summary>
        public Direction? Direction { get; set; }

        /// <summary>
        /// Header block. Specify a <a href="https://developers.line.biz/en/reference/messaging-api/#box">Box</a>.
        /// </summary>
        public BoxComponent Header { get; set; }

        /// <summary>
        /// Hero block. Specify a <a href="https://developers.line.biz/en/reference/messaging-api/#box">box</a> or an <a href="https://developers.line.biz/en/reference/messaging-api/#f-image">image</a>.
        /// </summary>
        public IComponent Hero { get; set; }

        /// <summary>
        /// Body block. Specify a <a href="https://developers.line.biz/en/reference/messaging-api/#box">Box</a>.
        /// </summary>
        public BoxComponent Body { get; set; }

        /// <summary>
        /// Footer block. Specify a <a href="https://developers.line.biz/en/reference/messaging-api/#box">Box</a>.
        /// </summary>
        public BoxComponent Footer { get; set; }

        /// <summary>
        /// Style of each block. Specify a <a href="https://developers.line.biz/en/reference/messaging-api/#bubble-style">bubble style</a>.
        /// </summary>
        public BubbleStyle Styles { get; set; }

        /// <summary>
        /// Action performed when this image is tapped. Specify an action object. This property is supported on the following versions of LINE.<br/>
        /// <br/>
        /// LINE for iOS and Android: 8.11.0 and later
        /// </summary>
        public IAction Action { get; set; }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// You can decide the direction of placing child elements by deciding the direction of the main axis of the box. There are three layout types for placing child elements in a box.
    /// The direction of placing child elements is specified by the layout property of the <a href="https://developers.line.biz/en/reference/messaging-api/#box">box</a>.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#box-layout-types">Here</a>.
    /// </remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LayoutType
    {
        /// <summary>
        /// The child elements are placed horizontally. The direction of placing the child elements is specified by the direction property of the <a href="https://developers.line.biz/en/reference/messaging-api/#bubble">bubble</a>.
        /// A box with this layout type is called a horizontal box.
        /// </summary>
        Horizontal,

        /// <summary>
        /// The child elements are placed vertically from top to bottom.
        /// A box with this layout type is called a vertical box.
        /// </summary>
        Vertical,

        /// <summary>
        /// The child elements are placed in the same way as in a horizontal box. For details on differences from a horizontal box, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#baseline-box">Characteristics of the baseline</a> box.
        /// A box with this layout type is called a baseline box.
        /// </summary>
        Baseline
    }
}
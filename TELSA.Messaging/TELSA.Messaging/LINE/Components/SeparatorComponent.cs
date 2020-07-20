namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// This component renders a separating line within a box. A vertical line will be rendered in a horizontal box and a horizontal line will be rendered in a vertical box.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#separator">Here</a>.
    /// </remarks>
    public class SeparatorComponent : IComponent
    {
        /// <inheritdoc/>
        public string Type { get => "separator"; }

        /// <summary>
        /// Minimum space between this component and the previous component in the parent element. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#margin-property">margin property of the component</a> in the API documentation.
        /// </summary>
        public string Margin { get; set; }

        /// <summary>
        /// Color of the separator. Use a hexadecimal color code.
        /// </summary>
        public string Color { get; set; }
    }
}
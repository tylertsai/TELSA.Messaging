namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// Components are elements that make up a block. Here are the types of components available:
    /// * <see cref="BoxComponent"/>
    /// * <see cref="ButtonComponent"/>
    /// * <see cref="ImageComponent"/>
    /// * <see cref="IconComponent"/>
    /// * <see cref="TextComponent"/>
    /// * <see cref="SpanComponent"/>
    /// * <see cref="SeparatorComponent"/>
    /// * <see cref="FillerComponent"/>
    ///
    /// For JSON samples and usage of each component, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-elements/">Flex Message elements</a> and <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/">Flex Message layout</a> in the API documentation.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#component">Here</a>.
    /// </remarks>
    public interface IComponent
    {
        /// <summary>
        /// The type of component.
        /// </summary>
        string Type { get; }
    }
}

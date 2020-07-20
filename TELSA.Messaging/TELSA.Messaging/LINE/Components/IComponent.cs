namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// Components are elements that make up a block. Here are the types of components available:<br/>
    /// * <see cref="BoxComponent"/><br/>
    /// * <see cref="ButtonComponent"/><br/>
    /// * <see cref="ImageComponent"/><br/>
    /// * <see cref="IconComponent"/><br/>
    /// * <see cref="TextComponent"/><br/>
    /// * <see cref="SpanComponent"/><br/>
    /// * <see cref="SeparatorComponent"/><br/>
    /// * <see cref="FillerComponent"/><br/>
    /// <br/>
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

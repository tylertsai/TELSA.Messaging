namespace TELSA.Messaging.LINE.Containers
{
    /// <summary>
    /// A container is the top-level structure of a Flex Message. Here are the types of containers available:<br/>
    /// * <see cref="BubbleContainer"/><br/>
    /// * <see cref="CarouselContainer"/><br/>
    /// For JSON samples and usage of containers, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-elements/">Flex Message elements</a> in the API documentation.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#container">Here</a>.
    /// </remarks>
    public interface IContainer
    {
        /// <summary>
        /// The type of Container.
        /// </summary>
        string Type { get; }
    }
}
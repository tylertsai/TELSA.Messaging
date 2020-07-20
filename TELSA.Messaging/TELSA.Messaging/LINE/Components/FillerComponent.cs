namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// This component is used to create a space. You can put a space between, before, or after components by inserting a filler anywhere within a box.
    /// </summary>
    /// <remarks>
    /// The spacing property of the parent element will be ignored for fillers.<br/>
    /// <br/>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#filler">Here</a>.
    /// </remarks>
    public class FillerComponent : IComponent
    {
        /// <inheritdoc/>
        public string Type { get => "filler"; }

        /// <summary>
        /// The ratio of the width or height of this component within the parent box. For more information, see <a href="https://developers.line.biz/en/docs/messaging-api/flex-message-layout/#component-width-and-height">Width and height of components</a>.
        /// </summary>
        public int? Flex { get; set; }
    }
}
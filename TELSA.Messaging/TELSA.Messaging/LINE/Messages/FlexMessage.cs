using TELSA.Messaging.LINE.Containers;

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Flex Messages are messages with a customizable layout. You can customize the layout freely based on the specification for CSS Flexible Box (CSS Flexbox). For more information, see Sending Flex Messages in the API documentation.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#flex-message">Here</a>.
    /// </remarks>
    public class FlexMessage : MessageBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="altText"><see cref="AltText"/></param>
        /// <param name="contents"><see cref="Contents"/></param>
        public FlexMessage(string altText, IContainer contents)
        {
            AltText = altText;
            Contents = contents;
        }

        /// <inheritdoc/>
        public override string Type { get => "flex"; }

        /// <summary>
        /// Alternative text
        /// Max character limit: 400
        /// </summary>
        public string AltText { get; set; }

        /// <summary>
        /// Flex Message container
        /// </summary>
        public IContainer Contents { get; set; }
    }
}

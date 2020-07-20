using TELSA.Messaging.LINE.Templates;

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Template messages are messages with predefined layouts which you can customize. For more information, see Template messages.<br/>
    /// The following template types are available:<br/>
    /// * <see cref="ButtonsTemplate"/><br/>
    /// * <see cref="ConfirmTemplate"/><br/>
    /// * <see cref="CarouselTemplate"/><br/>
    /// * <see cref="ImageCarouselTemplate"/><br/>
    /// <br/>
    /// Note: Template messages are only supported on LINE 6.7.0 and later for iOS and Android.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#template-messages">Here</a>.
    /// </remarks>
    public class TemplateMessage : MessageBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="altText"><see cref="AltText"/></param>
        /// <param name="template"><see cref="Template"/></param>
        public TemplateMessage(string altText, ITemplate template)
        {
            AltText = altText;
            Template = template;
        }

        /// <inheritdoc/>
        public override string Type { get => "template"; }

        /// <summary>
        /// Alternative text. Displayed on devices that do not support template messages.<br/>
        /// Max character limit: 400
        /// </summary>
        public string AltText { get; set; }

        /// <summary>
        /// A Buttons, Confirm, Carousel, or Image Carousel object.
        /// </summary>
        public ITemplate Template { get; set; }
    }
}

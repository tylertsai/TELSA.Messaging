using System.Collections.Generic;
using TELSA.Messaging.LINE.Actions;

namespace TELSA.Messaging.LINE.Templates
{
    /// <summary>
    /// Template with an image, title, text, and multiple action buttons.
    /// </summary>
    /// <remarks>
    /// Because of the height limitation for buttons template messages, the lower part of the text display area will get cut off if the height limitation is exceeded. For this reason, depending on the character width, the message text may not be fully displayed even when it is within the character limits.
    ///
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#buttons">Here</a>.
    /// </remarks>
    public class ButtonsTemplate : ITemplate
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="text"><see cref="Text"/></param>
        /// <param name="actions"><see cref="Actions"/></param>
        public ButtonsTemplate(string text, IList<IAction> actions)
        {
            Text = text;
            Actions = actions;
        }

        /// <inheritdoc/>
        public string Type { get => "buttons"; }

        /// <summary>
        /// Image URL (Max character limit: 1,000)
        /// HTTPS over TLS 1.2 or later
        /// JPEG or PNG
        /// Max width: 1024px
        /// Max file size: 1 MB
        /// </summary>
        public string ThumbnailImageUrl { get; set; }

        /// <summary>
        /// Aspect ratio of the image.
        /// 
        /// Default: rectangle
        /// </summary>
        public ImageAspectRatio ImageAspectRatio { get; set; }

        /// <summary>
        /// Size of the image.
        /// Default: <see cref="ImageSize.Cover"/>
        /// </summary>
        public ImageSize ImageSize { get; set; }

        /// <summary>
        /// Background color of the image. Specify a RGB color value. Default: #FFFFFF (white)
        /// </summary>
        public string ImageBackgroundColor { get; set; }

        /// <summary>
        /// Title
        /// Max character limit: 40
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Message text
        /// Max character limit: 160 (no image or title)
        /// Max character limit: 60 (message with an image or title)
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Action when image, title or text area is tapped.
        /// </summary>
        public IAction DefaultAction { get; set; }

        /// <summary>
        /// Action when tapped
        /// Max objects: 4
        /// </summary>
        public IList<IAction> Actions { get; set; }
    }
}

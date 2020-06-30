namespace TELSA.Messaging.LINE.Actions
{
    /// <summary>
    /// When a control associated with this action is tapped, the string in the text property is sent as a message from the user.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#message-action">Here</a>.
    /// </remarks>
    public class MessageAction : IAction
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="text"><see cref="Text"/></param>
        /// <param name="label"><see cref="Label"/></param>
        public MessageAction(string text, string label = null)
        {
            Text = text;
            Label = label;
        }

        /// <inheritdoc/>
        public string Type { get => "message"; }

        /// <summary>
        /// Label for the action
        /// * Required for templates other than image carousel.Max character limit: 20
        /// * Optional for image carousel templates.Max character limit: 12
        /// * Optional for rich menus.Spoken when the accessibility feature is enabled on the client device.Max character limit: 20. Supported on LINE 8.2.0 and later for iOS.
        /// * Required for quick reply buttons.Max character limit: 20. Supported on LINE 8.11.0 and later for iOS and Android.
        /// * Required for the button of Flex Message.This property can be specified for the box, image, and text but its value is not displayed. Max charater limit: 20
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Text sent when the action is performed
        /// Max character limit: 300
        /// </summary>
        public string Text { get; set; }
    }
}

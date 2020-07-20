namespace TELSA.Messaging.LINE.Actions
{
    /// <summary>
    /// When a control associated with this action is tapped, a postback event is returned via webhook with the specified string in the data property.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#postback-action">Here</a>.
    /// </remarks>
    public class PostbackAction : IAction
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data"><see cref="Data"/></param>
        /// <param name="label"><see cref="Label"/></param>
        public PostbackAction(string data, string label = null)
        {
            Data = data;
            Label = label;
        }

        /// <inheritdoc/>
        public string Type { get => "postback"; }

        /// <summary>
        /// Label for the action<br/>
        /// * Required for templates other than image carousel.Max character limit: 20<br/>
        /// * Optional for image carousel templates.Max character limit: 12<br/>
        /// * Optional for rich menus.Spoken when the accessibility feature is enabled on the client device.Max character limit: 20. Supported on LINE 8.2.0 and later for iOS.<br/>
        /// * Required for quick reply buttons.Max character limit: 20. Supported on LINE 8.11.0 and later for iOS and Android.<br/>
        /// * Required for the button of Flex Message.This property can be specified for the box, image, and text but its value is not displayed. Max character limit: 20
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// String returned via webhook in the postback.data property of the postback event<br/>
        /// Max character limit: 300
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Text displayed in the chat as a message sent by the user when the action is performed. Required for quick reply buttons. Optional for the other message types.<br/>
        /// Max character limit: 300
        /// </summary>
        public string DisplayText { get; set; }
    }
}

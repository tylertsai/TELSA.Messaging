using TELSA.Messaging.LINE.Actions;

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// This is a quick reply option that is displayed as a button.
    /// </summary>
    /// <remarks>
    /// If a version of LINE that doesn't support the quick reply feature receives a message that contains quick reply buttons, only the message is displayed.
    /// 
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#quick-reply-button-object">Here</a>.
    /// </remarks>
    public class QuickReplyButton
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="action"><see cref="Action"/></param>
        /// <param name="imageUrl"><see cref="ImageUrl"/></param>
        public QuickReplyButton(IAction action, string imageUrl = null)
        {
            Action = action;
            ImageUrl = imageUrl;
        }

        /// <summary>
        /// Quick reply type.
        /// </summary>
        public string Type { get => "action"; }

        /// <summary>
        /// URL of the icon that is displayed at the beginning of the button
        /// * Max character limit: 1000
        /// * URL scheme: https
        /// * Image format: PNG
        /// * Aspect ratio: 1:1
        /// * Data size: Up to 1 MB
        /// 
        /// There is no limit on the image size.
        /// If the action property has a <a href="https://developers.line.biz/en/reference/messaging-api/#camera-action">camera action</a>, <a href="https://developers.line.biz/en/reference/messaging-api/#camera-roll-action">camera roll action</a>, or <a href="https://developers.line.biz/en/reference/messaging-api/#location-action">location action</a>, and the imageUrl property is not set, the default icon is displayed.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Action performed when this button is tapped. Specify an <a href="https://developers.line.biz/en/reference/messaging-api/#action-objects">action object</a>. The following is a list of the available actions:
        /// * <see cref="PostbackAction"/>
        /// * <see cref="MessageAction"/>
        /// * <see cref="DatetimePickerAction"/>
        /// * <see cref="CameraAction"/>
        /// * <see cref="CameraRollAction"/>
        /// * <see cref="LocationAction"/>
        /// </summary>
        public IAction Action { get; set; }
    }
}

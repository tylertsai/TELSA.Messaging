namespace TELSA.Messaging.LINE.Actions
{
    /// <summary>
    /// These are types of actions for your bot to take when a user taps a button or an image in a message.<br/>
    /// * <see cref="PostbackAction"/><br/>
    /// * <see cref="MessageAction"/><br/>
    /// * <see cref="UriAction"/><br/>
    /// * <see cref="DatetimePickerAction"/><br/>
    /// * <see cref="CameraAction"/><br/>
    /// * <see cref="CameraRollAction"/><br/>
    /// * <see cref="LocationAction"/>
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#action-objects">Here</a>.
    /// </remarks>
    public interface IAction
    {
        /// <summary>
        /// Action type.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Label for the action.
        /// </summary>
        string Label { get; set; }
    }
}

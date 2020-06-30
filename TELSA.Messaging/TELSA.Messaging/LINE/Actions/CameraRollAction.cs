namespace TELSA.Messaging.LINE.Actions
{
    /// <summary>
    /// This action can be configured only with quick reply buttons. When a button associated with this action is tapped, the camera roll screen in LINE is opened.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#camera-roll-action">Here</a>.
    /// </remarks>
    public class CameraRollAction : IAction
    {
        /// <summary>
        /// Consturctor.
        /// </summary>
        /// <param name="label"><see cref="Label"/></param>
        public CameraRollAction(string label)
        {
            Label = label;
        }

        /// <inheritdoc/>
        public string Type { get => "cameraRoll"; }

        /// <summary>
        /// Label for the action
        /// Max character limit: 20
        /// </summary>
        public string Label { get; set; }
    }
}

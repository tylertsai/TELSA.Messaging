namespace TELSA.Messaging.LINE.Actions
{
    /// <summary>
    /// This action can be configured only with quick reply buttons. When a button associated with this action is tapped, the camera screen in LINE is opened.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#camera-action">Here</a>.
    /// </remarks>
    public class CameraAction : IAction
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="label"><see cref="Label"/></param>
        public CameraAction(string label)
        {
            Label = label;
        }

        /// <inheritdoc/>
        public string Type { get => "camera"; }

        /// <summary>
        /// Label for the action
        /// Max character limit: 20
        /// </summary>
        public string Label { get; set; }
    }
}

namespace TELSA.Messaging.LINE.Actions
{
    /// <summary>
    /// This action can be configured only with quick reply buttons. When a button associated with this action is tapped, the location screen in LINE is opened.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#location-action">Here</a>.
    /// </remarks>
    public class LocationAction : IAction
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="label"><see cref="Label"/></param>
        public LocationAction(string label)
        {
            Label = label;
        }

        /// <inheritdoc/>
        public string Type { get => "location"; }

        /// <summary>
        /// Label for the action
        /// Max character limit: 20
        /// </summary>
        public string Label { get; set; }
    }
}

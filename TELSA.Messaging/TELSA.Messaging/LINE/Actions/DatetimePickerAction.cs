namespace TELSA.Messaging.LINE.Actions
{
    /// <summary>
    /// When a control associated with this action is tapped, a <a href="https://developers.line.biz/en/reference/messaging-api/#postback-event">postback event</a> is returned via webhook with the date and time selected by the user from the date and time selection dialog. The datetime picker action does not support time zones.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#datetime-picker-action">Here</a>.
    /// </remarks>
    public class DatetimePickerAction : IAction
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data"><see cref="Data"/></param>
        /// <param name="mode"><see cref="Mode"/></param>
        /// <param name="label"><see cref="Label"/></param>
        /// <param name="initial"><see cref="Initial"/></param>
        /// <param name="max"><see cref="Max"/></param>
        /// <param name="min"><see cref="Min"/></param>
        public DatetimePickerAction(string data, string mode, string label, string initial, string max, string min)
        {
            Data = data;
            Mode = mode;
            Label = label;
            Initial = initial;
            Max = max;
            Min = min;
        }

        /// <inheritdoc/>
        public string Type { get => "datetimepicker"; }

        /// <summary>
        /// Label for the action
        /// * Required for templates other than image carousel.Max character limit: 20
        /// * Optional for image carousel templates.Max character limit: 12
        /// * Optional for rich menus.Spoken when the accessibility feature is enabled on the client device.Max character limit: 20. Supported on LINE 8.2.0 and later for iOS.
        /// * Required for quick reply buttons.Max character limit: 20. Supported on LINE 8.11.0 and later for iOS and Android.
        /// * Required for the button of Flex Message.This property can be specified for the box, image, and text but its value is not displayed. Max character limit: 20
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// String returned via webhook in the postback.data property of the <a href="https://developers.line.biz/en/reference/messaging-api/#postback-event">postback event</a>
        /// Max character limit: 300
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// todo: 改成列舉
        /// Action mode
        /// date: Pick date
        /// time: Pick time
        /// datetime: Pick date and time
        /// </summary>
        /// <remarks>
        /// The date and time formats for the initial, max, and min values are shown below. The full-date, time-hour, and time-minute formats follow the <a href="https://www.ietf.org/rfc/rfc3339.txt">RFC3339</a> protocol.
        /// full-date
        /// Max: 2100-12-31
        /// Min: 1900-01-01
        ///
        /// time-hour:time-minute
        /// Max: 23:59
        /// Min: 00:00
        ///
        /// full-dateTtime-hour:time-minute or full-datettime-hour:time-minute
        /// Max: 2100-12-31T23:59
        /// Min: 1900-01-01T00:00/// </remarks>
        public string Mode { get; set; }

        /// <summary>
        /// todo: 想想看怎麼塑模
        /// Initial value of date or time
        /// </summary>
        public string Initial { get; set; }

        /// <summary>
        /// todo: 想想看怎麼塑模
        /// Largest date or time value that can be selected. Must be greater than the min value.
        /// </summary>
        public string Max { get; set; }

        /// <summary>
        /// todo: 想想看怎麼塑模
        /// Smallest date or time value that can be selected. Must be less than the max value.
        /// </summary>
        public string Min { get; set; }
    }
}

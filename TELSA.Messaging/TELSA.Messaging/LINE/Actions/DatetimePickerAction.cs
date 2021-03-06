﻿namespace TELSA.Messaging.LINE.Actions
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
        public DatetimePickerAction(string data, ActionMode mode, string label = null)
        {
            Data = data;
            Mode = mode;
            Label = label;
        }

        /// <inheritdoc/>
        public string Type { get => "datetimepicker"; }

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
        /// String returned via webhook in the postback.data property of the <a href="https://developers.line.biz/en/reference/messaging-api/#postback-event">postback event</a><br/>
        /// Max character limit: 300
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Action mode<br/>
        /// date: Pick date<br/>
        /// time: Pick time<br/>
        /// datetime: Pick date and time<br/>
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
        /// Min: 1900-01-01T00:00
        /// </remarks>
        public ActionMode Mode { get; set; }

        /// <summary>
        /// Initial value of date or time
        /// </summary>
        public string Initial { get; set; }

        /// <summary>
        /// Largest date or time value that can be selected. Must be greater than the min value.
        /// </summary>
        public string Max { get; set; }

        /// <summary>
        /// Smallest date or time value that can be selected. Must be less than the max value.
        /// </summary>
        public string Min { get; set; }
    }
}

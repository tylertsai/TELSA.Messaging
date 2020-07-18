using System.Collections.Generic;
using TELSA.Messaging.LINE.Actions;

namespace TELSA.Messaging.LINE.Templates
{
    /// <summary>
    /// Template with two action buttons.
    /// </summary>
    /// <remarks>
    /// Because of the height limitation for confirm template messages, the lower part of the text display area will get cut off if the height limitation is exceeded. For this reason, depending on the character width, the message text may not be fully displayed even when it is within the character limits.
    /// 
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#confirm">Here</a>.
    /// </remarks>
    public class ConfirmTemplate : ITemplate
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="text"><see cref="Text"/></param>
        /// <param name="actions"><see cref="Actions"/></param>
        public ConfirmTemplate(string text, IList<IAction> actions)
        {
            Text = text;
            Actions = actions;
        }

        /// <inheritdoc/>
        public string Type { get => "confirm"; }

        /// <summary>
        /// Message text
        /// Max character limit: 240
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Action when tapped
        /// Set 2 actions for the 2 buttons
        /// </summary>
        public IList<IAction> Actions { get; set; }
    }
}

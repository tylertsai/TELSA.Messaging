using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Text message.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#text-message">Here</a>.
    /// </remarks>
    public class TextMessage : MessageBase
    {
        /// <summary>
        /// Constructors.
        /// </summary>
        /// <param name="text"><see cref="Text"/></param>
        /// <param name="emojis"><see cref="Emojis"/></param>
        public TextMessage(string text, IList<Emoji> emojis)
        {
            Text = text;
            Emojis = emojis;
        }

        /// <inheritdoc/>
        public override string Type { get => "text"; }

        /// <summary>
        /// Message text. You can include the following emoji:
        /// * Unicode emoji
        /// * LINE emoji(Use a $ character as a placeholder and specify details in the emojis property)
        /// * (Deprecated) LINE original emoji(Unicode code point table for LINE original emoji)
        /// * Max character limit: 5000
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// One or more LINE emoji.
        /// Max: 20 LINE emoji
        /// </summary>
        public IList<Emoji> Emojis { get; }
    }
}

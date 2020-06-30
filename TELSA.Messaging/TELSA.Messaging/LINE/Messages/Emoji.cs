namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// LINE emoji.
    /// </summary>
    public class Emoji
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="index"><see cref="Index"/></param>
        /// <param name="productId"><see cref="ProductId"/></param>
        /// <param name="emojiId"><see cref="EmojiId"/></param>
        public Emoji(int index, string productId, string emojiId)
        {
            Index = index;
            ProductId = productId;
            EmojiId = emojiId;
        }

        /// <summary>
        /// Index position for a character in text, with the first character being at position 0. The specified position must correspond to a $ character, which serves as a placeholder for the LINE emoji. If you specify a position that doesn't contain a $ character, the API returns HTTP 400 Bad request. See the text message example for details.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Product ID for a set of LINE emoji. See <a href="https://d.line-scdn.net/r/devcenter/sendable_line_emoji_list.pdf">Sendable LINE emoji list</a>.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// ID for a LINE emoji inside a set. See <a href="https://d.line-scdn.net/r/devcenter/sendable_line_emoji_list.pdf">Sendable LINE emoji list</a>.
        /// </summary>
        public string EmojiId { get; set; }
    }
}

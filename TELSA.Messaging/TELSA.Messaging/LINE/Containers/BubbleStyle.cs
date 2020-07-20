namespace TELSA.Messaging.LINE.Containers
{
    /// <summary>
    /// Bubble style.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#bubble-style">Here</a>.
    /// </remarks>
    public class BubbleStyle
    {
        /// <summary>
        /// Header block. Specify a <see cref="BlockStyle"/>.
        /// </summary>
        public BlockStyle Header { get; set; }

        /// <summary>
        /// Hero block. Specify a <see cref="BlockStyle"/>.
        /// </summary>
        public BlockStyle Hero { get; set; }

        /// <summary>
        /// Body block. Specify a <see cref="BlockStyle"/>.
        /// </summary>
        public BlockStyle Body { get; set; }

        /// <summary>
        /// Footer block. Specify a <see cref="BlockStyle"/>.
        /// </summary>
        public BlockStyle Footer { get; set; }
    }
}
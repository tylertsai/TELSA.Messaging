namespace TELSA.Messaging.LINE.Containers
{
    /// <summary>
    /// Block style.<br/>
    /// <br/>
    /// Note: You cannot place a separator above the first block.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#block-style">Here</a>.
    /// </remarks>
    public class BlockStyle
    {
        /// <summary>
        /// Background color of the block. Use a hexadecimal color code.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// true to place a separator above the block. The default value is false.
        /// </summary>
        public bool? Separator { get; set; }

        /// <summary>
        /// Color of the separator. Use a hexadecimal color code.
        /// </summary>
        public string SeparatorColor { get; set; }
    }
}
namespace TELSA.Messaging.LINE.Components
{
    /// <summary>
    /// This component renders multiple text strings with different designs in one row. You can specify the color, size, weight, and decoration for the font. Span is set to contents property in <see cref="Text"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#span">Here</a>.
    /// </remarks>
    public class SpanComponent : IComponent
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="text"><see cref="Text"/></param>
        public SpanComponent(string text)
        {
            Text = text;
        }

        /// <inheritdoc/>
        public string Type { get => "span"; }

        /// <summary>
        /// Text. If the wrap property of the parent text is set to true, you can use a new line character (\n) to begin on a new line.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Font color. Use a hexadecimal color code.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Font size. You can specify one of the following values: xxs, xs, sm, md, lg, xl, xxl, 3xl, 4xl, or 5xl. The size increases in the order of listing. The default value is md.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Font weight. You can specify one of the following values: regular or bold. Specifying bold makes the font bold. The default value is regular.
        /// </summary>
        public FontWeight? Weight { get; set; }

        /// <summary>
        /// Style of the text. Specify one of the following values:<br/>
        /// * normal: Normal<br/>
        /// * italic: Italic<br/>
        /// <br/>
        /// The default value is normal.
        /// </summary>
        public TextStyle? Style { get; set; }

        /// <summary>
        /// Decoration of the text. Specify one of the following values:<br/>
        /// * none: No decoration<br/>
        /// * underline: Underline<br/>
        /// * line-through: Strikethrough<br/>
        /// <br/>
        /// The default value is none.
        ///
        /// Note: The decoration set in the decoration property of the <see cref="TextComponent"/> cannot be overwritten by the decoration property of the span.
        /// </summary>
        public TextDecoration? Decoration { get; set; }
    }
}
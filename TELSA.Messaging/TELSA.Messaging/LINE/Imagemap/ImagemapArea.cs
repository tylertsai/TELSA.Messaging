namespace TELSA.Messaging.LINE.Imagemap
{
    /// <summary>
    /// Defines the size of a tappable area. The top left is used as the origin of the area. Set these properties based on the <see cref="ImagemapBaseSize.Width"/> property and the <see cref="ImagemapBaseSize.Height"/> property.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#imagemap-area-object">Here</a>.
    /// </remarks>
    public class ImagemapArea
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x"><see cref="X"/></param>
        /// <param name="y"><see cref="Y"/></param>
        /// <param name="width"><see cref="Width"/></param>
        /// <param name="height"><see cref="Height"/></param>
        public ImagemapArea(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Horizontal position relative to the left edge of the area. Value must be 0 or higher.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Vertical position relative to the top of the area. Value must be 0 or higher.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Width of the tappable area
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of the tappable area
        /// </summary>
        public int Height { get; set; }
    }
}

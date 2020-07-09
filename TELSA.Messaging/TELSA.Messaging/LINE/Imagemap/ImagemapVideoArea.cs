namespace TELSA.Messaging.LINE.Imagemap
{
    /// <summary>
    /// Defines a video area.
    /// </summary>
    public class ImagemapVideoArea
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x"><see cref="X"/></param>
        /// <param name="y"><see cref="Y"/></param>
        /// <param name="width"><see cref="Width"/></param>
        /// <param name="height"><see cref="Height"/></param>
        public ImagemapVideoArea(int x, int y, int width, int height)
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
        /// Width of the video area
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of the video area
        /// </summary>
        public int Height { get; set; }
    }
}

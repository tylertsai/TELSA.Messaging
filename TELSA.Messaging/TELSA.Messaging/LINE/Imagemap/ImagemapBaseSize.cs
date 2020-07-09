namespace TELSA.Messaging.LINE.Imagemap
{
    /// <summary>
    /// Defined Imagemap base size.
    /// </summary>
    public class ImagemapBaseSize
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="width"><see cref="Width"/></param>
        /// <param name="height"><see cref="Height"/></param>
        public ImagemapBaseSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Width of base image in pixels. Set to 1040.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of base image. Set to the height that corresponds to a width of 1040 pixels.
        /// </summary>
        public int Height { get; set; }
    }
}

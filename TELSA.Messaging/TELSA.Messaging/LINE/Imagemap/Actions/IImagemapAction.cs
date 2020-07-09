using TELSA.Messaging.LINE.Actions;

namespace TELSA.Messaging.LINE.Imagemap.Actions
{
    /// <summary>
    /// Object which specifies the actions and tappable areas of an imagemap.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#imagemap-action-objects">Here</a>.
    /// </remarks>
    public interface IImagemapAction : IAction
    {
        /// <summary>
        /// Defined tappable area
        /// </summary>
        ImagemapArea Area { get; set; }
    }
}

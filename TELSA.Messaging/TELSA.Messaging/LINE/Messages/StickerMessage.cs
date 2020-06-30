namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Sticker message.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#sticker-message">Here</a>.
    /// </remarks>
    public class StickerMessage : MessageBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="packageId"><see cref="PackageId"/></param>
        /// <param name="stickerId"><see cref="StickerId"/></param>
        public StickerMessage(string packageId, string stickerId)
        {
            PackageId = packageId;
            StickerId = stickerId;
        }

        /// <inheritdoc/>
        public override string Type { get => "sticker"; }

        /// <summary>
        /// Package ID for a set of stickers. For information on package IDs, see the <a href="https://developers.line.biz/media/messaging-api/sticker_list.pdf">Sticker list</a>.
        /// </summary>
        public string PackageId { get; set; }

        /// <summary>
        /// Sticker ID. For a list of sticker IDs for stickers that can be sent with the Messaging API, see the <a href="https://developers.line.biz/media/messaging-api/sticker_list.pdf">Sticker list</a>.
        /// </summary>
        public string StickerId { get; set; }
    }
}

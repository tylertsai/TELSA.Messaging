﻿using System.Collections.Generic;
using TELSA.Messaging.LINE.Imagemap;
using TELSA.Messaging.LINE.Imagemap.Actions;

namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Imagemap messages are messages configured with an image that has multiple tappable areas. You can assign one tappable area for the entire image or different tappable areas on divided areas of the image.<br/>
    /// <br/>
    /// You can also play a video on the image and display a label with a hyperlink after the video is finished.
    /// </summary>
    public class ImagemapMessage : MessageBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="baseUrl"><see cref="BaseUrl"/></param>
        /// <param name="altText"><see cref="AltText"/></param>
        /// <param name="baseSize"><see cref="BaseSize"/></param>
        /// <param name="actions"><see cref="Actions"/></param>
        public ImagemapMessage(string baseUrl, string altText, ImagemapBaseSize baseSize, IList<IImagemapAction> actions)
        {
            BaseUrl = baseUrl;
            AltText = altText;
            BaseSize = baseSize;
            Actions = actions;
        }

        /// <inheritdoc/>
        public override string Type { get => "imagemap"; }

        /// <summary>
        /// Base URL of the image<br/>
        /// Max character limit: 1000<br/>
        /// HTTPS over TLS 1.2 or later<br/>
        /// For more information about supported images in imagemap messages, see <a href="https://developers.line.biz/en/reference/messaging-api/#base-url">How to configure an image</a>.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Alternative text<br/>
        /// Max character limit: 400
        /// </summary>
        public string AltText { get; set; }

        /// <summary>
        /// Base size of the image.
        /// </summary>
        public ImagemapBaseSize BaseSize { get; }

        /// <summary>
        /// This property is required if you set a video to play on the imagemap.
        /// </summary>
        public ImagemapVideo Video { get; set; }

        /// <summary>
        /// Action when tapped<br/>
        /// Max: 50
        /// </summary>
        public IList<IImagemapAction> Actions { get; }
    }
}

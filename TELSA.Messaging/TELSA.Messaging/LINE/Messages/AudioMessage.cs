namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Audio message.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#audio-message">Here</a>.
    /// </remarks>
    public class AudioMessage : MessageBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="originalContentUrl"><see cref="OriginalContentUrl"/></param>
        /// <param name="duration"><see cref="Duration"/></param>
        public AudioMessage(string originalContentUrl, int duration)
        {
            OriginalContentUrl = originalContentUrl;
            Duration = duration;
        }

        /// <inheritdoc/>
        public override string Type { get => "audio"; }

        /// <summary>
        /// URL of audio file (Max character limit: 1000)<br/>
        /// HTTPS over TLS 1.2 or later<br/>
        /// m4a<br/>
        /// Max file size: 200 MB<br/>
        /// <br/>
        /// Note: Only M4A files are supported on the Messaging API.If a service only supports MP3 files, you can use a service like FFmpeg to convert the files to M4A.
        /// </summary>
        public string OriginalContentUrl { get; set; }

        /// <summary>
        /// Length of audio file (milliseconds)
        /// </summary>
        public int Duration { get; set; }
    }
}

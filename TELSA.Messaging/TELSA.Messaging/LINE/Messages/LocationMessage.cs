namespace TELSA.Messaging.LINE.Messages
{
    /// <summary>
    /// Location message.
    /// </summary>
    /// <remarks>
    /// See <a href="https://developers.line.biz/en/reference/messaging-api/#location-message">Here</a>.
    /// </remarks>
    public class LocationMessage : MessageBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="title"><see cref="Title"/></param>
        /// <param name="address"><see cref="Address"/></param>
        /// <param name="latitude"><see cref="Latitude"/></param>
        /// <param name="longitude"><see cref="Longitude"/></param>
        public LocationMessage(string title, string address, double latitude, double longitude)
        {
            Title = title;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <inheritdoc/>
        public override string Type { get => "location"; }

        /// <summary>
        /// Title
        /// Max character limit: 100
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Address
        /// Max character limit: 100
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude { get; set; }
    }
}

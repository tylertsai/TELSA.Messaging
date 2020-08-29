namespace TELSA.Messaging.LINE.Messages.Narrowcast.Recipients
{
    /// <summary>
    /// Define Audience object.
    /// </summary>
    public class Audience : Recipient
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="audienceGroupId"><see cref="AudienceGroupId"/></param>
        public Audience(long audienceGroupId)
        {
            AudienceGroupId = audienceGroupId;
        }
        
        /// <inheritdoc/>
        public override string Type => "audience";
        
        /// <summary>
        /// The audience ID. Create audiences with the <a href="https://developers.line.biz/en/reference/messaging-api/#manage-audience-group">manage</a> audience API.
        /// </summary>
        public long AudienceGroupId { get; set; }
    }
}
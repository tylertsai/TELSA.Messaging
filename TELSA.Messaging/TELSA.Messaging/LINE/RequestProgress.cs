namespace TELSA.Messaging.LINE
{
    /// <summary>
    /// Define request progress.
    /// </summary>
    public class RequestProgress
    {
        /// <summary>
        /// The current status. One of:<br/><br/>
        /// * waiting: Messages are not yet ready to be sent. They are currently being filtered or processed in some way.<br/><br/>
        /// * sending: Messages are currently being sent.<br/><br/>
        /// * succeeded: Messages were sent successfully. This may not mean the messages were successfully received.<br/><br/>
        /// * failed: Messages failed to be sent. Use the failedDescription property to find the cause of the failure.
        /// </summary>
        public ProgressPhase Phase { get; set; }
        
        /// <summary>
        /// The number of users who successfully received the message. *<br/><br/>
        /// * Not available when the phase property is waiting.
        /// </summary>
        public long? SuccessCount { get; set; }
        
        /// <summary>
        /// The number of users who failed to send the message. *<br/><br/>
        /// Even if the <see cref="Phase"/> is <see cref="ProgressPhase.Succeeded"/>, some users may not be able to receive narrowcast messages unless the <see cref="FailureCount"/> is 0. For example, if a user blocks the LINE Official Account while sending a narrowcast message, it will be added to the <see cref="FailureCount"/>.<br/><br/>
        /// * Not available when the phase property is waiting.
        /// </summary>
        public long? FailureCount { get; set; }
        
        /// <summary>
        /// The number of intended recipients of the message. *<br/><br/>
        /// * Not available when the phase property is waiting.
        /// </summary>
        public long? TargetCount { get; set; }
        
        /// <summary>
        /// The reason the message failed to be sent. This is only included with a <see cref="Phase"/> property value of <see cref="ProgressPhase.Failed"/>.
        /// </summary>
        public string FailedDescription { get; set; }
        
        /// <summary>
        /// Error summary. One of:<br/><br/>
        /// * 1: An internal error occurred.<br/><br/>
        /// * 2: An error occurred because there weren't enough recipients.<br/><br/>
        /// * 3: A conflict error of requests occurs because a request that has already been accepted is retried.
        /// </summary>
        public int? ErrorCode { get; set; }
    }
}

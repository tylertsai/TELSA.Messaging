using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Messages.Narrowcast.Filters
{
    /// <summary>
    /// Define OperatingSystemFilter.
    /// </summary>
    public class OperatingSystemFilter : DemographicFilter
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="oneOf"><see cref="OneOf"/></param>
        public OperatingSystemFilter(IList<OperatingSystem> oneOf)
        {
            OneOf = oneOf;
        }
        
        /// <inheritdoc />
        public override string Type => "appType";
        
        /// <summary>
        /// Send messages to users with the specified OS.
        /// </summary>
        public IList<OperatingSystem> OneOf { get; }
    }
}
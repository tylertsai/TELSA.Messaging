using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Messages.Narrowcast.Filters
{
    /// <summary>
    /// Define RegionFilter.
    /// </summary>
    public class RegionFilter : DemographicFilter
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="oneOf"><see cref="OneOf"/></param>
        public RegionFilter(IList<Region> oneOf)
        {
            OneOf = oneOf;
        }
        
        /// <inheritdoc />
        public override string Type => "area";
        
        /// <summary>
        /// Send messages to users in the specified region.
        /// </summary>
        public IList<Region> OneOf { get; }
    }
}
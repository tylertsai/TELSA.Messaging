using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Messages.Narrowcast.Filters
{
    /// <summary>
    /// Define GenderFilter.
    /// </summary>
    public class GenderFilter : DemographicFilter
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="oneOf"><see cref="OneOf"/></param>
        public GenderFilter(IList<Gender> oneOf)
        {
            OneOf = oneOf;
        }
        
        /// <inheritdoc />
        public override string Type => "gender";
        
        /// <summary>
        /// Send messages to users of a given gender.
        /// </summary>
        public IList<Gender> OneOf { get; }
    }
}
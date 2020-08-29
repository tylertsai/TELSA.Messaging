using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Messages.Narrowcast.Filters
{
    /// <summary>
    /// Use logical AND, OR, and NOT operators to combine multiple demographic filter objects together. You can specify up to 10 demographic filter objects per request.
    /// </summary>
    public class LogicalOperator : DemographicFilter
    {
        /// <summary>
        /// Constructor.<br/><br/>
        /// * Be sure to specify only one of these three properties (and, or, or not). You cannot specify an empty array.
        /// </summary>
        /// <param name="and"></param>
        /// <param name="or"></param>
        /// <param name="not"></param>
        public LogicalOperator(
            IList<DemographicFilter> and = null,
            IList<DemographicFilter> or = null,
            DemographicFilter not = null)
        {
            And = and;
            Or = or;
            Not = not;
        }

        /// <inheritdoc/>
        public override string Type => "operator";

        /// <summary>
        /// Create a new demographic filter object by taking the logical conjunction (AND) of the specified array of demographic filter objects.
        /// </summary>
        public IList<DemographicFilter> And { get; }

        /// <summary>
        /// Create a new demographic filter object by taking the logical disjunction (OR) of the specified array of demographic filter objects.
        /// </summary>
        public IList<DemographicFilter> Or { get; }

        /// <summary>
        /// Create a new demographic filter object that excludes the specified array of demographic filter objects.
        /// </summary>
        public DemographicFilter Not { get; }
    }
}
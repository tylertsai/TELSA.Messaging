using System.Collections.Generic;

namespace TELSA.Messaging.LINE.Messages.Narrowcast.Recipients
{
    /// <summary>
    /// Define LogicalOperator object.
    /// </summary>
    public class LogicalOperator : Recipient
    {
        /// <summary>
        /// Constructor.<br/><br/>
        /// * Be sure to specify only one of these three properties (and, or, or not). You cannot specify an empty array.
        /// </summary>
        /// <param name="and"></param>
        /// <param name="or"></param>
        /// <param name="not"></param>
        public LogicalOperator(
            IList<Recipient> and = null,
            IList<Recipient> or = null,
            Recipient not = null)
        {
            And = and;
            Or = or;
            Not = not;
        }

        /// <inheritdoc/>
        public override string Type => "operator";

        /// <summary>
        /// Create a new recipient object by taking the logical conjunction (AND) of the specified array of recipient objects.
        /// </summary>
        public IList<Recipient> And { get; }

        /// <summary>
        /// Create a new recipient object by taking the logical disjunction (OR) of the specified array of recipient objects.
        /// </summary>
        public IList<Recipient> Or { get; }

        /// <summary>
        /// Create a new recipient object that excludes the specified recipient object.
        /// </summary>
        public Recipient Not { get; }
    }
}
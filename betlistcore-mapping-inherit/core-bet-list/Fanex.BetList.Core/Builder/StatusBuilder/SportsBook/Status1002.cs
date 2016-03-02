using Fanex.BetList.Core.Entities;

namespace Fanex.BetList.Core.Builder.StatusBuilder
{
    /// <summary>
    /// Texas HOLD'EM.
    /// </summary>
    public class Status1002 : BaseStatusBuilder
    {
        protected override void BuildStatusResult(ITicket ticket)
        {
            base.BuildStatusResult(ticket);

            // Use sessionId instead of refNo to call API service
            Template.StatusResult.refNo = ticket.BetCheck;
        }
    }
}
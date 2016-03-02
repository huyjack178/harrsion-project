using Fanex.BetList.Core.Entities;

namespace Fanex.BetList.Core.Builder.StatusBuilder
{
    internal class Status73 : BaseStatusBuilder
    {
        protected override void BuildStatusResult(ITicket ticket)
        {
            base.BuildStatusResult(ticket);

            Template.StatusResult.refNo = ticket.RefNo;
        }
    }
}
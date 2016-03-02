namespace Fanex.BetList.Core.Builder.StatusBuilder
{
    using Fanex.BetList.Core.Entities;

    public class Status1000 : BaseStatusBuilder
    {
        protected override void BuildStatusResult(ITicket ticket)
        {
            base.BuildStatusResult(ticket);

            // Use sessionId instead of refNo to call API service
            Template.StatusResult.refNo = ticket.BetCheck;
        }
    }
}
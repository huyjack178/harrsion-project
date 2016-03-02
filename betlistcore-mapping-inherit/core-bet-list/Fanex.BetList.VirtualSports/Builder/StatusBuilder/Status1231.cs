using Fanex.BetList.Core.Entities;

namespace Fanex.BetList.Core.Builder.StatusBuilder
{
    public class Status1231 : BaseStatusBuilder
    {
        protected override void BuildStatusResult(ITicket ticket)
        {
            base.BuildStatusResult(ticket);

            Template.StatusResult.race = string.IsNullOrEmpty(ticket.Race) ? "0" : ticket.Race;
        }
    }
}
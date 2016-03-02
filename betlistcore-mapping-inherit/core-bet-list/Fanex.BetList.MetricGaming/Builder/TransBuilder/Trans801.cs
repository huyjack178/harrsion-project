using Fanex.BetList.Core.Entities;

namespace Fanex.BetList.Core.Builder.TransBuilder
{
    public class Trans801 : Trans1
    {
        protected override void BuildRefNo(ITicket ticket)
        {
            Template.TransTime.refNo = ticket.RefNo;
        }
    }
}

using Fanex.BetList.Core.Entities;

namespace Fanex.BetList.Core.Builder.TransBuilder
{
    public class Trans1701 : BaseTransBuilder
    {
        protected override void BuildRefNo(ITicket ticket)
        {
            Template.TransTime.refNo = ticket.RefNo;
        }
    }
}
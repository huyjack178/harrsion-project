using Fanex.BetList.Core.Entities;

namespace Fanex.BetList.Core.Builder.TransBuilder
{
    internal class Trans1501 : BaseTransBuilder
    {
        protected override void BuildRefNo(ITicket ticket)
        {
            Template.TransTime.refNo = ticket.RefNo;
        }
    }
}
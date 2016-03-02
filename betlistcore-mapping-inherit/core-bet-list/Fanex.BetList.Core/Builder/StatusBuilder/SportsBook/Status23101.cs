namespace Fanex.BetList.Core.Builder.StatusBuilder
{
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// P2P Transfer.
    /// </summary>
    public class Status23101 : BaseStatusBuilder
    {
        protected override void BuildStatusResult(ITicket ticket)
        {
            base.BuildStatusResult(ticket);

            Template.StatusResult.refNo = ticket.RefNo;
        }
    }
}
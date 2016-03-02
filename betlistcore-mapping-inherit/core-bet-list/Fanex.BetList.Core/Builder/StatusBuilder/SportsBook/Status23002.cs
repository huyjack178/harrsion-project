namespace Fanex.BetList.Core.Builder.StatusBuilder
{
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Casino pending.
    /// </summary>
    public class Status23002 : BaseStatusBuilder
    {
        protected override void BuildStatusResult(ITicket ticket)
        {
            base.BuildStatusResult(ticket);

            Template.StatusResult.refNo = ticket.RefNo;
        }
    }
}
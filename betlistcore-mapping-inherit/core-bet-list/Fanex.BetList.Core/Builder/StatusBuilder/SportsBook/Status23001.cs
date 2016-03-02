namespace Fanex.BetList.Core.Builder.StatusBuilder
{
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Casino Transfer.
    /// </summary>
    public class Status23001 : BaseStatusBuilder
    {
        protected override void BuildStatusResult(ITicket ticket)
        {
            base.BuildStatusResult(ticket);

            Template.StatusResult.refNo = ticket.RefNo;
        }
    }
}
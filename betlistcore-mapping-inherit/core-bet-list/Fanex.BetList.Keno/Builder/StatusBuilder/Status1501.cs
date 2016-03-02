namespace Fanex.BetList.Core.Builder.StatusBuilder
{
    using Fanex.BetList.Core.Entities;

    public class Status1501 : BaseStatusBuilder
    {
        protected override void BuildStatusResult(ITicket ticket)
        {
            Template.StatusResult.Hide();
        }
    }
}
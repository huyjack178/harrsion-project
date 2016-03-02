namespace Fanex.BetList.Core.Builder.ChoiceBuilder
{
    using Fanex.BetList.Core.Entities;

    public class Choice1102 : Choice1101
    {
        protected override string GetBetTeamName(ITicketData ticketData, ITicketHelper ticketHelper)
        {
            return ticketHelper.GetRouletteBetItemNameById(ticketData.BetTeam);
        }
    }
}

namespace Fanex.BetList.Core.Builder.ChoiceBuilder
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;
    using System.Collections.Generic;

    public class Choice81 : Choice1
    {
        private const string HandicapValue = "37.5";

        protected override void BuildBetTeam(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.betTeam = ticket.BetTeam == BetTeamValue.H ? CoreBetList.over : CoreBetList.under;
        }

        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            base.BuildMatch(ticket, ticketHelper);

            Template.Match.VS = null;
            Template.Match.homeTeam = string.Join(null, new string[] { CoreBetList.numbergameno, HtmlCharacters.NoneBreakingSpace, ticket.MatchCode });
        }

        protected override void BuildBetTeamClassNameAndHandicap(ITicket ticket)
        {
            Template.betTeamClassName = Favorite;
            Template.Handicap.handicap = HandicapValue;
        }
    }
}
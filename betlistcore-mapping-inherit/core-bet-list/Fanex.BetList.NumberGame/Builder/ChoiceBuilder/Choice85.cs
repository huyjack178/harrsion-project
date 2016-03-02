namespace Fanex.BetList.Core.Builder.ChoiceBuilder
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;
    using System.Collections.Generic;

    public class Choice85 : Choice3
    {
        protected override void BuildBetTeam(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildBetTeam(ticket, ticketHelper, ticketData);

            string betId = ticket.BetId.ToString();
            if (betId == "0")
            {
                betId = string.Empty;
            }

            string liveScore = string.Empty;
            liveScore = (!ticket.IsLive || string.IsNullOrEmpty(betId)) ? " [0]" : string.Join(null, new string[] { " [", betId, "]" });

            string betTeam = Template.betTeam;
            betTeam += " <span style='color:#555555'>37.5</span> ";

            Template.betTeam = betTeam + liveScore;
        }

        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            base.BuildMatch(ticket, ticketHelper);

            Template.Match.VS = null;
            Template.Match.homeTeam = string.Join(null, new string[] { CoreBetList.numbergameno, HtmlCharacters.NoneBreakingSpace, ticket.MatchCode });
        }

        protected override void BuildBetType(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildBetType(ticket, ticketHelper, ticketData);

            string bettypeName = Template.BetType.betTypeName;
            if (!ticket.IsLive)
            {
                bettypeName = string.Join(null, new string[] { CoreBetList.ft, ". ", bettypeName });
            }
            else
            {
                bettypeName = string.Join(null, new string[] { CoreBetList.next, HtmlCharacters.NoneBreakingSpace, bettypeName });
            }

            Template.BetType.betTypeName = bettypeName;
        }

        protected override void BuildScore(ITicket ticket)
        {
            Template.Score = null;
        }

        protected override void BuildBetTeamClassNameAndHandicap(ITicket ticket)
        {
            Template.betTeamClassName = Favorite;
            Template.Handicap.handicap = null;
        }
    }
}
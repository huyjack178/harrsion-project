﻿namespace Fanex.BetList.Core.Builder.ChoiceBuilder
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;
    using System.Collections.Generic;

    public class Choice89 : Choice1
    {
        protected override void BuildBetTeam(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            string betId = ticket.BetId.ToString();
            if (betId == "0")
            {
                betId = string.Empty;
            }

            string liveScore = (!ticket.IsLive || string.IsNullOrEmpty(betId)) ? " [0]" : string.Join(null, new string[] { " [", betId, "]" });

            string betTeam = string.Empty;
            switch (ticket.BetTeam)
            {
                case "1:1":
                    betTeam = CoreBetList.lblOverOdd;
                    break;

                case "1:2":
                    betTeam = CoreBetList.lblOverEven;
                    break;

                case "2:1":
                    betTeam = CoreBetList.lblUnderOdd;
                    break;

                case "2:2":
                    betTeam = CoreBetList.lblUnderEven;
                    break;
            }

            betTeam += " <span style='color:#555555'>37.5</span> ";

            Template.betTeam = betTeam + liveScore;
        }

        protected override void BuildBetTeamClassNameAndHandicap(ITicket ticket)
        {
            Template.Handicap.handicap = null;
            Template.betTeamClassName = Favorite;
        }

        protected override void BuildScore(ITicket ticket)
        {
            Template.Score = null;
        }

        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            base.BuildMatch(ticket, ticketHelper);

            Template.Match.VS = null;
            Template.Match.homeTeam = string.Join(null, new string[] { CoreBetList.numbergameno, HtmlCharacters.NoneBreakingSpace, ticket.MatchCode });
        }
    }
}
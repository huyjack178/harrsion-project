﻿using Fanex.BetList.Core.App_GlobalResources;
using Fanex.BetList.Core.Entities;
using System.Collections.Generic;

namespace Fanex.BetList.Core.Builder.ChoiceBuilder
{
    public class Choice71: Choice1
    {
        protected override void BuildBetTeam(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.betTeam = CoreBetList.casinoGame;
        }

        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            UpdateAllMatchMemberToNull();
        }

        protected override void BuildSport(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.League.sportTypeName = null;
        }

        protected override void BuildLeague(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.League.LeagueName.leagueName = null;
        }

        protected override void BuildScore(ITicket ticket)
        {
            Template.Score = null;
        }

        protected override void BuildBetTeamClassNameAndHandicap(ITicket ticket)
        {
            Template.Handicap.handicap = null;
            Template.betTeamClassName = Favorite;
        }

        protected override void BuildBetType(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetType.betTypeName = null;
        }
    }
}

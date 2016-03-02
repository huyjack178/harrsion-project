namespace Fanex.BetList.Core.Builder.ChoiceBuilder
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using App_GlobalResources;
    using Constants;
    using Entities;
    using Utils;

    public class Choice1701 : Choice1
    {
        private const string BetTeamFormat = "<div><span class='favorite'>{0}</span>&nbsp;<span class='stake'>{1}</span>&nbsp;@&nbsp;<span class='handicap custom'>{2}</span></div>";

        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.Match = null;
        }

        protected override void BuildBetType(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetType = null;
        }

        protected override void BuildLeague(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTypeName = GetBetTypeName(ticket.BetTypeId, ticketHelper);

            Template.League.LeagueName.leagueName = string.Join(null, new string[] { betTypeName, HtmlCharacters.NoneBreakingSpace, ticket.BetCheck });
        }

        protected override void BuildScore(ITicket ticket)
        {
            Template.Score.Hide();
        }

        protected override void BuildBetTeam(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            List<ITicketData> foundTicketData = GetTicketReference(ticket, ticketData);

            if (foundTicketData.Count > 0)
            {
                var betTeam = new StringBuilder();
                foreach (ITicketData refDataItem in foundTicketData)
                {
                    string betTeamName = GetBetTeamName(refDataItem, ticketHelper);
                    string odds = ConvertByBetType.Odds(refDataItem.Odds, ticket.BetTypeId, ticket.OddsType);

                    betTeam.AppendFormat(BetTeamFormat, betTeamName, ConvertByBetType.Stake(refDataItem.Stake), odds);
                }

                Template.betTeam = betTeam.ToString();
            }
            else
            {
                Template.betTeam = string.Empty;
            }
        }

        protected override void BuildBetTeamClassNameAndHandicap(ITicket ticket)
        {
            Template.Handicap.Hide();
            Template.betTeamClassName = string.Empty;
        }

        protected override string GetBetTeamName(ITicketData ticketData, ITicketHelper ticketHelper)
        {
            return ticketHelper.GetResourceData(GetResourceId(), ticketData.BetTeam);
        }

        protected override List<ITicketData> GetTicketReference(ITicket ticket, List<ITicketData> ticketData)
        {
            var foundTicketData = new List<ITicketData>();

            if (ticketData != null && ticketData.Count > 0)
            {
                foundTicketData = ticketData.FindAll(item => item.RefNo.Equals(ticket.TransId.ToString()));
            }

            return foundTicketData;
        }

        protected virtual string GetResourceId()
        {
            return "GD_Baccarat";
        }
    }
}
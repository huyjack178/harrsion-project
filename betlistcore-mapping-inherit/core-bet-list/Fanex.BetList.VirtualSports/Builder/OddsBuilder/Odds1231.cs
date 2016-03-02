namespace Fanex.BetList.Core.Builder.OddsBuilder
{
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Templates;
    using Fanex.BetList.Core.Utils;
    using System.Collections.Generic;

    public class Odds1231 : BaseOddsBuilder
    {
        public override Odds_Template Render(ITicket ticket, List<ITicketData> ticketData, GetCachePropertyById funcGetOddsTypeName)
        {
            object oddsType = string.IsNullOrEmpty(ticket.OddsType) ? (object)0 : ticket.OddsType;

            Template.odds = ConvertByBetType.VirtualHorseRacingOdds(ticket.Odds, ticket.BetTypeId, oddsType);
            Template.oddsType = funcGetOddsTypeName(ConvertByBetType.OddsType(ticket.BetTypeId, oddsType));

            return Template;
        }
    }
}
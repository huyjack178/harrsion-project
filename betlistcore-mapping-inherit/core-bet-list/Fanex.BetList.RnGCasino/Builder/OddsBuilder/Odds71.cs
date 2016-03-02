using Fanex.BetList.Core.Entities;
using Fanex.BetList.Core.Templates;
using NPOI.SS.UserModel;
using System.Collections.Generic;

namespace Fanex.BetList.Core.Builder.OddsBuilder
{
    public class Odds71: BaseOddsBuilder
    {
        public override Odds_Template Render(ITicket ticket, List<ITicketData> ticketData, GetCachePropertyById funcGetOddsTypeName)
        {
            // This bettype never has an odds
            Template.odds = "-";
            Template.oddsType = string.Empty;

            return Template;
        }

        public override IRichTextString RenderRTF(ITicket ticket, List<ITicketData> ticketData, GetCachePropertyById funcGetOddsTypeName, RTFHelper rtfHelper)
        {
            Render(ticket, ticketData, funcGetOddsTypeName);
            var rtfOdds = BuildRTFOddsCasino(rtfHelper);

            return rtfOdds;
        }
    }
}



namespace Fanex.BetList.Core.Builder.OddsBuilder._3rd
{
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Templates;
    using NPOI.SS.UserModel;
    using System.Collections.Generic;

    /// <summary>
    /// Play Tech Casino.
    /// </summary>
    public class Odds_22006 : BaseOddsBuilder
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
namespace Fanex.BetList.Core.Builder.OddsBuilder
{
    using Entities;
    using NPOI.SS.UserModel;
    using System.Collections.Generic;
    using Templates;

    public class Odds1233 : BaseOddsBuilder
    {
        public Odds1233()
        {
            WinBetId = 1231;
            PlaceBetId = 1232;
        }

        public int WinBetId { get; set; }

        public int PlaceBetId { get; set; }

        public override Odds_Template Render(ITicket ticket, List<ITicketData> ticketData, GetCachePropertyById funcGetOddsTypeName)
        {
            BuildOddsWinPlace(ticket, ticketData, funcGetOddsTypeName, WinBetId, PlaceBetId);

            return Template;
        }

        public override IRichTextString RenderRTF(ITicket ticket, List<ITicketData> ticketData, GetCachePropertyById funcGetOddsTypeName, RTFHelper rtfHelper)
        {
            Render(ticket, ticketData, funcGetOddsTypeName);

            var rtfOdds = BuildRTFOddsWinPlace(rtfHelper);

            return rtfOdds;
        }

        protected override List<ITicketData> GetReferenceData(ITicket ticket, List<ITicketData> ticketData)
        {
            return ticketData.FindAll(item => item.RefNo.Equals(ticket.RefNo));
        }
    }
}
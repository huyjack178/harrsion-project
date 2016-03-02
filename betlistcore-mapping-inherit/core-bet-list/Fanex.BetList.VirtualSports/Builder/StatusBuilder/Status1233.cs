namespace Fanex.BetList.Core.Builder.StatusBuilder
{
    using Fanex.BetList.Core.Entities;
    using NPOI.SS.UserModel;
    using System.Collections.Generic;

    public class Status1233 : Status1231
    {
        public Status1233()
        {
            WinBetId = 1231;
            PlaceBetId = 1232;
        }

        public int WinBetId { get; set; }

        public int PlaceBetId { get; set; }

        protected override void BuildResult(ITicket ticket, List<ITicketData> ticketData)
        {
            base.BuildResult(ticket, ticketData);

            BuildResultForWinPlaceType(ticket, ticketData, WinBetId, PlaceBetId);
        }

        public override IRichTextString RenderRTF(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData, bool isShowVNIP, RTFHelper rtfHelper)
        {
            Render(ticket, ticketHelper, ticketData, isShowVNIP);

            BuildResultWinPlaceLRF(rtfHelper);

            BuildResultIpRTF(ticket, ticketHelper, rtfHelper);

            return RTFRender(rtfHelper);
        }

        protected override List<ITicketData> GetReferenceData(ITicket ticket, List<ITicketData> ticketData)
        {
            return ticketData.FindAll(item => item.RefNo.Equals(ticket.RefNo));
        }
    }
}
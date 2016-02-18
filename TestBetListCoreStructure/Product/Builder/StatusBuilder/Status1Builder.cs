namespace BetList.Product.Builder
{
    using System;
    using BetList.Core.Builder;
    using Core.Config;
    using Core.Entity;
    using Core;
    using Core.Render;
    using HTML.Render;

    public class Status1Builder : IBuilder
    {
        public IConfig Config { get; set; }

        public object RenderExcel(ITicket ticket, ITicketHelper ticketHelper, object excelHelper)
        {
            throw new NotImplementedException();
        }

        public string RenderHtml(ITicket ticket, ITicketHelper ticketHelper)
        {
            IElement statusElement = BuildStatusElement(ticket, ticketHelper);
            IRender htmlRender = new HtmlRender();

            return htmlRender.Render(statusElement).ToString();
        }

        private IElement BuildStatusElement(ITicket ticket, ITicketHelper ticketHelper)
        {
            BetListInstanceGetter builder = new BetListInstanceGetter();

            string baseBetTypeId = Config.GetBaseBetTypeId(ticket.BetTypeId.ToString());

            return builder.GetStatusElementInstance(ticket, ticketHelper, baseBetTypeId);
        }
    }
}

namespace BetList.Product.Builder
{
    using BetList.Core;
    using BetList.Core.Entity;
    using BetList.Core.Render;
    using Core.Builder;
    using Core.Config;
    using Excel.Render;
    using HTML.Render;
    using System;

    public class Choice1Builder : IBuilder
    {
        public Choice1Builder()
        {
        }

        public IConfig Config { get; set; }

        public string RenderHtml(ITicket ticket, ITicketHelper ticketHelper)
        {
            IElement choiceElement = BuildChoiceElement(ticket, ticketHelper);
            IRender htmlRender = new HtmlRender();

            return htmlRender.Render(choiceElement).ToString();
        }

        public object RenderExcel(ITicket ticket, ITicketHelper ticketHelper, object excelHelper)
        {
            IElement choiceElement = BuildChoiceElement(ticket, ticketHelper);
            IRender excelRender = new ExcelRender(excelHelper);

            return excelRender.Render(choiceElement);

        }

        private IElement BuildChoiceElement(ITicket ticket, ITicketHelper ticketHelper)
        {
            BetListInstanceGetter builder = new BetListInstanceGetter();

            string baseBetTypeId = Config.GetBaseBetTypeId(ticket.BetTypeId.ToString());

            return builder.GetChoiceElementInstance(ticket, ticketHelper, baseBetTypeId);
        }
    }
}
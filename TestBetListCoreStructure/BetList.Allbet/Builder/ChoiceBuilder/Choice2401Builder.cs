namespace BetList.Product.Builder
{
    using BetList.Core;
    using BetList.Core.Entity;
    using BetList.Core.Render;
    using Core.Builder;
    using Core.Config;
    using HTML.Render;
    using System;

    public class Choice2401Builder : IBuilder
    {
        public Choice2401Builder()
        {
        }

        public IConfig Config { get; set; }

        public string RenderHtml(ITicket ticket, ITicketHelper ticketHelper)
        {
            IElement choiceElement = BuildChoiceElement(ticket, ticketHelper);
            IRender htmlRender = new HtmlRender();

            return htmlRender.Render(choiceElement).ToString();
        }

        private IElement BuildChoiceElement(ITicket ticket, ITicketHelper ticketHelper)
        {
            BetListInstanceGetter builder = new BetListInstanceGetter();

            string baseBetTypeId = Config.GetBaseBetTypeId(ticket.BetTypeId.ToString());

            return builder.GetChoiceElementInstance(ticket, ticketHelper, baseBetTypeId);
        }

        public object RenderExcel(ITicket ticket, ITicketHelper ticketHelper, object excelHelper)
        {
            throw new NotImplementedException();
        }
    }
}
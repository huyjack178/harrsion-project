namespace BetList.Product.Element
{
    using BetList.Core.Entity;

    public class Status1Element : Element
    {
        public Status1Element(ITicket ticket, ITicketHelper ticketHelper)
        {
            BuildStatus(ticket, ticketHelper);
        }

        private void BuildStatus(ITicket ticket, ITicketHelper ticketHelper)
        {
            this.Name = "status";
            this.IsBlock = true;

            BuildResult(ticket, ticketHelper);
            BuildIp(ticket, ticketHelper);
        }

        private void BuildResult(ITicket ticket, ITicketHelper ticketHelper)
        {
            IElement resultElement = new Element();
            resultElement.Name = "result";
            resultElement.IsBlock = true;
            resultElement.Text = ticket.Status;
            this.AddChild(resultElement);
        }

        private void BuildIp(ITicket ticket, ITicketHelper ticketHelper)
        {
            IElement ipElement = new Element();
            ipElement.Name = "ip";
            ipElement.Text = ticket.IP;
            ipElement.IsBlock = true;
            this.AddChild(ipElement);
        }

    }
}

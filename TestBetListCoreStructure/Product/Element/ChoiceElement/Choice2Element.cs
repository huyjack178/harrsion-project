﻿namespace BetList.Product.Element
{
    using BetList.Core.Entity;

    public class Choice2Element : Element
    {
        public Choice2Element(ITicket ticket, ITicketHelper ticketHelper)
        {
            BuildChoice(ticket, ticketHelper);
        }

        private void BuildChoice(ITicket ticket, ITicketHelper ticketHelper)
        {
            this.Name = "choice";
            this.IsBlock = true;

            BuildBetTeam(ticket, ticketHelper);
            BuildBetId(ticket, ticketHelper);
            BuildSportType(ticket, ticketHelper);
            BuildBetType(ticket, ticketHelper);
        }

        private void BuildBetTeam(ITicket ticket, ITicketHelper ticketHelper)
        {
            IElement betTeamElement = new Element();
            betTeamElement.Name = "betTeam";
            betTeamElement.Text = ticket.BetTeam;
            betTeamElement.Formats.Add("color", "#000");
            betTeamElement.IsBlock = true;
            this.AddChild(betTeamElement);
        }

        private void BuildBetId(ITicket ticket, ITicketHelper ticketHelper)
        {
            IElement betIdElement = new Element();
            betIdElement.Name = "betId";
            betIdElement.Text = "BetID: " + ticket.BetId;
            betIdElement.IsBlock = true;
            this.AddChild(betIdElement);
        }

        private void BuildSportType(ITicket ticket, ITicketHelper ticketHelper)
        {
            IElement sportTypeElement = new Element();
            sportTypeElement.Name = "sportType";
            sportTypeElement.Text = ticket.SportTypeId.ToString();
            sportTypeElement.IsBlock = false;
            this.AddChild(sportTypeElement);
        }

        private void BuildBetType(ITicket ticket, ITicketHelper ticketHelper)
        {
            IElement betTypeElement = new Element();
            betTypeElement.Name = "betType";
            betTypeElement.Text = ticket.BetTypeId.ToString();
            betTypeElement.IsBlock = false;
            this.AddChild(betTypeElement);
        }
    }
}
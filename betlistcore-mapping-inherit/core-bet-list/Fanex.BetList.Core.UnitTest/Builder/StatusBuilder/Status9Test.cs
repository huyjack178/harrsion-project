﻿// <auto-generated/>
namespace Fanex.BetList.Core.UnitTest.Builder.StatusBuilder
{
    using Common;
    using Common.Enums;
    using Core.Builder.StatusBuilder;
    using Core.Templates;
    using Entities;
    using NUnit.Framework;
    using Stubs;

    public class Status9Test
    {
        private Status9 _status;
        private ITicket _ticket;
        private ITicketHelper _ticketHelperStub;

        [SetUp]
        public void Setup()
        {
            _status = new Status9();
            _ticket = TestData.CreateTicket(BetTypes.Casino_Games);
            _ticketHelperStub = new TicketHelperStub();
        }

        [Test]
        public void Ticket_RefNoMixParlayOfStatusResultTemplateIsTicketRefNo()
        {
            // Act
            Status_Template template = _status.Render(_ticket, _ticketHelperStub, null, false);

            // Assert
            string expectedValue = _ticket.RefNo;
            Assert.AreEqual(expectedValue, template.StatusResult.refNo_MixParlay);
        }
    }
}
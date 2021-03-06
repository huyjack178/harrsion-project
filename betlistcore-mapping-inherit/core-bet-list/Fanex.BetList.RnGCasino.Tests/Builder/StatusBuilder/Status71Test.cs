﻿// <auto-generated/>

namespace Fanex.BetList.RnGCasino.Tests.Builder.StatusBuilder
{
    using Core.Builder.StatusBuilder;
    using Core.Templates;
    using Core.UnitTest.Common;
    using Core.UnitTest.Common.Enums;
    using Core.UnitTest.Stubs;
    using Fanex.BetList.Core.Entities;
    using NUnit.Framework;

    public class Status71Test
    {
        private Status71 _status;
        private ITicket _ticket;
        private ITicketHelper _ticketHelperStub;

        [SetUp]
        public void Setup()
        {
            _status = new Status71();
            _ticket = TestData.CreateTicket(BetTypes.Casino_Games);
            _ticketHelperStub = new TicketHelperStub();
        }

        [Test]
        public void Ticket_RefNoOfStatusResultTemplateIsTicketRefNo()
        {
            // Act
            Status_Template template = _status.Render(_ticket, _ticketHelperStub, null, false);

            // Assert
            string expectedValue = _ticket.RefNo;
            Assert.AreEqual(expectedValue, template.StatusResult.refNo);
        }
    }
}
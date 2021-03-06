﻿// <auto-generated/>
namespace Fanex.BetList.Core.UnitTest.Builder.OddsBuilder
{
    using Common;
    using Common.Enums;
    using Core.Builder.OddsBuilder;
    using Core.Templates;
    using Entities;
    using NUnit.Framework;
    using Stubs;

    public class Odds1Test
    {
        private Odds1 _odds;
        private ITicket _ticket;
        private ITicketHelper _ticketHelperStub;

        [SetUp]
        public void Setup()
        {
            _odds = new Odds1();
            _ticket = TestData.CreateTicket(BetTypes.Handicap);
            _ticketHelperStub = new TicketHelperStub();
        }

        [Test]
        public void OddsTypeIsNull_OddsTypeIsZero()
        {
            // Arrange
            _ticket.OddsType = null;

            // Act
            Odds_Template template = _odds.Render(_ticket, null, GetCachePropertyByIdStub);

            // Assert
            var expectedOdds = "<font color='#B50000'>-0.73</font>";
            Assert.AreEqual(expectedOdds, template.odds);
        }

        [Test]
        public void OddsTypeIsNull_OddsTypeIsZero1()
        {
            // Arrange
            _ticket.OddsType = "1";

            // Act
            Odds_Template template = _odds.Render(_ticket, null, GetCachePropertyByIdStub);

            // Assert
            var expectedOdds = "0.27";
            Assert.AreEqual(expectedOdds, template.odds);
        }

        [Test]
        public void OddsTypeIsNull_OddsTypeIsZero12()
        {
            // Arrange
            _ticket.OddsType = "1";

            // Act
            Odds_Template template = _odds.Render(_ticket, null, GetCachePropertyByIdStub);

            // Assert
            var expectedOdds = "1";
            Assert.AreEqual(expectedOdds, template.oddsType);
        }

        private string GetCachePropertyByIdStub(object id)
        {
            return id.ToString();
        }
    }
}
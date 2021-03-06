﻿// <auto-generated/>
namespace Fanex.BetList.Core.UnitTest.Builder.ChoiceBuilder
{
    using App_GlobalResources;
    using Common.Enums;
    using Core.Builder.ChoiceBuilder;
    using Entities;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class Choice151Test
    {
        private ITicket _ticket;
        private IChoice _choice;
        private ITicketHelper _ticketHelper;
        private const string BetTeamTemplate = " <span class=\"favorite\">{0}</span>&nbsp;{1} <span class=\"favorite\">&nbsp;{2}</span>";

        [SetUp]
        public void SetUp()
        {
            _ticket = Substitute.For<ITicket>();
            _ticket.BetTypeId = BetTypes._3rd1stHalfDoubleChance;
            _ticketHelper = Substitute.For<ITicketHelper>();
            _choice = new Choice151();
        }

        [Test]
        public void BuildBetTeam_BetTeamIs1x_ShowBetTeamIsHomeTeamNameOrDraw()
        {
            // Arrange
            var homeTeamName = "Home team name";
            _ticket.BetTeam = "1x";
            _ticketHelper.GetTeamNameById(Arg.Any<long>()).Returns(homeTeamName);

            // Act
            _choice.Render(_ticket, _ticketHelper, null, false);

            // Assert
            string expected = string.Format(BetTeamTemplate, _ticketHelper.GetTeamNameById(_ticket.HomeId), CoreBetList.lblOr, CoreBetList.lblDraw);
            Assert.AreEqual(expected, _choice.Template.betTeam);
        }

        [Test]
        public void BuildBetTeam_BetTeamIs2x_ShowBetTeamIsAwayTeamNameOrDraw()
        {
            // Arrange
            var awayTeamName = "Away team name";
            _ticket.BetTeam = "2x";
            _ticketHelper.GetTeamNameById(Arg.Any<long>()).Returns(awayTeamName);

            // Act
            _choice.Render(_ticket, _ticketHelper, null, false);

            // Assert
            string expected = string.Format(BetTeamTemplate, _ticketHelper.GetTeamNameById(_ticket.AwayId), CoreBetList.lblOr, CoreBetList.lblDraw);
            Assert.AreEqual(expected, _choice.Template.betTeam);
        }

        [Test]
        public void BuildBetTeam_BetTeamIs12_ShowBetTeamIsHomeTeamNameOrAwayTeamName()
        {
            // Arrange
            var teamName = "Team name";
            _ticket.BetTeam = "12";
            _ticketHelper.GetTeamNameById(Arg.Any<long>()).Returns(teamName);

            // Act
            _choice.Render(_ticket, _ticketHelper, null, false);

            // Assert
            string homeTeamName = _ticketHelper.GetTeamNameById(_ticket.HomeId);
            string awayTeamName = _ticketHelper.GetTeamNameById(_ticket.AwayId);
            string expected = string.Format(BetTeamTemplate, homeTeamName, CoreBetList.lblOr, awayTeamName);
            Assert.AreEqual(expected, _choice.Template.betTeam);
        }
    }
}
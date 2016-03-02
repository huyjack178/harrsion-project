﻿namespace Fanex.BetList.NumberGame.Test.Builder.ChoiceBuilder
{
    using Core.App_GlobalResources;
    using Core.Builder.ChoiceBuilder;
    using Core.Entities;
    using Core.UnitTest.Common.Enums;
    using NSubstitute;
    using NUnit.Framework;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Choice81Test
    {
        private Choice81 _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;

        [SetUp]
        public void Setup()
        {
            _choice = new Choice81();
            _ticket = Substitute.For<ITicket>();
            _ticket.BetTypeId = BetTypes._1st_Ball_OU;
            _ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void BuildMatch_Always_SetMatchVSBlockIsNull()
        {
            // Act
            var choiceTemplate = _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            Assert.IsNull(choiceTemplate.Match.VS);
        }

        [Test]
        public void BuildBetTeam_BetTeamIsh_SetBetTeamIsOverResource()
        {
            // Arrange
            _ticket.BetTeam = "h";

            // Act
            var choiceTemplate = _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            Assert.AreEqual(CoreBetList.over, choiceTemplate.betTeam);
        }

        [Test]
        public void BuildBetTeam_BetTeamIsNoth_SetBetTeamIsUnderResource()
        {
            // Arrange
            _ticket.BetTeam = "h87898";

            // Act
            var choiceTemplate = _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            Assert.AreEqual(CoreBetList.under, choiceTemplate.betTeam);
        }

        [Test]
        public void BuildBetTeamClassNameAndHandicap_Always_SetBetTeamClassNameIsFavorite()
        {
            // Act
            var choiceTemplate = _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            Assert.AreEqual("favorite", choiceTemplate.betTeamClassName);
        }

        [Test]
        public void BuildBetTeamClassNameAndHandicap_Always_SetHandicapIsAlways37point5()
        {
            // Act
            var choiceTemplate = _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            Assert.AreEqual("37.5", choiceTemplate.Handicap.handicap);
        }

        [Test]
        public void BuildMatch_Always_SetHomeTeamIsJoinedByNumberGameNoResourceAndMatchCode()
        {
            // Arrange
            _ticket.MatchCode = "6969";

            // Act
            var choiceTemplate = _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            Assert.AreEqual(string.Join(null, new string[] { CoreBetList.numbergameno, "&nbsp;", _ticket.MatchCode }), choiceTemplate.Match.homeTeam);
        }
    }
}
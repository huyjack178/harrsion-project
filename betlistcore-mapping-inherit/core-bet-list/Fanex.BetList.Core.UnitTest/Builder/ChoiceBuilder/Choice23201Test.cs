﻿namespace Fanex.BetList.Core.UnitTest.Builder.ChoiceBuilder
{
    using App_GlobalResources;
    using Common.Enums;
    using Core.Builder.ChoiceBuilder;
    using Entities;
    using NSubstitute;
    using NUnit.Framework;

    /// <summary>
    /// Unit test for Choice23201 class.
    /// </summary>
    [TestFixture]
    public class Choice23201Test
    {
        private IChoice _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;

        [SetUp]
        public void Setup()
        {
            _choice = new Choice23201();
            _ticket = Substitute.For<ITicket>();
            _ticket.BetTypeId = BetTypes.BingoTransfer;
            _ticketHelper = Substitute.For<ITicketHelper>();
        }

        /// <summary>
        /// The value of Template.BetType.betTypeName is always null.
        /// </summary>
        [Test]
        public void BuildBetType_Always_SetBetTypeNameIsNull()
        {
            // Act
            _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            Assert.IsNull(_choice.Template.BetType.betTypeName);
        }

        /// <summary>
        /// The value of Template.Match.VS is always null.
        /// </summary>
        [Test]
        public void BuildMatch_Always_SetMatchVSBlockIsNull()
        {
            // Act
            _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            Assert.IsNull(_choice.Template.Match.VS);
        }

        /// <summary>
        /// The value of Template.League.sportTypeName is always null.
        /// </summary>
        [Test]
        public void BuildSport_Always_SetSportTypeNameIsNull()
        {
            // Act
            _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            Assert.IsNull(_choice.Template.League.sportTypeName);
        }

        /// <summary>
        /// The value of Template.Handicap.handicap is always null.
        /// </summary>
        [Test]
        public void BuildBetTeamClassNameAndHandicap_Always_SetHandicapIsNull()
        {
            // Act
            _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            Assert.IsNull(_choice.Template.Handicap.handicap);
        }

        /// <summary>
        /// The value of Template.betTeam is always Bingo -  Transfer.
        /// </summary>
        [Test]
        public void BuildBetTeam_HomeIdNotZero_BetTeamAreBingoTransferResource()
        {
            // Act
            _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            string expectedBetTeam = string.Format("{0} - {1}", CoreBetList.bingo, CoreBetList.transfer);
            Assert.AreEqual(expectedBetTeam, _choice.Template.betTeam);
        }

        /// <summary>
        /// The value of Template.betTeamClassName is always favorite.
        /// </summary>
        [Test]
        public void BuildBetTeamClassNameAndHandicap_Always_SetBetTeamClassNameIsFavorite()
        {
            // Act
            _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            const string CSS_CLASS_FAVORITE = "favorite";
            Assert.AreEqual(CSS_CLASS_FAVORITE, _choice.Template.betTeamClassName);
        }
    }
}
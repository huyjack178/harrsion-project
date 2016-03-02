﻿namespace Fanex.BetList.Core.UnitTest.Builder.ChoiceBuilder
{
    using System;
    using System.Collections.Generic;
    using App_GlobalResources;
    using Common.Enums;
    using Core.Builder.ChoiceBuilder;
    using Core.Templates;
    using Entities;
    using NSubstitute;
    using NUnit.Framework;

    /// <summary>
    ///  Unit testing class for choice bet type 90.
    /// </summary>
    public class Choice90Test
    {
        private static readonly object[] LiveScores =
        {
            // ticket.Live, betId, liveScore
            new object[] { true, null, string.Empty },
            new object[] { true, (long?)1, " [1]" },
            new object[] { false, null, string.Empty },
            new object[] { false,  (long?)2, string.Empty }
        };

        #region betTeamMap

        private static IDictionary<string, string> betTeamMap = new Dictionary<string, string>
                                                                {
                                                                    { "1-1", "1~5" },
                                                                    { "1-2", "6~10" },
                                                                    { "1-3", "11~15" },
                                                                    { "1-4", "16~20" },
                                                                    { "1-5", "21~25" },
                                                                    { "1-6", "26~30" },
                                                                    { "1-7", "31~35" },
                                                                    { "1-8", "36~40" },
                                                                    { "1-9", "41~45" },
                                                                    { "1-10", "46~50" },
                                                                    { "1-11", "51~55" },
                                                                    { "1-12", "56~60" },
                                                                    { "1-13", "61~65" },
                                                                    { "1-14", "66~70" },
                                                                    { "1-15", "71~75" },
                                                                    { "2-1", "1~15" },
                                                                    { "2-2", "16~30" },
                                                                    { "2-3", "31~45" },
                                                                    { "2-4", "46~60" },
                                                                    { "2-5", "61~75" },
                                                                    { "3-1", "1~25" },
                                                                    { "3-2", "26~50" },
                                                                    { "3-3", "51~75" },
                                                                    { "4-1", "1,6,11,16,21,26,31,36,41,46,51,56,61,66,71" },
                                                                    { "4-2", "2,7,12,17,22,27,32,37,42,47,52,57,62,67,72" },
                                                                    { "4-3", "3,8,13,18,23,28,33,38,43,48,53,58,63,68,73" },
                                                                    { "4-4", "4,9,14,19,24,29,34,39,44,49,54,59,64,69,74" },
                                                                    { "4-5", "5,10,15,20,25,30,35,40,45,50,55,60,65,70,75" },
                                                                    { "5-1", "1" },
                                                                    { "5-2", "2" },
                                                                    { "5-3", "3" },
                                                                    { "5-4", "4" },
                                                                    { "5-5", "5" },
                                                                    { "5-6", "6" },
                                                                    { "5-7", "7" },
                                                                    { "5-8", "8" },
                                                                    { "5-9", "9" },
                                                                    { "5-10", "10" },
                                                                    { "5-11", "11" },
                                                                    { "5-12", "12" },
                                                                    { "5-13", "13" },
                                                                    { "5-14", "14" },
                                                                    { "5-15", "15" },
                                                                    { "5-16", "16" },
                                                                    { "5-17", "17" },
                                                                    { "5-18", "18" },
                                                                    { "5-19", "19" },
                                                                    { "5-20", "20" },
                                                                    { "5-21", "21" },
                                                                    { "5-22", "22" },
                                                                    { "5-23", "23" },
                                                                    { "5-24", "24" },
                                                                    { "5-25", "25" },
                                                                    { "5-26", "26" },
                                                                    { "5-27", "27" },
                                                                    { "5-28", "28" },
                                                                    { "5-29", "29" },
                                                                    { "5-30", "30" },
                                                                    { "5-31", "31" },
                                                                    { "5-32", "32" },
                                                                    { "5-33", "33" },
                                                                    { "5-34", "34" },
                                                                    { "5-35", "35" },
                                                                    { "5-36", "36" },
                                                                    { "5-37", "37" },
                                                                    { "5-38", "38" },
                                                                    { "5-39", "39" },
                                                                    { "5-40", "40" },
                                                                    { "5-41", "41" },
                                                                    { "5-42", "42" },
                                                                    { "5-43", "43" },
                                                                    { "5-44", "44" },
                                                                    { "5-45", "45" },
                                                                    { "5-46", "46" },
                                                                    { "5-47", "47" },
                                                                    { "5-48", "48" },
                                                                    { "5-49", "49" },
                                                                    { "5-50", "50" },
                                                                    { "5-51", "51" },
                                                                    { "5-52", "52" },
                                                                    { "5-53", "53" },
                                                                    { "5-54", "54" },
                                                                    { "5-55", "55" },
                                                                    { "5-56", "56" },
                                                                    { "5-57", "57" },
                                                                    { "5-58", "58" },
                                                                    { "5-59", "59" },
                                                                    { "5-60", "60" },
                                                                    { "5-61", "61" },
                                                                    { "5-62", "62" },
                                                                    { "5-63", "63" },
                                                                    { "5-64", "64" },
                                                                    { "5-65", "65" },
                                                                    { "5-66", "66" },
                                                                    { "5-67", "67" },
                                                                    { "5-68", "68" },
                                                                    { "5-69", "69" },
                                                                    { "5-70", "70" },
                                                                    { "5-71", "71" },
                                                                    { "5-72", "72" },
                                                                    { "5-73", "73" },
                                                                    { "5-74", "74" },
                                                                    { "5-75", "75" }
                                                                };

        #endregion betTeamMap

        private Choice90 _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;

        [SetUp]
        public void Setup()
        {
            _choice = new Choice90();
            _ticket = Substitute.For<ITicket>();
            _ticket.BetTypeId = BetTypes.NumberWheel;
            _ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void BuildScore_Always_SetScoreBlockIsNull()
        {
            // Act
            Choice_Template choiceTemplate = _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            Assert.IsNull(choiceTemplate.Score);
        }

        [Test]
        public void BuildMatch_Always_SetMatchVSBlockIsNull()
        {
            // Act
            Choice_Template choiceTemplate = _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            Assert.IsNull(choiceTemplate.Match.VS);
        }

        [Test]
        public void BuildBetTeamClassNameAndHandicap_Always_SetHandicapIsEmpty()
        {
            // Act
            Choice_Template choiceTemplate = _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            Assert.IsNullOrEmpty(choiceTemplate.Handicap.handicap);
        }

        [Test]
        public void BuildBetType_Always_SetBetTypeNameIsNumberGroupResource()
        {
            // Act
            Choice_Template choiceTemplate = _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());
            var actualBetTypeName = choiceTemplate.BetType.betTypeName;

            // Assert
            var expectedBetTypeName = CoreBetList.numberGroup;
            Assert.AreEqual(expectedBetTypeName, actualBetTypeName);
        }

        /// <summary>
        ///  Build choice function always set bet team by combined number game no and match code.
        /// </summary>
        [Test]
        public void BuildMatch_Always_SetHomeTeamIsJoinedByNumberGameNoResourceAndMatchCode()
        {
            // Arrange
            _ticket.MatchCode = "6969";

            // Act
            _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());

            // Assert
            var expectedHomeTeam = string.Join(null, CoreBetList.numbergameno, "&nbsp;", _ticket.MatchCode);
            Assert.AreEqual(expectedHomeTeam, _choice.Template.Match.homeTeam);
        }

        [Test]
        public void BuildBetTeam_Always_SetBetTeamCssClassNameIsFavorite()
        {
            // Act
            Choice_Template choiceTemplate = _choice.Render(_ticket, _ticketHelper, null, Arg.Any<bool>());
            var actualBetTeamCssClass = choiceTemplate.betTeamClassName;

            // Assert
            Assert.AreEqual("favorite", actualBetTeamCssClass);
        }

        /// <summary>
        ///  This function uses test cases resource "live scores" and loop all bet team map to check returned results.
        /// </summary>
        /// <param name="isLive"> Is live ticket.</param>
        /// <param name="betId"> Bet id of ticket.</param>
        /// <param name="liveScore"> Live score status of ticket.</param>
        [Test, TestCaseSource("LiveScores")]
        public void BuildBetTeam_WhenCalled_SetValidNameForBetTeam(bool isLive, long? betId, string liveScore)
        {
            foreach (string key in betTeamMap.Keys)
            {
                // Arrange
                string[] keyValue = key.Split('-');
                _ticket.Handicap1 = Convert.ToDecimal(keyValue[0]);
                _ticket.BetId = betId;
                _ticket.IsLive = isLive;
                _ticket.BetTeam = keyValue[1];

                // Act
                _choice.Render(_ticket, _ticketHelper, null, false);

                // Assert
                Assert.AreEqual(string.Join(null, betTeamMap[key], liveScore), _choice.Template.betTeam);

                // re-setup
                Setup();
            }
        }
    }
}
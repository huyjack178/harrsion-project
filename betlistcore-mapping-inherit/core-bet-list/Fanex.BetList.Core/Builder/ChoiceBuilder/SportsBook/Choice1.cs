namespace Fanex.BetList.Core.Builder.ChoiceBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Constants;
    using Core.App_GlobalResources;
    using Entities;
    using NPOI.SS.UserModel;
    using Templates;
    using Utils;

    /// <summary>
    /// Bet type name: Handicap.
    /// </summary>
    public class Choice1 : BaseChoiceBuilder
    {

        private const string VoidStatus = "void";
        private const string RejectStatus = "reject";
        private const string RefundStatus = "refund";
        private const string FirstGoalCssClass = "firstGoal ";
        private const string LastGoalCssClass = "lastGoal";
        private const string FirstHalfFirstGoalCssClass = "fhFirstGoal";
        private const string FirstHalfLastGoalCssClass = "fhLastGoal";
        private const string Space = " ";
        private const string FirstGoalTextName = "(F)";
        private const string LastGoalTextName = "(L)";
        private const string FirstHalfFirstGoalTextName = "(1F)";
        private const string FirstHalfLastGoalTextName = "(1L)";
        private const string BetStatusFl = "fl";
        private const string BetStatus1Fl = "1fl";
        private const int MuayThaiSportId = 44;
        private const int HandicapBetTypeId = 1;

        #region Common utils

        protected virtual string GetHomeTeamName(ITicket ticket, ITicketHelper ticketHelper)
        {
            string homeTeamName = ticketHelper.GetTeamNameById(ticket.HomeId);
            string neutral = string.Format(" {0} ", CoreBetList.Neutral);
            homeTeamName = string.Join(null, new string[] { homeTeamName, ticket.IsNeutral ? neutral : string.Empty });

            return homeTeamName;
        }

        /// <summary>
        /// Calculates the (F) (L) (1F) (1L) label.
        /// </summary>
        /// <param name="betStatus">The bet status.
        /// <![CDATA[Refund HT;1FL:1-2;FL:2-0]]>
        /// <![CDATA[1FL:1-2;FL:2-0]]>
        /// <![CDATA[Refund HT;FL:2-0]]>
        /// <![CDATA[Refund HT;1FL:1-2]]>
        /// <![CDATA[FL:2-0]]>
        /// <![CDATA[Refund HT]]>
        /// <![CDATA[1FL:1-2]]>
        /// </param>
        /// <param name="homeFGLG">The home FGLG.</param>
        /// <param name="awayFGLG">The away FGLG.</param>
        protected virtual void BuildFGLGLabel(string betStatus, ref string homeFGLG, ref string awayFGLG)
        {
            if (string.IsNullOrWhiteSpace(betStatus))
            {
                return;
            }

            string[] betStatusParts = betStatus.ToLower().Split(';');

            string[] fglg = GetBetStatusPart(betStatusParts, BetStatusFl);
            CalculateFGLGLabel(FirstGoalCssClass, LastGoalCssClass, fglg, ref homeFGLG, ref awayFGLG);

            string[] fhfglg = GetBetStatusPart(betStatusParts, BetStatus1Fl);
            CalculateFGLGLabel(FirstHalfFirstGoalCssClass, FirstHalfLastGoalCssClass, fhfglg, ref homeFGLG, ref awayFGLG);

            if (!string.IsNullOrEmpty(homeFGLG))
            {
                homeFGLG = string.Join(null, new string[] { HtmlCharacters.NoneBreakingSpace, homeFGLG });
            }

            if (!string.IsNullOrEmpty(awayFGLG))
            {
                awayFGLG = string.Join(null, new string[] { HtmlCharacters.NoneBreakingSpace, awayFGLG });
            }
        }

        /// <summary>
        /// Updates all match member to null.
        /// </summary>
        protected void UpdateAllMatchMemberToNull()
        {
            if (Template.Match == null)
            {
                return;
            }

            Template.Match.homeTeam = null;
            Template.Match.awayTeam = null;
            Template.Match.VS = null;
            Template.Match.home_firstGoal_lastGoal = null;
            Template.Match.away_firstGoal_lastGoal = null;
        }

        #endregion Common utils

        #region Build Html Block

        protected override void BuildBetTeam(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            var awayTeamName = ticketHelper.GetTeamNameById(ticket.AwayId);
            var homeTeamName = GetHomeTeamName(ticket, ticketHelper);

            var isBetHomeTeam = IsBetHomeTeam(ticket);
            Template.betTeam = isBetHomeTeam ? homeTeamName : awayTeamName;
        }

        protected override void BuildBetTeamClassNameAndHandicap(ITicket ticket)
        {
            var isBetHomeTeam = IsBetHomeTeam(ticket);

            string betTeamClassName;

            if (isBetHomeTeam)
            {
                betTeamClassName = ticket.Handicap2 >= ticket.Handicap1 ? Underdog : Favorite;
            }
            else
            {
                betTeamClassName = ticket.Handicap2 <= ticket.Handicap1 ? Underdog : Favorite;
            }

            Template.betTeamClassName = betTeamClassName;

            ChangeClassNameWhenSportIsMauyThai(ticket.SportTypeId, ticket.BetTypeId, isBetHomeTeam);

            decimal handicap = ticket.Handicap2 > ticket.Handicap1 ? ticket.Handicap2 : ticket.Handicap1;

            handicap = betTeamClassName == Favorite ? -handicap : handicap;

            Template.Handicap.handicap = ConvertByBetType.Hdp(handicap);
        }
        private void ChangeClassNameWhenSportIsMauyThai(int sportId, int betTypeId, bool isBetHomeTeam)
        {
            if (sportId == MuayThaiSportId
                && betTypeId == HandicapBetTypeId)
            {
                Template.betTeamClassName = Favorite;

                if (!isBetHomeTeam)
                {
                    Template.betTeamClassName += " light-blue";
                }
            }
        }

        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            if (Template.Match == null)
            {
                return;
            }

            Template.Match.homeTeam = GetHomeTeamName(ticket, ticketHelper);
            Template.Match.awayTeam = ticketHelper.GetTeamNameById(ticket.AwayId);

            Template.Match.home_firstGoal_lastGoal = string.Empty;
            Template.Match.away_firstGoal_lastGoal = string.Empty;
            BuildFGLGLabel(ticket.EventStatus, ref Template.Match.home_firstGoal_lastGoal, ref Template.Match.away_firstGoal_lastGoal);
        }

        #endregion Build Html Block

        protected bool IsBetHomeTeam(ITicket ticket)
        {
            bool betHomeTeam = ticket.BetTeam != null && ticket.BetTeam.ToLowerInvariant().Contains(BetTeamValue.H);

            return betHomeTeam;
        }
    }
}
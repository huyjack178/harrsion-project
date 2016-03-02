﻿namespace Fanex.BetList.Core.Entities
{
    using System;

    /// <summary>
    /// Ticket data interface.
    /// </summary>
    public interface ITicket
    {
        int SportTypeId { get; set; }

        string UserName { get; set; }

        long TransId { get; set; }

        long? BetId { get; set; }

        int BetTypeId { get; set; }

        decimal Handicap1 { get; set; }

        decimal Handicap2 { get; set; }

        decimal MasterOdds { get; set; }

        string OddsType { get; set; }

        decimal Odds { get; set; }

        decimal Stake { get; set; }

        decimal ActualStake { get; set; }

        string BetTeam { get; set; }

        string Status { get; set; }

        int? StatusId { get; set; }

        string RefNo { get; set; }

        DateTime TransDate { get; set; }

        DateTime WinlostDate { get; set; }

        decimal Winlost { get; set; }

        decimal AgentWinlost { get; set; }

        decimal MasterWinlost { get; set; }

        decimal SuperWinlost { get; set; }

        decimal PlayerComm { get; set; }

        decimal Comm { get; set; }

        decimal AgentComm { get; set; }

        decimal SuperComm { get; set; }

        decimal AgentPositionTaking { get; set; }

        decimal MasterPositionTaking { get; set; }

        decimal SuperPositionTaking { get; set; }

        decimal AgentDiscount { get; set; }

        decimal MasterDiscount { get; set; }

        decimal SuperDiscount { get; set; }

        bool IsLive { get; set; }

        int LiveHomeScore { get; set; }

        int LiveAwayScore { get; set; }

        string IP { get; set; }

        int LeagueId { get; set; }

        int MatchId { get; set; }

        string MatchCode { get; set; }

        string Race { get; set; }

        long HomeId { get; set; }

        long AwayId { get; set; }

        string EventStatus { get; set; }

        bool IsNeutral { get; set; }

        long CustId { get; set; }

        string ShowTime { get; set; }

        string BetCheck { get; set; }

        string CommStatus { get; set; }

        DateTime EventDate { get; set; }

        string TransDesc { get; set; }

        decimal OddsSpread { get; set; }
    }
}
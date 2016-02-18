﻿namespace BetList.Core.Entity
{
    using System;

    public class Ticket : ITicket
    {
        #region ITicket Members

        public int SportTypeId { get; set; }

        public string UserName { get; set; }

        public long TransId { get; set; }

        public long? BetId { get; set; }

        public int BetTypeId { get; set; }

        public decimal Handicap1 { get; set; }

        public decimal Handicap2 { get; set; }

        public decimal MasterOdds { get; set; }

        public string OddsType { get; set; }

        public decimal Odds { get; set; }

        public decimal Stake { get; set; }

        public decimal ActualStake { get; set; }

        public string BetTeam { get; set; }

        public string Status { get; set; }

        public int? StatusId { get; set; }

        public string RefNo { get; set; }

        public DateTime TransDate { get; set; }

        public DateTime WinlostDate { get; set; }

        public decimal Winlost { get; set; }

        public decimal AgentWinlost { get; set; }

        public decimal MasterWinlost { get; set; }

        public decimal SuperWinlost { get; set; }

        public decimal PlayerComm { get; set; }

        public decimal Comm { get; set; }

        public decimal AgentComm { get; set; }

        public decimal SuperComm { get; set; }

        public decimal AgentPositionTaking { get; set; }

        public decimal MasterPositionTaking { get; set; }

        public decimal SuperPositionTaking { get; set; }

        public decimal AgentDiscount { get; set; }

        public decimal MasterDiscount { get; set; }

        public decimal SuperDiscount { get; set; }

        public bool IsLive { get; set; }

        public int LiveHomeScore { get; set; }

        public int LiveAwayScore { get; set; }

        public string IP { get; set; }

        public int LeagueId { get; set; }

        public int MatchId { get; set; }

        public string MatchCode { get; set; }

        public string Race { get; set; }

        public long HomeId { get; set; }

        public long AwayId { get; set; }

        public string EventStatus { get; set; }

        public bool IsNeutral { get; set; }

        public long CustId { get; set; }

        public string ShowTime { get; set; }

        public string BetCheck { get; set; }

        public string CommStatus { get; set; }

        public DateTime EventDate { get; set; }

        public string TransDesc { get; set; }

        public decimal OddsSpread { get; set; }

        #endregion ITicket Members
    }
}
﻿//<auto-generated/>
// ---------------------------------------------------------------------------------
// <copyright file="TicketsExcelDAO.cs" company="Nexcel Solutions Vietnam">
//     Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
// <history>
//     <change who="Marc.Bui" date="2014.02.11">Create</change>
// </history>
// ---------------------------------------------------------------------------------

namespace Fanex.BetList.Example.Data
{
    using Fanex.BetList.Core.Entities;
    using NPOI.HSSF.UserModel;
    using NPOI.POIFS.FileSystem;
    using NPOI.SS.UserModel;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;

    /// <summary>
    /// Class TicketsExcelDAO.
    /// </summary>
    public class TicketsExcelDAO : ITicketsDAO
    {
        private string _dashboardFile;
        private IWorkbook _workbook;
        private IFormulaEvaluator _formulaEvaluator;
        private DataFormatter _dataFormatter;

        public TicketsExcelDAO(string filePath)
        {
            _dashboardFile = filePath;
        }

        /// <summary>
        /// Gets the tickets.
        /// </summary>
        /// <returns>List of ITicket.</returns>
        public IList<ITicket> GetTickets()
        {
            this.LazyLoadWorkbook();

            ISheet betTicketSheet = _workbook.GetSheet("BetTickets");

            IList<ITicket> tickets = new List<ITicket>();

            if (betTicketSheet != null)
            {
                // Remove header row
                betTicketSheet.RemoveRow(betTicketSheet.GetRow(0));

                foreach (IRow row in betTicketSheet)
                {
                    ITicket ticket = this.MapRowToTicketObject(row);
                    if (ticket != null)
                    {
                        tickets.Add(ticket);
                    }
                }
            }

            return tickets;
        }

        /// <summary>
        /// Gets the ticket data.
        /// </summary>
        /// <returns>List of ITicketData.</returns>
        public IList<ITicketData> GetTicketData()
        {
            this.LazyLoadWorkbook();

            ISheet ticketDataSheet = _workbook.GetSheet("ReferenceData");

            IList<ITicketData> ticketData = new List<ITicketData>();

            if (ticketDataSheet != null)
            {
                // Remove header row
                ticketDataSheet.RemoveRow(ticketDataSheet.GetRow(0));

                foreach (IRow row in ticketDataSheet)
                {
                    ITicketData data = this.MapRowToTicketDataObject(row);
                    if (data != null)
                    {
                        ticketData.Add(data);
                    }
                }
            }

            return ticketData;
        }

        /// <summary>
        /// Maps the row to ticket data object.
        /// </summary>
        /// <param name="row">The IRow object.</param>
        /// <returns>ITicketData object.</returns>
        private ITicketData MapRowToTicketDataObject(IRow row)
        {
            try
            {
                ITicketData data = new TicketData();

                data.AgentPT = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketDataTemplateColumnIndex.AgentPT)));
                data.BetTeam = this.GetCellValue(row.GetCell((int)TicketDataTemplateColumnIndex.BetTeam));
                data.BetTypeId = Convert.ToInt32(this.GetCellValue(row.GetCell((int)TicketDataTemplateColumnIndex.BetTypeId)));
                data.MasterPT = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketDataTemplateColumnIndex.MasterPT)));
                data.Odds = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketDataTemplateColumnIndex.Odds)));
                data.RefNo = this.GetCellValue(row.GetCell((int)TicketDataTemplateColumnIndex.RefNo));
                data.Stake = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketDataTemplateColumnIndex.Stake)));
                data.Status = this.GetCellValue(row.GetCell((int)TicketDataTemplateColumnIndex.Status));
                data.SuperPT = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketDataTemplateColumnIndex.SuperPT)));
                data.TransDesc = this.GetCellValue(row.GetCell((int)TicketDataTemplateColumnIndex.TransDesc));

                return data;
            }
            catch
            {
            }

            return null;
        }

        /// <summary>
        /// Lazily the load workbook.
        /// </summary>
        private void LazyLoadWorkbook()
        {
            // Check to lazily initialize workbook object
            if (_workbook == null)
            {
                // Check if file path is valid
                if (!string.IsNullOrWhiteSpace(_dashboardFile))
                {
                    _workbook = this.LoadWorkbook(_dashboardFile);
                    _formulaEvaluator = new HSSFFormulaEvaluator(_workbook);
                    _dataFormatter = new HSSFDataFormatter(new CultureInfo("en-US"));
                }
            }
        }

        /// <summary>
        /// Maps the row to ticket object.
        /// </summary>
        /// <param name="row">The IRow object.</param>
        /// <returns>ITicket object.</returns>
        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules", "SP2101:MethodMustNotContainMoreLinesThan", Justification = "Reviewed. Suppression is OK here.")]
        private ITicket MapRowToTicketObject(IRow row)
        {
            try
            {
                ITicket ticket = new Ticket();

                ticket.ActualStake = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.ActualStake)));
                ticket.AgentComm = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.AgentComm)));
                ticket.AgentDiscount = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.AgentDiscount)));
                ticket.AgentPositionTaking = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.AgentPositionTaking)));
                ticket.AgentWinlost = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.AgentWinlost)));
                ticket.AwayId = Convert.ToInt64(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.AwayId)));
                ticket.BetCheck = this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.BetCheck));
                ticket.BetId = Convert.ToInt64(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.BetId)));
                ticket.BetTeam = this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.BetTeam));
                ticket.BetTypeId = Convert.ToInt32(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.BetTypeId)));
                ticket.Comm = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.Comm)));
                ticket.CommStatus = this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.CommStatus));
                ticket.CustId = Convert.ToInt64(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.CustId)));
                ticket.EventDate = Convert.ToDateTime(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.EventDate)));
                ticket.EventStatus = this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.EventStatus));
                ticket.Handicap1 = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.Handicap1)));
                ticket.Handicap2 = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.Handicap2)));
                ticket.HomeId = Convert.ToInt64(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.HomeId)));
                ticket.IP = this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.IP));
                ticket.IsLive = Convert.ToBoolean(Convert.ToInt32(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.IsLive))));
                ticket.IsNeutral = Convert.ToBoolean(Convert.ToInt32(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.IsNeutral))));
                ticket.LeagueId = Convert.ToInt32(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.LeagueId)));
                ticket.LiveAwayScore = Convert.ToInt32(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.LiveAwayScore)));
                ticket.LiveHomeScore = Convert.ToInt32(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.LiveHomeScore)));
                ticket.MasterDiscount = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.MasterDiscount)));
                ticket.MasterOdds = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.MasterOdds)));
                ticket.MasterPositionTaking = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.MasterPositionTaking)));
                ticket.MasterWinlost = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.MasterWinlost)));
                ticket.MatchCode = this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.MatchCode));
                ticket.MatchId = Convert.ToInt32(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.MatchId)));
                ticket.Odds = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.Odds)));
                ticket.OddsType = this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.OddsType));
                ticket.PlayerComm = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.PlayerComm)));
                ticket.Race = this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.Race));
                ticket.RefNo = this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.RefNo));
                ticket.ShowTime = this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.ShowTime));
                ticket.SportTypeId = Convert.ToInt32(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.SportTypeId)));
                ticket.Stake = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.Stake)));
                ticket.Status = this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.Status));
                ticket.SuperComm = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.SuperComm)));
                ticket.SuperDiscount = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.SuperDiscount)));
                ticket.SuperPositionTaking = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.SuperPositionTaking)));
                ticket.SuperWinlost = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.SuperWinlost)));
                ticket.TransDate = Convert.ToDateTime(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.TransDate)));
                ticket.TransId = Convert.ToInt64(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.TransId)));
                ticket.UserName = this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.UserName));
                ticket.Winlost = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.Winlost)));
                ticket.WinlostDate = Convert.ToDateTime(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.WinlostDate)));
                ticket.TransDesc = this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.TransDesc));

                try
                {
                    ticket.OddsSpread = Convert.ToDecimal(this.GetCellValue(row.GetCell((int)TicketTemplateColumnIndex.OddsSpread)));
                }
                catch
                {
                }

                return ticket;
            }
            catch
            {
            }

            return null;
        }

        /// <summary>
        /// Loads the workbook.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>IWorkbook object.</returns>
        private IWorkbook LoadWorkbook(string filePath)
        {
            try
            {
                using (StreamReader input = new StreamReader(filePath))
                {
                    IWorkbook workbook = new HSSFWorkbook(new POIFSFileSystem(input.BaseStream));

                    return workbook;
                }
            }
            catch
            {
                throw;
            }
        }

        private string GetCellValue(ICell cell)
        {
            return NPOIUtil.GetValue(cell, _dataFormatter, _formulaEvaluator);
        }
    }
}
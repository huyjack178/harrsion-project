using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fanex.BetList.Core.Entities;
using Fanex.BetList.Core.Templates;
using NPOI.SS.UserModel;
using Fanex.BetList.Core.App_GlobalResources;
using System.Globalization;
using Fanex.BetList.Core.Utils;

namespace Fanex.BetList.Core.Builder.StatusBuilder
{
    public class BaseStatusBuilder : IStatus
    {
        public BaseStatusBuilder()
        {
            Template = new Status_Template();
        }

        public Status_Template Template { get; set; }

        public virtual Status_Template Render(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData, bool isShowVNIP)
        {
            BuildResult(ticket, ticketData);

            BuildStatusResult(ticket);

            BuildIP(ticket, ticketHelper, isShowVNIP);

            return Template;
        }

        /// <summary>
        /// Renders the RTF.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="ticketHelper">The ticket helper.</param>
        /// <param name="ticketData">The ticket data.</param>
        /// <param name="isShowVNIP">If set to <c>true</c> [VNIP is shown].</param>
        /// <param name="rtfHelper">The RTF helper.</param>
        /// <returns>IRichTextString represents the Status block.</returns>
        public virtual IRichTextString RenderRTF(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData, bool isShowVNIP, RTFHelper rtfHelper)
        {
            Render(ticket, ticketHelper, ticketData, isShowVNIP);

            string status = Template.result;

            BuildResultLRF(status, rtfHelper);

            BuildResultIpRTF(ticket, ticketHelper, rtfHelper);

            return RTFRender(rtfHelper);
        }

        protected virtual void BuildResultLRF(string status, RTFHelper rtfHelper)
        {
            rtfHelper.RTFRenderer.AddText(status, rtfHelper.PosFont);
        }

        protected virtual void BuildResultIpRTF(ITicket ticket, ITicketHelper ticketHelper, RTFHelper rtfHelper)
        {
            string status = Template.result;

            if (Template.ShowIP != null && Template.ShowIP.Visible)
            {
                status = string.Join(null, new string[] { "\n", Template.ShowIP.betIp });
                rtfHelper.RTFRenderer.AddText(status);
            }
        }
      
        protected virtual IRichTextString RTFRender(RTFHelper rtfHelper)
        {
            IRichTextString rtfStatus = rtfHelper.RTFRenderer.Render();
            rtfHelper.RTFRenderer.Clear();

            return rtfStatus;
        }

        /// <summary>
        /// Build Result string for Win/Place betType
        /// </summary>
        /// <param name="rtfHelper"></param>
        protected virtual void BuildResultWinPlaceLRF(RTFHelper rtfHelper)
        {
            // Status != Win/Lose
            if (Template.result.Length < 80)
            {
                rtfHelper.RTFRenderer.AddText(Template.result, rtfHelper.PosFont);
            }
            else
            {
                int breakPos = Template.result.IndexOf("<br/>");

                string status_WinString = Template.result.Substring(0, breakPos);
                string status_PlaceString = Template.result.Replace(status_WinString, string.Empty);

                string status_Win = ExtractStringBetweenTag("b", status_WinString);
                string status_Place = ExtractStringBetweenTag("b", status_PlaceString);
                string[] status = new string[] { CoreBetList.win, ": ", status_Win, "\n", CoreBetList.place, ": ", status_Place };
                rtfHelper.RTFRenderer.AddText(string.Join(null, status), rtfHelper.PosFont);
            }
        }

        private string ExtractStringBetweenTag(string tag, string source)
        {
            string startTag = string.Join(null, new string[] { "<", tag, ">" });
            string endTag = string.Join(null, new string[] { "</", tag, ">" });

            int startIndex = source.IndexOf(startTag) + startTag.Length;
            int endIndex = source.IndexOf(endTag, startIndex);
            return source.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// Gets the result string.
        /// </summary>
        /// <param name="ticketStatus">The ticket status.</param>
        /// <returns>System.String: result.</returns>
        protected static string GetResultString(string ticketStatus)
        {
            string result = string.Empty;

            switch (ticketStatus.ToLower())
            {
                case BetStatus.Running:
                    result = CoreBetList.running;
                    break;

                case BetStatus.Reject:
                    result = CoreBetList.reject;
                    break;

                case BetStatus.Won:
                    result = CoreBetList.won;
                    break;

                case BetStatus.Lose:
                    result = CoreBetList.lose;
                    break;

                case BetStatus.Draw:
                    result = CoreBetList.draw;
                    break;

                case BetStatus.Waiting:
                    result = CoreBetList.waiting;
                    break;

                case BetStatus.Void:
                    result = CoreBetList.voided;
                    break;

                case BetStatus.Refund:
                    result = CoreBetList.refund;
                    break;
            }

            return result;
        }

        protected virtual void BuildResult(ITicket ticket, List<ITicketData> ticketData)
        {
            BuildResultDefault(ticket);
        }

        /// <summary>
        /// Builds the status result.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        protected virtual void BuildStatusResult(ITicket ticket)
        {
            var result = ticket.Status.ToLower(CultureInfo.InvariantCulture);

            if (result.Equals(BetStatus.Running)
                || result.Equals(BetStatus.Waiting)
                || result.Equals(BetStatus.Void)
                || result.Equals(BetStatus.Reject)
                || result.Equals(BetStatus.Refund))
            {
                Template.StatusResult.Hide();
            }
            else
            {
                Template.StatusResult.matchId = ticket.MatchId.ToString(CultureInfo.InvariantCulture);
                Template.StatusResult.betType = ticket.BetTypeId.ToString(CultureInfo.InvariantCulture);
                Template.StatusResult.race = string.IsNullOrEmpty(ticket.Race) ? "0" : ticket.Race;
                Template.StatusResult.refNo = ticket.TransId.ToString(CultureInfo.InvariantCulture);
                Template.StatusResult.sportType = ticket.SportTypeId.ToString(CultureInfo.InvariantCulture);
                Template.StatusResult.league = ticket.LeagueId.ToString(CultureInfo.InvariantCulture);
                Template.StatusResult.userName = ticket.UserName;
                Template.StatusResult.winlostDate = Formatter.FullDateFormat(ticket.WinlostDate);
            }
        }

        /// <summary>
        /// Builds the IP.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="ticketHelper">The ticket helper.</param>
        /// <param name="isShowVNIP">If set to <c>true</c> [is show VNIP].</param>
        protected virtual void BuildIP(ITicket ticket, ITicketHelper ticketHelper, bool isShowVNIP)
        {
            if (isShowVNIP)
            {
                Template.ShowIP.betIp = ticket.IP;
            }
            else
            {
                if (ticketHelper.IsVnIp(ticket.IP))
                {
                    Template.ShowIP.Hide();
                }
                else
                {
                    Template.ShowIP.betIp = ticket.IP;
                }
            }
        }

        private void BuildResultDefault(ITicket ticket)
        {
            Template.result = ticket.Status.ToLower(CultureInfo.InvariantCulture);
            string result = GetResultString(ticket.Status);

            if (!string.IsNullOrEmpty(result))
            {
                Template.result = result;
            }
        }

        protected virtual void BuildResultForWinPlaceType(ITicket ticket, List<ITicketData> ticketData, int winId, int placeId)
        {
            // Custom Status generated from base class if ticketData has matched items for the current ticket
            if (ticketData != null && ticketData.Count > 0)
            {
                List<ITicketData> foundTicketData = GetReferenceData(ticket, ticketData);

                if (foundTicketData != null && foundTicketData.Count > 1)
                {
                    string winStatus = foundTicketData.Find(item => item.BetTypeId == winId).Status.ToLower();
                    string placeStatus = foundTicketData.Find(item => item.BetTypeId == placeId).Status.ToLower();

                    string contextWinStatus = GetResultString(winStatus);
                    string contextPlaceStatus = GetResultString(placeStatus);

                    string[] tmpWinStatus = new string[] { "<span class='blue' style='font-weight:normal;'>", CoreBetList.win, ": ", "<b>", contextWinStatus, "</b>", "</span>" };

                    string winStatusMarkup = string.Join(null, tmpWinStatus);

                    string[] tmpPlaceStatus = new string[] { "<span class='' style='font-weight:normal;'>", CoreBetList.place, ": ", "<b>", contextPlaceStatus, "</b>", "</span>" };

                    string placeStatusMarkup = string.Join(null, tmpPlaceStatus);

                    string ticketBetStatus = ticket.Status.ToLower(CultureInfo.InvariantCulture);

                    switch (ticketBetStatus)
                    {
                        case BetStatus.Running:
                        case BetStatus.Waiting:
                        case BetStatus.Void:
                        case BetStatus.Reject:
                        case BetStatus.Refund:
                            break;

                        default:
                            Template.result = string.Join(null, new string[] { winStatusMarkup, "<br/>", placeStatusMarkup });
                            break;
                    }
                }
            }
        }

        protected virtual List<ITicketData> GetReferenceData(ITicket ticket, List<ITicketData> ticketData)
        {
            return ticketData.FindAll(item => item.RefNo.Equals(ticket.TransId.ToString()));
        }

    }
}
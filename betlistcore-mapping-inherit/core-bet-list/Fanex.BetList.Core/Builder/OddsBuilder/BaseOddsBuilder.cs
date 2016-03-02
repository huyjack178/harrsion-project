using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fanex.BetList.Core.Entities;
using Fanex.BetList.Core.Templates;
using NPOI.SS.UserModel;
using Fanex.BetList.Core.Utils;
using Fanex.BetList.Core.App_GlobalResources;
using NPOI.HSSF.UserModel;

namespace Fanex.BetList.Core.Builder.OddsBuilder
{
    public class BaseOddsBuilder : IOdds
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseOddsBuilder" /> class.
        /// </summary>
        public BaseOddsBuilder()
        {
            Template = new Odds_Template();
        }

        public Odds_Template Template { get; set; }

        public virtual Odds_Template Render(ITicket ticket, List<ITicketData> ticketData, GetCachePropertyById funcGetOddsTypeName)
        {
            BuildOddsDefault(ticket, ticketData, funcGetOddsTypeName);

            return Template;
        }

        protected virtual void BuildOddsDefault(ITicket ticket, List<ITicketData> ticketData, GetCachePropertyById funcGetOddsTypeName)
        {
            object oddsType = string.IsNullOrEmpty(ticket.OddsType) ? (object)0 : ticket.OddsType;

            Template.odds = ConvertByBetType.Odds(ticket.Odds, ticket.BetTypeId, oddsType);
            Template.oddsType = funcGetOddsTypeName(ConvertByBetType.OddsType(ticket.BetTypeId, oddsType));
        }

        protected virtual void BuildOddsWinPlace(ITicket ticket, List<ITicketData> ticketData, GetCachePropertyById funcGetOddsTypeName, int winId, int placeId)
        {
            if (ticketData != null && ticketData.Count > 0)
            {
                List<ITicketData> foundTicketData = GetReferenceData(ticket, ticketData);

                if (foundTicketData != null && foundTicketData.Count > 1)
                {
                    ITicketData winTicket = foundTicketData.Find(item => item.BetTypeId == winId);
                    ITicketData placeTicket = foundTicketData.Find(item => item.BetTypeId == placeId);

                    string oddsWin = Formatter.FormatNumber3(winTicket.Odds);
                    string oddsPlace = Formatter.FormatNumber3(placeTicket.Odds);

                    var oddsWinMarkup = string.Join(null, new string[] { CoreBetList.win, ": ", "<b>", oddsWin, "</b>" });
                    var oddsPlaceMarkup = string.Join(null, new string[] { CoreBetList.place, ": ", "<b>", oddsPlace, "</b>" });

                    var oddsWinContent = string.Join(null, new string[] { "<span class='blue' style='font-weight:normal;'>", oddsWinMarkup, "</span>" });
                    var oddsPlaceContent = string.Join(null, new string[] { "<span class='' style='font-weight:normal;'>", oddsPlaceMarkup, "</span>" });

                    Template.odds = string.Join(null, new string[] { oddsWinContent, "<br>", oddsPlaceContent });
                }
                else
                {
                    Template.odds = "-";
                }
            }
            else
            {
                Template.odds = "-";
            }

            Template.oddsType = funcGetOddsTypeName(ConvertByBetType.OddsType(ticket.BetTypeId, ticket.OddsType));
        }

        protected virtual List<ITicketData> GetReferenceData(ITicket ticket, List<ITicketData> ticketData)
        {
            return ticketData.FindAll(item => item.RefNo.Equals(ticket.TransId.ToString()));
        }

        private string GetOddsWin(ITicketData winTicket)
        {
            string winStatus = winTicket.Status.ToLower();
            string oddsWin;

            if (!winStatus.Equals(BetStatus.Won)
                && !winStatus.Equals(BetStatus.Lose))
            {
                oddsWin = "-";
            }
            else
            {
                oddsWin = Formatter.FormatNumber3(winTicket.Odds);
            }

            return oddsWin;
        }

        /// <summary>
        /// Gets the odds place.
        /// </summary>
        /// <param name="placeTicket">The place ticket.</param>
        /// <returns>Odds of place.</returns>
        private string GetOddsPlace(ITicketData placeTicket)
        {
            string placeStatus = placeTicket.Status.ToLower();

            string oddsPlace;

            if (!placeStatus.Equals(BetStatus.Won)
                && !placeStatus.Equals(BetStatus.Lose))
            {
                oddsPlace = "-";
            }
            else
            {
                oddsPlace = Formatter.FormatNumber3(placeTicket.Odds);
            }

            return oddsPlace;
        }

        public virtual IRichTextString RenderRTF(ITicket ticket, List<ITicketData> ticketData, GetCachePropertyById funcGetOddsTypeName, RTFHelper rtfHelper)
        {
            Render(ticket, ticketData, funcGetOddsTypeName);
            var rtfOdds = BuildRTFOdds(rtfHelper);

            return rtfOdds;
        }

        /// <summary>
        /// Builds the RTF odds.
        /// </summary>
        /// <param name="rtfHelper">The RTF helper.</param>
        /// <returns>IRichTextString represents excel-formatted Odds string.</returns>
        protected virtual IRichTextString BuildRTFOdds(RTFHelper rtfHelper)
        {
            string odds = Template.odds;

            var rtfNumberRenderer = new RTFNumber(rtfHelper.RTFRenderer, rtfHelper.PosFont, rtfHelper.NegFont);

            rtfNumberRenderer.Render(odds);

            if (!string.IsNullOrEmpty(Template.oddsType))
            {
                odds = "\n" + Template.oddsType;
                rtfHelper.RTFRenderer.AddText(odds, rtfHelper.PosFont);
            }

            var rtfOdds = rtfHelper.RTFRenderer.Render();
            rtfHelper.RTFRenderer.Clear();
            return rtfOdds;
        }

        protected virtual IRichTextString BuildRTFOddsWinPlace(RTFHelper rtfHelper)
        {
            if (Template.odds == "-")
            {
                return new HSSFRichTextString("-");
            }

            int breakPos = Template.odds.IndexOf("<br>");

            string oddsWinString = Template.odds.Substring(0, breakPos);
            string oddsPlaceString = Template.odds.Replace(oddsWinString, string.Empty);

            string oddsWinVal = ExtractStringBetweenTag("b", oddsWinString);
            string oddsPlaceVal = ExtractStringBetweenTag("b", oddsPlaceString);

            var rtfNumberRenderer = new RTFNumber(rtfHelper.RTFRenderer, rtfHelper.PosFont, rtfHelper.NegFont);

            // Add Win
            rtfHelper.RTFRenderer.AddText(string.Join(null, new string[] { CoreBetList.win, ": " }), rtfHelper.PosFont);
            rtfNumberRenderer.Render(oddsWinVal);

            // Add Place
            rtfHelper.RTFRenderer.AddText(string.Join(null, new string[] { "\n", CoreBetList.place, ": " }), rtfHelper.PosFont);
            rtfNumberRenderer.Render(oddsPlaceVal);

            var rtfOdds = rtfHelper.RTFRenderer.Render();
            rtfHelper.RTFRenderer.Clear();
            return rtfOdds;
        }

        /// <summary>
        /// Extract string value between tags from a source string.
        /// </summary>
        /// <param name="tag">Name of the tags.</param>
        /// <param name="source">Source string.</param>
        /// <returns>Value string.</returns>
        private string ExtractStringBetweenTag(string tag, string source)
        {
            string startTag = string.Join(null, new string[] { "<", tag, ">" });
            string endTag = string.Join(null, new string[] { "</", tag, ">" });

            int startIndex = source.IndexOf(startTag) + startTag.Length;
            int endIndex = source.IndexOf(endTag, startIndex);
            return source.Substring(startIndex, endIndex - startIndex);
        }

        protected virtual IRichTextString BuildRTFOddsCasino(RTFHelper rtfHelper)
        {
            string odds = Template.odds;

            var rtfNumberRenderer = new RTFNumber(rtfHelper.RTFRenderer, rtfHelper.PosFont, rtfHelper.NegFont);

            rtfNumberRenderer.Render(odds);

            var rtfOdds = rtfHelper.RTFRenderer.Render();
            rtfHelper.RTFRenderer.Clear();
            return rtfOdds;
        }

    }
}
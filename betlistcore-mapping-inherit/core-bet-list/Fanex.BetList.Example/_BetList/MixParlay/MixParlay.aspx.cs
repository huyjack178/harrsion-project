﻿// <auto-generated/>

// ---------------------------------------------------------------------------------
// <copyright file="MixParlay.aspx.cs" company="Nexcel Solutions Vietnam">
//     Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
// <history>
//     <change who="Marc.Bui" date="2012.11.16">Create</change>
// </history>
// ---------------------------------------------------------------------------------

namespace Sunplus.Agent.UI._BetList.MixParlay
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.UI;
    using Fanex.Age.UI;
    using Fanex.Age.UI.Components;
    using Fanex.BetList.Age.DTO;
    using Fanex.BetList.Core.Builder;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Factories;
    using Fanex.BetList.Core.TicketHelper;
    using Sunplus.Agent.UI.BetList;
    using Fanex.BetList.Core.Builder.ChoiceBuilder;

    public partial class MixParlay_Page : TplPage
    {
        DataTable betListData = null;
        long transid;
        public override void RenderContent(HtmlTextWriter writer)
        {
            betListData = View as DataTable;

            IList<ITicket> tickets = TicketTransformer.Transform(betListData);

            BetListHTMLFactory factory = new BetListHTMLFactory();
            BetListHTMLBuilder builder = factory.CreateBuilder();
            ITicketHelper ticketHelper = new TicketHelper();

            string line = "<div class='line'></div>";

            for (int i = 0; i < tickets.Count; i++)
            {
                if (i == tickets.Count - 1)
                {
                    line = "<div></div>";
                }
                builder.AddChoice(tickets[i], ticketHelper, null, string.Empty, line, false);
            }

            string row = builder.GetBetList();                 

            writer.Write(row.ToString());
        }

        public override object InvokeData(Hashtable hash)
        {
            DataTable dtResult = null;
            IBetListCmd command = new MixParlayBetListCmd(CurrentUserSession.NetSessionId);
            if (command != null)
            {
                hash.Add("transid", transid);
                command.SetParams(hash);
                dtResult = command.Execute() as System.Data.DataTable;
            }
            return dtResult;
        }

        public override void ProcessRequest(ref Hashtable hash)
        {
            long.TryParse(Request["transid"].ToString(), out transid);
        }

        public override object ValidateRequest(Hashtable p)
        {
            if (transid < 0)
            {
                return new ErrorPage_Page(Resources.Lang.strNotAccessPage);
            }
            return null;
        }
    }

}
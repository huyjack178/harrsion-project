﻿namespace Fanex.BetList.Core.Builder.StatusBuilder
{
    using Fanex.BetList.Core.Entities;

    public class Status1801 : BaseStatusBuilder
    {
        protected override void BuildStatusResult(ITicket ticket)
        {
            base.BuildStatusResult(ticket);

            if (string.IsNullOrWhiteSpace(ticket.TransDesc))
            {
                Template.StatusResult.Hide();
            }
            else
            {
                var externalLink = string.Format("{0},'{1}',{2}", ticket.BetId ?? 0, ticket.BetCheck, ticket.CustId);

                Template.StatusResult.betId = externalLink;
            }
        }
    }
}
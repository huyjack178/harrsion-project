﻿namespace Fanex.BetList.Core.Builder.TransBuilder
{
    using Fanex.BetList.Core.Entities;

    public class Trans71 : BaseTransBuilder
    {
        protected override void BuildRefNo(ITicket ticket)
        {
            Template.TransTime.refNo = ticket.RefNo;
        }
    }
}
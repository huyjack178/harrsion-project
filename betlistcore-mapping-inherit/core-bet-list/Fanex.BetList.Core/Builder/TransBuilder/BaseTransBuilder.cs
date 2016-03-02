﻿namespace Fanex.BetList.Core.Builder.TransBuilder
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Templates;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;

    public class BaseTransBuilder: ITrans
    {
        public BaseTransBuilder()
        {
            Template = new Trans_Template();
        }

        public Trans_Template Template { get; set; }

        public virtual Trans_Template Render(ITicket ticket)
        {
            BuildTransTime(ticket);

            BuildRefNo(ticket);

            return Template;
        }

        public virtual IRichTextString RenderRTF(ITicket ticket, ITicketHelper ticketHelper)
        {
            Render(ticket);

            string refNo = Template.TransTime.refNo;
            string transTime = string.Join(null, new string[] { CoreBetList.refno, ": ", refNo });
            IRichTextString rtfTrans = new HSSFRichTextString(string.Join(null, new string[] { transTime, "\n", Template.transTime }));

            return rtfTrans;
        }

        protected virtual void BuildTransTime(ITicket ticket)
        {
            Template.transTime = ticket.TransDate.ToString();
        }

        protected virtual void BuildRefNo(ITicket ticket)
        {
            // For Mix parlay (Trans9) to reuse
            Template.TransTime.refNo = ticket.TransId.ToString();
        }
    }
}
namespace Fanex.BetList.Core.Builder.ChoiceBuilder
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Templates;
    using NPOI.SS.UserModel;
    using System.Collections.Generic;

    public class Choice1000 : Choice1
    {
        public override Choice_Template Render(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData, bool isShowScoreMap)
        {
            var content = string.Join(null, new string[] { "<div><span class='", Favorite, "'>", CoreBetList.p2pGame, "</span></div>" });
            Template.SetValue(content);

            return Template;
        }

        protected override IRichTextString BuildRTFChoice(ITicket ticket, RTFHelper rtfHelper, ITicketHelper ticketHelper)
        {
            rtfHelper.RTFRenderer.AddText(CoreBetList.p2pGame, rtfHelper.PosFont);

            var choiceRtf = rtfHelper.RTFRenderer.Render();
            rtfHelper.RTFRenderer.Clear();
            return choiceRtf;
        }
    }
}
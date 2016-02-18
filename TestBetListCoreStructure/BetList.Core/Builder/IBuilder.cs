using BetList.Core.Config;
using BetList.Core.Entity;

namespace BetList.Core.Builder
{
    public interface IBuilder
    {
        IConfig Config { get; set; }

        string RenderHtml(ITicket ticket, ITicketHelper ticketHelper);

        object RenderExcel(ITicket ticket, ITicketHelper ticketHelper);
    }
}
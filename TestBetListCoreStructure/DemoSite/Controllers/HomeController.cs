using BetList.Core.Builder;
using BetList.Core.Entity;
using BetList.Core.Helper.TicketHelper;
using Excel.Render;
using NPOI.SS.UserModel;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace DemoSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void ExportExcel()
        {
            IList<ITicket> tickets = CreateSampleTickets();
            ITicketHelper ticketHelper = new TicketHelper();

            var builderGetter = new BetListBaseBuilderGetter();
            BaseExcelRender excelRender = new BaseExcelRender();

            const short excelColumns = 1;
            excelRender.BuildWorksheet("BetList", excelColumns);

            foreach(ITicket ticket in tickets)
            {
                var choiceBuilder = builderGetter.GetChoiceBuilder(ticket);

                IRichTextString choiceString = (IRichTextString)choiceBuilder.RenderExcel(ticket, ticketHelper, excelRender.RTFHelper);

                excelRender.AddCell(choiceString);
            }

            var ms = new MemoryStream();
            var resultWorkbook = excelRender.GetBetList();
            resultWorkbook.Write(ms);
            ExportToExcel(ms, "BetList.xls");

        }

        private void ExportToExcel(MemoryStream excelStream, string fileName)
        {
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
            Response.Clear();
            Response.BinaryWrite(excelStream.GetBuffer());
            Response.End();
        }

        private IList<ITicket> CreateSampleTickets()
        {
            IList<ITicket> tickets = new List<ITicket>();
            ITicket ticketSample1 = new Ticket();
            ticketSample1.BetTeam = "Player";
            ticketSample1.BetId = 123456;
            ticketSample1.SportTypeId = 211;
            ticketSample1.BetTypeId = 1;
            ticketSample1.Status = "win";
            ticketSample1.IP = "1.1.1.1";
            tickets.Add(ticketSample1);

            ITicket ticketSample2 = new Ticket();
            ticketSample2.BetTeam = "Player";
            ticketSample2.BetId = 123456;
            ticketSample2.SportTypeId = 211;
            ticketSample2.BetTypeId = 2;
            ticketSample2.Status = "win";
            ticketSample2.IP = "1.1.1.1";
            tickets.Add(ticketSample2);

            ITicket ticketSample3 = new Ticket();
            ticketSample3.BetTeam = "Player";
            ticketSample3.BetId = 123456;
            ticketSample3.SportTypeId = 211;
            ticketSample3.BetTypeId = 3;
            ticketSample3.Status = "lost";
            ticketSample3.IP = "1.1.1.1";
            tickets.Add(ticketSample3);

            ITicket ticketSample4 = new Ticket();
            ticketSample4.BetTeam = "Player";
            ticketSample4.BetId = 123456;
            ticketSample4.SportTypeId = 211;
            ticketSample4.BetTypeId = 4;
            ticketSample4.Status = "running";
            ticketSample4.IP = "1.1.1.1";
            tickets.Add(ticketSample4);

            ITicket ticketSample5 = new Ticket();
            ticketSample5.BetTeam = "Player";
            ticketSample5.BetId = 123456;
            ticketSample5.SportTypeId = 211;
            ticketSample5.BetTypeId = 5;
            ticketSample5.Status = "waiting";
            ticketSample5.IP = "1.1.1.1";
            tickets.Add(ticketSample5);

            return tickets;
        }
    }
}
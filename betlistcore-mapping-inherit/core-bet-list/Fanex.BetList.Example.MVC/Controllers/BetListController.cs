﻿// <auto-generated/>
namespace Fanex.BetList.Example.MVC.Controllers
{
    using Fanex.BetList.Core.Builder;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Factories;
    using Fanex.BetList.Core.TicketHelper;
    using Fanex.BetList.Example.Extension.BetListExcelBuilderExt;
    using Fanex.BetList.Example.MVC.Models;
    using Fanex.BetList.Example.MVC.Services;
    using Fanex.BetList.Example.MVC.ViewModel;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Web.Mvc;

    /// <summary>
    /// Class HomeController.
    /// </summary>
    public class BetListController : Controller
    {
        private IList<ITicket> _tickets;
        private List<ITicketData> _ticketData = new List<ITicketData>();
        private readonly DataService _dataService;
        private const string DefaultLanguage = "en-US";
        private static readonly CultureInfo DefaultCulture = CultureInfo.CreateSpecificCulture(DefaultLanguage);

        private string DataSourcePath
        {
            get { return Session["DataSourcePath"].ToString(); }
            set { Session["DataSourcePath"] = value; }
        }

        public BetListController()
        {
            _dataService = new DataService();
            var ticketHelper = new TicketHelper();
            var test = ticketHelper.GetLeagueNameById(1073741825);
            var test1 = ticketHelper.GetTeamNameById(1073741825);
            var test2 = ticketHelper.GetTeamNameById(1073741826);
        }

        public ActionResult All(BetListData model = null)
        {
            var betTypes = _dataService.QueryBetTypes();
            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/BetListDummyData.xls";
            model = GetDataSource(model, sourcePath: DataSourcePath);
            return View(model);
        }

        public ActionResult BetRadar(BetListData model = null)
        {
            var betTypes = _dataService.QueryBetTypes(133, 134, 135, 140, 141, 145, 146, 147, 148, 149, 150, 151, 152);
            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/BetListDummyData.xls";
            model = GetDataSource(model, sourcePath: DataSourcePath);
            return BetListView(model);
        }

        public ActionResult New11BetTypes(BetListData model = null)
        {
            var betTypes = _dataService.QueryBetTypes(128, 129, 130, 131, 136, 137, 138, 139, 143, 144, 14, 127, 16, 6, 126);
            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/11NewBetTypeData.xls";
            model = GetDataSource(model, sourcePath: DataSourcePath);
            return BetListView(model);
        }

        public ActionResult New60BetTypesBetRadar(BetListData model = null)
        {
            var betTypes = new List<BetType>();
            betTypes.Add(new BetType
            {
                Id = 157,
                Name = CacheRef.GetBettype(157)
            });

            for (int i = 159; i <= 217; i++)
            {
                betTypes.Add(new BetType
                {
                    Id = i,
                    Name = CacheRef.GetBettype(i)
                });
            }

            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/60NewBetTypeBetRadarData.xls";
            model = GetDataSource(model, sourcePath: DataSourcePath);
            return BetListView(model);
        }

        public ActionResult SportingSolutionBetTypes(BetListData model = null)
        {
            var betTypes = _dataService.QueryBetTypes(153, 154, 155, 156, 1301, 1302, 1303, 1305, 1306, 1311, 1312, 1316, 1317, 1318, 1324);

            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/SportingSolutionBetTypesData.xls";
            model = GetDataSource(model, sourcePath: DataSourcePath);

            return BetListView(model);
        }

        public ActionResult GoldDeluxe(BetListData model = null)
        {
            var betTypes = _dataService.QueryBetTypes(1701, 1702, 1703);

            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/GoldDeluxe.xls";
            model = GetDataSource(model, sourcePath: DataSourcePath);

            return BetListView(model);
        }

        public ActionResult MetricGamming(BetListData model = null)
        {
            var betTypes = _dataService.QueryBetTypes(801, 803, 804, 805, 806);

            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/MetricGamming.xls";
            model = GetDataSource(model, sourcePath: DataSourcePath);

            return BetListView(model);
        }

        public ActionResult MicroGamming(BetListData model = null)
        {
            var betTypes = _dataService.QueryBetTypes(2001, 2002, 2003, 2004, 2005, 2006, 2007);

            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/MicroGamming.xls";
            model = GetDataSource(model, sourcePath: DataSourcePath);

            return BetListView(model);
        }

        public ActionResult AGCasino(BetListData model = null)
        {
            var betTypes = _dataService.QueryBetTypes(1801, 1802, 1803, 1804);

            DataSourcePath = "~/App_Data/AGCasino.xls";

            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            model = GetDataSource(model, sourcePath: DataSourcePath);

            return BetListView(model);
        }

        public ActionResult CockFighting(BetListData model = null)
        {
            var betTypes = _dataService.QueryBetTypes(1, 1003);

            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/CockFighting.xls";
            model = GetDataSource(model, sourcePath: DataSourcePath);

            return BetListView(model);
        }

        public ActionResult ColossusBets(BetListData model = null)
        {
            var betTypes = _dataService.QueryBetTypes(18000, 18001, 18002, 18003, 18004, 18005);

            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/ColossusBets.xls";
            model = GetDataSource(model, sourcePath: DataSourcePath);

            return BetListView(model);
        }

        public ActionResult ColosussBetsDetails()
        {
            var betListData = GetDataSource(new BetListData(), sourcePath: "~/App_Data/ColossusBets.xls");

            return View(betListData);
        }

        public ActionResult BetTrade(BetListData model = null)
        {
            var betTypes = _dataService.QueryBetTypes(901, 902);

            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/BetTrade.xls";
            model = GetDataSource(model, sourcePath: DataSourcePath);

            return BetListView(model);
        }

        public ActionResult MyanmarOdds(BetListData model = null)
        {
            var betTypes = _dataService.QueryBetTypes(301, 302, 303, 304);

            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/MyanmarOdds.xls";
            model = GetDataSource(model, sourcePath: DataSourcePath);

            return BetListView(model);
        }

        public ActionResult PHAllInOne(BetListData model = null)
        {
            var betTypes = _dataService.QueryBetTypes(4, 30, 151, 159, 161, 162, 171, 191, 401, 402, 403, 404, 405, 406, 407, 408, 409, 410, 411, 412, 413, 414);

            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/PHAllInOne.xls";
            model = GetDataSource(model, sourcePath: DataSourcePath);

            return BetListView(model);
        }

        public ActionResult RnGCasino(BetListData model = null)
        {
            DataSourcePath = "~/App_Data/RnGCasinoSingleWallet.xls";

            ViewBag.BetTypes = new List<SelectListItem>();
            model = GetDataSource(model, DataSourcePath);

            return BetListView(model);
        }

        private ViewResult BetListView(BetListData model)
        {
            return View("All", model);
        }

        private IEnumerable<SelectListItem> CreateSelectListItem(IEnumerable<BetType> betTypes)
        {
            return betTypes.Select(betType => new SelectListItem { Text = betType.Name, Value = betType.Id.ToString() });
        }

        private BetListData GetDataSource(BetListData model, string sourcePath)
        {
            if (model != null)
            {
                if (!string.IsNullOrWhiteSpace(model.Language) && model.Language != DefaultLanguage)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(model.Language);

                    //Thread.CurrentThread.CurrentCulture.DateTimeFormat = DefaultCulture.DateTimeFormat;
                    //Thread.CurrentThread.CurrentCulture.NumberFormat = DefaultCulture.NumberFormat;
                }
            }

            BetListData betListData = _dataService.GetBetListData(sourcePath, model.BetTypeId);

            // check whether request filter by bet type id, and does not contain select all
            if (model.BetTypeId != 0)
            {
                model.Tickets = betListData
                    .Tickets
                    .Where(ticket => model.BetTypeId == ticket.BetTypeId)
                    .Select(ticket => ticket)
                    .ToList();

                model.TicketData = betListData
                  .TicketData
                  .Where(ticketData => model.BetTypeId == ticketData.BetTypeId)
                  .Select(ticket => ticket)
                  .ToList();

                model.TicketData = model.TicketData ?? new List<ITicketData>();
                model.Tickets = model.Tickets ?? new List<ITicket>();
            }
            else
            {
                model.TicketData = betListData.TicketData ?? new List<ITicketData>();
                model.Tickets = betListData.Tickets ?? new List<ITicket>();
            }

            return model;
        }

        /// <summary>
        /// Exports the excel.
        /// </summary>
        public void ExportExcel(BetListData query)
        {
            GetCachePropertyById funcGetOddsTypeName = CacheRef.GetOddsTypeName;
            var factory = new BetListExcelFactory();
            BetListExcelBuilder builder = factory.CreateBuilder();
            ITicketHelper ticketHelper = new TicketHelper();
            const short excelColumns = 7;
            builder.BuildWorksheet("BetList", excelColumns);
            var index = 0;

            var model = GetDataSource(query, sourcePath: DataSourcePath);

            _tickets = model.Tickets;
            _ticketData = model.TicketData;

            if (_tickets != null)
            {
                foreach (ITicket ticket in _tickets)
                {
                    index++;
                    ticketHelper.Index = index;

                    builder.AddNo(index)
                           .AddTrans(ticket, ticketHelper)
                           .AddUsername(ticket, ticketHelper)
                           .AddChoice(ticket, ticketHelper, _ticketData)
                           .AddOdds(ticket, _ticketData, funcGetOddsTypeName)
                           .AddStatus(ticket, ticketHelper, _ticketData, true)
                           .AddStake(ticket);
                }

                var ms = new MemoryStream();
                var resultWorkbook = builder.GetBetList();
                resultWorkbook.Write(ms);
                ExportToExcel(ms, "BetList.xls");
            }
        }

        private void ExportToExcel(MemoryStream excelStream, string fileName)
        {
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
            Response.Clear();
            Response.BinaryWrite(excelStream.GetBuffer());
            Response.End();
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetlistExcel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public void ExportExcel(ElementTable elements)
        {
        }
    }

    public class ElementTable
    {
        public Element[][] Elements { get; set; }
    }

    public class Element
    {
        public string Text { get; set; }
        public Element[] Children { get; set; }

        public string TagType { get; set; }

        public bool InLine { get; set; }

        public object Style { get; set; }
    }
}

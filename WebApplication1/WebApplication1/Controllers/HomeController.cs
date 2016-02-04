using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StringWriter stringWriter = new StringWriter();

            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                string classValue = "className";
                writer.RenderBeginTag(HtmlTextWriterTag.Html);

                writer.AddAttribute(HtmlTextWriterAttribute.Class, classValue);
                writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "#db4141");
                writer.Write("Huy");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.RenderEndTag();

                writer.RenderEndTag();
                GridView grid = new GridView();
                grid.AllowPaging = false;
                grid.RenderControl(writer);
                //Change the Header Row back to white color
                DataTable[] dt = new DataTable[2];

                for (int i = 0; i <= 1; i++)
                {
                    dt[i] = new DataTable();
                    dt[i].Columns.Add("id");
                    dt[i].Columns.Add("name");
                }

                IHTMLBuilder htmlBuilder = new HTMLBuilder();
                htmlBuilder.Build();

                grid.DataSource = dt;
                grid.DataBind();
                //Apply style to Individual Cells
                grid.HeaderRow.Cells[0].Text = "harrison";
                grid.HeaderRow.Cells[0].Style.Add("background-color", "green");

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                 "attachment;filename=GridViewExport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Dictionary<string, IdentityModels> test = new Dictionary<string, IdentityModels>();
                test.Add("huy", new IdentityModels());
                var testModel =  test["huy"];

            }
            Response.Output.Write(stringWriter.ToString());
            Response.Flush();
            Response.End();
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
    }
}
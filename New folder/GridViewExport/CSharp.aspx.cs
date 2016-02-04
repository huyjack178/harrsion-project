using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;

public partial class CSharp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strQuery = "select CustomerID,City,Country,PostalCode from customers";
        SqlCommand cmd = new SqlCommand(strQuery);
        DataTable dt = GetData(cmd);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    private DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            sda.Dispose();
            con.Dispose();
        }
    }
   

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void OnPaging(object sender, GridViewPageEventArgs  e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();  
    }

    protected void btnExportWord_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.doc");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-word ";
        StringWriter sw= new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.AllowPaging = false;
        GridView1.DataBind(); 
        GridView1.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
       
        Response.AddHeader("content-disposition", 
         "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        GridView1.AllowPaging = false;
        GridView1.DataBind(); 

        //Change the Header Row back to white color
        GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");

        //Apply style to Individual Cells
        GridView1.HeaderRow.Cells[0].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[1].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[2].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[3].Style.Add("background-color", "green");   

        for (int i = 0; i < GridView1.Rows.Count;i++ )
        {
            GridViewRow row = GridView1.Rows[i];

            //Change Color back to white
            row.BackColor = System.Drawing.Color.White;

            //Apply text style to each Row
            row.Attributes.Add("class", "textmode");

            //Apply style to Individual Cells of Alternating Row
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#C2D69B");
                row.Cells[1].Style.Add("background-color", "#C2D69B");
                row.Cells[2].Style.Add("background-color", "#C2D69B");
                row.Cells[3].Style.Add("background-color", "#C2D69B");   
            }
        }
        GridView1.RenderControl(hw);

        //style to format numbers to string
        string style = @"<style> .textmode { mso-number-format:\@; } </style>"; 
        Response.Write(style); 
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    protected void btnExportPDF_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.AllowPaging = false;
        GridView1.DataBind(); 
        GridView1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f,10f,10f,0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();  
    }
    protected void btnExportCSV_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.csv");
        Response.Charset = "";
        Response.ContentType = "application/text";

        GridView1.AllowPaging = false;
        GridView1.DataBind(); 

        StringBuilder sb = new StringBuilder();
        for (int k = 0; k < GridView1.Columns.Count; k++)
        {
            //add separator
            sb.Append(GridView1.Columns[k].HeaderText + ',');
        }
        //append new line
        sb.Append("\r\n");
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int k = 0; k < GridView1.Columns.Count; k++)
            {
                //add separator
                sb.Append(GridView1.Rows[i].Cells[k].Text + ',');
            }
            //append new line
            sb.Append("\r\n");
        }
        Response.Output.Write(sb.ToString());
        Response.Flush();
        Response.End();
    }
}

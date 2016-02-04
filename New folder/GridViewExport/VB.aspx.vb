Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser
Partial Class VB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strQuery As String = "select CustomerID,City,Country,PostalCode from customers"
        Dim cmd As New SqlCommand(strQuery)
        Dim dt As DataTable = GetData(cmd)
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub
    Private Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable()
        Dim strConnString As String = System.Configuration.ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter()
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            sda.SelectCommand = cmd
            sda.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            sda.Dispose()
            con.Dispose()
        End Try
    End Function
    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered 
    End Sub
    Protected Sub OnPaging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Sub btnExportWord_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.doc")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-word "
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        GridView1.AllowPaging = False
        GridView1.DataBind()
        GridView1.RenderControl(hw)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.[End]()
    End Sub

    Protected Sub btnExportExcel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Clear()
        Response.Buffer = True

        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)

        GridView1.AllowPaging = False
        GridView1.DataBind()

        'Change the Header Row back to white color 
        GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF")

        'Apply style to Individual Cells 
        GridView1.HeaderRow.Cells(0).Style.Add("background-color", "green")
        GridView1.HeaderRow.Cells(1).Style.Add("background-color", "green")
        GridView1.HeaderRow.Cells(2).Style.Add("background-color", "green")
        GridView1.HeaderRow.Cells(3).Style.Add("background-color", "green")

        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim row As GridViewRow = GridView1.Rows(i)

            'Change Color back to white 
            row.BackColor = System.Drawing.Color.White

            'Apply text style to each Row 
            row.Attributes.Add("class", "textmode")

            'Apply style to Individual Cells of Alternating Row 
            If i Mod 2 <> 0 Then
                row.Cells(0).Style.Add("background-color", "#C2D69B")
                row.Cells(1).Style.Add("background-color", "#C2D69B")
                row.Cells(2).Style.Add("background-color", "#C2D69B")
                row.Cells(3).Style.Add("background-color", "#C2D69B")
            End If
        Next
        GridView1.RenderControl(hw)

        'style to format numbers to string 
        Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub

    Protected Sub btnExportPDF_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        GridView1.AllowPaging = False
        GridView1.DataBind()
        GridView1.RenderControl(hw)
        Dim sr As New StringReader(sw.ToString())
        Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)
        Dim htmlparser As New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        pdfDoc.Open()
        htmlparser.Parse(sr)
        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.End()
    End Sub
    Protected Sub btnExportCSV_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.csv")
        Response.Charset = ""
        Response.ContentType = "application/text "

        GridView1.AllowPaging = False
        GridView1.DataBind()

        Dim sb As New StringBuilder()
        For k As Integer = 0 To GridView1.Columns.Count - 1
            'add separator 
            sb.Append(GridView1.Columns(k).HeaderText + ","c)
        Next
        'append new line 
        sb.Append(vbCr & vbLf)

        For i As Integer = 0 To GridView1.Rows.Count - 1
            For k As Integer = 0 To GridView1.Columns.Count - 1
                'add separator 
                sb.Append(GridView1.Rows(i).Cells(k).Text + ","c)
            Next
            'append new line 
            sb.Append(vbCr & vbLf)

        Next
        Response.Output.Write(sb.ToString())
        Response.Flush()
        Response.End()
    End Sub
End Class

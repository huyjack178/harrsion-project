<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VB.aspx.vb" Inherits="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>GridView Export</title>
</head>
<body>
       <form id="form2" runat="server">
        
      <asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns = "false" Font-Names = "Arial" 
            Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B"  
            HeaderStyle-BackColor = "green" AllowPaging = "true"  
            OnPageIndexChanging = "OnPaging" >
           <Columns>
            <asp:BoundField ItemStyle-Width = "150px" DataField = "CustomerID" HeaderText = "CustomerID" />
            <asp:BoundField ItemStyle-Width = "150px" DataField = "City" HeaderText = "City"/>
            <asp:BoundField ItemStyle-Width = "150px" DataField = "Country" HeaderText = "Country"/>
            <asp:BoundField ItemStyle-Width = "150px" DataField = "PostalCode" HeaderText = "PostalCode"/>
           </Columns> 
        </asp:GridView>
        <br />
        <asp:Button ID="btnExportWord" runat="server" Text="ExportToWord" OnClick="btnExportWord_Click" />
        &nbsp;
        <asp:Button ID="btnExportExcel" runat="server" Text="ExportToExcel" OnClick="btnExportExcel_Click" />
        &nbsp;
        <asp:Button ID="btnExportPDF" runat="server" Text="ExportToPDF" OnClick="btnExportPDF_Click" />
         &nbsp;
        <asp:Button ID="Button1" runat="server" Text="ExportToCSV" OnClick="btnExportCSV_Click" />
    </form>
</body>
</html>


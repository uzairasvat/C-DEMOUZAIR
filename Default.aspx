<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
    <form id="form1" runat="server">
    <div>
        <h1> SIMPLE DROPDOWN AND INSERT UPDATE DELETE PREC</h1>
    <asp:GridView ID="gvEmp" runat="server" /><br />
        <asp:DropDownList ID="ddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged"></asp:DropDownList><br />
           ID:<asp:TextBox ID="txtID" runat="server"></asp:TextBox><br />
         Name:<asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
         City:<asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"  />
    </div>
    </form>
</center>
</body>
</html>

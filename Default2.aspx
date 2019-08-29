<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<center>
    <form id="form1" runat="server">
    <div>
      <h1> STORED PROCEDURE PREC</h1>
        <asp:GridView ID="gvEmp" runat="server"></asp:GridView><br />
        ID:<asp:TextBox ID="txtID" runat="server" /><br />
        Name:<asp:TextBox ID="txtName" runat="server" /><br />
        City:<asp:TextBox ID="txtCity" runat="server" /><br />
        <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandArgument="1" OnClick="btnIUD_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument="2"  OnClick="btnIUD_Click"  />
        <asp:Button ID="btnDelete" runat="server" Text="Delete"  CommandArgument="3" OnClick="btnIUD_Click" />
    </div>
    </form>
    </center>
</body>
</html>

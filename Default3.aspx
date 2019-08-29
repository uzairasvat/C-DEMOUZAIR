<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
        <h1>CONNECTION LESS</h1>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="gvEmp" runat="server" />
        <br />
        ID:<asp:TextBox ID="txtId" runat="server" /><br />
        Name:<asp:TextBox ID="txtName" runat="server" /><br />
        City:<asp:TextBox ID="txtCity" runat="server" /><br />
        <br />
        <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandArgument="1" OnClick="btnIUD_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument="2" OnClick="btnIUD_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument="3" OnClick="btnIUD_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click"/>
    </div>
    </form>
        </center>
</body>
</html>

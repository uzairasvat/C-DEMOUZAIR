<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default6.aspx.cs" Inherits="Default6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
        <h1>COMMAND USE</h1>
    <form id="form1" runat="server">
    <div>
    ID<asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br />
        <br />
    Name<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <br />
    City<asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        <br />
        <br />
    Salary<asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
    <br />
        <br />
    <asp:Button ID="btnInsert" runat="server" Text="Insert" onclick="btnInsert_Click" />
    <asp:Button ID="btnDisplay" runat="server" Text="Display" 
            onclick="btnDisplay_Click"/>
    <asp:Button ID="btnFind" runat="server" Text="Find" onclick="btnFind_Click" />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" onclick="btnUpdate_Click" />
        <br />
    <br />
    <asp:GridView ID="gvEmpDetail" runat="server"></asp:GridView>
    </div>
    </form>
        </center>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
        <h1>Salary Is Less 10000 is Green color</h1>
    
    <form id="form1" runat="server">
    <div>
           
            <asp:GridView ID="GridView1" runat="server" CellPadding="6" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">  

            <Columns>  

                <asp:BoundField DataField="Empid" HeaderText="Id"/>  

                <asp:BoundField DataField="Empname" HeaderText="Name"/>  

                <asp:BoundField DataField="Empcity" HeaderText="City"/>  

                <asp:BoundField DataField="Empsalary" HeaderText="Salary"/>  

            </Columns>  

        </asp:GridView>  

    </div>
    </form>
        </center>
</body>
</html>

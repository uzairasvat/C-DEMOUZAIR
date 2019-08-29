using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Default3 : System.Web.UI.Page
{
    public static SqlConnection con;
    public static SqlDataAdapter da;
    public static DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\uzair\Documents\EMPDB.mdf;Integrated Security=True;Connect Timeout=30");
            FillGrid();
        }
    }
    private void FillGrid()
    {
        da = new SqlDataAdapter("Select * from EmpTbl", con);
        dt = new DataTable();
        da.Fill(dt);
        gvEmp.DataSource = dt;
        gvEmp.DataBind();
    }
    protected void btnIUD_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        dt.PrimaryKey = new DataColumn[] { dt.Columns["eid"] };
        if (btn.CommandArgument == "1")
        {
            DataRow dr = dt.NewRow();
            dr[0] = txtId.Text;
            dr[1] = txtName.Text;
            dr[2] = txtCity.Text;
            dt.Rows.Add(dr);


        }
        else if (btn.CommandArgument == "2")
        {
            DataRow dr = dt.Rows.Find(txtId.Text);
            dr[1] = txtName.Text;
            dr[2] = txtCity.Text;
        }
        else if (btn.CommandArgument == "3")
        {
            dt.Rows.Find(txtId.Text).Delete();
        }
        gvEmp.DataSource = dt;
        gvEmp.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommandBuilder cmdb = new SqlCommandBuilder(da);
        da.Update(dt);
    }
}
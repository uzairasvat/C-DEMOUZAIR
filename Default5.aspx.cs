using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Default5 : System.Web.UI.Page
{
    public static SqlConnection con;
    public static SqlDataAdapter da;
    public static DataSet ds;
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
        da = new SqlDataAdapter("select * from Emp_Table", con);
        ds = new DataSet();
        da.Fill(ds);
        gvEmp.DataSource = ds;
        gvEmp.DataBind();
    }
    protected void gvEmp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow gvr = gvEmp.Rows[e.RowIndex];
        Label lblidd = gvr.FindControl("lblid1") as Label;
        int id = Convert.ToInt32(lblidd.Text);
        String q = "delete from Emp_Table where Empid=@EmpId";
        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.AddWithValue("@Empid", id);
        con.Open();

        int i = cmd.ExecuteNonQuery();
        con.Close();
        FillGrid();

    }
    protected void gvEmp_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmp.EditIndex = e.NewEditIndex;
        FillGrid();

    }
    protected void gvEmp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEmp.EditIndex = -1;
        FillGrid();
    }
    protected void gvEmp_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow gvr = gvEmp.Rows[e.RowIndex];
        TextBox tid = gvr.FindControl("txtid1") as TextBox;
        TextBox tname = gvr.FindControl("txtname1") as TextBox;
        TextBox tcity = gvr.FindControl("txtcity1") as TextBox;
        TextBox tsalary = gvr.FindControl("txtsalary1") as TextBox;
        int eid = Convert.ToInt32(tid.Text);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "update Emp_Table set Empname=@ename,Empcity=@ecity,Empsalary=@esalary where Empid=@eid";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@eid", eid);
        cmd.Parameters.AddWithValue("@ename", tname.Text);
        cmd.Parameters.AddWithValue("@ecity", tcity.Text);
        cmd.Parameters.AddWithValue("@esalary", Convert.ToInt32(tsalary.Text));

        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i > 0)
        {
            gvEmp.EditIndex = -1;
            FillGrid();
        }

    }
    protected void gvEmp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
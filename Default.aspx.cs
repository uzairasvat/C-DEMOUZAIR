using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    public static SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\uzair\Documents\EMPDB.mdf;Integrated Security=True;Connect Timeout=30";
            FillGrid();
            FIllDDL();
        }
    }
    private void FIllDDL()
    {
        ddl.Items.Clear();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Select eid from EmpTbl";
        cmd.Connection = con;
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddl.Items.Add(dr[0].ToString());
        }
        con.Close();
    }
    private void FillGrid()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Select * from EmpTbl";
        cmd.Connection = con;
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        gvEmp.DataSource = dr;
        gvEmp.DataBind();
        con.Close();
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Insert into EmpTbl values(@eid,@enm,@ect)";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@eid", Convert.ToInt32(txtID.Text));
        cmd.Parameters.AddWithValue("@enm", txtName.Text);
        cmd.Parameters.AddWithValue("@ect", txtCity.Text);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i > 0)
        {
            FillGrid();
            FIllDDL();
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Delete from EmpTbl where Eid=@eid";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@eid", Convert.ToInt32(txtID.Text));
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i > 0)
        {
            FillGrid();
            FIllDDL();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Update EmpTbl set Ename=@enm, Ecity=@ect where Eid=@eid";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@eid", Convert.ToInt32(txtID.Text));
        cmd.Parameters.AddWithValue("@enm", txtName.Text);
        cmd.Parameters.AddWithValue("@ect", txtCity.Text);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i > 0)
        {
            FillGrid();
            FIllDDL();
        }
    }
    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Select * from EmpTbl where eid=@eid";
        cmd.Parameters.AddWithValue("@eid", Convert.ToInt32(ddl.SelectedItem.Text));
        cmd.Connection = con;
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        txtID.Text = dr[0].ToString();
        txtName.Text = dr[1].ToString();
        txtCity.Text = dr[2].ToString();
        con.Close();
    }
}
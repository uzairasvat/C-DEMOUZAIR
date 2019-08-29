using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Default2 : System.Web.UI.Page
{
    public static SqlCommand cmd;
    public static SqlConnection con;

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
        cmd = new SqlCommand();
        cmd.CommandText = "SPEMP";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@OP", 4);
        cmd.Connection = con;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvEmp.DataSource = dt;
        gvEmp.DataBind();


    }

    protected void btnIUD_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        cmd = new SqlCommand();
        cmd.CommandText = "SPEmp";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@OP", Convert.ToInt32(btn.CommandArgument));
        cmd.Parameters.AddWithValue("@Eid", Convert.ToInt32(txtID.Text));
        cmd.Parameters.AddWithValue("@Ename", txtName.Text);
        cmd.Parameters.AddWithValue("@Ecity", txtCity.Text);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i > 0)
            FillGrid();
    }
}
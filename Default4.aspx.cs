using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;

public partial class Default4 : System.Web.UI.Page
{
    public static SqlConnection con;
    public static DataTable dt;
    public static SqlDataAdapter adapt;
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
        adapt = new SqlDataAdapter("Select * from Emp_Table", con);
        dt = new DataTable();
        adapt.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    //RowDataBound Event  

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)

    {

        //Checking the RowType of the Row  

        if (e.Row.RowType == DataControlRowType.DataRow)

        {

            //If Salary is less than 10000 than set the row Background Color to Cyan  

            if (Convert.ToInt32(e.Row.Cells[3].Text) < 10000)

            {

                e.Row.BackColor = Color.Cyan;

            }

        }

    }


    
}
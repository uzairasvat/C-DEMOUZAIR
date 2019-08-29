using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Default6 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\uzair\Documents\EMPDB.mdf;Integrated Security=True;Connect Timeout=30");
    SqlDataAdapter da = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        fillGrid();
    }
    public void fillGrid()
    {
        DataSet ds = new DataSet();
        da = new SqlDataAdapter("SELECT * FROM Emp_Table", con);
        da.Fill(ds);
        gvEmpDetail.DataSource = ds;
        gvEmpDetail.DataBind();

    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        //da.InsertCommand = new SqlCommand("INSERT INTO Emp_Table VALUES(@Empid,dd)", con);
        //da.InsertCommand.Parameters.Add("@Empid", SqlDbType.Int).Value = txtID.Text;
        //con.Open();
        //da.InsertCommand.ExecuteNonQuery();
        //con.Close();


        da.InsertCommand = new SqlCommand("INSERT INTO Emp_Table VALUES (@Empid,@EmpName,@EmpCity,@EmpSalary)", con);
        da.InsertCommand.Parameters.Add("@Empid", SqlDbType.Int).Value = txtID.Text;
        da.InsertCommand.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = txtName.Text;
        da.InsertCommand.Parameters.Add("@EmpCity", SqlDbType.VarChar).Value = txtCity.Text;
        da.InsertCommand.Parameters.Add("@EmpSalary", SqlDbType.Int).Value = txtSalary.Text;
        con.Open();
        da.InsertCommand.ExecuteNonQuery();
        con.Close();
        Response.Write("Inserted");
        fillGrid();


    }
    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        //DataSet ds = new DataSet();
        //da = new SqlDataAdapter("SELECT * FROM EmpTable", con);
        //da.Fill(ds);
        //gvEmpDetail.DataSource = ds;
        //gvEmpDetail.DataBind();
        fillGrid();
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        da.SelectCommand = new SqlCommand("SELECT * FROM Emp_Table WHERE Empid=@Empid", con);
        da.SelectCommand.Parameters.Add("@Empid", SqlDbType.Int).Value = txtID.Text;
        da.Fill(dt);
        gvEmpDetail.DataSource = dt;
        gvEmpDetail.DataBind();
        txtName.Text = dt.Rows[0][1].ToString();
        txtCity.Text = dt.Rows[0][2].ToString();
        txtSalary.Text = dt.Rows[0][3].ToString();

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        da.UpdateCommand = new SqlCommand("UPDATE Emp_Table SET Empname=@EmpName,Empcity=@EmpCity,Empsalary=@EmpSalary WHERE Empid=@EmpID", con);
        da.UpdateCommand.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = txtName.Text;
        da.UpdateCommand.Parameters.Add("@EmpCity", SqlDbType.VarChar).Value = txtCity.Text;
        da.UpdateCommand.Parameters.Add("@EmpSalary", SqlDbType.Int).Value = txtSalary.Text;
        da.UpdateCommand.Parameters.Add("@EmpID", SqlDbType.Int).Value = txtID.Text;
        con.Open();
        da.UpdateCommand.ExecuteNonQuery();
        con.Close();
        fillGrid();
    }
}
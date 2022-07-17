using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DbConnectionDemo
{
    public partial class UserDisplay : System.Web.UI.Page
    {
        //Allocate, Create and Configure connection object
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //open connection
            conn.Open();
            //allocate and configure command object
            cmd = new SqlCommand("select * from Users", conn);
            //execute Command
            rdr = cmd.ExecuteReader();
            grddata.DataSource = rdr;
            grddata.DataBind();
            conn.Close();
        }
    }
}
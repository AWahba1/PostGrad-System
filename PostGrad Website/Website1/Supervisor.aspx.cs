using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Website1
{
    public partial class Supervisor : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            String myName = "";
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);



            SqlCommand sup = new SqlCommand("SupViewProfile", conn);
            sup.CommandType = CommandType.StoredProcedure;
            sup.Parameters.Add(new SqlParameter("@supervisorID", SqlDbType.Int)).Value = Session["user"];
            conn.Open();
            SqlDataReader rdr = sup.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                myName = rdr.GetString(rdr.GetOrdinal("name"));
             
            }
            name.Text = myName;
            name.Visible = true;





        }
       
        }
}
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
    public partial class SupervisorsList : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder htmlTable = new StringBuilder();
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand listSup = new SqlCommand("AdminListSup", conn);
            listSup.CommandType = CommandType.StoredProcedure;

            htmlTable.Append("<table border='1'>");
            htmlTable.Append("<tr><th>Supervisor ID</th><th>Name</th><th>Email</th><th>Password</th>" +
                "<th>Faculty</th> </tr>");


            conn.Open();
            SqlDataReader rdr = listSup.ExecuteReader(CommandBehavior.CloseConnection);
            
                while (rdr.Read())
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("id")) + "</td>");
                    htmlTable.Append("<td>" +  rdr.GetValue(rdr.GetOrdinal("name")) + "</td>");
                    htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("email"))  + "</td>");
                    htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("password")) + "</td>");
                    htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("faculty")) + "</td>");
                    htmlTable.Append("</tr>");

                }
                htmlTable.Append("</table>");
                
                form1.Controls.Add(new Literal { Text = htmlTable.ToString() });
            
           



           


            


            
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
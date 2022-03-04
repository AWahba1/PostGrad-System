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
    public partial class StudentThesisSupervisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand StdThesSup = new SqlCommand("AdminViewStudentThesisBySupervisor", conn);

            StdThesSup.CommandType = CommandType.StoredProcedure;




            conn.Open();
            SqlDataReader rdr = StdThesSup.ExecuteReader(CommandBehavior.CloseConnection);


            StringBuilder htmlTable = new StringBuilder();

            htmlTable.Append("<table border='1'>");

            htmlTable.Append("<tr><th>Supervisor Name</th><th>Thesis Title</th> <th>Student Name</th> </tr>");
            while (rdr.Read())
            {
                htmlTable.Append("<tr>");
                htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("name")) + "</td>");
                htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("title")) + "</td>");
                htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("firstName")) + "</td>");


                htmlTable.Append("</tr>");

            }
            htmlTable.Append("</table>");

            form1.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
    }
}
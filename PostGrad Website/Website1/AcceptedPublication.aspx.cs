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
    public partial class AcceptedPublication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand listPub = new SqlCommand("AdminListAcceptPublication", conn);

            listPub.CommandType = CommandType.StoredProcedure;




            conn.Open();
            SqlDataReader rdr = listPub.ExecuteReader(CommandBehavior.CloseConnection);


            StringBuilder htmlTable = new StringBuilder();

            htmlTable.Append("<table border='1'>");

            htmlTable.Append("<tr><th>Serial Number</th><th>Title</th> </tr>");
            while (rdr.Read())
            {
                htmlTable.Append("<tr>");
                htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("serialNumber")) + "</td>");
                htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("title")) + "</td>");


                htmlTable.Append("</tr>");

            }
            htmlTable.Append("</table>");

            form1.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }
    }
}
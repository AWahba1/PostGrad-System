using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    public partial class StudentPublication : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void search1(object sender, EventArgs e)
        {
            Message.Visible = false;
            error1.Visible = false; 
            if (TextBox1.Text.Length == 0)
            {
                error1.Visible = true;
                return;
            }
            Message.Visible = false;
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand studentP = new SqlCommand("ViewAStudentPublications", conn);
            studentP.CommandType = CommandType.StoredProcedure;
            studentP.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int)).Value = Int32.Parse(TextBox1.Text);
            htmlTable.Append("<table border='1'>");
            htmlTable.Append("<tr><th bgcolor=white>ID</th><th bgcolor=white>Title</th><th bgcolor=white>Date</th><th bgcolor=white>Place</th><th bgcolor=white>Accepted</th><th bgcolor=white>Host</th></tr>");
            int Flag = 0;
            conn.Open();
            SqlDataReader rdr = studentP.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Flag = 1;
                int ID = rdr.GetInt32(rdr.GetOrdinal("id"));
                String Title = rdr.GetString(rdr.GetOrdinal("title"));
                DateTime PDate =rdr.GetDateTime(rdr.GetOrdinal("dateOfPublication"));
                String Place = rdr.GetString(rdr.GetOrdinal("place"));
                bool Accepted = rdr.GetBoolean(rdr.GetOrdinal("accepted"));
                String Host = rdr.GetString(rdr.GetOrdinal("host"));

                htmlTable.Append("<tr>");
                htmlTable.Append("<td bgcolor=white>" + ID + "</td>");
                htmlTable.Append("<td bgcolor=white>" + Title + "</td>");
                htmlTable.Append("<td bgcolor=white>" + PDate + "</td>");
                htmlTable.Append("<td bgcolor=white>" + Place + "</td>");
                htmlTable.Append("<td bgcolor=white>" + Accepted + "</td>");
                htmlTable.Append("<td bgcolor=white>" + Host + "</td>");
                htmlTable.Append("</tr>");



            }
            if (Flag == 1)
            {
                htmlTable.Append("</table>");
                form1.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }
            else
            {
                Message.Visible = true;
            }


        }

    }
}

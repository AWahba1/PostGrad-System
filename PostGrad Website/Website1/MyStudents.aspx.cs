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
    public partial class MyStudents : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand students = new SqlCommand("ViewSupStudentsYears", conn);
            students.CommandType = CommandType.StoredProcedure;
            htmlTable.Append("<table border='1'>");
            htmlTable.Append("<tr><th bgcolor=white>FirstName</th><th bgcolor=white>LastName</th><th bgcolor=white>Years spent in the thesis</th></tr>");
            students.Parameters.Add(new SqlParameter("@supervisorID", SqlDbType.Int)).Value = Session["user"];
            conn.Open();
            SqlDataReader rdr = students.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String studentFname = rdr.GetString(rdr.GetOrdinal("firstName"));
                String studentLname = rdr.GetString(rdr.GetOrdinal("lastName"));
                int studentYears =rdr.GetInt32(rdr.GetOrdinal("years"));
                htmlTable.Append("<tr>");
                htmlTable.Append("<td bgcolor=white>" + studentFname + "</td>");
                htmlTable.Append("<td bgcolor=white>" + studentLname + "</td>");
                htmlTable.Append("<td bgcolor=white>" + studentYears + "</td>");
                htmlTable.Append("</tr>");



            }
            htmlTable.Append("</table>");
            form1.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
    }
}
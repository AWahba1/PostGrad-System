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
    public partial class examinerDataList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void returnToExaminer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner.aspx");
        }
        StringBuilder htmlTable = new StringBuilder();
        protected void displayPersonel_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand ListAllDefensePersonellProc = new SqlCommand("ListAllDefensePersonell", conn);
            ListAllDefensePersonellProc.CommandType = CommandType.StoredProcedure;
            htmlTable.Append("<table border='1'>");
            htmlTable.Append("<tr><th bgcolor=white>Thesis Title</th><th bgcolor=white>Supervisor Name</th><th bgcolor=white>Student First Name</th><th bgcolor=white>Student Last Name</th></tr>");
            //students.Parameters.Add(new SqlParameter("@examId", SqlDbType.Int)).Value = Session["user"];
            ListAllDefensePersonellProc.Parameters.Add(new SqlParameter("@examId", SqlDbType.Int)).Value = Session["user"];
            conn.Open();
            SqlDataReader rdr = ListAllDefensePersonellProc.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.HasRows == true)
            {

                while (rdr.Read())
                {
                    String thesisTitle = rdr.GetString(rdr.GetOrdinal("title"));
                    String supervisorName = rdr.GetString(rdr.GetOrdinal("name"));
                    String studentFN = rdr.GetString(rdr.GetOrdinal("firstName"));
                    String studentLN = rdr.GetString(rdr.GetOrdinal("lastName"));
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td bgcolor=white>" + thesisTitle + "</td>");
                    htmlTable.Append("<td bgcolor=white>" + supervisorName + "</td>");
                    htmlTable.Append("<td bgcolor=white>" + studentFN + "</td>");
                    htmlTable.Append("<td bgcolor=white>" + studentLN + "</td>");
                    htmlTable.Append("</tr>");



                }
                htmlTable.Append("</table>");
                form1.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }
            else
            {
                String k = "You have not Attended any Defenses yet";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + k + "')", true);
            }

        }

        protected void serialNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
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
    public partial class SearchThesis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        StringBuilder htmlTable = new StringBuilder();
        protected void thesisSearch_Click(object sender, EventArgs e)
        {
            String connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String keyword = ThesisTitleInput.Text;
            if (keyword == "")
            {
                String x = "Please type a keyword";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
            }
            else
            {

                SqlCommand ExaminerSearchThesisProc = new SqlCommand("ExaminerSearchThesis", conn);
                ExaminerSearchThesisProc.CommandType = CommandType.StoredProcedure;
                htmlTable.Append("<table border='1'>");
                htmlTable.Append("<tr><th bgcolor=white>Thesis Serial Number</th>" +
                    "<th bgcolor=white>Field</th>" +
                    "<th bgcolor=white>Thesis Type</th>" +
                    "<th bgcolor=white>Thesis Title</th>" +
                    "<th bgcolor=white>Start Date</th>" +
                    "<th bgcolor=white>End Date</th>" +
                    "<th bgcolor=white>Defense Date</th>" +
                    "<th bgcolor=white>Years</th>" +
                    "<th bgcolor=white>Grade</th></tr>");
                //students.Parameters.Add(new SqlParameter("@examId", SqlDbType.Int)).Value = Session["user"];
                ExaminerSearchThesisProc.Parameters.Add(new SqlParameter("@Thesistitle", SqlDbType.VarChar)).Value = keyword;
                conn.Open();
                SqlDataReader rdr = ExaminerSearchThesisProc.ExecuteReader(CommandBehavior.CloseConnection);

                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        String thesisSerialNumber = "" + rdr.GetValue(rdr.GetOrdinal("serialNumber"));
                        String thesisField = "" + rdr.GetValue(rdr.GetOrdinal("field"));
                        String thesisType = "" + rdr.GetValue(rdr.GetOrdinal("type"));
                        String thesisTitle = "" + rdr.GetValue(rdr.GetOrdinal("title"));
                        String thesisStartDate = "" + rdr.GetValue(rdr.GetOrdinal("startDate"));
                        String thesisEndDate = "" + rdr.GetValue(rdr.GetOrdinal("endDate"));
                        String thesisDefenseDate = "" + rdr.GetValue(rdr.GetOrdinal("defenseDate"));
                        String thesisYears = "" + rdr.GetValue(rdr.GetOrdinal("years"));
                        String thesisGrade = "" + rdr.GetValue(rdr.GetOrdinal("grade"));
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td bgcolor=white>" + thesisSerialNumber + "</td>");
                        htmlTable.Append("<td bgcolor=white>" + thesisField + "</td>");
                        htmlTable.Append("<td bgcolor=white>" + thesisType + "</td>");
                        htmlTable.Append("<td bgcolor=white>" + thesisTitle + "</td>");
                        htmlTable.Append("<td bgcolor=white>" + thesisStartDate + "</td>");
                        htmlTable.Append("<td bgcolor=white>" + thesisEndDate + "</td>");
                        htmlTable.Append("<td bgcolor=white>" + thesisDefenseDate + "</td>");
                        htmlTable.Append("<td bgcolor=white>" + thesisYears + "</td>");
                        htmlTable.Append("<td bgcolor=white>" + thesisGrade + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</table>");
                    form1.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
                else
                {
                    String k = "No Rows Exist for your Input";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + k + "')", true);
                }
            }
        }

        protected void returnToExaminer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner.aspx");
        }
    }
}
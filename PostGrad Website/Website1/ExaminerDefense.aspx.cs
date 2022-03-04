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
    public partial class ExaminerDefense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnCheck(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);



            if (Date.Text.Length == 0 )
            {
                String x = "Please choose a date first.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
            }

            else
            {
                
                DateTime dt = Convert.ToDateTime(Date.Text);


                SqlCommand cmd = new SqlCommand("Select @temp=serialNumber from Defense where date=@x", conn);
                cmd.Parameters.Add(new SqlParameter("@x", dt));

                SqlParameter Temp = cmd.Parameters.Add("@temp", SqlDbType.Int);
                Temp.Direction = ParameterDirection.Output;



                
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                String a = Temp.Value.ToString();

                


                //no defense on this data
                if (a.Length == 0)
                {
                    String x = "There are NO defenses on the provided date. ";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
                }
                
                
                else
                {
                    SqlCommand viewExamDef = new SqlCommand("ViewExamSupDefense", conn);
                    viewExamDef.CommandType = CommandType.StoredProcedure;
                    viewExamDef.Parameters.Add(new SqlParameter("@defenseDate", dt));


                    conn.Open();
                    SqlDataReader rdr = viewExamDef.ExecuteReader(CommandBehavior.CloseConnection);


                    StringBuilder htmlTable = new StringBuilder();

                    htmlTable.Append("<table border='1'>");;

                    htmlTable.Append("<tr><th>Serial Number</th><th>Defense Date</th> " +
                        "<th>Examiner Name</th> <th>Supervisor Name</th>   </tr>");
                    while (rdr.Read())
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("serial_no")) + "</td>");
                        htmlTable.Append("<td>" + rdr.GetDateTime(rdr.GetOrdinal("date")).ToString("dd/MM/yyyy") + "</td>");
                        htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("ename")) + "</td>");
                        htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("supname")) + "</td>");

                        htmlTable.Append("</tr>");

                    }
                    htmlTable.Append("</table>");

                    form1.Controls.Add(new Literal { Text = htmlTable.ToString() });

                }



            }
            }
        }
}
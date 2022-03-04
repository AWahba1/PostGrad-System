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
    public partial class NonGucianCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnView(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            //empty field
            if (CID.Text.Length==0)
            {
                String x = "Course ID cannot be left empty";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
            }
            else
            {
                Int32 courseID = Int32.Parse(CID.Text);

                SqlCommand cmd = new SqlCommand("Select @temp=id from Course where id=@x", conn);
                cmd.Parameters.Add(new SqlParameter("@x", courseID));

                SqlParameter Temp = cmd.Parameters.Add("@temp", SqlDbType.Int);
                Temp.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                String a = Temp.Value.ToString();

                //invalid Course ID
                if (a.Length==0)
                {
                    String x = "Course ID entered doesnt exist. Please enter a VALID ID";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
                }
                else
                {
                    SqlCommand noGucianCourse = new SqlCommand("AdminListNonGucianCourse", conn);

                    noGucianCourse.CommandType = CommandType.StoredProcedure;
                    noGucianCourse.Parameters.Add(new SqlParameter("@courseID", courseID));


                    


                    


                    conn.Open();
                    SqlDataReader rdr = noGucianCourse.ExecuteReader(CommandBehavior.CloseConnection);
                    // no students take this course
                   if (!rdr.HasRows)
                    {
                        String x = "No non gucian students are enrolled in this course";
                         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
                    }
                   //outputs table
                    else
                    {   
                        StringBuilder htmlTable = new StringBuilder();



                        htmlTable.Append("<table border='1'>");

                        htmlTable.Append("<tr><th>First Name</th><th>Last Name</th><th>Course Code</th><th>Student Grade </tr>");
                        while (rdr.Read())
                        {
                            htmlTable.Append("<tr>");
                            htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("firstName")) + "</td>");
                            htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("lastName")) + "</td>");
                            htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("code")) + "</td>");
                            htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("grade")) + "</td>");

                            htmlTable.Append("</tr>");

                        }
                        htmlTable.Append("</table>");

                        form1.Controls.Add(new Literal { Text = htmlTable.ToString() });
                    }
                }
            }

            

            

            



            
        }
    }
}
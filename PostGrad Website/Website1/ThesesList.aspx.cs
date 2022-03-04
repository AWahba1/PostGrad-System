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
    public partial class ThesesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder htmlTable = new StringBuilder();

            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand listSup = new SqlCommand("AdminViewAllTheses", conn);
            listSup.CommandType = CommandType.StoredProcedure;

            htmlTable.Append("<table border='1'>");

            htmlTable.Append("<tr><th>Serial Number</th><th>Field</th><th>Type</th><th>Title</th>" +
                "<th>Start Date</th> <th>End Date</th>  <th>Defense Date</th>  <th>Years</th> " +
                "<th>Grade</th> <th>Payment ID</th> <th>NumberOfExtensions</th>  </tr>");


            conn.Open();
            SqlDataReader rdr = listSup.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {
                htmlTable.Append("<tr>");
                htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("serialNumber")) + "</td>");
                htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("field")) + "</td>");
                htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("type")) + "</td>");
                htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("title")) + "</td>");
                htmlTable.Append("<td>" + rdr.GetDateTime(rdr.GetOrdinal("startDate")).ToString("dd/MM/yyyy") + "</td>");
                htmlTable.Append("<td>" + rdr.GetDateTime(rdr.GetOrdinal("endDate")).ToString("dd/MM/yyyy") + "</td>");
                htmlTable.Append("<td>" + rdr.GetDateTime(rdr.GetOrdinal("defenseDate")).ToString("dd/MM/yyyy") + "</td>");
                htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("years")) + "</td>");
                htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("grade")) + "</td>");
                htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("payment_id")) + "</td>");
                htmlTable.Append("<td>" + rdr.GetValue(rdr.GetOrdinal("noOfExtensions")) + "</td>");
                htmlTable.Append("</tr>");

            }
            htmlTable.Append("</table>");

            form1.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

       


        protected void OnCount(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            
            SqlCommand onGoing = new SqlCommand("AdminViewOnGoingTheses", conn);
            onGoing.CommandType = CommandType.StoredProcedure;
            


            SqlParameter Number = onGoing.Parameters.Add("@thesesCount", SqlDbType.Int);
            Number.Direction = ParameterDirection.Output;

            conn.Open();
            onGoing.ExecuteNonQuery();
            conn.Close();
            String x = "Number of Ongoing Theses: "+Number.Value;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);


        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            //no serial num entered
            if (SerialBox.Text.Length == 0)
            {
                String x = "Extension Update failed. Serial Num cannot be left empty ";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
            }
            else
            {
                Int32 serial = Int32.Parse(SerialBox.Text);

                SqlCommand cmd = new SqlCommand("select @temp=serialNumber from Thesis " +
                   "where serialNumber=@ThesisSerialNo", conn);
                
                cmd.Parameters.Add(new SqlParameter("@ThesisSerialNo", serial));

                SqlParameter Temp = cmd.Parameters.Add("@temp", SqlDbType.Int);
                Temp.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                String a = Temp.Value.ToString();

                //invalid thesis serial num
                if(a.Length==0)
                {
                    String x = "Extension Update failed. Please enter a VALID Thesis Serial Num";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);

                }
                else
                {
                    SqlCommand addExt = new SqlCommand("AdminUpdateExtension", conn);
                    addExt.CommandType = CommandType.StoredProcedure;

                    addExt.Parameters.Add(new SqlParameter("@ThesisSerialNo", serial));

                    conn.Open();
                    addExt.ExecuteNonQuery();
                    conn.Close();

                    String x = "Number of Extenions for Serial " + serial + " was successfully updated by 1 ";
                    ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('" + x + "');window.location='ThesesList.aspx';", true);
                    
                }







            }

            


            

            


        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
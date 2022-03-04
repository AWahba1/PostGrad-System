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
    public partial class Installment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnIssue(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);



            if (Payment.Text.Length==0 || Date.Text.Length==0)
            {
                String x = "Some fields are empty. Please fill ALL fields.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
            }

            else
            {
                Int32 payID = Int32.Parse(Payment.Text);
                DateTime dt = Convert.ToDateTime(Date.Text);


                SqlCommand cmd = new SqlCommand("Select @temp=id from Payment where id=@x", conn);
                cmd.Parameters.Add(new SqlParameter("@x", payID));

                SqlParameter Temp = cmd.Parameters.Add("@temp", SqlDbType.Int);
                Temp.Direction = ParameterDirection.Output;

                

                SqlCommand cmd1 = new SqlCommand("Select @temp=paymentId from Installment where paymentId=@x", conn);
                cmd1.Parameters.Add(new SqlParameter("@x", payID));

                SqlParameter Temp1 = cmd1.Parameters.Add("@temp", SqlDbType.Int);
                Temp1.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                conn.Close();

                String a = Temp.Value.ToString();

                String a1 = Temp1.Value.ToString();


                //invalid Payment ID
                if (a.Length==0)
                {
                    String x = "Issuing Installments failed. Payment ID provided was non existing. ";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
                }
                //payment ID already has issued payments
                else if (a1.Length!=0)
                {
                    String x = "Installments had been already issued for the Payment ID provided. ";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
                }
                else
                {
                    SqlCommand issueInstall = new SqlCommand("AdminIssueInstallPayment", conn);
                    issueInstall.CommandType = CommandType.StoredProcedure;
                    issueInstall.Parameters.Add(new SqlParameter("@paymentID", payID));
                    issueInstall.Parameters.Add(new SqlParameter("@InstallStartDate", dt));

                    conn.Open();
                    issueInstall.ExecuteNonQuery();
                    conn.Close();

                    String x = "Installments were successfully issued for payment ID "+payID;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);

                }
            }
            




            
        }
    }
}
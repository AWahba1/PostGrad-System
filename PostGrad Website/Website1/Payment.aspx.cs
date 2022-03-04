using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Website1
{
    public partial class PaymentsInstallments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           

        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Password_TextChanged1(object sender, EventArgs e)
        {

        }


        protected void OnIssue(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            bool flag = SerialLabel.Text.Length == 0 || AmountLabel.Text.Length == 0 ||
                        numOfInstallmentsLabel.Text.Length == 0 || fundPercLabel.Text.Length == 0;
            // at least one is empty
            if (flag)
            {
                Error.Text = "Issuing Payment failed. Please fill ALL fields";
                



            }
            else
            {
                long serialNum = Int64.Parse(SerialLabel.Text);
                double amount = double.Parse(AmountLabel.Text, System.Globalization.CultureInfo.InvariantCulture);
                long noInstallments = Int64.Parse(numOfInstallmentsLabel.Text); ;
                double fundPercentage = double.Parse(fundPercLabel.Text, System.Globalization.CultureInfo.InvariantCulture);




                SqlCommand issuePaym = new SqlCommand("AdminIssueThesisPayment", conn);
                issuePaym.CommandType = CommandType.StoredProcedure;
                issuePaym.Parameters.Add(new SqlParameter("@ThesisSerialNo", serialNum));
                issuePaym.Parameters.Add(new SqlParameter("@amount", amount));
                issuePaym.Parameters.Add(new SqlParameter("@noOfInstallments", noInstallments));
                issuePaym.Parameters.Add(new SqlParameter("@fundPercentage", fundPercentage));


                conn.Open();
                issuePaym.ExecuteNonQuery();
                conn.Close();



                //checks if there is an ongoing thesis for the serial Num input
                SqlCommand isThesisValid = new SqlCommand("isThesisValid", conn);
                isThesisValid.CommandType = CommandType.StoredProcedure;
                isThesisValid.Parameters.Add(new SqlParameter("@serialNum", serialNum));

                conn.Open();
                SqlDataReader dr = isThesisValid.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.HasRows)
                {
                    String x = "Payment successfully issued for thesis number: "+serialNum;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
                }
                else
                {
                    Error.Text = "No ongoing thesis for the the entered Thesis Serial Nunber";
                }


                


            }






        }
    }
}
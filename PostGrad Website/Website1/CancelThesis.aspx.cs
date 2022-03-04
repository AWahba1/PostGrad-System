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
    public partial class CancelThesis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void delete1(object sender, EventArgs e)
        {
            error1.Visible = false;
            Message.Visible = false;
            if (TextBox1.Text.Length == 0)
            {
                error1.Visible = true;
                return;
            }
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cancel = new SqlCommand("CancelThesis", conn);
            cancel.CommandType = CommandType.StoredProcedure;
            cancel.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = Int32.Parse(TextBox1.Text);
            SqlParameter cannot = cancel.Parameters.Add(new SqlParameter("@cannot", SqlDbType.Bit));
            cannot.Direction = ParameterDirection.Output;
            SqlParameter notValid = cancel.Parameters.Add(new SqlParameter("@notValid", SqlDbType.Bit));
            notValid.Direction = ParameterDirection.Output;

            conn.Open();
            cancel.ExecuteNonQuery();
            conn.Close();
            if ((bool)notValid.Value)
            {
                Message.Text = "No Progress Reports Related To this ThesisSerialNo";
                Message.Visible = true;
                return;
            }
            if ((bool)cannot.Value)
            {
                Message.Text = "Cannot Cancel Thesis,Last Progress Report Evaluation Not Equal Zero";
                Message.Visible = true;
                return;
            }

            Message.Text = "Thesis Removed Successfully!";
            Message.Visible = true;

        }
    }
}
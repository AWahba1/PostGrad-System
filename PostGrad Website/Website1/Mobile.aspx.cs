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
    public partial class Mobile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void onAdd(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);



            SqlCommand addMobileProc = new SqlCommand("addMobile", conn);
            addMobileProc.CommandType = CommandType.StoredProcedure;

            String phone = PhoneBox.Text;

            addMobileProc.Parameters.Add(new SqlParameter("@ID", Session["user"]));
            addMobileProc.Parameters.Add(new SqlParameter("@mobile_number", SqlDbType.VarChar)).Value = phone;




            conn.Open();
            addMobileProc.ExecuteNonQuery();
            conn.Close();

            String x = "Phone number added successfully for student with ID " + Session["user"];
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
        }

        protected void PhoneBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
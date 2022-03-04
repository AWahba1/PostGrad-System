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
    public partial class AddGrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void add(object sender, EventArgs e)
        {
            error1.Visible = false;
            done.Visible = false;
            new1.Visible = false;

            int Flag = 0;

            if (T1.Text.Length == 0)
            {
                error1.Text = "Field Required!";
                error1.Visible = true;
                Flag = 1;
            }
           
            if (Flag == 1)
                return;
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand add = new SqlCommand("AddGrade", conn);
            add.CommandType = CommandType.StoredProcedure;
            add.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = Int32.Parse(T1.Text);
            SqlParameter notAvailable = add.Parameters.Add("@notAvailable", SqlDbType.Bit);
            notAvailable.Direction = ParameterDirection.Output;
            conn.Open();
            add.ExecuteNonQuery();
            conn.Close();
            if ((bool)notAvailable.Value)
            {
                error1.Text = "No Available Defense Grade For This Thesis";
                error1.Visible = true;
                return;
            }
            done.Visible = true;
            new1.Visible = true;

        }
    }
}
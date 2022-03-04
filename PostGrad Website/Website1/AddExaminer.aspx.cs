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
    public partial class AddExaminer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Add(object sender, EventArgs e)
        {
            error1.Visible = false;
            error2.Visible = false;
            error3.Visible = false;
            error4.Visible = false;
            error5.Visible = false;
            done.Visible = false;
            new1.Visible = false;

            int Flag = 0;

            if (T1.Text.Length == 0)
            {
                error1.Visible = true;
                Flag = 1;
            }
            if (T2.Text.Length == 0)
            {
                error2.Visible = true;
                Flag = 1;
            }
            if (T3.Text.Length == 0)
            {
                error3.Visible = true;
                Flag = 1;
            }
            if (T4.Text.Length == 0)
            {
                error4.Visible = true;
                Flag = 1;
            }
            if (T4.Text.Length == 0)
            {
                error4.Visible = true;
                Flag = 1;
            }
            if (T5.Text.Length == 0)
            {
                error5.Visible = true;
                Flag = 1;
            }


            if (Flag == 1)
                return;
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand add = new SqlCommand("AddExaminer", conn);
            add.CommandType = CommandType.StoredProcedure;
            add.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = Int32.Parse(T1.Text);
            add.Parameters.Add(new SqlParameter("@DefenseDate", SqlDbType.DateTime)).Value = DateTime.Parse(T2.Text);
            add.Parameters.Add(new SqlParameter("@ExaminerName", SqlDbType.VarChar)).Value = T3.Text;
            add.Parameters.Add(new SqlParameter("@National", SqlDbType.Bit)).Value = CheckBox1.Checked;
            add.Parameters.Add(new SqlParameter("@fieldOfWork", SqlDbType.VarChar)).Value = T4.Text;
            add.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar)).Value = T4.Text;
            SqlParameter notValid = add.Parameters.Add(new SqlParameter("notValid", SqlDbType.Bit));
            notValid.Direction = ParameterDirection.Output;
            conn.Open();
            add.ExecuteNonQuery();
            conn.Close();
            if ((bool)notValid.Value)
            {
                done.Text = "Please Enter Valid Defense Data";
                done.Visible = true;
                return;


            }
            done.Text = "New Examiner Added";
            done.Visible = true;
            new1.Visible = true;



        }

       
    }
}
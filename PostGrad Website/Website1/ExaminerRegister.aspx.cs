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
    public partial class ExaminerRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Register(object sender, EventArgs e)
        {
            l1.Text = "";
            l2.Text = "";
            l3.Text = "";
            l4.Text = "";
            RepPassLab.Text = "";

            String Name = name.Text;
            String Password = password.Text;
            String FieldOfWork = fieldOfWork.Text;
            String Email = email.Text;
            String RepPassword = RepPassBox.Text;

            int IsNational = 0;
            bool Flag = false;
            if (CheckBox.Checked == true)
                IsNational = 1;
            if (Name.Length == 0)
            {
                Flag = true;
                l1.Text = "This Field Is Required!";
            }

            if (Password.Length == 0)
            {
                Flag = true;
                l2.Text = "This Field Is Required!";
            }
            if (RepPassword.Length == 0)
            {
                Flag = true;
                RepPassLab.Text = "This Field Is Required!";
            }
            if (FieldOfWork.Length == 0)
            {
                Flag = true;
                l3.Text = "This Field Is Required!";
            }
            if (Email.Length == 0)
            {
                Flag = true;
                l4.Text = "This Field Is Required!";
            }

            if (RepPassBox.Text != password.Text)
            {
                Flag = true;
                RepPassLab.Text = "Password and repeated password do not match";

            }
            if (RepPassword.Length == 0)
            {
                Flag = true;
                RepPassLab.Text = "This Field Is Required!";
            }
            if (!Flag)
            {
                String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();

                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand RegProc = new SqlCommand("ExaminerRegister", conn);
                RegProc.CommandType = CommandType.StoredProcedure;

                RegProc.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar)).Value = Name;
                RegProc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = Password;
                RegProc.Parameters.Add(new SqlParameter("@fieldOfWork", SqlDbType.VarChar)).Value = FieldOfWork;
                RegProc.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = Email;
                RegProc.Parameters.Add(new SqlParameter("@isNational", SqlDbType.Bit)).Value = IsNational;
                conn.Open();
                RegProc.ExecuteNonQuery();
                conn.Close();


                SqlCommand cmd = new SqlCommand("select @temp=max(id) from PostGradUser", conn);


                SqlParameter Temp = cmd.Parameters.Add("@temp", SqlDbType.Int);
                Temp.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                String id = Temp.Value.ToString();


                String x = "Signed up Successfully. Your id is: " + id;
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('" + x + "');window.location='LogIn.aspx';", true);




            }
        }
    }
}
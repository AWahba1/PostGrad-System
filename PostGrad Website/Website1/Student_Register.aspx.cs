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
    public partial class StdReg : System.Web.UI.Page
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
            l5.Text = "";
            l6.Text = "";
            RepPassLab.Text = "";
            String First_Name = first_Name.Text;
            String Last_Name = last_Name.Text;
            String Password = password.Text;
            String Faculty = faculty.Text;
            String Email = email.Text;
            String Address = address.Text;
            String RepPassword = RepPassBox.Text;
            int Gucian = 0;
            bool Flag = false;
            if (CheckBox.Checked == true)
                Gucian = 1;
            if (First_Name.Length == 0)
            {
                Flag = true;
                l1.Text = "This Field Is Required!";
            }
            if (Last_Name.Length == 0)
            {
                Flag = true;
                l2.Text = "This Field Is Required!";
            }
            if (Password.Length == 0)
            {
                Flag = true;
                l3.Text = "This Field Is Required!";
            }
            if (RepPassword.Length == 0)
            {
                Flag = true;
                RepPassLab.Text = "This Field Is Required!";
            }
            if (Faculty.Length == 0)
            {
                Flag = true;
                l4.Text = "This Field Is Required!";
            }
            if (Email.Length == 0)
            {
                Flag = true;
                l5.Text = "This Field Is Required!";
            }
            if (Address.Length == 0)
            {
                Flag = true;
                l6.Text = "This Field Is Required!";
            }
            if (RepPassBox.Text != password.Text)
            {
                Flag = true;
                RepPassLab.Text = "Password and repeated password do not match";
            }
            if (!Flag)
            {
                String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();

                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand RegProc = new SqlCommand("StudentRegister", conn);
                RegProc.CommandType = CommandType.StoredProcedure;

                RegProc.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar)).Value = First_Name;
                RegProc.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar)).Value = Last_Name;
                RegProc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = Password;
                RegProc.Parameters.Add(new SqlParameter("@faculty", SqlDbType.VarChar)).Value = Faculty;
                RegProc.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = Email;
                RegProc.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar)).Value = Address;
                RegProc.Parameters.Add(new SqlParameter("@Gucian", SqlDbType.Bit)).Value = Gucian;
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


                String x = "Signed up Successfully. Your id is:  " + id;
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('" + x + "');window.location='LogIn.aspx';", true);



            }
        }
    }
}
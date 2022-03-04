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
    public partial class LogIn : System.Web.UI.Page
    {
        private object loginProc;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
     
        }
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void LogIN(object sender, EventArgs e)
        {
            Incorrect_Label.Text = " ";
            Label6.Visible = false;
            Label7.Visible = false;
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if (UserName.Text.Length == 0)
            {
                Label6.Visible = true;
                if (Password.Text.Length == 0)
                {
                    Label7.Visible = true;
                    if (!Admin.Selected && !Supervisor.Selected && !Examiner.Selected && !Student.Selected)
                    {
                        Required_Label.Visible = true;
                    }
                }
                if (!Admin.Selected && !Supervisor.Selected && !Examiner.Selected && !Student.Selected)
                {
                    Required_Label.Visible = true;
                }
            }
            if (Password.Text.Length == 0)
            {
                Label7.Visible = true;
                if (!Admin.Selected && !Supervisor.Selected && !Examiner.Selected && !Student.Selected)
                {
                    Required_Label.Visible = true;
                }
                return;
            }

                long id = Int64.Parse(UserName.Text);
            String pass = Password.Text;
            SqlCommand loginproc = new SqlCommand("userLogin",conn);
            loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@ID", id));
            loginproc.Parameters.Add(new SqlParameter("@password ", pass));
           

                SqlParameter Available = loginproc.Parameters.Add("@success", SqlDbType.Bit);
            Available.Direction =ParameterDirection.Output;

         
            
            SqlParameter type = loginproc.Parameters.Add("@type", SqlDbType.Int);
            type.Direction = ParameterDirection.Output;
            conn.Open();
            loginproc.ExecuteNonQuery();
            conn.Close(); 


            Required_Label.Visible = false;
            Int32 temp = 0;
            if (!Admin.Selected && !Supervisor.Selected && !Examiner.Selected && !Student.Selected)
            {
                Required_Label.Visible = true;
            }
            
            else
            {
                
                if (Admin.Selected)
                {
                    temp = 1;
                }
                else
                if (Supervisor.Selected)
                {
                    temp = 2;
                }
                else
                if (Examiner.Selected)
                {
                    temp = 3;
                }
               else
               {
                    temp = 0;
                }


                if (!(bool)Available.Value || (int)type.Value != temp)
                {
                    Incorrect_Label.Text = "Please Enter Correct User Name Or Password";

                }
                else
                {   
                    Session["user"] = id;
                    switch (temp)
                    {
                        case 1:
                            Response.Redirect("Admin.aspx");
                            break;
                        case 2:
                            Response.Redirect("Supervisor.aspx");
                            break;
                        case 3: Response.Redirect("Examiner.aspx");
                            break;
                        default:
                            Response.Redirect("Student.aspx");
                            break;
                    }
                }



            }
              
            
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      

    }
}
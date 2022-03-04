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
    public partial class StudentProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            //empty field
            if (TextBox1.Text.Length == 0)
            {
                String x = "ID cannot be left empty.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);

            }

            else
            {
                Int32 UserID = Int32.Parse(TextBox1.Text);


                SqlCommand cmd = new SqlCommand("set @success=0" +
                    "if (exists(Select * from GucianStudent where id=@sid))" +
                    "set @success=1" +
                    "if (exists(Select * from NonGucianStudent where id=@sid))" +
                    "set @success=1", conn);

                cmd.Parameters.Add(new SqlParameter("@sid", UserID));

                SqlParameter Temp = cmd.Parameters.Add("@success", SqlDbType.Int);
                Temp.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                //invalid user
                if (Int32.Parse(Temp.Value.ToString()) == 0)
                {
                    Error.Visible = true;

                    IDLabel.Text = "";
                    FirstNameLabel.Text = "";
                    LastNameLabel.Text = "";
                    EmailLabel.Text = "";
                    PasswordLabel.Text = "";
                    FacultyLabel.Text = "";
                    TypeLabel.Text = "";
                    AddressLabel.Text = "";
                    GPALabel.Text = "";

                }
                else
                {
                    SqlCommand viewStudentProfile = new SqlCommand("AdminViewStudentProfile", conn);
                    viewStudentProfile.CommandType = CommandType.StoredProcedure;
                    viewStudentProfile.Parameters.Add(new SqlParameter("@sid", UserID));

                    conn.Open();
                    SqlDataReader rdr = viewStudentProfile.ExecuteReader(CommandBehavior.CloseConnection);

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {


                            Error.Visible = false;
                           

                            IDLabel.Text = "ID: " + rdr.GetValue(rdr.GetOrdinal("id")) ;
                            FirstNameLabel.Text = "First Name: " + rdr.GetValue(rdr.GetOrdinal("firstName")); ;
                            LastNameLabel.Text = "Last Name: " + rdr.GetValue(rdr.GetOrdinal("lastName")); ;
                            EmailLabel.Text = "Email: " + rdr.GetValue(rdr.GetOrdinal("email")); ;
                            PasswordLabel.Text = "Password: " + rdr.GetValue(rdr.GetOrdinal("password")); ;
                            FacultyLabel.Text = "Faculty: " + rdr.GetValue(rdr.GetOrdinal("faculty")); ;
                            TypeLabel.Text = "Type: " + rdr.GetValue(rdr.GetOrdinal("type")); ;
                            AddressLabel.Text = "Address: " + rdr.GetValue(rdr.GetOrdinal("address")); ;
                            GPALabel.Text = "GPA: " + rdr.GetValue(rdr.GetOrdinal("GPA")); ;

                        }
                    }

                }
            }













        }
    }
}
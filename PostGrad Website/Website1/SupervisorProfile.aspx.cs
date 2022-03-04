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
    public partial class SupervisorProfile : System.Web.UI.Page
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


                SqlCommand cmd = new SqlCommand("select @success=id from Supervisor where id=@sid", conn);

                cmd.Parameters.Add(new SqlParameter("@sid", UserID));

                SqlParameter Temp = cmd.Parameters.Add("@success", SqlDbType.Int);
                Temp.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();


                String a = Temp.Value.ToString();

                //invalid user
                if (a.Length == 0)
                {
                    Error.Visible = true;

                    IDLabel.Text = "";
                    FirstNameLabel.Text = "";

                    EmailLabel.Text = "";
                    PasswordLabel.Text = "";
                    FacultyLabel.Text = "";


                }
                else
                {
                    SqlCommand viewStudentProfile = new SqlCommand("AdminViewSupervisorProfile", conn);
                    viewStudentProfile.CommandType = CommandType.StoredProcedure;
                    viewStudentProfile.Parameters.Add(new SqlParameter("@supId", UserID));

                    conn.Open();
                    SqlDataReader rdr = viewStudentProfile.ExecuteReader(CommandBehavior.CloseConnection);

                    if (rdr.HasRows)
                    {
                        Error.Visible = false;
                        while (rdr.Read())
                        {





                            IDLabel.Text = "ID: " + rdr.GetValue(rdr.GetOrdinal("id"));
                            FirstNameLabel.Text = "Name: " + rdr.GetValue(rdr.GetOrdinal("name"));
                            EmailLabel.Text = "Email: " + rdr.GetValue(rdr.GetOrdinal("email")); ;
                            PasswordLabel.Text = "Password: " + rdr.GetValue(rdr.GetOrdinal("password")); ;
                            FacultyLabel.Text = "Faculty: " + rdr.GetValue(rdr.GetOrdinal("faculty")); ;
                            ;

                        }
                    }


                }
            }
        }
    }
}
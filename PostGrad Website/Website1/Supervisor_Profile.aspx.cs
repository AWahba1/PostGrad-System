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
    public partial class Supervisor_Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);



            SqlCommand sup = new SqlCommand("SupViewProfile", conn);
            sup.CommandType = CommandType.StoredProcedure;
            sup.Parameters.Add(new SqlParameter("@supervisorID", SqlDbType.Int)).Value = Session["user"];
            conn.Open();
            SqlDataReader rdr = sup.ExecuteReader(CommandBehavior.CloseConnection);
            T1.Text= ""+Session["user"];
            while (rdr.Read())
            {
                T2.Text = rdr.GetString(rdr.GetOrdinal("name"));
                T3.Text = rdr.GetString(rdr.GetOrdinal("faculty"));
                T4.Text = rdr.GetString(rdr.GetOrdinal("email"));

            }

        }
        protected void edit(object sender, EventArgs e)
        {
            hide.Visible = false;
            edit1.Visible = false;
            checkLabel.Visible = true;
            password.Visible = true;
            CheckBox1.Visible = true;
            ok1.Visible = true;
            cancel1.Visible = true;


        }
      
        protected void ok(object sender, EventArgs e)
        {   
            error1.Visible = false;
            wrong.Visible = false;
            if (password.Text.Length == 0)
            {
                error1.Visible = true;
                return;
            }
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            long id = (long)Session["user"];
            String pass = password.Text;
            SqlCommand loginproc = new SqlCommand("userLogin", conn);
            loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@ID", id));
            loginproc.Parameters.Add(new SqlParameter("@password ", pass));

            SqlParameter Available = loginproc.Parameters.Add("@success", SqlDbType.Bit);
            Available.Direction = ParameterDirection.Output;
            SqlParameter Type = loginproc.Parameters.Add("@type", SqlDbType.Int);
            Type.Direction = ParameterDirection.Output;

            conn.Open();
            loginproc.ExecuteNonQuery();
            conn.Close();
            if(Available.Value.ToString() == "False")
            {
                wrong.Visible = true;
            }
            else
            {
                checkLabel.Visible = false;
                password.Visible = false;
                CheckBox1.Visible = false;
                ok1.Visible = false;
                cancel1.Visible = false;
                newName.Visible = true;
                newFaculty.Visible = true;
               save1.Visible = true;
                N1.Visible = true;
                N2.Visible = true;
                T2.Visible = false;
                T3.Visible = false;
                hide.Visible = true;
            }

        }
        protected void cancel(object sender, EventArgs e)
        {
            hide.Visible = true;
            error1.Visible = false;
            wrong.Visible = false;
            edit1.Visible = true;
            checkLabel.Visible = false;
            password.Visible = false;
            CheckBox1.Visible = false;
            ok1.Visible = false;
            cancel1.Visible = false;
        }
        protected void save(object snder, EventArgs e)

        {
            newFaculty.Visible = true; ;
            newName.Visible = true;
            int Flag = 0;
            if (N1.Text.Length != 0)
            {
                
                newName.Visible = false;
            }
            else
                Flag = 1;
            if (N2.Text.Length != 0)
            {
                newFaculty.Visible = false;
            }
            else
                Flag = 1;
            if (Flag == 1)
            return;
          

            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand UpDate = new SqlCommand("UpdateSupProfile", conn);
            UpDate.CommandType = CommandType.StoredProcedure;
            UpDate.Parameters.Add(new SqlParameter("@supervisorID", SqlDbType.Int)).Value = Session["user"];
            UpDate.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar)).Value = N1.Text;
            UpDate.Parameters.Add(new SqlParameter("@faculty", SqlDbType.VarChar)).Value = N2.Text;
            conn.Open();
            UpDate.ExecuteNonQuery();
            conn.Close();
            save1.Visible = false;
            edit1.Visible = true;
            T2.Text = N1.Text;
            T3.Text = N2.Text;
            T2.Visible = true;
            T3.Visible = true;
            N1.Visible = false;
            N2.Visible = false;


        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
           
 
        }
    }
}
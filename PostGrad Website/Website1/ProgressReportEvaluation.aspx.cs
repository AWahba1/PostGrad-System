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
    public partial class ProgressReportEvaluation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Evaluate(object sender, EventArgs e)
        {
            error1.Visible = false;
            error2.Visible = false;
            error3.Visible = false;
            error4.Visible = false;
            error5.Visible = false;
            done.Visible = false;
            new1.Visible = false;

            int Flag = 0;

        
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
            else
            {
                if (Int32.Parse(T4.Text)< 0|| Int32.Parse(T4.Text) > 3)
                {
                    error5.Visible = true;
                    Flag = 1;
                }
            }
            if (Flag == 1)
                return;
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand eval = new SqlCommand("EvaluateProgressReport", conn);
            eval.CommandType = CommandType.StoredProcedure;
            eval.Parameters.Add(new SqlParameter("@supervisorID", SqlDbType.Int)).Value = Session["user"];
            eval.Parameters.Add(new SqlParameter("@thesisSerialNo", SqlDbType.Int)).Value = Int32.Parse(T2.Text);
            eval.Parameters.Add(new SqlParameter("@progressReportNo", SqlDbType.Int)).Value = Int32.Parse(T3.Text);
            eval.Parameters.Add(new SqlParameter("@evaluation", SqlDbType.Int)).Value = Int32.Parse(T4.Text);
            SqlParameter NoStudent = eval.Parameters.Add("@NoStudent", SqlDbType.Bit);
            NoStudent.Direction = ParameterDirection.Output;
            SqlParameter NoThesis = eval.Parameters.Add("@NoThesis", SqlDbType.Bit);
            NoThesis.Direction = ParameterDirection.Output;
            SqlParameter NoProgress = eval.Parameters.Add("@NoProgress", SqlDbType.Bit);
            NoProgress.Direction = ParameterDirection.Output;
            conn.Open();
            eval.ExecuteNonQuery();
            conn.Close();

            if ((bool)NoThesis.Value)
            {
                error1.Text = "Please Enter Valid ThesisSerialNo";
                error1.Visible = true;
                return;
            }
            if ((bool)NoStudent.Value)
            {
                error1.Text = "None Of Your Students Is Related To This Thesis";
                error1.Visible = true;
                return;
            }
            if ((bool)NoProgress.Value)
            {
                error1.Text = "ProgressReportNo Is Not Available For This Thesis";
                error1.Visible = true;
                return;
            }




            done.Visible = true;
            new1.Visible = true;
        }
    }
}
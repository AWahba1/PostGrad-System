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
    public partial class AddDefense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void new1(object sender, EventArgs e)
        {

            Response.Redirect("AddDefense.aspx");


        }
        protected void return1(object sender, EventArgs e)
        {

            Response.Redirect("Supervisor.aspx");


        }
        protected void Submit(object sender, EventArgs e)
        {
        
            error1.Visible = false;
            error2.Visible = false;
            error3.Visible = false;
            error4.Visible = false;
            error5.Visible = false;
            AddNew.Visible = false;
            done.Visible = false;

            int Flag = 0;
       
            if (tsn.Text.Length == 0)
            {
                error1.Visible = true;
                Flag = 1;
            }
            if (DD.Text.Length == 0)
            {
                error2.Visible = true;
                Flag = 1;
            }
            if (DL.Text.Length == 0)
            {
                error3.Visible = true;
                Flag = 1;
            }
            if (!Gucian.Selected && !NonGucian.Selected)
            {
                error4.Visible = true;
                Flag = 1;
            }
            if (Flag == 1)
                return;
            int TSN = Int32.Parse(tsn.Text);
            DateTime DefenseDate = DateTime.Parse(DD.Text);
            String DefenseLocation = DL.Text;
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            String temp = "";
            if (Gucian.Selected)
                temp = "AddDefenseGucian";
            else
                temp = "AddDefenseNonGucian";
                SqlCommand def = new SqlCommand(temp, conn);
            def.CommandType = CommandType.StoredProcedure;
            def.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = TSN;
            def.Parameters.Add(new SqlParameter("@DefenseLocation", SqlDbType.VarChar)).Value = DefenseLocation;
            def.Parameters.Add(new SqlParameter("@DefenseDate", SqlDbType.DateTime)).Value = DefenseDate;

            SqlParameter Available = def.Parameters.Add("@available", SqlDbType.Bit);
            Available.Direction = ParameterDirection.Output;

            SqlParameter NotValid = def.Parameters.Add("@notValid", SqlDbType.Bit);
            NotValid.Direction = ParameterDirection.Output;


            if (temp== "AddDefenseNonGucian")
            {
               SqlParameter Cannot = def.Parameters.Add("@cannot", SqlDbType.Bit);
                Cannot.Direction = ParameterDirection.Output;
                conn.Open();
                def.ExecuteNonQuery();
                conn.Close();
                if ((bool)NotValid.Value)
                {
                    error5.Text = "No Available Student For This ThesisSerialNo ";
                    error5.Visible = true;
                    return;
                }
                if ((bool)Available.Value)
                {
                    error5.Text = "This Thesis Has Defense";
                    error5.Visible = true;
                    return;
                }
                if ((bool)Cannot.Value)
                {
                    error5.Text = "This Student Has Grade Less That 50 In at Least One Of The Courses!";
                    error5.Visible = true;
                    return;
                }





                AddNew.Visible = true;
                done.Visible = true;
                return;
            }






            conn.Open();
                def.ExecuteNonQuery();
                conn.Close();
            if ((bool)NotValid.Value)
            {
                error5.Text = "No Available Student For This ThesisSerialNo ";
                error5.Visible = true;
                return;
            }
            if ((bool)Available.Value)
            {
                error5.Text = "This Thesis Has Defense ";
                error5.Visible = true;
                return;
            }
           





            AddNew.Visible = true;
                done.Visible = true;
         
           
           

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website1
{
    public partial class Examiner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand sup = new SqlCommand("DisplayData", conn);
            sup.CommandType = CommandType.StoredProcedure;
            sup.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = Session["user"];
            conn.Open();
            SqlDataReader rdr = sup.ExecuteReader(CommandBehavior.CloseConnection);
            idPlace.Text = "" + Session["user"];
            while (rdr.Read())
            {
                namePlace.Text = rdr.GetString(rdr.GetOrdinal("name"));
                fieldOfWorkPlace.Text = rdr.GetString(rdr.GetOrdinal("fieldOfWork"));

            }
        }

        protected void editProfile_Click(object sender, EventArgs e)
        {
            String connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String name = nameInput.Text;
            String fieldOfWork = placeOfWorkInput.Text;
            if (name == "")
            {
                String x = "Please Enter a Name";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
            }
            else if (fieldOfWork == "")
            {
                String y = "Please Enter Field of Work";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + y + "')", true);
            }
            else
            {

                SqlCommand EditExaminerProfileProc = new SqlCommand("EditExaminerProfile", conn);
                EditExaminerProfileProc.CommandType = CommandType.StoredProcedure;
                EditExaminerProfileProc.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar)).Value = Session["user"];
                EditExaminerProfileProc.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar)).Value = name;
                EditExaminerProfileProc.Parameters.Add(new SqlParameter("@fieldOfWork", SqlDbType.VarChar)).Value = fieldOfWork;

                //Chaning the 3 labels at the heading of the examiner page
                idPlace.Text = "" + Session["user"];
                namePlace.Text = name;
                fieldOfWorkPlace.Text = fieldOfWork;

                conn.Open();
                EditExaminerProfileProc.ExecuteNonQuery();
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("examinerDataList.aspx");
        }

        protected void DefenseDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            String connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String thesisSerialNo = thesisSerialNoInput.Text;
            String defenseDate = defenseDateInput.Text;
            //DateTime defenseDate = Convert.ToDateTime(defenseDateInput.Text);
            String comments = commentInput.Text;


            if (thesisSerialNoInput.Text == "")
            {
                String x = "Please type the Thesis Number of the Thesis you Wish to Comment on";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
            }
            else if (defenseDateInput.Text == "")
            {
                String y = "Defense Date Field Cannot be Empty!";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + y + "')", true);
            }
            else if (commentInput.Text == "")
            {
                String z = "Please Add a Comment!";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + z + "')", true);
            }
            else
            {
                SqlCommand searchForPrimaryKeysDefenseCommentProc = new SqlCommand("searchForPrimaryKeysDefenseComment", conn);
                searchForPrimaryKeysDefenseCommentProc.CommandType = CommandType.StoredProcedure;
                searchForPrimaryKeysDefenseCommentProc.Parameters.Add(new SqlParameter("@x", SqlDbType.Int)).Value = thesisSerialNo;
                searchForPrimaryKeysDefenseCommentProc.Parameters.Add(new SqlParameter("@y", SqlDbType.Date)).Value = defenseDate;
                searchForPrimaryKeysDefenseCommentProc.Parameters.Add(new SqlParameter("@z", SqlDbType.Int)).Value = Session["user"];

                SqlParameter Temp1 = searchForPrimaryKeysDefenseCommentProc.Parameters.Add("@temp1", SqlDbType.Int);
                SqlParameter Temp2 = searchForPrimaryKeysDefenseCommentProc.Parameters.Add("@temp2", SqlDbType.DateTime);
                SqlParameter Temp3 = searchForPrimaryKeysDefenseCommentProc.Parameters.Add("@temp3", SqlDbType.Int);
                Temp1.Direction = ParameterDirection.Output;
                Temp2.Direction = ParameterDirection.Output;
                Temp3.Direction = ParameterDirection.Output;

                conn.Open();
                searchForPrimaryKeysDefenseCommentProc.ExecuteNonQuery();
                conn.Close();

                String a = Temp1.Value.ToString();
                String b = Temp2.Value.ToString();
                String c = Temp3.Value.ToString();

                if (a.Length == 0 || b.Length == 0 || c.Length == 0)
                {
                    String w = "There is no Defense with such Date and Thesis Serial Number in the Database Or you might have no Rights in Commenting on this Defense";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + w + "')", true);
                }
                else
                {

                    SqlCommand AddCommentsGradeProc = new SqlCommand("AddCommentsGrade", conn);
                    AddCommentsGradeProc.CommandType = CommandType.StoredProcedure;
                    AddCommentsGradeProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = thesisSerialNo;
                    AddCommentsGradeProc.Parameters.Add(new SqlParameter("@DefenseDate", SqlDbType.DateTime)).Value = defenseDate;
                    AddCommentsGradeProc.Parameters.Add(new SqlParameter("@comments", SqlDbType.VarChar)).Value = comments;

                    String k = "Comment Submitted Successfully";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + k + "')", true);

                    conn.Open();
                    AddCommentsGradeProc.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

        protected void submitGrade_Click(object sender, EventArgs e)
        {
            String connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String thesisSerialNo = thesisSerialNo2.Text;
            String defenseDate = defenseDate2.Text;
            String grade = thesisGrade.Text;
            if (thesisSerialNo == "")
            {
                String x = "Please type the Thesis Number of the Thesis you Wish to Grade";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
            }
            else if (defenseDate == "")
            {
                String y = "Defense Date Field Cannot be Empty!";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + y + "')", true);
            }
            else if (grade == "")
            {
                String z = "Please Add a Grade!";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + z + "')", true);
            }
            else
            {
                SqlCommand searchForPrimaryKeysDefenseProc = new SqlCommand("searchForPrimaryKeysDefense", conn);
                searchForPrimaryKeysDefenseProc.CommandType = CommandType.StoredProcedure;
                searchForPrimaryKeysDefenseProc.Parameters.Add(new SqlParameter("@x", SqlDbType.Int)).Value = thesisSerialNo;
                searchForPrimaryKeysDefenseProc.Parameters.Add(new SqlParameter("@y", SqlDbType.Date)).Value = defenseDate;
                searchForPrimaryKeysDefenseProc.Parameters.Add(new SqlParameter("@z", SqlDbType.Int)).Value = Session["user"];

                SqlParameter Temp1 = searchForPrimaryKeysDefenseProc.Parameters.Add("@temp1", SqlDbType.Int);
                SqlParameter Temp2 = searchForPrimaryKeysDefenseProc.Parameters.Add("@temp2", SqlDbType.DateTime);
                SqlParameter Temp3 = searchForPrimaryKeysDefenseProc.Parameters.Add("@temp3", SqlDbType.Int);
                Temp1.Direction = ParameterDirection.Output;
                Temp2.Direction = ParameterDirection.Output;
                Temp3.Direction = ParameterDirection.Output;

                conn.Open();
                searchForPrimaryKeysDefenseProc.ExecuteNonQuery();
                conn.Close();

                String a = Temp1.Value.ToString();
                String b = Temp2.Value.ToString();
                String c = Temp3.Value.ToString();

                if (a.Length == 0 || b.Length == 0 || c.Length == 0)
                {
                    String w = "There is no Defense with such Date and Thesis Serial Number in the Database Or You might have no Right to Grade this Defense";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + w + "')", true);
                }
                else
                {

                    SqlCommand AddDefenseGradeProc = new SqlCommand("AddDefenseGrade", conn);
                    AddDefenseGradeProc.CommandType = CommandType.StoredProcedure;
                    AddDefenseGradeProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = thesisSerialNo;
                    AddDefenseGradeProc.Parameters.Add(new SqlParameter("@DefenseDate", SqlDbType.Date)).Value = defenseDate;
                    AddDefenseGradeProc.Parameters.Add(new SqlParameter("@grade", SqlDbType.Decimal)).Value = grade;

                    String k = "Grade Submitted Successfully!";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + k + "')", true);

                    conn.Open();
                    AddDefenseGradeProc.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchThesis.aspx");
        }

        protected void signOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void editPersonalInfo_Click(object sender, EventArgs e)
        {
            String connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String email = emailInput.Text;
            String pass = passInput.Text;
            if (email == "")
            {
                String x = "Please Enter an Email";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
            }
            else if (pass == "")
            {
                String y = "Please Enter a Password";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + y + "')", true);
            }
            else
            {

                SqlCommand editPersonalInformationProc = new SqlCommand("editPersonalInformation", conn);
                editPersonalInformationProc.CommandType = CommandType.StoredProcedure;
                editPersonalInformationProc.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar)).Value = Session["user"];
                editPersonalInformationProc.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = email;
                editPersonalInformationProc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = pass;

                conn.Open();
                editPersonalInformationProc.ExecuteNonQuery();
                conn.Close();

                String k = "Personal Information Changed Successfully!";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + k + "')", true);
            }
        }

    }
}
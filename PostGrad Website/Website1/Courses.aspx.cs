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
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        
        protected void OnAdd(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            bool flag = CourseCode.Text.Length == 0 || CreditHours.Text.Length == 0 ||
                    Fees.Text.Length == 0;
            // at least one is empty
            if (flag)
            {
                String x = "ALL fields should be filled. Please enter any missing values.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
            }
            else
            {
                String code = CourseCode.Text;
                Int32 creditHrs = Int32.Parse(CreditHours.Text);
                Double fees = Double.Parse(Fees.Text);


                SqlCommand addCourse = new SqlCommand("AddCourse", conn);
                addCourse.CommandType = CommandType.StoredProcedure;
                addCourse.Parameters.Add(new SqlParameter("@courseCode", code));
                addCourse.Parameters.Add(new SqlParameter("@creditHrs", creditHrs));
                addCourse.Parameters.Add(new SqlParameter("@fees", SqlDbType.Float)).Value=fees;






                 

                // checks if course that is going to be added is already present or not
                SqlCommand cmd = new SqlCommand("Select @temp=id from Course where code=@x", conn);
                cmd.Parameters.Add(new SqlParameter("@x", code));

                SqlParameter Temp = cmd.Parameters.Add("@temp", SqlDbType.Int);
                Temp.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();


                String a = Temp.Value.ToString();
                //already exists
                if (a.Length != 0)
                {
                    String x = "Course already exists.";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
                }
                else
                {
                    conn.Open();
                    addCourse.ExecuteNonQuery();
                    conn.Close();

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();


                    a = Temp.Value.ToString();
                    String x = "Course " + code + " was added successfully. Course ID is " + a;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);

                }
                

            }



        }





        protected void OnLink(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            bool flag = CourseID.Text.Length == 0 || StudentID.Text.Length == 0;
                   
            // at least one is empty
            if (flag)
            {
                String x = "ALL fields should be filled. Please enter any missing values.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
            }
            else
            {
                Int32 courseID = Int32.Parse(CourseID.Text);
                Int32 studentID = Int32.Parse(StudentID.Text);
                

                SqlCommand linkCourseToStudent = new SqlCommand("linkCourseStudent", conn);
                linkCourseToStudent.CommandType = CommandType.StoredProcedure;
                linkCourseToStudent.Parameters.Add(new SqlParameter("@courseID", courseID));
                linkCourseToStudent.Parameters.Add(new SqlParameter("@studentID", studentID));

                //check the validity of Student ID and Course ID

                SqlCommand cmd = new SqlCommand("Select @temp=id from NonGucianStudent where id=@sid", conn);
                cmd.Parameters.Add(new SqlParameter("@sid", studentID));

                SqlParameter Temp = cmd.Parameters.Add("@temp", SqlDbType.Int);
                Temp.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                String a = Temp.Value.ToString();


                SqlCommand cmd1 = new SqlCommand("Select @temp1=id from Course where id=@cid", conn);
                cmd1.Parameters.Add(new SqlParameter("@cid", courseID));

                SqlParameter Temp1 = cmd1.Parameters.Add("@temp1", SqlDbType.Int);
                Temp1.Direction = ParameterDirection.Output;

                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();
                String a1 = Temp1.Value.ToString();


                SqlCommand cmd2 = new SqlCommand("Select @temp1=sid from NonGucianStudentTakeCourse where cid=@cid1 and sid=@sid1", conn);
                cmd2.Parameters.Add(new SqlParameter("@cid1", courseID));
                cmd2.Parameters.Add(new SqlParameter("@sid1", studentID));

                SqlParameter Temp2 = cmd2.Parameters.Add("@temp1", SqlDbType.Int);
                Temp2.Direction = ParameterDirection.Output;

                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                String a2 = Temp2.Value.ToString();

                //one of them (or both) is invalid
                if (a.Length==0 || a1.Length==0)
                {
                    String x = " Course ID or Student ID doesnt exist. Please enter valid IDs";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);

                }
                // if both already exists in NonGucianTakeCourse(to handle primary key constraint)
                else if (a2.Length!=0)
                {
                    String x = " Course is already to linked to that Student";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
                }

                else
                {
                    conn.Open();
                    linkCourseToStudent.ExecuteNonQuery();
                    conn.Close();

                    String x = "Course with ID " + courseID + " was linked successfully to student with ID " + studentID;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
                }


                

            }



        }

        protected void onAddGrade(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            bool flag = CourseID1.Text.Length == 0 || StudentID1.Text.Length == 0 || Grade.Text.Length==0;

            // at least one is empty
            if (flag)
            {
                String x = "ALL fields should be filled. Please enter any missing values.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
            }
            else
            {
                Int32 courseID = Int32.Parse(CourseID1.Text);
                Int32 studentID = Int32.Parse(StudentID1.Text);
                Double grade=Double.Parse(Grade.Text);

                SqlCommand addGrade = new SqlCommand("addStudentCourseGrade", conn);
                addGrade.CommandType = CommandType.StoredProcedure;
                addGrade.Parameters.Add(new SqlParameter("@courseID", courseID));
                addGrade.Parameters.Add(new SqlParameter("@studentID", studentID));
                addGrade.Parameters.Add(new SqlParameter("@grade", grade));

                //check the validity of Student ID and Course ID

                SqlCommand cmd = new SqlCommand("Select @temp=id from NonGucianStudent where id=@sid", conn);
                cmd.Parameters.Add(new SqlParameter("@sid", studentID));

                SqlParameter Temp = cmd.Parameters.Add("@temp", SqlDbType.Int);
                Temp.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                String a = Temp.Value.ToString();


                SqlCommand cmd1 = new SqlCommand("Select @temp1=id from Course where id=@cid", conn);
                cmd1.Parameters.Add(new SqlParameter("@cid", courseID));

                SqlParameter Temp1 = cmd1.Parameters.Add("@temp1", SqlDbType.Int);
                Temp1.Direction = ParameterDirection.Output;

                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();
                String a1 = Temp1.Value.ToString();

                //checks if this course is linked to a non gucian student or not
                SqlCommand cmd2 = new SqlCommand("Select @temp2=sid from NonGucianStudentTakeCourse where cid=@cid1 and sid=@sid1", conn);
                cmd2.Parameters.Add(new SqlParameter("@cid1", courseID));
                cmd2.Parameters.Add(new SqlParameter("@sid1", studentID));

                SqlParameter Temp2 = cmd2.Parameters.Add("@temp2", SqlDbType.Int);
                Temp2.Direction = ParameterDirection.Output;

                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                String a2 = Temp2.Value.ToString();

                //one of them (or both) is invalid
                if (a.Length == 0 || a1.Length == 0)
                {
                    String x = " Course ID or Student ID doesnt exist. Please enter valid IDs";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);

                }
                // if both are not linked together in NonGucianStudentTakesCourse
                else if (a2.Length == 0)
                {
                    String x = " Course is not linked to that Student";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
                }

                else
                {
                    conn.Open();
                    addGrade.ExecuteNonQuery();
                    conn.Close();

                    String x = "Grade of Course " + courseID + " was added successfully to student with ID " + studentID;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
                }




            }



        }


    }
}
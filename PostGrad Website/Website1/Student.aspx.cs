using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Website1
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            theses.Visible = false;
            profile.Visible = false;
            courses.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;
            Label11.Visible = false;
            serialNumber.Visible = false;
            progressReportDate.Visible = false;
            progNo.Visible = false;
            submit1.Visible = false;
            Title.Visible = false;
            pubdate.Visible = false;
            host.Visible = false;
            place.Visible = false;
            Radio.Visible = false;
            submit3.Visible = false;
            TextBox1.Visible = false;
            serial2.Visible = false;
            TextBox2.Visible = false;
            prg.Visible = false;
            state1.Visible = false;
            des.Visible = false;
            Label12.Visible = false;
            Label13.Visible = false;
            Label14.Visible = false;
            Label15.Visible = false;
            submits.Visible = false;
            linkpub.Visible = false;









        }
        protected void viewprofile(object sender, EventArgs e)
        {
            profile.Visible = true;
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view_prof = new SqlCommand("viewMyProfile", conn);
            view_prof.CommandType = CommandType.StoredProcedure;
            view_prof.Parameters.Add(new SqlParameter("@studentId", Session["user"]));


            conn.Open();

            SqlDataReader rdr = view_prof.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 stdID = rdr.GetInt32(rdr.GetOrdinal("id"));
                String firstname = "";
                try
                {
                    firstname = rdr.GetString(rdr.GetOrdinal("firstname"));
                }
                catch (Exception e1)
                {

                }

                String lastname = "";
                try
                {
                    lastname = rdr.GetString(rdr.GetOrdinal("lastName"));
                }
                catch (Exception e1)
                {

                }

                string type = "0";
                try
                {
                    type = rdr.GetString(rdr.GetOrdinal("Type"));
                }
                catch (Exception e1)
                {

                }

                String faculty = "";
                try
                {
                    faculty = rdr.GetString(rdr.GetOrdinal("faculty"));
                }
                catch (Exception e1)
                {

                }

                String address = "";
                try
                {
                    address = rdr.GetString(rdr.GetOrdinal("address"));
                }
                catch (Exception e1)
                {

                }

                decimal gpa = 0;
                try
                {
                    gpa = rdr.GetDecimal(rdr.GetOrdinal("GPA"));
                }
                catch (Exception e1)
                {

                }


                int undergradId = 0;
                try
                {
                    undergradId = rdr.GetInt32(rdr.GetOrdinal("undergardID")); ;
                }
                catch (Exception e1)
                {

                }

                HtmlTableRow Rows = new HtmlTableRow();
                HtmlTableCell id1 = new HtmlTableCell();
                id1.InnerText = "" + stdID;
                HtmlTableCell firstname1 = new HtmlTableCell();
                firstname1.InnerText = firstname;
                HtmlTableCell lastname1 = new HtmlTableCell();
                lastname1.InnerText = lastname;
                HtmlTableCell type1 = new HtmlTableCell();
                type1.InnerText = type;
                HtmlTableCell faculty1 = new HtmlTableCell();
                faculty1.InnerText = faculty;
                HtmlTableCell address1 = new HtmlTableCell();
                address1.InnerText = address;
                HtmlTableCell gpa1 = new HtmlTableCell();
                gpa1.InnerText = "" + gpa;
                HtmlTableCell undergrad1 = new HtmlTableCell();
                undergrad1.InnerText = "" + undergradId;

                Rows.Controls.Add(id1);
                Rows.Controls.Add(firstname1);
                Rows.Controls.Add(lastname1);
                Rows.Controls.Add(type1);
                Rows.Controls.Add(faculty1);
                Rows.Controls.Add(address1);
                Rows.Controls.Add(gpa1);
                Rows.Controls.Add(undergrad1);

                profile.Rows.Add(Rows);

            }

            conn.Close();

        }

        protected void viewMyThesis(object sender, EventArgs e)
        {
            theses.Visible = true;
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view_theses = new SqlCommand("viewTheses", conn);
            view_theses.CommandType = CommandType.StoredProcedure;
            view_theses.Parameters.Add(new SqlParameter("@studentId", Session["user"]));
            conn.Open();
            SqlDataReader rdr = view_theses.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 serialNo = rdr.GetInt32(rdr.GetOrdinal("serialNumber"));
                String field = "";
                try
                {
                    field = rdr.GetString(rdr.GetOrdinal("field"));
                }
                catch (Exception e1)
                {

                }

                String type = "";
                try
                {
                    type = rdr.GetString(rdr.GetOrdinal("type"));
                }
                catch (Exception e1)
                {

                }

                String title = "";
                try
                {
                    title = rdr.GetString(rdr.GetOrdinal("title"));
                }
                catch (Exception e1)
                {

                }

                DateTime startDate = rdr.GetDateTime(rdr.GetOrdinal("startDate"));
                DateTime endDate = rdr.GetDateTime(rdr.GetOrdinal("endDate"));
                DateTime defenceDate = rdr.GetDateTime(rdr.GetOrdinal("defenseDate"));
                int years = 0;
                try
                {
                    years = rdr.GetInt32(rdr.GetOrdinal("years"));
                }
                catch (Exception e1)
                {

                }
                decimal grade = 0;
                try
                {
                    grade = rdr.GetDecimal(rdr.GetOrdinal("grade"));
                }
                catch (Exception e1)
                {

                }

                int payment_id = 0;
                try
                {
                    payment_id = rdr.GetInt32(rdr.GetOrdinal("payment_id"));
                }
                catch (Exception e1)
                {

                }

                int noext = 0;
                try
                {
                    noext = rdr.GetInt32(rdr.GetOrdinal("noOfExtensions"));
                }
                catch (Exception e1)
                {

                }


                HtmlTableRow Rows = new HtmlTableRow();

                HtmlTableCell serialNo1 = new HtmlTableCell();
                serialNo1.InnerText = "" + serialNo;
                HtmlTableCell field1 = new HtmlTableCell();
                field1.InnerText = field;
                HtmlTableCell type1 = new HtmlTableCell();
                type1.InnerText = type;
                HtmlTableCell title1 = new HtmlTableCell();
                title1.InnerText = title;
                HtmlTableCell startdate1 = new HtmlTableCell();
                startdate1.InnerText = "" + startDate;
                HtmlTableCell enddate1 = new HtmlTableCell();
                enddate1.InnerText = "" + endDate;
                HtmlTableCell defencedate1 = new HtmlTableCell();
                defencedate1.InnerText = "" + defenceDate;
                HtmlTableCell years1 = new HtmlTableCell();
                years1.InnerText = "" + years;
                HtmlTableCell grade1 = new HtmlTableCell();
                grade1.InnerText = "" + grade;
                HtmlTableCell payment_id1 = new HtmlTableCell();
                payment_id1.InnerText = "" + payment_id;
                HtmlTableCell noext1 = new HtmlTableCell();
                noext1.InnerText = "" + noext;

                Rows.Controls.Add(serialNo1);
                Rows.Controls.Add(field1);
                Rows.Controls.Add(type1);
                Rows.Controls.Add(title1);
                Rows.Controls.Add(startdate1);
                Rows.Controls.Add(enddate1);
                Rows.Controls.Add(defencedate1);
                Rows.Controls.Add(years1);
                Rows.Controls.Add(grade1);
                Rows.Controls.Add(payment_id1);
                Rows.Controls.Add(noext1);

                theses.Rows.Add(Rows);

            }
            conn.Close();
        }

        protected void viewcourses(object sender, EventArgs e)
        {
            courses.Visible = true;
            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view_courses = new SqlCommand("courses", conn);
            view_courses.CommandType = CommandType.StoredProcedure;
            view_courses.Parameters.Add(new SqlParameter("@studentId", Session["user"]));
            SqlParameter Available = view_courses.Parameters.Add("@success", SqlDbType.Bit);
            Available.Direction = ParameterDirection.Output;

            conn.Open();
            view_courses.ExecuteNonQuery();
            conn.Close();

            if (Available.Value.ToString() == "True")
            {

                conn.Open();
                SqlDataReader rdr = view_courses.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    int cid = rdr.GetInt32(rdr.GetOrdinal("cid"));
                    //decimal grade = rdr.GetDecimal(rdr.GetOrdinal("grade"));

                    HtmlTableRow tRow = new HtmlTableRow();

                    HtmlTableCell cid1 = new HtmlTableCell();
                    cid1.InnerText = "" + cid;

                    HtmlTableCell grade1 = new HtmlTableCell();
                    grade1.InnerText = "" + rdr.GetValue(rdr.GetOrdinal("grade"));


                    tRow.Controls.Add(cid1);
                    tRow.Controls.Add(grade1);


                    courses.Rows.Add(tRow);

                }
                conn.Close();
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('coures not found!')", true);
        }

        protected void submit(object sender, EventArgs e)
        {

            long serial = 0;
            if (serialNumber.Text.Length == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "serial number must be inserted" + "')", true);
            }
            else
            {
                serial = Int64.Parse(serialNumber.Text);
            }
            String progDate = "";
            if (progressReportDate.Text.Length == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "progress report date must be inserted" + "')", true);
            }
            else
            {
                progDate = progressReportDate.Text;
            }

            string progNo1 = "";
            if (progNo.Text.Length == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "progress report number must be inserted" + "')", true);
            }
            else
            {
                progNo1 = progNo.Text;

            }

            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand add_prog = new SqlCommand("linkTheses2", conn);
            add_prog.CommandType = CommandType.StoredProcedure;
            add_prog.Parameters.Add(new SqlParameter("@studentId", Session["user"]));
            add_prog.Parameters.Add(new SqlParameter("@serialNo", serial));
            // add_pub.Parameters.Add(new SqlParameter("@progressReportDate", progDate));//
            //  add_pub.Parameters.Add(new SqlParameter("@studentId", Session["user"]));
            // add_pub.Parameters.Add(new SqlParameter("@progressReportNo", progNo));//

            SqlParameter Available = add_prog.Parameters.Add("@success", SqlDbType.Bit);
            Available.Direction = ParameterDirection.Output;
            conn.Open();
            add_prog.ExecuteNonQuery();
            conn.Close();
            String StudID = Session["user"].ToString();
            if (Available.Value.ToString() == "True")
            {
                DateTime dt = Convert.ToDateTime(progDate);


                SqlCommand add_pub2 = new SqlCommand("addProgressReport", conn);
                add_pub2.CommandType = CommandType.StoredProcedure;
                add_pub2.Parameters.Add(new SqlParameter("@thesisSerialNo", serial));
                add_pub2.Parameters.Add(new SqlParameter("@progressReportDate", dt));
                add_pub2.Parameters.Add(new SqlParameter("@studentId", Session["user"]));
                add_pub2.Parameters.Add(new SqlParameter("@progressReportNo", progNo1));

                conn.Open();
                add_pub2.ExecuteNonQuery();
                conn.Close();

                String x = "Submitted successfully";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('thesis not found !')", true);

            }


        }



        protected void submit3_Click(object sender, EventArgs e)
        {

            string title1 = "";
            if (Title.Text.Length == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "title must be inserted" + "')", true);
            }
            else
            {
                title1 = Title.Text;
            }

            String pubdate1 = "";
            if (pubdate.Text.Length == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "publication date must be inserted" + "')", true);
            }
            else
            {
                pubdate1 = pubdate.Text;
            }
            DateTime dt = Convert.ToDateTime(pubdate1);


            string host1 = "";
            if (host.Text.Length == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "host must be inserted" + "')", true);
            }
            else
            {
                host1 = host.Text;
            }


            string place1 = "";
            if (place.Text.Length == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "place must be inserted" + "')", true);
            }
            else
            {
                place1 = place.Text;
            }

            int temp = 0;
            if (!accepted.Selected && !notaccepted.Selected)
            {

            }

            else
            {

                if (accepted.Selected)
                {
                    temp = 1;
                }
                else
                if (notaccepted.Selected)
                {
                    temp = 0;
                }
            }

            String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (title1.Length == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have to insert your title !')", true);

            }
            else if (pubdate1.Length == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have to insert publication date !')", true);

            }
            else
            {
                SqlCommand add_pub = new SqlCommand("addPublication", conn);
                add_pub.CommandType = CommandType.StoredProcedure;
                add_pub.Parameters.Add(new SqlParameter("@title", title1));
                add_pub.Parameters.Add(new SqlParameter("@pubDate", dt));
                add_pub.Parameters.Add(new SqlParameter("@host", host1));
                add_pub.Parameters.Add(new SqlParameter("@place", place1));
                add_pub.Parameters.Add(new SqlParameter("@accepted", temp));



                conn.Open();
                add_pub.ExecuteNonQuery();
                conn.Close();

                String x = "Submitted successfully";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);
            }


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Title.Visible = true;
            pubdate.Visible = true;
            host.Visible = true;
            place.Visible = true;
            Radio.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label4.Visible = true;
            submit3.Visible = true;

        }

        protected void addprog(object sender, EventArgs e)
        {
            serialNumber.Visible = true;
            progressReportDate.Visible = true;
            progNo.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            submit1.Visible = true;


        }

        protected void acceptance(object sender, EventArgs e)
        {

        }

        protected void submits_Click(object sender, EventArgs e)
        {
            long serial = 0;
            if (serial2.Text.Length == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "serial number must be inserted" + "')", true);
            }
            else
            {
                serial = Int64.Parse(serial2.Text);
            }

            long prognum = 0;
            if (prg.Text.Length == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "progress report number must be inserted" + "')", true);
            }
            else
            {
                prognum = Int64.Parse(prg.Text);
            }


            long state2 = 0;
            if (state1.Text.Length == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "state must be inserted" + "')", true);
            }
            else
            {
                state2 = Int64.Parse(state1.Text);
            }


            string descr = "";
            if (des.Text.Length == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "description must be inserted" + "')", true);
            }
            else
            {
                descr = des.Text;
            }


            if (serial.Equals((int)0))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have to insert serial number !')", true);

            }
            else if (prognum.Equals((int)0))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have to insert progress report number !')", true);

            }
            else
            {
                String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand add_prog = new SqlCommand("linkTheses2", conn);
                add_prog.CommandType = CommandType.StoredProcedure;
                add_prog.Parameters.Add(new SqlParameter("@studentId", Session["user"]));
                add_prog.Parameters.Add(new SqlParameter("@serialNo", serial));
                SqlParameter Available = add_prog.Parameters.Add("@success", SqlDbType.Bit);
                Available.Direction = ParameterDirection.Output;
                conn.Open();
                add_prog.ExecuteNonQuery();
                conn.Close();
                String StudID = Session["user"].ToString();
                if (Available.Value.ToString() == "True")
                {
                    SqlCommand add_pub2 = new SqlCommand("fillProgressReport", conn);
                    add_pub2.CommandType = CommandType.StoredProcedure;
                    add_pub2.Parameters.Add(new SqlParameter("@thesisSerialNo", serial));
                    add_pub2.Parameters.Add(new SqlParameter("@progressReportNo", prognum));
                    add_pub2.Parameters.Add(new SqlParameter("@description", descr));
                    add_pub2.Parameters.Add(new SqlParameter("@state", state2));
                    add_pub2.Parameters.Add(new SqlParameter("@studentId", Session["user"]));


                    conn.Open();
                    add_pub2.ExecuteNonQuery();
                    conn.Close();

                    String x = "Submitted successfully";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('thesis not found !')", true);

                }
            }

        }

        protected void fill_Click(object sender, EventArgs e)
        {
            serial2.Visible = true;
            prg.Visible = true;
            state1.Visible = true;
            des.Visible = true;
            Label12.Visible = true;
            Label13.Visible = true;
            Label14.Visible = true;
            Label15.Visible = true;
            submits.Visible = true;

        }

        protected void linkpub_Click(object sender, EventArgs e)
        {

            long serial = 0;
            if (TextBox1.Text.Length == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "serial number must be inserted" + "')", true);
            }
            else
            {
                serial = Int64.Parse(TextBox1.Text);
            }

            long pubid = 0;
            if (TextBox2.Text.Length == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "publication id must be inserted" + "')", true);
            }
            else
            {
                pubid = Int64.Parse(TextBox2.Text);
            }


            if (serial.Equals((int)0))

            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have to insert serial number !')", true);

            }
            else
            if (pubid.Equals((int)0))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have to insert your publication id !')", true);

            }
            else
            {
                String connStr = WebConfigurationManager.ConnectionStrings["DB"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand add_prog = new SqlCommand("linkTheses2", conn);
                add_prog.CommandType = CommandType.StoredProcedure;
                add_prog.Parameters.Add(new SqlParameter("@studentId", Session["user"]));
                add_prog.Parameters.Add(new SqlParameter("@serialNo", serial));
                SqlParameter Available = add_prog.Parameters.Add("@success", SqlDbType.Bit);
                Available.Direction = ParameterDirection.Output;
                conn.Open();
                add_prog.ExecuteNonQuery();
                conn.Close();


                if (Available.Value.ToString() == "True")
                {
                    SqlCommand add_pub2 = new SqlCommand("linkPubThesis", conn);
                    add_pub2.CommandType = CommandType.StoredProcedure;
                    add_pub2.Parameters.Add(new SqlParameter("@thesisSerialNo", serial));
                    add_pub2.Parameters.Add(new SqlParameter("@PubID", pubid));



                    conn.Open();
                    add_pub2.ExecuteNonQuery();
                    conn.Close();

                    String x = "Submitted successfully";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + x + "')", true);


                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('thesis not found !')", true);
                }
            }
        }

        protected void links_Click(object sender, EventArgs e)
        {
            Label9.Visible = true;
            Label11.Visible = true;
            TextBox2.Visible = true;
            TextBox1.Visible = true;
            linkpub.Visible = true;

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mobile.aspx");
        }
    }

}
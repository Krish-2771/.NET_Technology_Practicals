using System;

namespace AttendanceReport
{
    public partial class AcademicCalender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check Login Session

            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }


            if (!IsPostBack)
            {
                // Display success message

                if (Session["LeaveSuccessMessage"] != null)
                {
                    lblSuccess.Text =
                        Session["LeaveSuccessMessage"].ToString();

                    Session.Remove("LeaveSuccessMessage");
                }
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Calendar1.SelectedDate;
            lblDate.Text = "Selected Date: " + selectedDate.ToString("dd-MM-yyyy");
            Session["SelectedDate"] = selectedDate.ToString("dd-MM-yyyy");
        }

        protected void btnAttendance_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate == DateTime.MinValue)
            {
                lblDate.Text = "Please select a date first.";
                return;
            }

            Session["AttendanceDate"] = Calendar1.SelectedDate.ToString("dd-MM-yyyy");
            Response.Write("<script>alert('Attendance submitted successfully!');</script>");
        }


        protected void btnLeave_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate == DateTime.MinValue)
            {
                lblDate.Text = "Please select a date first.";
                return;
            }

            Session["SelectedDate"] = Calendar1.SelectedDate.ToString("dd-MM-yyyy");
            Response.Redirect("LeaveReport.aspx");
        }
    }
}
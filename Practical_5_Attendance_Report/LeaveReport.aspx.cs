using System;

namespace AcademicCalendarPractical
{
    public partial class LeaveReport : System.Web.UI.Page
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
                // Get selected date from Session

                if (Session["SelectedDate"] != null)
                {
                    lblSelectedDate.Text = Session["SelectedDate"].ToString();

                    DateTime date;

                    if (DateTime.TryParse(Session["SelectedDate"].ToString(),out date))
                    {
                        txtFromDate.Text = date.ToString("yyyy-MM-dd");
                    }
                }
                else
                {
                    lblSelectedDate.Text = "No date selected";
                }
            }
        }

        //Submit
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Store success message in Session
                Session["LeaveSuccessMessage"] = "Leave application submitted successfully!";

                // Redirect to Home Page
                Response.Redirect("AcademicCalender.aspx");
            }
        }

        // Logout
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear all Session data

            Session.Clear();

            Session.Abandon();


            // Redirect to Login Page

            Response.Redirect("Login.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceReport
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check Remember Me cookie

                if (Request.Cookies["RememberUser"] != null)
                {
                    txtUserID.Text =
                        Request.Cookies["RememberUser"].Value;

                    chkRemember.Checked = true;
                }
            }
        }


        protected void btnLogin_Click(
            object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Simple login for practical
                // User ID: student
                // Password: 12345

                if (txtUserID.Text == "student" &&
                    txtPassword.Text == "12345")
                {
                    // Create Session

                    Session["UserID"] = txtUserID.Text;


                    // Remember Me Cookie

                    if (chkRemember.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("RememberUser");

                        cookie.Value = txtUserID.Text;

                        cookie.Expires = DateTime.Now.AddDays(7);

                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        // Delete existing cookie

                        if (Request.Cookies["RememberUser"] != null)
                        {
                            HttpCookie cookie = new HttpCookie("RememberUser");

                            cookie.Expires = DateTime.Now.AddDays(-1);

                            Response.Cookies.Add(cookie);
                        }
                    }


                    // Redirect to Home Page

                    Response.Redirect("AcademicCalender.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid User ID or Password.";
                }
            }
        }
    }
}
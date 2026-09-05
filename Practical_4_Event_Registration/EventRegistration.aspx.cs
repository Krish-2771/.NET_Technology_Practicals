using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Event_Registration
{
    public partial class EventRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void calEventDate_SelectionChanged(object sender, EventArgs e)
        {
            lblDate.Text = calEventDate.SelectedDate.ToShortDateString();
        }
        protected void btnRegister_Click(
            object sender,
            EventArgs e)
        {
            if (Page.IsValid)
            {
                lblMessage.Text =
                    "Registration Successful! Welcome " +
                    txtName.Text;
            }
        }

        protected void btnClear_Click(
            object sender,
            EventArgs e)
        {
            txtName.Text = "";
            txtEnrollment.Text = "";
            txtEmail.Text = "";
            txtAge.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";

            ddlBranch.SelectedIndex = 0;

            rblGender.ClearSelection();

            foreach (ListItem item in cblEvent.Items)
            {
                item.Selected = false;
            }

            calEventDate.SelectedDates.Clear();
            lblDate.Text = "";

            lblMessage.Text = "";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER.Admin
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string firstName = txtFirstname.Text;
            string lastName = txtLastname.Text;
            string hashedPassword = UserManagement.CalculateHash(txtPassword.Text);
            string userLevel = dropUserLevel.SelectedValue;
            string accessStatus = dropAccessStatus.SelectedValue;

            if(UserManagement.DoesUserExists(username) == false)
            {
                UserManagement.RegisterUser(username, firstName, lastName, hashedPassword, userLevel, accessStatus);
                Response.Redirect("ListUsers.aspx", true);
            }
            else
            {
                lblFeedback.Text = "This user already exists.";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListUsers.aspx", true);
        }
    }
}
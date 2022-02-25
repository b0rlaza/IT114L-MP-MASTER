using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if(txtPass1.Text != txtPass2.Text)
            {
                lblFeedback.Text = "Passwords do not match.";
            }
            else if(UserManagement.DoesUserExists(txtUsername.Text))
            {
                lblFeedback.Text = "Account with the same username already exists.";
            }
            else
            {
                string username = txtUsername.Text;
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string hashedPassword = UserManagement.CalculateHash(txtPass1.Text);

                UserManagement.RegisterUser(username, firstName, lastName, hashedPassword, "Customer", "Allowed");
                Response.Redirect("~/Login.aspx", true);
            }
        }
    }
}
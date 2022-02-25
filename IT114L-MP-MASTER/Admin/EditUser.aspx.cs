using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER.Admin
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Page.IsPostBack == false)
            {
                int userID;
                int.TryParse(Request.QueryString["user-id"], out userID);

                lblUserID.Text = userID.ToString();
                txtUsername.Text = UserManagement.GetUsername(userID);
                txtFirstName.Text = UserManagement.GetFirstName(userID);
                txtLastName.Text = UserManagement.GetLastName(userID);
                txtAddress.Text = UserManagement.GetAddress(userID);
                txtContact.Text = UserManagement.GetContact(userID);
                dropUserLevel.SelectedValue = UserManagement.GetUserLevel(userID);
                dropAccessStatus.SelectedValue = UserManagement.GetStatus(userID);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(lblUserID.Text);
            string username = txtUsername.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string contact = txtContact.Text;
            string userLevel = dropUserLevel.SelectedValue;
            string accessStatus = dropAccessStatus.SelectedValue;

            UserManagement.UpdateUser(userID, username, firstName, lastName, address, contact, userLevel, accessStatus);
            Response.Redirect("ListUsers.aspx", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListUsers.aspx", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(lblUserID.Text);
            UserManagement.DeleteUser(userID);
        }
    }
}
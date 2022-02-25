using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER
{
    public partial class ManageAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            int userID= -1;
            if (Request.Cookies["user-id"] == null || Request.Cookies["user-id"].Value == "")
            {
                Response.Redirect("~/Login.aspx", true);
            }
            else if (Request.Cookies["user-id"] != null || Request.Cookies["user-id"].Value != "")
            {
                int.TryParse(Request.Cookies["user-id"].Value, out userID);
            }

            if(Page.IsPostBack == false)
            {
                lblUsername.Text = UserManagement.GetUsername(userID);
                txtFirstname.Text = UserManagement.GetFirstName(userID);
                txtLastname.Text = UserManagement.GetLastName(userID);
                txtContact.Text = UserManagement.GetContact(userID);
                txtAddress.Text = UserManagement.GetAddress(userID);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstname.Text;
            string lastName = txtLastname.Text;
            string contact = txtContact.Text;
            string address = txtAddress.Text;
            int userID = UserManagement.GetUserID(lblUsername.Text);

            if(txtCurrentPass.Text == String.Empty)
            {
                UserManagement.UpdateUser(userID, firstName, lastName, address, contact);
                Response.Redirect("~/MyAccount.aspx", true);
            }
            //else if (txtCurrentPass.Text != null || txtCurrentPass.Text != "")
            else
            {
                if (UserManagement.IsSuccessfulAuth(lblUsername.Text, txtCurrentPass.Text))
                {
                    if(txtNewPass1.Text == txtNewPass2.Text)
                    {
                        UserManagement.UpdateUser(userID, firstName, lastName, address, contact);
                        UserManagement.ChangePassword(lblUsername.Text, txtNewPass1.Text);
                        Response.Redirect("~/MyAccount.aspx", true);
                    }
                    else
                    {
                        lblFeedback.Text = "Password Change Failed"; ;
                    }
                }
                else
                {
                    lblFeedback.Text = "Password Change Failed";
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyAccount.aspx", true);
        }
    }
}
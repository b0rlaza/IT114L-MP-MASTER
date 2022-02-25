using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if(UserManagement.IsSuccessfulAuth(username,password))
            {
                if(UserManagement.GetStatus(username) == "Allowed")
                {
                    HttpCookie cookie = new HttpCookie("user-id");
                    cookie.Value = UserManagement.GetUserID(username).ToString();
                    //cookie.Domain = "localhost";
                    cookie.Expires = DateTime.Now.AddHours(5);
                    Response.SetCookie(cookie);

                    if (UserManagement.GetUserLevel(username) == "Customer")
                    {
                        Response.Redirect("~/Default.aspx", true);
                    }
                    else
                    {
                        Response.Redirect("~/Admin/Admin.aspx", true);
                    }
                }
                else
                {
                    lblFeedback.Text = "This user account has been deactivated";
                }
            }
            else
            {
                lblFeedback.Text = "Login Failed";
            }
        }
    }
}
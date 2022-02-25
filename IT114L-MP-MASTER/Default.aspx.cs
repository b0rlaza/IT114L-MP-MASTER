using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if(Request.Cookies["user-id"] == null || Request.Cookies["user-id"].Value == "")
            {
                btnLogin.Visible = true;
                btnLogout.Visible = false;
                lblGreetings.Text = "Welcome to PETS";
            }
            else
            {
                int userID;
                int.TryParse(Request.Cookies["user-id"].Value, out userID);
                lblGreetings.Text = "Hello, " + UserManagement.GetFirstName(userID);
                btnLogin.Visible = false;
                btnLogout.Visible = true;
            }*/
        }
        /*
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", true);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.SetCookie(new HttpCookie("user-id", ""));
            btnLogin.Visible = true;
            btnLogout.Visible = false;
            lblGreetings.Text = "Welcome to PETS";
        }
        */
    }
}
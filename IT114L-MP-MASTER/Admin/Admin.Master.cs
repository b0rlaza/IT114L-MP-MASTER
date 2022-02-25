using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user-id"] == null || Request.Cookies["user-id"].Value == "")
            {
                Response.Redirect("~/Login.aspx", true);
            }
            else
            {
                int userID;
                int.TryParse(Request.Cookies["user-id"].Value, out userID);

                if (UserManagement.GetUserLevel(userID) == "Customer")
                {
                    Response.Redirect("~/Default.aspx", true);
                }
                else
                {
                    lblName.Text = UserManagement.GetFirstName(userID) + " " + UserManagement.GetLastName(userID);
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.SetCookie(new HttpCookie("user-id", ""));
            Response.Redirect("~/Login.aspx", true);
        }
    }
}
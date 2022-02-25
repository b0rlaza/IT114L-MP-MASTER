using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER
{
    public partial class Frontend : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            int userID;

            if (Request.Cookies["user-id"] == null || Request.Cookies["user-id"].Value == "")
            {
                linkMyAccount.Text = "Login";
                linkMyAccount.NavigateUrl = "~/Login.aspx";
                linkBtnLogout.Visible = false;
                linkAdminPanel.Visible = false;
            }
            else if (Request.Cookies["user-id"] != null || Request.Cookies["user-id"].Value != "")
            {
                int.TryParse(Request.Cookies["user-id"].Value, out userID);
                linkMyAccount.Text = "My Account";
                linkMyAccount.NavigateUrl = "~/MyAccount.aspx";
                linkBtnLogout.Visible = true;

                if(UserManagement.GetUserLevel(userID) != "Customer")
                {
                    linkAdminPanel.Visible = true;
                }
                else
                {
                    linkAdminPanel.Visible = false;
                }
            }
        }

        protected void linkBtnLogout_Click(object sender, EventArgs e)
        {
            Response.SetCookie(new HttpCookie("user-id", ""));
            Response.Redirect("~/Default.aspx", true);
        }
    }
}
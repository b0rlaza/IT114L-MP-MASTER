using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace IT114L_MP_MASTER
{
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int userID = -1;
                if (Request.Cookies["user-id"] == null || Request.Cookies["user-id"].Value == "")
                {
                    Response.Redirect("~/Login.aspx", true);
                }
                else if (Request.Cookies["user-id"] != null || Request.Cookies["user-id"].Value == "")
                {
                    int.TryParse(Request.Cookies["user-id"].Value, out userID);
                    lblUsername.Text = UserManagement.GetUsername(userID);
                    lblFirstName.Text = UserManagement.GetFirstName(userID);
                    lblLastName.Text = UserManagement.GetLastName(userID);
                    lblContact.Text = UserManagement.GetContact(userID);
                    lblAddress.Text = UserManagement.GetAddress(userID);

                    string dbConn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
                    //string query = "select * from UserAccountTBL";
                    string query = $"select ps.transaction_id, ps.transaction_date, p.name, ps.quantity, ps.total_invoice, ps.payment_status, d.type, d.status, d.estimate_arrival from ProductSalesTBL ps left join DeliveryTBL d on ps.transaction_id=d.delivery_id left join ProductTBL p on ps.product_id=p.product_id where ps.user_id={userID}";

                    SqlConnection connection = new SqlConnection(dbConn);
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    gridPurchases.DataSource = reader;
                    gridPurchases.DataBind();
                    connection.Close();
                }
                else
                {
                    Response.Redirect("~/Login.aspx", true);
                }
            }
            catch
            {

            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageAccount.aspx", true);
        }
    }
}
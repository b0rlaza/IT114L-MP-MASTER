using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace IT114L_MP_MASTER.Admin
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                string dbconn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
                string query = $"select count(*), sum(total_invoice) from ProductSalesTBL where transaction_date='{date}'";

                string orderCount = "";
                string totalAmount = "";

                try
                {
                    using (SqlConnection connection = new SqlConnection(dbconn))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            orderCount = reader.GetInt32(0).ToString();
                            totalAmount = reader.GetDecimal(1).ToString();
                        }
                        connection.Close();
                    };
                    lblNoOrders.Text = orderCount;
                    lblAmtSold.Text = totalAmount;
                    txtSalesDate.Text = date;
                }
                catch
                {

                }
            }
        }

        protected void txtSalesDate_TextChanged(object sender, EventArgs e)
        {
            string date = txtSalesDate.Text;
            string dbconn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            string query = $"select count(*), sum(total_invoice) from ProductSalesTBL where transaction_date='{date}'";

            string orderCount = "";
            string totalAmount = "";

            using (SqlConnection connection = new SqlConnection(dbconn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    orderCount = reader.GetInt32(0).ToString();
                    if(reader.IsDBNull(1) == false)
                    {
                        totalAmount = reader.GetDecimal(1).ToString();
                    }
                    else
                    {
                        totalAmount = "0.00";
                    }
                }
                connection.Close();
            };
            lblNoOrders.Text = orderCount;
            lblAmtSold.Text = totalAmount;
        }
    }
}
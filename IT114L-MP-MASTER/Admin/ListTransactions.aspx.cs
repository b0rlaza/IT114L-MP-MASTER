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
    public partial class ListTransactions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbConn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            
            try
            {
                string query = "select ps.transaction_id, p.name, ps.quantity, ps.total_invoice, ps.payment_status, ps.transaction_date from ProductSalesTBL ps left join ProductTBL p on ps.product_id=p.product_id";

                SqlConnection connection = new SqlConnection(dbConn);
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                gridTransactions.DataSource = reader;
                gridTransactions.DataBind();
                connection.Close();
            }
            catch
            {

            }
        }
    }
}
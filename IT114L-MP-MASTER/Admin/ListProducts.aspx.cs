using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER.Admin
{
    public partial class ListProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string dbConn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
                string query = "select product_id, name, price, qty_stock, qty_sold, status from ProductTBL";

                SqlConnection connection = new SqlConnection(dbConn);
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                gridProducts.DataSource = reader;
                gridProducts.DataBind();
                connection.Close();
            }
            catch
            {

            }
        }
    }
}
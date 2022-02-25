using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace IT114L_MP_MASTER.Admin
{
    public partial class ListDeliveries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbConn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            try
            {
                string query = "select delivery_id, transaction_id, type, name, contact, status, estimate_arrival from DeliveryTBL";

                SqlConnection connection = new SqlConnection(dbConn);
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                gridDeliveries.DataSource = reader;
                gridDeliveries.DataBind();
                connection.Close();
            }
            catch
            {

            }
        }
    }
}
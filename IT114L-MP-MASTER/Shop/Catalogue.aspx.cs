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
    public partial class Catalogue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbConn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            //string query = "select * from UserAccountTBL";
            string query = "select product_id, name, price, status from ProductTBL";

            SqlConnection connection = new SqlConnection(dbConn);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            gridProducts.DataSource = reader;
            gridProducts.DataBind();
            connection.Close();
        }
    }
}
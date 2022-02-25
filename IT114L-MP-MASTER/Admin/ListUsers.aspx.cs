using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace IT114L_MP_MASTER.Admin
{
    public partial class ListUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string dbConn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
                //string query = "select * from UserAccountTBL";
                string query = "select user_id, username, first_name, last_name, format(date_created, 'dd-MM-yyyy') as 'date_created', user_level, access_status from UserAccountTBL";

                SqlConnection connection = new SqlConnection(dbConn);
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                gridUsers.DataSource = reader;
                gridUsers.DataBind();
                connection.Close();
            }
            catch
            {

            }
        }
    }
}
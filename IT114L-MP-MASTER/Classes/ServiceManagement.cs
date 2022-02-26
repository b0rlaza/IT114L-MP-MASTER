using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace IT114L_MP_MASTER.Classes
{
    public class ServiceManagement
    {
        static string dbConn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

        public static int GetLatestTransaction()
        {
            int latestID = 0;
            string query = $"select max(groom_srv_id) from GroomingSrvTBL";
            try
            {
                using (SqlConnection connection = new SqlConnection(dbConn))
                {
                    //Run the SQL Query
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        latestID = reader.GetInt32(0);
                    }
                    reader.Close();
                };
            }
            catch
            {

            }
            return latestID;
        }
        public static void NewService()
        {

        }
    }
}
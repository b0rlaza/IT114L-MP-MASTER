using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace IT114L_MP_MASTER
{
    public static class DeliveryManagement
    {
        static string dbConn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

        public static int GetLatestTransactionId()
        {
            //gets the latest user_id from the database.
            int latestID = 0;
            string query = $"select max(delivery_id) from DeliveryTBL";
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
        public static void CreateDelivery(int deliveryID, int transactionID, int userID, string type, string name, string contact, string address, string status)
        {
            string arrival = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
            string query;

            if (userID == -1)
            {
                query = $"insert into DeliveryTBL values({deliveryID}, {transactionID}, null, '{type}', '{name}', '{contact}', '{address}', '{status}', '{arrival}')";
            }
            else
            {
                query = $"insert into DeliveryTBL values({deliveryID}, {transactionID}, {userID}, '{type}', '{name}', '{contact}', '{address}', '{status}', '{arrival}')";
            }
            
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            };
        }
        public static void UpdateInfo(int deliveryID, string type, string name, string contact, string address, string status, string arrival)
        {
            string query = $"update DeliveryTBL set type='{type}', name='{name}', contact='{contact}', address='{address}', status='{status}', estimate_arrival='{arrival}' where delivery_id={deliveryID}";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            };
        }
        public static int GetSalesTransactionId(int deliveryID)
        {
            int transactionID = 0;
            string query = $"select transaction_id from DeliveryTBL where delivery_id={deliveryID}";

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
                        transactionID = reader.GetInt32(0);
                    }
                    reader.Close();
                };
            }
            catch
            {

            }
            return transactionID;
        }
        public static int GetUserId(int deliveryID)
        {
            int userID = 0;
            string query = $"select user_id from DeliveryTBL where delivery_id={deliveryID}";

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
                        userID = reader.GetInt32(0);
                    }
                    reader.Close();
                };
            }
            catch
            {

            }
            return userID;
        }
        public static string GetRecipientName(int deliveryID)
        {
            string name = "";
            string query = $"select name from DeliveryTBL where delivery_id={deliveryID}";

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
                        name = reader.GetString(0);
                    }
                    reader.Close();
                };
            }
            catch
            {

            }
            return name;
        }
        public static string GetRecipientContact(int deliveryID)
        {
            string contact = "";
            string query = $"select contact from DeliveryTBL where delivery_id={deliveryID}";

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
                        contact = reader.GetString(0);
                    }
                    reader.Close();
                };
            }
            catch
            {

            }
            return contact;
        }
        public static string GetRecipientAddress(int deliveryID)
        {
            string address = "";
            string query = $"select address from DeliveryTBL where delivery_id={deliveryID}";

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
                        address = reader.GetString(0);
                    }
                    reader.Close();
                };
            }
            catch
            {

            }
            return address;
        }
        public static string GetType(int deliveryID)
        {
            string type = "";
            string query = $"select type from DeliveryTBL where delivery_id={deliveryID}";

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
                        type = reader.GetString(0);
                    }
                    reader.Close();
                };
            }
            catch
            {

            }
            return type;
        }
        public static string GetStatus(int deliveryID)
        {
            string status = "";
            string query = $"select status from DeliveryTBL where delivery_id={deliveryID}";

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
                        status = reader.GetString(0);
                    }
                    reader.Close();
                };
            }
            catch
            {

            }
            return status;
        }
        public static string GetEstimateArrival(int deliveryID)
        {
            string arrival = "";
            string query = $"select estimate_arrival from DeliveryTBL where delivery_id={deliveryID}";

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
                        arrival = reader.GetDateTime(0).ToString("yyyy-MM-dd");
                    }
                    reader.Close();
                };
            }
            catch
            {

            }
            return arrival;
        }
    }
}
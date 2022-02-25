using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace IT114L_MP_MASTER
{
    public static class TransactionManagement
    {
        static string dbConn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

        public static void CreateTransaction(int transactionID, int userID, int deliveryID, int productID, int qty, string paymentStatus, double total)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string query = $"insert into ProductSalesTBL values({transactionID}, {userID}, {deliveryID}, {productID}, {qty}, '{paymentStatus}', {total}, '{date}')";
            if (userID == -1)
            {
                query = $"insert into ProductSalesTBL values({transactionID}, null, {deliveryID}, {productID}, {qty}, '{paymentStatus}', {total}, '{date}')";
            }

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            };
        }
        public static void UpdateTransactionStatus(int transactionID, string status)
        {
            string query = $"update ProductSalesTBL set payment_status='{status}' where transaction_id={transactionID}";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static int GetLatestTransactionId()
        {
            int latestID = 0;
            string queryRegister = $"select max(transaction_id) from ProductSalesTBL";

            try
            {
                using (SqlConnection connection = new SqlConnection(dbConn))
                {
                    //Run the SQL Query
                    SqlCommand command = new SqlCommand(queryRegister, connection);
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
        public static int GetProductId(int id)
        {
            int productID = 0;
            string query = $"select product_id from ProductSalesTBL where transaction_id={id}";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productID = reader.GetInt32(0);
                }
                reader.Close();
            };
            return productID;
        }
        public static int GetQtySold(int id)
        {
            int qtySold = 0;
            string query = $"select quantity from ProductSalesTBL where transaction_id={id}";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    qtySold = reader.GetInt32(0);
                }
                reader.Close();
            };
            return qtySold;
        }
        public static int GetDeliveryId(int id)
        {
            int deliveryID = 0;
            string query = $"select delivery_id from ProductSalesTBL where transaction_id={id}";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    deliveryID = reader.GetInt32(0);
                }
                reader.Close();
            };
            return deliveryID;
        }
        public static string GetStatus(int id)
        {
            string status = "";
            string query = $"select payment_status from ProductSalesTBL where transaction_id={id}";
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
            return status;
        }
        public static string GetDate(int id)
        {
            string date = "";
            string query = $"select transaction_date from ProductSalesTBL where transaction_id={id}";
            
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    date = reader.GetDateTime(0).ToString("yyyy-MM-dd");
                }
                reader.Close();
            };
            return date;
        }
    }
}
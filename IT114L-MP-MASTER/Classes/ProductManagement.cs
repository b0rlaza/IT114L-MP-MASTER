using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace IT114L_MP_MASTER
{
    public static class ProductManagement
    {
        static string dbConn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

        //Needs to be moved to a JSON file
        static string sqlUsername = "it114mp";
        static string sqlPassword = "it114mp";
        static string sqlServer = "localhost";
        static string sqlDatabase = "IT114-MP-DB";

        static string sqlAccess = $"user id={sqlUsername};password={sqlPassword};server={sqlServer};Trusted_Connection=yes;database={sqlDatabase};connection timeout=30";


        private static int GetLatestProductID()
        {
            //gets the latest product_id from the database.
            int latestID = 0;
            string queryRegister = $"select max(product_id) from ProductTBL";
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
        public static void CreateProduct(string name, string description, double price, int stock, string img, string status)

        {
            int newID = GetLatestProductID() + 1;
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"insert into ProductTBL values(" +
                    $"{newID}, '{name}', '{description}', {price}, '{img}', {stock}, 0, '{status}')";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                int result = command.ExecuteNonQuery();
            };
        }
        public static void EditProduct(int id, string name, string description, double price, int stock, int sold, string img, string status)
        {
            string queryRegister = $"update ProductTBL set [name]='{name}', [description]='{description}', [price]={price}, [image_loc]='{img}', [qty_stock]={stock}, [qty_sold]={sold}, [status]='{status}' where [product_id]={id}";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                command.ExecuteNonQuery();
            };
        }
        public static void DeleteProduct(int id)
        {
            string queryRegister = $"delete from ProductTBL where product_id={id}";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                command.ExecuteNonQuery();
            };
        }
        public static void ProductSold(int id, int sold)
        {
            int currentStock=0;
            int currentSold=0;
            int newStock;
            int newSold;

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryCurrent = $"select qty_stock, qty_sold from ProductTBL where product_id={id}";
                SqlCommand cmd = new SqlCommand(queryCurrent, connection);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    currentStock = reader.GetInt32(0);
                    currentSold = reader.GetInt32(1);
                }
                connection.Close();

                newStock = currentStock - sold;
                newSold = currentSold + sold;

                string queryNew = $"update ProductTBL set qty_stock={newStock}, qty_sold={newSold} where product_id={id}";

                SqlCommand cmdUpdate = new SqlCommand(queryNew, connection);
                connection.Open();
                cmdUpdate.ExecuteNonQuery();
                connection.Close();
            };
            StockCheck(id);
        }
        public static void StockCheck(int id)
        {
            if(GetQtyStock(id) <= 0)
            {
                using (SqlConnection connection = new SqlConnection(dbConn))
                {
                    //Run the SQL Query
                    string query = $"update ProductTBL set status='Out of Stock' where product_id={id}";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                };
            }
        }
        //Get Info Functions
        public static string GetName(int id)
        {
            string name = "";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select name from ProductTBL where product_id={id}";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    name = reader.GetString(0);
                }
                reader.Close();
            };
            return name;
        }
        public static string GetDescription(int id)
        {
            string description = "";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select description from ProductTBL where product_id={id}";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    description = reader.GetString(0);
                }
                reader.Close();
            };
            return description;
        }
        public static double GetPrice(int id)
        {
            double price = 0;
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select price from ProductTBL where product_id={id}";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    price = (double) reader.GetDecimal(0);
                }
                reader.Close();
            };
            return price;
        }
        public static int GetQtyStock(int id)
        {
            int stock = 0;
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select qty_stock from ProductTBL where product_id={id}";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    stock = reader.GetInt32(0);
                }
                reader.Close();
            };
            return stock;
        }
        public static int GetQtySold(int id)
        {
            int sold = 0;
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select qty_sold from ProductTBL where product_id={id}";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sold = reader.GetInt32(0);
                }
                reader.Close();
            };
            return sold;
        }
        public static string GetStatus(int id)
        {
            string status = "";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select status from ProductTBL where product_id={id}";
                SqlCommand command = new SqlCommand(queryRegister, connection);
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
        public static void UpdateStatus(int productID)
        {
            if(GetQtyStock(productID) == 0)
            {
                //Out of Stock
                try
                {
                    using (SqlConnection connection = new SqlConnection(sqlAccess))
                    {
                        //Run the SQL Query
                        string queryRegister = $"update ProductTBL set status='Out of Stock' where product_id={productID}";
                        SqlCommand command = new SqlCommand(queryRegister, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                    };
                }
                catch
                {

                }
            }
        }
    }
}
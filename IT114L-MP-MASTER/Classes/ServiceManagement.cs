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
        public static void NewService(string name, string description,double price)
        {
            int serviceID = GetLatestTransaction() + 1;
            string query = $"insert into GroomingSrvTBL values({serviceID},'{name}','{description}',{price},0)";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            };
        }
        public static void UpdateService(int servID, string name, string description,double price, int timesAvailed)
        {
            string query = $"update GroomingSrvTBL set [name] = {name}, set [description] = '{description}' [price] ={price}, [times_availed] = {timesAvailed}  where [groom_srv_id] = {servID}";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            };
        }
        public static void DeleteProduct(int servID)
        {
            string queryRegister = $"delete from GroomingSrvTBL where product_id={servID}";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                command.ExecuteNonQuery();
            };
        }

        public static void IncrementService(int servID, int tAvailed)
        {
            //Call this after a service gets used, such as in booking
            int newAvailed = tAvailed + 1;
            string query = $"UPDATE GroomingSrvTBL set [times_availed] = {newAvailed} where [groom_srv_id] = {servID}";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            };
        }
        
        public static string GetName(int servID)
        {
            string name = "";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select [name] GroomingSrvTBL from  where product_id={servID}";
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

        public static string GetDescription(int servID)
        {
            string description = "";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select [description] GroomingSrvTBL from  where product_id={servID}";
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
        public static double GetPrice(int servID)
        {
            double price = 0;
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select price from GroomingSrvTBL where product_id={servID}";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    price = (double)reader.GetDecimal(0);
                }
                reader.Close();
            };
            return price;
        }
        public static int GetTimesAvailed(int servID)
        {
            int tAvailed = 0;
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select [times_availed] from GroomingSrvTBL where product_id={servID}";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tAvailed = reader.GetInt32(0);
                }
                reader.Close();
            };
            return tAvailed;
        }
    }
}
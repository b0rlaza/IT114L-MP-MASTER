using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Configuration;

namespace IT114L_MP_MASTER
{
    public static class UserManagement
    {
        static string dbConn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

        public static string CalculateHash(string password)
        {
            //Calculates the hash of a password
            string hashed;

            byte[] salt = new byte[128 / 8];

            hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA256,
                10000,
                256 / 8));
            return hashed;
        }
        public static void RegisterUser(string username, string firstName, string lastName, string hashedPassword, string userLevel, string accessStatus)
        {
            //Before registering a user, verify if user already exists using DoesUserExists()
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            int newID = GetLatestUserID() + 1;

            string queryRegister = $"insert into UserAccountTBL values ({newID}, '{username}', '{firstName}', '{lastName}', '{hashedPassword}', '{date}', '', '', '{userLevel}', '{accessStatus}')";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(queryRegister, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            };
        }
        public static void ChangePassword(string username, string newPass)
        {
            //Authenticate user using IsSuccessfulAuth() first before calling this function.
            string newHashedPass = CalculateHash(newPass);
            string queryRegister = $"update UserAccountTBL set password = '{newHashedPass}' where username = '{username}'";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            };
        }
        public static void UpdateUser(int userID, string username, string firstName, string lastName, string address, string contact, string userLevel, string accessStatus)
        {
            string query = $"update UserAccountTBL set username='{username}', first_name='{firstName}', last_name='{lastName}', address='{address}', contact_no='{contact}', user_level='{userLevel}', access_status='{accessStatus}' where user_id={userID}";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void UpdateUser(int userID, string firstName, string lastName, string address, string contact)
        {
            string query = $"update UserAccountTBL set first_name='{firstName}', last_name='{lastName}', address='{address}', contact_no='{contact}' where user_id={userID}";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void DeleteUser(int userID)
        {
            //Method to delete user
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"delete from UserAccountTBL where user_id = {userID}";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            };
        }
        public static bool DoesUserExists(string username)
        {
            //Verify if username already exists.
            string user = "";
            string query = $"select username from UserAccountTBL where username='{username}'";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = reader.GetString(0);
                    }
                    reader.Close();
                    if (user == null || user =="")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch
                {
                    return true;
                }
            };
        }
        public static bool IsSuccessfulAuth(string username, string password)
        {
            //Method used to authenticate user.
            string storedUsername = "";
            string storedPassword = "";

            if (DoesUserExists(username))
            {
                using (SqlConnection connection = new SqlConnection(dbConn))
                {
                    //Run the SQL Query
                    string queryUsername = $"select username from UserAccountTBL where username = '{username}'";
                    string queryPassword = $"select password from UserAccountTBL where username = '{username}'";

                    SqlCommand cmdUsername = new SqlCommand(queryUsername, connection);
                    SqlCommand cmdPassword = new SqlCommand(queryPassword, connection);

                    connection.Open();

                    SqlDataReader readUsername = cmdUsername.ExecuteReader();
                    while (readUsername.Read())
                    {
                        storedUsername = readUsername.GetString(0);
                    }

                    connection.Close();
                    connection.Open();

                    SqlDataReader readPassword = cmdPassword.ExecuteReader();
                    while (readPassword.Read())
                    {
                        storedPassword = readPassword.GetString(0);
                    }

                    connection.Close();
                };

                using (SqlConnection connection = new SqlConnection(dbConn))
                {
                    //Run the SQL Query
                    string queryUsername = $"select username from UserAccountTBL where username = '{username}'";
                    string queryPassword = $"select password from UserAccountTBL where username = '{username}'";

                    SqlCommand cmdUsername = new SqlCommand(queryUsername, connection);
                    SqlCommand cmdPassword = new SqlCommand(queryPassword, connection);

                    connection.Open();

                    SqlDataReader readUsername = cmdUsername.ExecuteReader();
                    while (readUsername.Read())
                    {
                        storedUsername = readUsername.GetString(0);
                    }

                    connection.Close();
                    connection.Open();

                    SqlDataReader readPassword = cmdPassword.ExecuteReader();
                    while (readPassword.Read())
                    {
                        storedPassword = readPassword.GetString(0);
                    }

                    connection.Close();
                };

                if (storedUsername == username && storedPassword == CalculateHash(password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Get Information
        public static int GetUserID(string username)
        {
            //Gets the user's user_id.
            int userID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(dbConn))
                {
                    //Run the SQL Query
                    string queryRegister = $"select user_id from UserAccountTBL where username = '{username}'";
                    SqlCommand command = new SqlCommand(queryRegister, connection);
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
        public static string GetUsername(int userID)
        {
            string username = "";
            string query = $"select username from UserAccountTBL where user_id={userID}";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    username = reader.GetString(0);
                }
                reader.Close();
            }
            return username;
        }
        public static string GetUserLevel(string username)
        {
            //This method is used to get the user's privilege level
            string userLevel = "";

            if (DoesUserExists(username))
            {
                using (SqlConnection connection = new SqlConnection(dbConn))
                {
                    //Run the SQL Query
                    string queryRegister = $"select user_level from UserAccountTBL where username = '{username}'";
                    SqlCommand command = new SqlCommand(queryRegister, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        userLevel = reader.GetString(0);
                    }
                    reader.Close();
                };
                return userLevel;
            }
            else
            {
                return userLevel;
            }
        }
        public static string GetUserLevel(int userID)
        {
            //This method is used to get the user's privilege level
            string userLevel = "";
            string queryRegister = $"select user_level from UserAccountTBL where user_id={userID}";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userLevel = reader.GetString(0);
                }
                reader.Close();
            };
            return userLevel;
        }
        public static int GetLatestUserID()
        {
            //gets the latest user_id from the database.
            int latestID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(dbConn))
                {
                    //Run the SQL Query
                    string queryRegister = $"select max(user_id) from UserAccountTBL";
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
        public static string GetFirstName(string username)
        {
            //Get User's First Name
            string firstName = "";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select first_name from UserAccountTBL where username = '{username}'";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    firstName = reader.GetString(0);
                }
                reader.Close();
            };
            return firstName;
        }
        public static string GetFirstName(int userID)
        {
            //Get User's First Name
            string firstName = "";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select first_name from UserAccountTBL where user_id = '{userID}'";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    firstName = reader.GetString(0);
                }
                reader.Close();
            };
            return firstName;
        }
        public static string GetLastName(string username)
        {
            //Get User's First Name
            string firstName = "";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select last_name from UserAccountTBL where username = '{username}'";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    firstName = reader.GetString(0);
                }
                reader.Close();
            };
            return firstName;
        }
        public static string GetLastName(int userID)
        {
            //Get User's First Name
            string lastName = "";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select last_name from UserAccountTBL where user_id = '{userID}'";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lastName = reader.GetString(0);
                }
                reader.Close();
            };
            return lastName;
        }
        public static string GetAddress(string username)
        {
            //Get User's Address
            string address = "";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select address from UserAccountTBL where username = '{username}'";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    address = reader.GetString(0);
                }
                reader.Close();
            };
            return address;
        }
        public static string GetAddress(int userID)
        {
            //Get User's Address using userID
            string address = "";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select address from UserAccountTBL where user_id = '{userID}'";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    address = reader.GetString(0);
                }
                reader.Close();
            };
            return address;
        }
        public static string GetContact(string username)
        {
            //Get User's Contact
            string contact = "";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select contact_no from UserAccountTBL where username = '{username}'";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    contact = reader.GetString(0);
                }
                reader.Close();
            };
            return contact;
        }
        public static string GetContact(int userID)
        {
            //Get User's Contact
            string contact = "";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select contact_no from UserAccountTBL where user_id = '{userID}'";
                SqlCommand command = new SqlCommand(queryRegister, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    contact = reader.GetString(0);
                }
                reader.Close();
            };
            return contact;
        }
        public static string GetStatus(string username)
        {
            string status = "";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select access_status from UserAccountTBL where username = '{username}'";
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
        public static string GetStatus(int userID)
        {
            string status = "";

            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string queryRegister = $"select access_status from UserAccountTBL where user_id = '{userID}'";
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
    }
}
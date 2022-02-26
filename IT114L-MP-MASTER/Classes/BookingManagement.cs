using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace IT114L_MP_MASTER.Classes
{
    public static class BookingManagement
    {
        static string dbConn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

        public static int LatestBookingID()
        {
            int latestID = 0;
            string query = $"select max(booking_id) from BookingTBL";
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

        public static void CreateBooking(int bookingID, int serviceID, int userID, string date, string timeSlot)
        {
            //creates a booking
            int transactionID = ServiceManagement.GetLatestTransaction() + 1;
            string query = $"insert into BookingTBL values({bookingID},{userID},NULL,{serviceID},{transactionID},'{date}','{timeSlot}','Pending Approval')";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            };
        }
        public static void UpdateBooking(int bookingID, int serviceID, string date, string timeSlot, int assignedGroomerId)
        {
            string query = $"update BookingTBL set groomer_id = {assignedGroomerId}, groom_srv_id = {serviceID} [date] ='{date}', time_slot ='{timeSlot}'  where booking_id = {bookingID}";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            };
        }
        public static void ApproveBooking(int bookingID)
        {
            string query = $"update BookingTBL set status = 'Approved' where booking_id = {bookingID}";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            };
        }
        public static void DeleteBooking(int bookingID)
        {
            string query = $"delete from BookingTBL where booking_id = {bookingID}";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            };
        }
        //Get Info
        public static int GetUserId(int bookingID)
        {
            int userID = 0;
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string query = $"select user_id from BookingTBL where booking_id = {bookingID}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userID = reader.GetInt32(0);
                }
                reader.Close();
            };
            return userID;
        }
        public static int GetServiceId(int bookingID)
        {
            int serviceID = 0;
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string query = $"select [groom_srv_id] from BookingTBL where booking_id = {bookingID}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    serviceID = reader.GetInt32(0);
                }
                reader.Close();
            };
            return serviceID;
        }
        public static string GetBookingDate(int bookingID)
        {
            string bookingDate = "";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string query = $"select [date] from BookingTBL where booking_id = {bookingID}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bookingDate  = reader.GetString(0);
                }
                reader.Close();
            };
            return bookingDate;
        }

        public static string GetTimeSlot(int bookingID)
        {
            string timeslot = "";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string query = $"select [time_slot] from BookingTBL where booking_id = {bookingID}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    timeslot = reader.GetString(0);
                }
                reader.Close();
            };
            return timeslot;
        }
        public static bool IsGroomerAssigned(int bookingID)
        {
            //Returns true or false to indicate if a groomer is assigned
            bool groomer_status = false;
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                
                string query = $"select [groomer_id] from BookingTBL where booking_id = {bookingID}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.IsDBNull(0)==true){
                        groomer_status = false;
                    }
                    else
                    {
                        groomer_status = true;
                    }
                }
                reader.Close();
            };
            return groomer_status;
        }
        public static int GetGroomerId(int bookingID)
        {
            //return -1 to signify a Null groomer id
            int groomerid = 0;
            if (IsGroomerAssigned(bookingID) == true)
            {
                using (SqlConnection connection = new SqlConnection(dbConn))
                {
                    //Run the SQL Query
                    string query = $"select [groom_srv_id] from BookingTBL where booking_id = {bookingID}";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        groomerid = reader.GetInt32(0);
                    }
                    reader.Close();
                };
            }
            else
            {
                //if the groomer is not assigned yet
                groomerid = -1;
            }
            return groomerid;
        }
        public static string GetBookingStatus(int bookingID)
        {
            // returns either awaiting approval or approved
            string bStatus = "";
            using (SqlConnection connection = new SqlConnection(dbConn))
            {
                //Run the SQL Query
                string query = $"select [status] from BookingTBL where booking_id = {bookingID}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bStatus = reader.GetString(0);
                }
                reader.Close();
            };
            return bStatus;
        }

    }
}
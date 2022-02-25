using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace IT114L_MP_MASTER.Admin
{
    public partial class Install : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            string address = txtDBAddress.Text;
            string dbName = txtDBName.Text;
            string dbUsername = txtDBUsername.Text;
            string dbPassword = txtDBPassword.Text;

            string connString = $"user id={dbUsername};password={dbPassword};server={address};Trusted_Connection=yes;database={dbName};connection timeout=30";
            try
            {
                using(SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    if(connection.State == System.Data.ConnectionState.Open)
                    {
                        lblDbTestFeedback.Text = "Database connection successful!";
                    }
                    connection.Close();
                };
            }
            catch (Exception ex)
            {
                lblDbTestFeedback.Text = ex.Message;
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Admin.aspx", true);
        }

        protected void btnInstall_Click(object sender, EventArgs e)
        {
            try
            {
                string address = txtDBAddress.Text;
                string dbName = txtDBName.Text;
                string dbUsername = txtDBUsername.Text;
                string dbPassword = txtDBPassword.Text;

                string connString = $"user id={dbUsername};password={dbPassword};server={address};Trusted_Connection=yes;database={dbName};connection timeout=30";

                string adminUsername = txtAdminUsername.Text;
                string hashedPassword = UserManagement.CalculateHash(txtAdminPassword.Text);

                ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString = connString;

                SetupUserTbl();
                SetupProductsTbl();
                SetupTransactionTbl();
                SetupDeliveryTbl();

                UserManagement.RegisterUser(adminUsername, "", "", hashedPassword, "Administrator", "Allowed");
            }
            catch (Exception ex)
            {
                lblFeedback.Text = ex.Message;
            }
        }

        private void SetupUserTbl()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            string query = "create table [dbo].[UserAccountTBL]([user_id][int] not null, [username] [nvarchar](20) not null, [first_name] [nvarchar](50) not null, [last_name] [nvarchar](50) not null, [password] [nvarchar](100) not null, [date_created] [date] not null, [address] [nvarchar](200) null, [contact_no] [varchar](20) null, [user_level] [varchar](20) not null, [access_status] [varchar](20) not null)";
            using(SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            };
        }
        private void SetupProductsTbl()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            string query = "create table [dbo].[ProductTBL]([product_id][int] not null, [name] [nvarchar](100) not null, [description] [nvarchar](255) null, [price] [decimal](10, 2) not null, [image_loc] [nvarchar](255) null, [qty_stock] [int] not null, [qty_sold] [int] not null, [status] [varchar](30) not null)";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            };
        }
        private void SetupDeliveryTbl()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            string query = "create table [dbo].[DeliveryTBL]([delivery_id][int] not null, [transaction_id] [int] not null, [user_id] [int] null, [type] [varchar](20) not null, [name] [nvarchar](50) not null, [contact] [varchar](20) not null, [address] [nvarchar](150) not null, [status] [varchar](20) not null, [estimate_arrival] [date] not null)";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            };
        }
        private void SetupTransactionTbl()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            string query = "create table [dbo].[ProductSalesTBL]([transaction_id][int] not null, [user_id] [int] null, [delivery_id] [int] not null, [product_id] [int] not null, [quantity] [int] not null, [payment_status] [varchar](30) not null, [total_invoice] [decimal](10, 2) not null)";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            };
        }
    }
}
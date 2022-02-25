using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER
{
    public partial class Buy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            
            int productID;
            int userID;

            int.TryParse(Request.QueryString["product-id"], out productID);
            if(Page.IsPostBack == false)
            {
                if (Request.Cookies["user-id"] == null || Request.Cookies["user-id"].Value == "")
                {
                    txtName.Text = "";
                }
                else
                {
                    int.TryParse(Request.Cookies["user-id"].Value, out userID);
                    txtName.Text = UserManagement.GetFirstName(userID) + " " + UserManagement.GetLastName(userID);
                    txtContact.Text = UserManagement.GetContact(userID);
                    txtAddress.Text = UserManagement.GetAddress(userID);
                }

                lblName.Text = ProductManagement.GetName(productID);
                lblPrice.Text = ProductManagement.GetPrice(productID).ToString("N2");
                lblTotal.Text = ProductManagement.GetPrice(productID).ToString("N2");
                lblProductID.Text = productID.ToString();
                lblProductID.Visible = false;
                lblDeliveryFee.Text = "0.00";

                txtContact.Enabled = false;
                txtAddress.Enabled = false;

                if(ProductManagement.GetQtyStock(productID) < 10)
                {
                    dropQty.Items.Clear();
                    for(int i=1; i<=ProductManagement.GetQtyStock(productID); i++)
                    {
                        dropQty.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int userID;

            if(Request.Cookies["user-id"] == null || Request.Cookies["user-id"].Value == "")
            {
                userID = -1;
            }
            else
            {
                int.TryParse(Request.Cookies["user-id"].Value, out userID);
            }

            int transactionID = TransactionManagement.GetLatestTransactionId() + 1;
            int deliveryID = DeliveryManagement.GetLatestTransactionId() + 1;
            string type = dropDeliveryType.SelectedValue;
            string name = txtName.Text;
            string contact = txtContact.Text;
            string address = txtAddress.Text;
            string paymentStatus = "Unpaid";
            string deliveryStatus;

            if(dropDeliveryType.SelectedValue=="Onsite Pickup")
            {
                deliveryStatus = "Pending Pickup";
                address = "";
                contact = "";
            }
            else
            {
                deliveryStatus = "Pending Delivery";
            }

            TransactionManagement.CreateTransaction(transactionID, userID, deliveryID, int.Parse(lblProductID.Text), int.Parse(dropQty.SelectedValue), paymentStatus, double.Parse(lblTotal.Text));
            DeliveryManagement.CreateDelivery(deliveryID, transactionID, userID, type, name, contact, address, deliveryStatus);
            ProductManagement.ProductSold(int.Parse(lblProductID.Text), int.Parse(dropQty.SelectedValue));
            Response.Redirect("~/Shop/Catalogue.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx?product-id=" + lblProductID.Text, true);
        }

        protected void dropDeliveryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            double price = double.Parse(lblPrice.Text);
            int qty = int.Parse(dropQty.Text);
            double deliveryFee = 0;

            if (dropDeliveryType.SelectedValue == "Onsite Pickup")
            {
                txtContact.Enabled = false;
                txtAddress.Enabled = false;

                rfvAddress.Enabled = false;
                rfvContact.Enabled = false;

                deliveryFee = 0;
                lblDeliveryFee.Text = deliveryFee.ToString("N2");
            }
            else if (dropDeliveryType.SelectedValue == "Delivery")
            {
                txtContact.Enabled = true;
                txtAddress.Enabled = true;

                rfvAddress.Enabled = true;
                rfvContact.Enabled = true;

                deliveryFee = 50;
                lblDeliveryFee.Text = deliveryFee.ToString("N2");
            }

            double total = price * qty + deliveryFee;
            lblTotal.Text = total.ToString("N2");
        }

        protected void dropQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            double price = double.Parse(lblPrice.Text);
            double deliveryFee = double.Parse(lblDeliveryFee.Text);
            int qty = int.Parse(dropQty.Text);
            double total = price * qty + deliveryFee;
            lblTotal.Text = total.ToString("N2");
        }
    }
}

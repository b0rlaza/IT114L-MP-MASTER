using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER.Admin
{
    public partial class EditDelivery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            int deliveryID;
            int.TryParse(Request.QueryString["delivery-id"], out deliveryID);
            if (Page.IsPostBack == false)
            {
                lblDeliveryID.Text = deliveryID.ToString();
                lblTransactionID.Text = DeliveryManagement.GetSalesTransactionId(deliveryID).ToString();
                lblUserID.Text = DeliveryManagement.GetUserId(deliveryID).ToString();

                txtName.Text = DeliveryManagement.GetRecipientName(deliveryID);
                txtContact.Text = DeliveryManagement.GetRecipientContact(deliveryID);
                txtAddress.Text = DeliveryManagement.GetRecipientAddress(deliveryID);
                dropType.SelectedValue = DeliveryManagement.GetType(deliveryID);
                dropStatus.SelectedValue = DeliveryManagement.GetStatus(deliveryID);
                txtDate.Text = DeliveryManagement.GetEstimateArrival(deliveryID);

                if (dropType.SelectedValue == "Onsite Pickup")
                {
                    txtContact.Enabled = false;
                    txtAddress.Enabled = false;
                    rfvContact.Enabled = false;
                    rfvAddress.Enabled = false;
                }
                else
                {
                    txtContact.Enabled = true;
                    txtAddress.Enabled = true;
                    rfvContact.Enabled = true;
                    rfvAddress.Enabled = true;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int deliveryID = int.Parse(lblDeliveryID.Text);
            string type = dropType.SelectedValue;
            string name = txtName.Text;
            string contact = txtContact.Text;
            string address = txtAddress.Text;
            string status = dropStatus.SelectedValue;
            string date = txtDate.Text;

            DeliveryManagement.UpdateInfo(deliveryID, type, name, contact, address, status, date);
            Response.Redirect("ListDeliveries.aspx", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListDeliveries.aspx", true);
        }

        protected void linkToTransaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditTransaction.aspx?transaction-id=" + lblTransactionID.Text, true);
        }

        protected void dropType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dropType.SelectedValue == "Onsite Pickup")
            {
                txtContact.Enabled = false;
                txtAddress.Enabled = false;
                rfvContact.Enabled = false;
                rfvAddress.Enabled = false;
            }
            else
            {
                txtContact.Enabled = true;
                txtAddress.Enabled = true;
                rfvContact.Enabled = true;
                rfvAddress.Enabled = true;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER.Admin
{
    public partial class EditTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int transactionID;

            int.TryParse(Request.QueryString["transaction-id"], out transactionID);
            if (Page.IsPostBack == false)
            {
                lblTransactionID.Text = transactionID.ToString();
                lblDate.Text = TransactionManagement.GetDate(transactionID);
                lblProductName.Text = ProductManagement.GetName(TransactionManagement.GetProductId(transactionID));
                lblQtySold.Text = TransactionManagement.GetQtySold(transactionID).ToString();
                dropStatus.SelectedValue = TransactionManagement.GetStatus(transactionID);
            }
        }

        protected void linkToDelivery_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditDelivery.aspx?delivery-id=" + TransactionManagement.GetDeliveryId(int.Parse(lblTransactionID.Text)), true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TransactionManagement.UpdateTransactionStatus(int.Parse(lblTransactionID.Text), dropStatus.SelectedValue);
            Response.Redirect("ListTransactions.aspx", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListTransactions.aspx", true);
        }
    }
}
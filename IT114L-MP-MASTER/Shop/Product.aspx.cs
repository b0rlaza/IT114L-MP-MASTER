using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER
{
    public partial class Product : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int productID;
            int.TryParse(Request.QueryString["product-id"], out productID);

            lblName.Text = ProductManagement.GetName(productID);
            lblDescription.Text = ProductManagement.GetDescription(productID);
            lblPrice.Text = ProductManagement.GetPrice(productID).ToString();
            lblStatus.Text = ProductManagement.GetStatus(productID);
            lblProductId.Text = productID.ToString();

            if (lblStatus.Text == "Available")
            {
                btnBuy.Enabled = true;
            }
            else
            {
                btnBuy.Enabled = false;
            }
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("Buy.aspx?product-id=" + lblProductId.Text, true);
        }
    }
}
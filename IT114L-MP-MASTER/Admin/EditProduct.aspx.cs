using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER.Admin
{
    public partial class EditProduct : System.Web.UI.Page
    {
        int productID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Page.IsPostBack == false)
            {
                int.TryParse(Request.QueryString["product-id"], out productID);

                lblProductID.Text = productID.ToString();
                txtName.Text = ProductManagement.GetName(productID);
                txtDescription.Text = ProductManagement.GetDescription(productID);

                txtPrice.Text = String.Format("{0:0.##}", ProductManagement.GetPrice(productID));
                txtQty.Text = ProductManagement.GetQtyStock(productID).ToString();
                txtSold.Text = ProductManagement.GetQtySold(productID).ToString();

                dropStatus.SelectedValue = ProductManagement.GetStatus(productID);
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            double price;
            int stock;
            int sold;

            string name = txtName.Text;
            string description = txtDescription.Text;
            string status = dropStatus.Text;
            int id = int.Parse(lblProductID.Text);

            double.TryParse(txtPrice.Text, out price);
            int.TryParse(txtQty.Text, out stock);
            int.TryParse(txtSold.Text, out sold);

            ProductManagement.EditProduct(id, name, description, price, stock, sold, "", status);
            Response.Redirect("~/Admin/ListProducts.aspx", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ProductManagement.DeleteProduct(int.Parse(lblProductID.Text));
            Response.Redirect("~/Admin/ListProducts.aspx", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ListProducts.aspx", true);
        }

        protected void linkToStore_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shop/Product.aspx?product-id=" + lblProductID.Text, true);
        }
    }
}
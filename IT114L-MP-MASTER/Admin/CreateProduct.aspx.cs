using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MP_MASTER.Admin
{
    public partial class CreateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            double price;
            int stock;

            string name = txtName.Text;
            string description = txtDescription.Text;
            string status = dropStatus.Text;
            double.TryParse(txtPrice.Text, out price);
            int.TryParse(txtQty.Text, out stock);

            ProductManagement.CreateProduct(name, description, price, stock, "", status);
            Response.Redirect("ListProducts.aspx", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListProducts.aspx", true);
        }
    }
}
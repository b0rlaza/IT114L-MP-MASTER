<%@ Page Title="Products List" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ListProducts.aspx.cs" Inherits="IT114L_MP_MASTER.Admin.ListProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Products List</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View All Products</h2>
    <p><a href="CreateProduct.aspx">Add product to shop</a></p>
    <asp:GridView ID="gridProducts" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="product_id" HeaderText="Product ID" DataNavigateUrlFormatString="EditProduct.aspx?product-id={0}" DataTextField="product_id" />
            <asp:BoundField DataField="name" HeaderText="Product Name" />
            <asp:BoundField DataField="price" HeaderText="Price" />
            <asp:BoundField DataField="qty_stock" HeaderText="In Stock" />
            <asp:BoundField DataField="qty_sold" HeaderText="Qty. Sold" />
            <asp:BoundField DataField="status" HeaderText="Availability" />
        </Columns>
    </asp:GridView>
</asp:Content>

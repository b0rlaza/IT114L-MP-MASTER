<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Catalogue.aspx.cs" Inherits="IT114L_MP_MASTER.Catalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Shop Catalogue</h2>
    <asp:GridView ID="gridProducts" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="product_id" HeaderText="Product Name" DataNavigateUrlFormatString="Product.aspx?product-id={0}" DataTextField="name" />
            <asp:BoundField DataField="price" HeaderText="Price" />
            <asp:BoundField DataField="status" HeaderText="Availability" />
        </Columns>
    </asp:GridView>
    
</asp:Content>

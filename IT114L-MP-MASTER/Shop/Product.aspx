<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="IT114L_MP_MASTER.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><asp:Label ID="lblName" runat="server" Text="ProductName"></asp:Label></h1>
    <p>Price: <asp:Label ID="lblPrice" runat="server" Text="ProductPrice"></asp:Label></p>
    <p>Description: <asp:Label ID="lblDescription" runat="server" Text="ProductDescription"></asp:Label></p>
    <p>Availability: <asp:Label ID="lblStatus" runat="server" Text="AvailabilityStatus"></asp:Label></p>
    <asp:Button ID="btnBuy" runat="server" Text="Buy" OnClick="btnBuy_Click" /><br />
    <asp:Label ID="lblProductId" runat="server" Visible="False"></asp:Label>
</asp:Content>

<%@ Page Title="Modify Transaction" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EditTransaction.aspx.cs" Inherits="IT114L_MP_MASTER.Admin.EditTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Modify Transaction</h1>
    Transaction ID: <asp:Label ID="lblTransactionID" runat="server" Text="TransactionID"></asp:Label><br />
    Transaction Date: <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label><br />
    Product: <asp:Label ID="lblProductName" runat="server" Text="ProductName"></asp:Label><br />
    Quantity: <asp:Label ID="lblQtySold" runat="server" Text="QuantitySold"></asp:Label><br />
    Payment Status: <asp:DropDownList ID="dropStatus" runat="server">
        <asp:ListItem>Unpaid</asp:ListItem>
        <asp:ListItem>Paid</asp:ListItem>
        <asp:ListItem>Cancelled</asp:ListItem>
        <asp:ListItem>Refunded</asp:ListItem>
    </asp:DropDownList><br />
    <asp:LinkButton ID="linkToDelivery" runat="server" OnClick="linkToDelivery_Click">View Delivery Info</asp:LinkButton><br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

</asp:Content>

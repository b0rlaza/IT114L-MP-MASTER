<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ListTransactions.aspx.cs" Inherits="IT114L_MP_MASTER.Admin.ListTransactions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Transactions</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>All Transactions</h2>
    <asp:GridView ID="gridTransactions" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="transaction_id" HeaderText="Transaction ID" DataNavigateUrlFormatString="EditTransaction.aspx?transaction-id={0}" DataTextField="transaction_id" />
            <asp:BoundField DataField="name" HeaderText="Product Name" />
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="total_invoice" HeaderText="Invoice" />
            <asp:BoundField DataField="payment_status" HeaderText="Payment Status" />
            <asp:BoundField DataField="transaction_date" HeaderText="Date" />
        </Columns>
    </asp:GridView>
</asp:Content>

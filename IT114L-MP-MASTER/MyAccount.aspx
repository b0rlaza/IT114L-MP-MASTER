<%@ Page Title="My Account" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="IT114L_MP_MASTER.MyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>My Account</h2>
    Username: <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
    <br />
    First Name: <asp:Label ID="lblFirstName" runat="server" Text="FirstName"></asp:Label>
    <br />
    Last Name: <asp:Label ID="lblLastName" runat="server" Text="LastName"></asp:Label>
    <br />
    Contact no.: <asp:Label ID="lblContact" runat="server" Text="ContactNo."></asp:Label>
    <br />
    Address: <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
    <br />
    <asp:Button ID="btnEdit" runat="server" Text="Manage Account" OnClick="btnEdit_Click" />
    <hr />
    <h3>My Purchases</h3>
    <asp:GridView ID="gridPurchases" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="transaction_id" HeaderText="Transaction ID" DataNavigateUrlFormatString="#" DataTextField="transaction_id" />
            <asp:BoundField DataField="transaction_date" HeaderText="Date" />
            <asp:BoundField DataField="name" HeaderText="Product Name" />
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="total_invoice" HeaderText="Invoice" />
            <asp:BoundField DataField="payment_status" HeaderText="Payment Status" />
            <asp:BoundField DataField="type" HeaderText="Delivery Type" />
            <asp:BoundField DataField="status" HeaderText="Delivery Status" />
            <asp:BoundField DataField="estimate_arrival" HeaderText="Estimate Arrival" />
        </Columns>
    </asp:GridView>
    <h3>My Bookings</h3>
    <asp:GridView ID="gridBookings" runat="server"></asp:GridView>
</asp:Content>

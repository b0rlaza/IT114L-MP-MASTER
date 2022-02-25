<%@ Page Title="Deliveries List" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ListDeliveries.aspx.cs" Inherits="IT114L_MP_MASTER.Admin.ListDeliveries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>All Deliveries</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>All Deliveries</h2>
    <asp:GridView ID="gridDeliveries" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="delivery_id" HeaderText="Delivery ID" DataNavigateUrlFormatString="EditDelivery.aspx?delivery-id={0}" DataTextField="delivery_id" />
            <asp:BoundField DataField="type" HeaderText="Delivery Type" />
            <asp:BoundField DataField="name" HeaderText="Recipient Name" />
            <asp:BoundField DataField="contact" HeaderText="Recipient Contact no." />
            <asp:BoundField DataField="status" HeaderText="Delivery Status" />
            <asp:BoundField DataField="estimate_arrival" HeaderText="Estimate Date of Arrival" />
        </Columns>
    </asp:GridView>
</asp:Content>

<%@ Page Title="Admin Home" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="IT114L_MP_MASTER.Admin.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Admin Home</h2>
    <h3>Sales Report</h3>
    Date: <asp:TextBox ID="txtSalesDate" runat="server" AutoPostBack="True" OnTextChanged="txtSalesDate_TextChanged" TextMode="Date"></asp:TextBox><br />
    No. of Transactions: <asp:Label ID="lblNoOrders" runat="server" Text="NumOrders"></asp:Label><br />
    Total amount sold: <asp:Label ID="lblAmtSold" runat="server" Text="AmountSold"></asp:Label><br />
    
    <h3>Grooming Service Appointments</h3>
    No. of booked appointments for <asp:Label ID="lblAppointmentDate" runat="server" Text="AppoinmentDate"></asp:Label>: 
    <asp:Label ID="lblBookingCount" runat="server" Text="BookingCount"></asp:Label>
</asp:Content>

<%@ Page Title="Users List" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ListUsers.aspx.cs" Inherits="IT114L_MP_MASTER.Admin.ListUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>All Users</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View All Users</h2>
    <p><a href="CreateUser.aspx">Create User Account</a></p>
    <asp:GridView ID="gridUsers" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="user_id" HeaderText="User ID" DataNavigateUrlFormatString="EditUser.aspx?user-id={0}" DataTextField="user_id" />
            <asp:BoundField DataField="username" HeaderText="Username" />
            <asp:BoundField DataField="first_name" HeaderText="First Name" />
            <asp:BoundField DataField="last_name" HeaderText="Last Name" />
            <asp:BoundField DataField="date_created" HeaderText="Date Created" />
            <asp:BoundField DataField="user_level" HeaderText="Account Type" />
            <asp:BoundField DataField="access_status" HeaderText="Access Status" />
        </Columns>
    </asp:GridView>
</asp:Content>

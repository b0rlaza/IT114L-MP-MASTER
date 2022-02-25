<%@ Page Title="Add New User" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="IT114L_MP_MASTER.Admin.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Create User Account</h2>
    Username: <asp:TextBox ID="txtUsername" runat="server" MaxLength="19"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Blank Username" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    First Name: <asp:TextBox ID="txtFirstname" runat="server" MaxLength="49"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstname" ErrorMessage="Blank First Name" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Last Name: <asp:TextBox ID="txtLastname" runat="server" MaxLength="49"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvLastname" runat="server" ControlToValidate="txtLastname" ErrorMessage="Blank Last Name" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Blank Password" ForeColor="Red" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
    <br />
    User Level: <asp:DropDownList ID="dropUserLevel" runat="server">
        <asp:ListItem Value="Customer"></asp:ListItem>
        <asp:ListItem Value="Shop Attendant"></asp:ListItem>
        <asp:ListItem Value="Shop Manager"></asp:ListItem>
        <asp:ListItem Value="Grooming Attendant"></asp:ListItem>
        <asp:ListItem Value="Grooming Manager"></asp:ListItem>
        <asp:ListItem Value="Administrator"></asp:ListItem>
    </asp:DropDownList><br />
    Access Status: <asp:DropDownList ID="dropAccessStatus" runat="server">
        <asp:ListItem>Allowed</asp:ListItem>
        <asp:ListItem>Denied</asp:ListItem>
    </asp:DropDownList><br />
    <asp:Button ID="btnCreate" runat="server" Text="Create User" OnClick="btnCreate_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click" />
    <br />
    <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label>
</asp:Content>

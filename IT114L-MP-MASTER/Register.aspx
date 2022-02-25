<%@ Page Title="Create Account" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="IT114L_MP_MASTER.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Create Account</h2>
    Username: <asp:TextBox ID="txtUsername" runat="server" MaxLength="19"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Blank Username" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    First Name: <asp:TextBox ID="txtFirstName" runat="server" MaxLength="49"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Blank First Name" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Last Name: <asp:TextBox ID="txtLastName" runat="server" MaxLength="49"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Password: <asp:TextBox ID="txtPass1" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPass1" runat="server" ControlToValidate="txtPass1" ErrorMessage="Blank Password" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Confirm Password: <asp:TextBox ID="txtPass2" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPass2" runat="server" ControlToValidate="txtPass2" ErrorMessage="Blank" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="btnConfirm" runat="server" Text="Sign Up" OnClick="btnConfirm_Click" />
    <br />
    <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label>
</asp:Content>

<%@ Page Title="Login" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IT114L_MP_MASTER.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Login</h2>
    Username: <asp:TextBox ID="txtUsername" runat="server" MaxLength="19"></asp:TextBox><br />
    Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /><br />
    <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label><br />
    Not Registered yet? <a href="Register.aspx">Register now</a>.
</asp:Content>

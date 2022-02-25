<%@ Page Title="Edit My Account" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="ManageAccount.aspx.cs" Inherits="IT114L_MP_MASTER.ManageAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Edit My Account</h2>
    Username: <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
    <br />
    First Name: <asp:TextBox ID="txtFirstname" runat="server" MaxLength="49"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstname" ErrorMessage="Blank First Name" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Last Name: <asp:TextBox ID="txtLastname" runat="server" MaxLength="49"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvLastname" runat="server" ControlToValidate="txtLastname" ErrorMessage="Blank Last Name" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Contact No.: <asp:TextBox ID="txtContact" runat="server" MaxLength="19"></asp:TextBox>
    <br />
    Address: <asp:TextBox ID="txtAddress" runat="server" Height="80px" TextMode="MultiLine" Width="300px" MaxLength="199"></asp:TextBox>
    <hr />
    <h3>Change Password</h3>
    <p>Leave blank if undersired</p>
    Current Password: <asp:TextBox ID="txtCurrentPass" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    New Pasword: <asp:TextBox ID="txtNewPass1" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    Confirm New Password: <asp:TextBox ID="txtNewPass2" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    <br />
    <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label>
</asp:Content>

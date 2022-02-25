<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="IT114L_MP_MASTER.Admin.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Edit User</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Edit User Account</h2>
    User ID: <asp:Label ID="lblUserID" runat="server" Text="UserID"></asp:Label>
    <br />
    Username: <asp:TextBox ID="txtUsername" runat="server" MaxLength="19"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Blank Username" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    First Name: <asp:TextBox ID="txtFirstName" runat="server" MaxLength="49"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Blank First Name" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Last Name: <asp:TextBox ID="txtLastName" runat="server" MaxLength="49"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Blank Last Name" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Contact No.: <asp:TextBox ID="txtContact" runat="server" MaxLength="19"></asp:TextBox>
    <br />
    Address: <asp:TextBox ID="txtAddress" runat="server" Height="80px" TextMode="MultiLine" Width="300px" MaxLength="199"></asp:TextBox>
    <br />
    User Level: <asp:DropDownList ID="dropUserLevel" runat="server">
        <asp:ListItem Value="Customer"></asp:ListItem>
        <asp:ListItem Value="Shop Attendant"></asp:ListItem>
        <asp:ListItem Value="Shop Manager"></asp:ListItem>
        <asp:ListItem Value="Groomer Attendant"></asp:ListItem>
        <asp:ListItem Value="Groomer Manager"></asp:ListItem>
        <asp:ListItem Value="Administrator"></asp:ListItem>
    </asp:DropDownList>
    <br />
    Access Status:<asp:DropDownList ID="dropAccessStatus" runat="server">
        <asp:ListItem Value="Allowed"></asp:ListItem>
        <asp:ListItem Value="Deactivated"></asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CausesValidation="False" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
</asp:Content>

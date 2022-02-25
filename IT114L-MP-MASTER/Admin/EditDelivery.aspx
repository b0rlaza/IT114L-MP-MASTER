<%@ Page Title="Edit Delivery Info" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EditDelivery.aspx.cs" Inherits="IT114L_MP_MASTER.Admin.EditDelivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Edit Delivery Info</h2>
    Delivery ID: <asp:Label ID="lblDeliveryID" runat="server" Text="DeliveryID"></asp:Label><br />
    Transaction ID: <asp:Label ID="lblTransactionID" runat="server" Text="TransactionID"></asp:Label><br />
    User ID: <asp:Label ID="lblUserID" runat="server" Text="UserID"></asp:Label><br />
    Recipient Name: <asp:TextBox ID="txtName" runat="server" MaxLength="49"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Blank Name" ControlToValidate="txtName" ForeColor="Red">*</asp:RequiredFieldValidator>
<br />
    Recipient Contact: <asp:TextBox ID="txtContact" runat="server" MaxLength="19"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvContact" runat="server" ControlToValidate="txtContact" ErrorMessage="Blank Contact no." ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Recipient Address: <asp:TextBox ID="txtAddress" runat="server" Height="80px" TextMode="MultiLine" Width="300px" MaxLength="254"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Blank Address" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Delivery Type: <asp:DropDownList ID="dropType" runat="server" OnSelectedIndexChanged="dropType_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem>Onsite Pickup</asp:ListItem>
        <asp:ListItem>Delivery</asp:ListItem>
    </asp:DropDownList><br />
    Delivery Status: <asp:DropDownList ID="dropStatus" runat="server">
        <asp:ListItem>Pending Pickup</asp:ListItem>
        <asp:ListItem>Pending Delivery</asp:ListItem>
        <asp:ListItem>In Delivery</asp:ListItem>
        <asp:ListItem>Delivered</asp:ListItem>
        <asp:ListItem>Cancelled</asp:ListItem>
    </asp:DropDownList><br />
    Estimate Arrival: <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox><br />
    <asp:LinkButton ID="linkToTransaction" runat="server" OnClick="linkToTransaction_Click" CausesValidation="False">View Transaction Info</asp:LinkButton><br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
</asp:Content>

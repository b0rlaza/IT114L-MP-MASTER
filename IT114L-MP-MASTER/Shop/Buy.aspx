<%@ Page Title="Buy Product" Language="C#" MasterPageFile="~/Frontend.Master" AutoEventWireup="true" CodeBehind="Buy.aspx.cs" Inherits="IT114L_MP_MASTER.Buy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Buy Product</h2>

    <h3>Delivery Information</h3>
    Delivery Type: <asp:DropDownList ID="dropDeliveryType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropDeliveryType_SelectedIndexChanged">
        <asp:ListItem Value="Onsite Pickup">Onsite Pickup</asp:ListItem>
        <asp:ListItem>Delivery</asp:ListItem>
    </asp:DropDownList><br />
    Full Name: <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Blank Name" ForeColor="Red">*</asp:RequiredFieldValidator>
<br />
    Contact no.: <asp:TextBox ID="txtContact" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvContact" runat="server" ControlToValidate="txtContact" Enabled="False" ErrorMessage="Blank Contact no." ForeColor="Red">*</asp:RequiredFieldValidator>
<br />
    Address: <asp:TextBox ID="txtAddress" runat="server" Height="80px" TextMode="MultiLine" Width="300px"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" Enabled="False" ErrorMessage="Blank Address" ForeColor="Red">*</asp:RequiredFieldValidator>
<br />

    <h3>Product Information</h3>
    Product Name: <asp:Label ID="lblName" runat="server" Text="ProductName"></asp:Label><br />
    Quantity: <asp:DropDownList ID="dropQty" runat="server" OnSelectedIndexChanged="dropQty_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem Value="1"></asp:ListItem>
        <asp:ListItem Value="2"></asp:ListItem>
        <asp:ListItem Value="3"></asp:ListItem>
        <asp:ListItem Value="4"></asp:ListItem>
        <asp:ListItem Value="5"></asp:ListItem>
        <asp:ListItem Value="6"></asp:ListItem>
        <asp:ListItem Value="7"></asp:ListItem>
        <asp:ListItem Value="8"></asp:ListItem>
        <asp:ListItem Value="9"></asp:ListItem>
        <asp:ListItem Value="10"></asp:ListItem>
    </asp:DropDownList><br />
    Unit
    Price: <asp:Label ID="lblPrice" runat="server" Text="ProductPrice"></asp:Label><br />
    Delivery Fee: <asp:Label ID="lblDeliveryFee" runat="server" Text="DeliveryFee"></asp:Label><br />
    Total: <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label><br />

    <asp:Button ID="btnConfirm" runat="server" Text="Confirm Order" OnClick="btnConfirm_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" /><br />
    <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblProductID" runat="server" Visible="False"></asp:Label><br />
</asp:Content>

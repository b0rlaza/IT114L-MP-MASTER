<%@ Page Title="Add New Product" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CreateProduct.aspx.cs" Inherits="IT114L_MP_MASTER.Admin.CreateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add New Product</h2>
    Name: <asp:TextBox ID="txtName" runat="server" MaxLength="99"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Blank Name" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Description: <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="80px" Width="220px" MaxLength="254"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage="Blank Description" ForeColor="Red" ControlToValidate="txtDescription">*</asp:RequiredFieldValidator>
    <br />
    Price: <asp:TextBox ID="txtPrice" runat="server" MaxLength="11"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Blank Price" ForeColor="Red" ControlToValidate="txtPrice">*</asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPrice" ErrorMessage="Invalid Price" ForeColor="Red" MaximumValue="400000.00" MinimumValue="0.01" Type="Currency">*</asp:RangeValidator>
    <br />
    Stock Qty: <asp:TextBox ID="txtQty" runat="server" MaxLength="5"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvQty" runat="server" ControlToValidate="txtQty" ErrorMessage="Blank Stock" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:RangeValidator ID="rvQty" runat="server" ControlToValidate="txtQty" ErrorMessage="Invalid Stock" ForeColor="Red" MaximumValue="100000" MinimumValue="0" Type="Integer">*</asp:RangeValidator>
    <br />
    Stock Status: <asp:DropDownList ID="dropStatus" runat="server">
        <asp:ListItem>Available</asp:ListItem>
        <asp:ListItem>Not Available</asp:ListItem>
        <asp:ListItem>Out of Stock</asp:ListItem>
    </asp:DropDownList>
    <br />
    Image: <asp:FileUpload ID="uploadPic" runat="server" /><br />
    <asp:Button ID="btnSubmit" runat="server" Text="Create Product" OnClick="btnSubmit_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click" />
</asp:Content>

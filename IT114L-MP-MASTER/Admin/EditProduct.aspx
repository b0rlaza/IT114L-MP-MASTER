<%@ Page Title="Edit Product Info" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="IT114L_MP_MASTER.Admin.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Edit Product Info</h2>

    Product ID: <asp:Label ID="lblProductID" runat="server" Text=""></asp:Label>
    <br />
    <asp:LinkButton ID="linkToStore" runat="server" OnClick="linkToStore_Click">Visit Store Page</asp:LinkButton>
    <br />
    Name: <asp:TextBox ID="txtName" runat="server" MaxLength="99"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Blank Name" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Description: <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="80px" Width="220px" MaxLength="254"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ErrorMessage="Blank Description" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    Price: <asp:TextBox ID="txtPrice" runat="server" MaxLength="11"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="Blank Price" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:RangeValidator ID="rvPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="Invalid Price" ForeColor="Red" MaximumValue="400000" MinimumValue="0.01" Type="Currency">*</asp:RangeValidator>
    <br />
    Stock Qty: <asp:TextBox ID="txtQty" runat="server" MaxLength="5"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvStock" runat="server" ControlToValidate="txtQty" ErrorMessage="Blank Quantity" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:RangeValidator ID="rvStock" runat="server" ControlToValidate="txtQty" ErrorMessage="Invalid Qty" ForeColor="Red" MaximumValue="100000" MinimumValue="0" Type="Integer">*</asp:RangeValidator>
    <br />
    Stock Sold: <asp:TextBox ID="txtSold" runat="server" MaxLength="5"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvSold" runat="server" ControlToValidate="txtSold" ErrorMessage="Blank Sold" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:RangeValidator ID="rvSold" runat="server" ControlToValidate="txtSold" ErrorMessage="Invalid Sold" ForeColor="Red" MaximumValue="1000000" MinimumValue="0" Type="Integer">*</asp:RangeValidator>
    <br />
    Stock Status: <asp:DropDownList ID="dropStatus" runat="server">
        <asp:ListItem>Available</asp:ListItem>
        <asp:ListItem>Not Available</asp:ListItem>
        <asp:ListItem>Out of Stock</asp:ListItem>
    </asp:DropDownList>
    <br />
    Image: <asp:FileUpload ID="uploadPic" runat="server" /><br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnConfirm_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CausesValidation="False" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Install.aspx.cs" Inherits="IT114L_MP_MASTER.Admin.Install" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome!</h1>
            <p>This utility is an installer that will allow you to install this website. Fill up the forms appropriately.</p>
            <hr />
            <h2>Database Setup</h2>
            <p>This section allows you to configure the database. Be sure to test the connection before proceeding.<br />Contact your hosting provider for credentials.</p>
            Server Address: <asp:TextBox ID="txtDBAddress" runat="server"></asp:TextBox><br />
            Database Name: <asp:TextBox ID="txtDBName" runat="server"></asp:TextBox><br />
            Username: <asp:TextBox ID="txtDBUsername" runat="server"></asp:TextBox><br />
            Password: <asp:TextBox ID="txtDBPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="btnTest" runat="server" Text="Test DB Connection" OnClick="btnTest_Click" /><br />
            <asp:Label ID="lblDbTestFeedback" runat="server" Text=""></asp:Label>
            <hr />
            <h2>Administrator Account</h2>
            <p>This section allows you to create an administrator account. Do NOT lose your password at this point.</p>
            Username: <asp:TextBox ID="txtAdminUsername" runat="server"></asp:TextBox><br />
            Password: <asp:TextBox ID="txtAdminPassword" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label><br />
            <asp:Button ID="btnInstall" runat="server" Text="Install" OnClick="btnInstall_Click" />
            <asp:Button ID="btnHome" runat="server" Text="Start!" OnClick="btnHome_Click" />
        </div>
    </form>
</body>
</html>

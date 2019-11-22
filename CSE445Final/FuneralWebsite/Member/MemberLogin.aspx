<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberLogin.aspx.cs" Inherits="FuneralWebsite.Member.MemberLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            Username: <asp:TextBox ID="txbxUsername" runat="server"></asp:TextBox> <br />
            Password: <asp:TextBox ID="txbxPassword" runat="server"></asp:TextBox> <br />
            <asp:Button ID="btnMemberLogin" runat="server" Text="Log in as Member" OnClick="btnMemberLogin_Click" /> <br />
            <asp:Label ID="lblLoginError" runat="server" Text="There was an error logging in." Visible="false"></asp:Label> <br />
            <br />Don't have a login? <br />
            <asp:Button ID="btnRegister" runat="server" Text="Register as a Member" OnClick="btnRegister_Click" />
        </div>
    </form>
</body>
</html>



<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FuneralWebsite.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Log into the site:
            <br />
            Username:
            <asp:TextBox ID="txbxUserName" runat="server"></asp:TextBox>
            <br />
            Password:
            <asp:TextBox ID="txbxPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="LoginFunc" />
            <br />
            <asp:Label ID="lblOutput" runat="server" Text="output..."></asp:Label>
        </div>
    </form>
</body>
</html>


<script language="C#" runat="server">
    void LoginFunc(Object sender, EventArgs e)
    {
        //if (FormsAuthentication.Authenticate(txbxUserName.Text, txbxPassword.Text))
        if (myAuthenticate(txbxUserName.Text, txbxPassword.Text))
        {
            FormsAuthentication.RedirectFromLoginPage(txbxUserName.Text, false);
        }
        else
        {
            lblOutput.Text = "Invalid login";
        }
    }
</script>

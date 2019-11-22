<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="FuneralWebsite.Member.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Welcome to the Jungle, err the Member page. <br />
            Philip will put things here. Eventually. <br />
            Clicking the signout button will cause you to expire the login cookie. <br />
            <asp:Button ID="btnSignout" runat="server" Text="Sign Out" OnClick="logoutFunc" />
        </div>
    </form>
</body>
</html>


<script language="C#" runat="server">
    void logoutFunc(Object sender, EventArgs e)
    {
        //expire the login cookie
        HttpCookie myCookies = Request.Cookies["LoginCookie"];
        Response.Cookies["LoginCookie"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("~/Default.aspx");
    }
</script>

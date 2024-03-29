﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="FuneralWebsite.Member.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 490px">
    <form id="form1" runat="server">
        <h1>Member page</h1>
        <div>
            <asp:Button ID="btnSignout" runat="server" Text="Sign Out" OnClick="logoutFunc" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="New Funeral" />
            <br />
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="40px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <asp:Button ID="edit" runat="server" OnClick="edit_Click" Text="View / Edit" />
            <br />
            <br />
            Welcome to the Jungle, err the Member page. <br />
            Clicking the signout button will cause you to expire the login cookie. <br />
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

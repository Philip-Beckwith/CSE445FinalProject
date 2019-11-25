<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberRegister.aspx.cs" Inherits="FuneralWebsite.Member.MemberRegister" %>

<!DOCTYPE html>
<%@ Register TagPrefix="cap" TagName="semesterr" Src="~/captchaControl.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Member registration page</h1>
        <div>
            Member Registration Page <br />
            Enter information below to create an account <br />
            Name:<asp:TextBox ID="txbxName" runat="server"></asp:TextBox> <br />
            Username:<asp:TextBox ID="txbxUsername" runat="server"></asp:TextBox> <br />
            Password:<asp:TextBox ID="txbxPassword" runat="server"></asp:TextBox> 
            <br />
            <br />
            <cap:semesterr runat="server" />
            <br />
            <asp:Label ID="lblResult" runat="server" Text="..."></asp:Label> <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Create Member Account" OnClick="btnSubmit_Click" /> <br /><br />
            <asp:Button ID="btnMember" runat="server" Text="Go to Member Page" OnClick="btnMember_Click" Visible="false"/>
            
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FuneralWebsite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Funeral Services</h1>
        <div>
            Welcome to the default page of the funeral services site.<br />
            Below you will find links to the member and staff pages<br />
            <asp:Button ID="btnMemberPage" runat="server" Text="Go to Member Page" OnClick="btnMemberPage_Click" /> <br />
            <asp:Button ID="btnStaffPage" runat="server" Text="Go to Staff Page" OnClick="btnStaffPage_Click" /> <br />
        </div>
    </form>
</body>
</html>

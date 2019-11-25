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
            Use the buttons below to navigate to the different pages<br />
            Under the member page, it is possible to reserve a funeral for an individual.<br />
            All the reserved funeral dates can be displayed behind the staff page.<br />
            Below you will find links to the member and staff pages<br />
            <asp:Button ID="btnMemberPage" runat="server" Text="Go to Member Page" OnClick="btnMemberPage_Click" /> <br />
            <asp:Button ID="btnStaffPage" runat="server" Text="Go to Staff Page" OnClick="btnStaffPage_Click" /> <br /><br />
            Login Pages are below:<br />
            <asp:Button ID="memberLogin" runat="server" Text="Go to Member Login Page" OnClick="memberLogin_Click"/><br />
            <asp:Button ID="staffLogin" runat="server" Text="Go to Staff Login Page" OnClick="staffLogin_Click"/><br />
        </div>
    </form>
</body>
</html>

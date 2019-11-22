<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="FuneralWebsite.Staff.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title>staff page</title></head>
<body>
    <form id="form2" runat="server">
        <h1>Staff page</h1>
        <div>
            <% Response.Write("Hello " + Context.User.Identity.Name + ", "); %>
            <br />
            This is the Staff Page<br />
            <asp:Button ID="btnSignout" runat="server" Text="Sign Out" OnClick="logoutFunc" />
        </div>
    </form>
</body>
</html>


<script language="C#" runat="server">
    void logoutFunc(Object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("~/Default.aspx");
    }
</script>

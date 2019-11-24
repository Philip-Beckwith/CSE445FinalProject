<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="FuneralWebsite.Staff.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title>staff page</title></head>
<body>
    <form id="form2" runat="server">
        <asp:Button ID="btnSignout" runat="server" Text="Sign Out" OnClick="logoutFunc" Style="float: right;" />
        <h1>Staff page</h1>
        <table>
            <tr>
                <td>
                    <div>
                        <% Response.Write("Hello " + Context.User.Identity.Name + ", "); %>
                        <br />
                        This is the Staff Page<br />
                        Click the "Sign Out" button at the top right to sign out of this page.<br />
                        Click "Display Reservations" To see all of the funeral reservations.<br />
                        between the given date range<br />
                        <br />
                        Dates must be in MM/DD/YYYY format<br />
                        Start:<asp:TextBox ID="txbxStartDate" runat="server"></asp:TextBox>
                        End:&nbsp;&nbsp;<asp:TextBox ID="txbxEndDate" runat="server"></asp:TextBox><br />
                        <asp:Button ID="btnDisplayReservation" runat="server" Text="Display Reservations" OnClick="btnDisplayReservation_Click" />
                    </div>
                </td>
                <td>
                    <p style="color: red;">THIS IS A DANGEROUS BUTTON.<br />
                        This will delete all records in the XML file</p>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete All Data" OnClick="btnDelete_Click" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblData" runat="server" Text="..."></asp:Label>
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

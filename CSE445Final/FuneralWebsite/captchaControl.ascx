<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="captchaControl.ascx.cs" Inherits="FuneralWebsite.captchaControl" %>
<asp:Image ID="Image1" runat="server" />
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show String" />
<p>
    &nbsp;</p>
<asp:Label ID="Label2" runat="server" Text="Enter String here:"></asp:Label>
<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Submit" />
<asp:Label ID="Label3" runat="server" Text="[Output]"></asp:Label>
<p>
    &nbsp;</p>


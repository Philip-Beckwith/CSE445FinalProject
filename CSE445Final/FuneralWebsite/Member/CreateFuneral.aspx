<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateFuneral.aspx.cs" Inherits="FuneralWebsite.Member.CreateFuneral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 332px;
            width: 591px;
            margin-top: 0px;
        }
        #eulogy {
            height: 254px;
            width: 604px;
        }
    </style>
</head>
<body style="height: 1194px">
    <form id="form1" runat="server">
        <div id="eulogy" style="height: 1143px">
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="name of deceased"></asp:Label>
            <asp:TextBox ID="NameOfTheDead" runat="server" Font-Size="XX-Large" Height="47px" Width="586px"></asp:TextBox>
            <br />
            <br />
            <br />
            Date Of Service: <asp:Label ID="reservedDay" runat="server" Text="Date"></asp:Label>
            <br />
&nbsp;<br />
            <br />
            <asp:TextBox ID="eulogy" runat="server" Height="349px" TextMode="MultiLine" Width="586px"></asp:TextBox>
            <br />
            <br />
            <br />
            Day Selector: <asp:Label ID="dateLabel" runat="server" Text="Date"></asp:Label>
&nbsp;Is
            <asp:Label ID="availablity" runat="server" Text="Available"></asp:Label>
            <br />
            <asp:Calendar ID="daySelector" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            <br />
            <asp:Button ID="reserveDate" runat="server" OnClick="Button1_Click" Text="Reserve Date" />
            <br />
            <br />
            <br />
            <asp:Button ID="saveChanges" runat="server" OnClick="saveChanges_Click" Text="Save " />
        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>

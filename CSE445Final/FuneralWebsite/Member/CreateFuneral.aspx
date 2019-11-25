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
        <div id="eulogy" style="height: 1383px">
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="name of deceased"></asp:Label>
            <asp:TextBox ID="NameOfTheDead" runat="server" Font-Size="XX-Large" Height="47px" Width="586px" OnTextChanged="NameOfTheDead_TextChanged" AutoPostBack="True"></asp:TextBox>
            <br />
            <asp:Button ID="updateName" runat="server" OnClick="updateName_Click" Text="Update Name" />
            <br />
            <br />
            Date Of Service: <asp:Label ID="reservedDay" runat="server" Text="Date"></asp:Label>
            <br />
&nbsp;<br />
            <br />
            <asp:TextBox ID="eulogy" runat="server" Height="349px" TextMode="MultiLine" Width="586px" AutoPostBack="True"></asp:TextBox>
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
            What kind of Funeral would you like?<br />
            <asp:RadioButtonList ID="FuneralType" runat="server">
                <asp:ListItem Value="0" Selected="True">Bad</asp:ListItem>
                <asp:ListItem Value="1">Acceptable</asp:ListItem>
                <asp:ListItem Value="3">Exquisite</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            What kind of Casket is required?<br />
            <asp:RadioButtonList ID="CasketType" runat="server">
                <asp:ListItem Selected="True" Value="0">Cardboard</asp:ListItem>
                <asp:ListItem Value="2">Wood</asp:ListItem>
                <asp:ListItem Value="3">Illuminated</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            How loved is the departed?<br />
            Number Of Flowers:
            <asp:TextBox ID="NumberOfFlowers" runat="server">0</asp:TextBox>
            <br />
            <br />
            <br />
            Cost:
            <asp:Label ID="Cost" runat="server" Text="$ N/A"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Calculate Cost" />
            <br />
            <br />
            <br />
            <asp:Button ID="saveChanges" runat="server" OnClick="saveChanges_Click" Text="Save " />
            <br />
            <br />
            <asp:Button ID="homeButton" runat="server" OnClick="homeButton_Click" Text="Home Page" />
        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>

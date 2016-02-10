<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Assignment04.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Styles/SpellChecker.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="clsDiv1">
        <asp:Label ID="lblPrompt" runat="server" Text="Enter your word to spell check"></asp:Label>&nbsp
        <asp:TextBox ID="txtCheck" runat="server"></asp:TextBox>&nbsp
        <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" />&nbsp
        <asp:Label ID="lblResult" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <div class="clsDiv2">
        <asp:Label ID="Label1" runat="server" Text="Words beginning with"></asp:Label>&nbsp
        <asp:TextBox ID="txtPrefix" runat="server"></asp:TextBox>&nbsp
        <asp:Button ID="btnPrefix" runat="server" Text="Build List" OnClick="btnPrefix_Click"  />&nbsp
        <asp:TextBox ID="txtPrefixResult" runat="server" EnableViewState="False" ReadOnly="True" TextMode="MultiLine" Width="300px"></asp:TextBox>
        <asp:Label ID="lblCount" runat="server"></asp:Label>
    </div>
    <div class="clsDiv3">
        <asp:Label ID="lblGenerateStatistics" runat="server" Text="Generate Statistics"></asp:Label>&nbsp
        <asp:Button ID="btnGenerateStatistics" runat="server" Text="Go" OnClick="btnGenerateStatistics_Click"   />&nbsp
        <asp:TextBox ID="txtStatistics" runat="server" EnableViewState="False" ReadOnly="True" TextMode="MultiLine" Width="300px"></asp:TextBox>
    </div>
    <div class="clsDiv3">
        <asp:Label ID="lblTwoRandomWords" runat="server" Text="Generate two random words"></asp:Label>&nbsp
        <asp:Button ID="btnTwoRandomWords" runat="server" Text="Go" OnClick="btnTwoRandomWords_Click"  />&nbsp
        <asp:TextBox ID="txtTwoRandomWords" runat="server" EnableViewState="False" ReadOnly="True" TextMode="MultiLine" Width="300px"></asp:TextBox>
    </div>
    </form>
</body>
</html>

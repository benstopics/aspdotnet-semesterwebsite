<%--Name: Ben Ward
Assignment: 02
Date: 1/27/2016
Course: ASP.NET Class
Description: This is the main page of the website. From this page you can access all other assignment pages. --%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/benstopics.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>=== Assignments ===</p><br />
            <p><asp:HyperLink ID="hlAssignment01" runat="server" NavigateUrl="Assignment01.aspx">./Assignment01</asp:HyperLink></p>
            <p><asp:HyperLink ID="hlAssignment02" runat="server" NavigateUrl="Assignment02.aspx">./Assignment02</asp:HyperLink></p>
            <p><asp:HyperLink ID="hlAssignment03" runat="server" NavigateUrl="Assignment03.aspx">./Assignment03</asp:HyperLink></p>
            <p><asp:HyperLink ID="hlAssignment04" runat="server" NavigateUrl="Assignment04.aspx">./Assignment04</asp:HyperLink></p>
        </div>
    </form>
</body>
</html>

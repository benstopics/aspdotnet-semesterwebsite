<%--Name: Ben Ward
Assignment: 02
Date: 1/27/2016
Course: ASP.NET Class
Description: Page for Assignment02. This is a slave page. ALl hail MASter PAGE!.--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment02.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:Label ID="lblEnter" runat="server" Text="Enter your number: "></asp:Label><asp:Label ID="lblPhonenumber" runat="server" Text=""></asp:Label></p><br />
    <asp:Button ID="btn1" runat="server" Text="1" Width="56px" OnClick="NumberButtonClicked" />
    <asp:Button ID="btn2" runat="server" Text="2" Width="56px" OnClick="NumberButtonClicked" />
    <asp:Button ID="btn3" runat="server" Text="3" Width="56px" OnClick="NumberButtonClicked" /><br />
    <asp:Button ID="btn4" runat="server" Text="4" Width="56px" OnClick="NumberButtonClicked" />
    <asp:Button ID="btn5" runat="server" Text="5" Width="56px" OnClick="NumberButtonClicked" />
    <asp:Button ID="btn6" runat="server" Text="6" Width="56px" OnClick="NumberButtonClicked" /><br />
    <asp:Button ID="btn7" runat="server" Text="7" Width="56px" OnClick="NumberButtonClicked" />
    <asp:Button ID="btn8" runat="server" Text="8" Width="56px" OnClick="NumberButtonClicked" />
    <asp:Button ID="btn9" runat="server" Text="9" Width="56px" OnClick="NumberButtonClicked" /><br />
    <asp:Button ID="btnClear" runat="server" Text="Clear" Width="56px" OnClick="NumberButtonClicked" />
    <asp:Button ID="btn0" runat="server" Text="0" Width="56px" OnClick="NumberButtonClicked" />
    <asp:Button ID="btnBackspace" runat="server" Text="<=" Width="56px" OnClick="NumberButtonClicked" /><br />
    <asp:Button ID="btnOk" runat="server" Text="OK" Width="168px" OnClick="NumberButtonClicked" />

</asp:Content>
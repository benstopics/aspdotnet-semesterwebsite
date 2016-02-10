<%--Name: Ben Ward
Assignment: 03
Date: 2/3/2016
Course: ASP.NET Class
Description: Slave page to master page. Assignment03 page to populate multiview from textbox and button and navigate with dropdown. --%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment03.aspx.cs" Inherits="Assignment03" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:TextBox ID="txtUserTextbox" runat="server"></asp:TextBox>
    <asp:Button ID="btnUserButton" runat="server" Text="Button" OnClick="btnUserButton_Click" /><br />
    <asp:DropDownList ID="ddNavigation" runat="server" OnSelectedIndexChanged="ddNavigation_SelectedIndexChanged"></asp:DropDownList><br />
    <asp:MultiView ID="mvUserMultiview" runat="server"></asp:MultiView>
</asp:Content>


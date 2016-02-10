<%--Name: Ben Ward
Assignment: 02
Date: 1/27/2016
Course: ASP.NET Class
Description: Slave page to master page. Assignment02 page to display the sent phone number from form. --%>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment02DisplayNumber.aspx.cs" Inherits="Assignment02DisplayNumber" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><asp:Label ID="lblDisplayPhoneNumber" runat="server" Text=""></asp:Label></p>
</asp:Content>


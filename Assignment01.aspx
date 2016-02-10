<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment01.aspx.cs" Inherits="Assignment01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>For any N, let f(N) be the last five digits before the trailing zeroes in N!.<br /></p>
    <p>For example,<br /></p>
    <br />
    <p>9! = 362880 so f(9)=36288<br /></p>
    <p>10! = 3628800 so f(10)=36288<br /></p>
    <p>20! = 2432902008176640000 so f(20)=17664<br /></p>
    <br />
    <p>Find f(1,000,000,000,000)</p>
    <p>
        <p>Solution: <% Response.Write(new Problem160().Solve()); %></p>
    </p>
</asp:Content>


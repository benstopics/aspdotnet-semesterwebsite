<%--
Assignment05: Markup
Benjamin Ward
2/17/2016
wardb3@mail.uc.edu
--%>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment05.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <asp:Label ID="lblModel" runat="server" Text="Choose your model: "></asp:Label>
        <asp:DropDownList ID="ddModel" runat="server" Height="16px" Width="195px" DataSourceID="sdsModel" DataTextField="Model" DataValueField="ModelID" OnSelectedIndexChanged="ddModel_SelectedIndexChanged" >
        </asp:DropDownList>
        <asp:SqlDataSource ID="sdsModel" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tModel]"></asp:SqlDataSource>
    </p>
    <asp:ListBox ID="lbLeftSide" runat="server" Width="250px" DataSourceID="sdsLeftListBox" DataTextField="VehicleOption" DataValueField="VehicleOptionID"></asp:ListBox>
    <asp:SqlDataSource ID="sdsLeftListBox" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [vModelAndOption]"></asp:SqlDataSource>
    <asp:Button ID="btnAllRight" runat="server" Text=">>" OnClick="btnAllRight_Click" />
    <asp:Button ID="btnRight" runat="server" Text=">" OnClick="btnRight_Click" />
    <asp:Button ID="btnLeft" runat="server" Text="<" OnClick="btnLeft_Click" />
    <asp:Button ID="btnAllLeft" runat="server" Text="<<" OnClick="btnAllLeft_Click" />
    <asp:ListBox ID="lbRightSide" runat="server" Width="250px"></asp:ListBox>
</asp:Content>

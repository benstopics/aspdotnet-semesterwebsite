<%--
Assignment05: Markup
Benjamin Ward
<<<<<<< HEAD
2/17/2016
wardb3@mail.uc.edu
=======
3/16/2016
wardb3@mail.uc.edu

References:
    http://aspsolutionkirit.blogspot.com/2013/09/autocomplete-textbox-in-aspnet-using.html
>>>>>>> origin/master
--%>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment05.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<<<<<<< HEAD
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
=======

    <span style="display: block; overflow: hidden; padding-right: 5px;">
        <asp:TextBox ID="txtSentence" class="autosuggest" style="width: 500px;" runat="server"></asp:TextBox>
    </span>

    <script>
        var txtSentence = document.getElementById("ContentPlaceHolder1_txtSentence");
        $(document).ready(function () {
            SearchText();
        });
        function SearchText() {
            $('.ui-autocomplete-input').css('width', '500px');
            $(".autosuggest").autocomplete({

                source: function (request, response) {
                    console.log("test ajax");
                    $.ajax({
                        appendTo: $(".autosuggest").next(),
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "WordService.asmx/GetSynonyms",
                        data: "{'sentence':'" + txtSentence.value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                    console.log("end test ajax");
                }
            });
        }
    </script>
>>>>>>> origin/master
</asp:Content>

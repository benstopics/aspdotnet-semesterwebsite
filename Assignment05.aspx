<%--
Assignment05: Markup
Benjamin Ward
3/16/2016
wardb3@mail.uc.edu

References:
    http://aspsolutionkirit.blogspot.com/2013/09/autocomplete-textbox-in-aspnet-using.html
--%>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Assignment05.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
</asp:Content>

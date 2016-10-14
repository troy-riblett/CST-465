<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site1.Master" AutoEventWireup="true" CodeBehind="ValidatedFormOutput.aspx.cs" Inherits="Lab1.WebForms.ValidatedFormOutput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:Placeholder ID="uxInvalidDataArea" Visible="false" runat="server">This form did not receive the parameters expected</asp:Placeholder>
    <asp:Placeholder ID="uxValidDataArea" Visible="false" runat="server">
        <asp:div>Name: <asp:Literal ID="uxNameLiteral" runat="server"></asp:Literal></asp:div> 
        <asp:div>Favorite Color: <asp:Literal ID="uxFavoriteColorLiteral" runat="server"></asp:Literal></asp:div>
        <asp:div>City: <asp:Literal ID="uxCityLiteral" runat="server"></asp:Literal></asp:div>
    </asp:Placeholder>
</asp:Content>

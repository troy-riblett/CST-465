<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site1.Master" AutoEventWireup="true" CodeBehind="ValidatedForm.aspx.cs" Inherits="Lab1.WebForms.WebForm1" %>
<%@ Register TagPrefix="CST" TagName="RequiredBox" Src="~/WebForms/RequiredTextBox.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:Panel runat="server">
        <CST:RequiredBox ID="uxNameBox" LabelText="Name" ValidationGroup="ValidationGroup" runat="server" />
        <CST:RequiredBox ID="uxColorBox" LabelText="Favorite Color" ValidationGroup="ValidationGroup" runat="server" />
        <CST:RequiredBox ID="uxCityBox" LabelText="City" ValidationGroup="ValidationGroup" runat="server" />
    </asp:Panel>
    <asp:Button ValidationGroup="ValidationGroup" CausesValidation="true" ID="uxSubmit" Text="Submit" runat="server" OnClick="uxSubmit_Click"/>
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RequiredTextBox.ascx.cs" Inherits="Lab1.WebForms.WebUserControl1" %>
<asp:Label ID="uxLabel" AssociatedControlID="uxTextBox" runat="server"></asp:Label>
<asp:TextBox ID="uxTextBox" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="uxValidator" ControlToValidate="uxTextBox" ErrorMessage="Don't leave that textbox blank ya jackwagon!" Text="<-This thing" runat="server"></asp:RequiredFieldValidator>
<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="Contact.aspx.cs" Inherits="CST465.WebForms.Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label AssociatedControlID="uxName" runat="server">Name</asp:Label>
        <asp:TextBox ID="uxName" runat="server"></asp:TextBox>

        <asp:Label AssociatedControlID="uxPriority" runat="server">Priority</asp:Label>
        <asp:DropDownList ID="uxPriority" runat="server">
            <asp:ListItem>High</asp:ListItem>
            <asp:ListItem>Medium</asp:ListItem>
            <asp:ListItem>Low</asp:ListItem>
        </asp:DropDownList>

        <asp:Label AssociatedControlID="uxSubject" runat="server">Subject</asp:Label>
        <asp:TextBox ID="uxSubject" runat="server"></asp:TextBox>

        <asp:Label AssociatedControlID="uxDescription" runat="server">Description</asp:Label>
        <asp:TextBox ID="uxDescription" TextMode="MultiLine" runat="server"></asp:TextBox>

        <asp:Button Text="Submit" ID="uxSubmit" OnClick="uxSubmit_Click" runat="server"/>

        <asp:Literal ID="uxFormOutput" runat="server" ></asp:Literal>
        <asp:Literal ID="uxEventOutput" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>

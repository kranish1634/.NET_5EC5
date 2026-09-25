<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Leave_Management.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Academic Calendar</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Academic Calendar</h2>
        <asp:Calendar ID="Calendar1"
            runat="server"
            OnSelectionChanged="Calendar1_SelectionChanged">
        </asp:Calendar>
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br /><br />
        <asp:Button ID="Button1"
            runat="server"
            Text="Apply"
            OnClick="Button1_Click" />
    </form>
</body>
</html>

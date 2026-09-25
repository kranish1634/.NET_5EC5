<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leave.aspx.cs" Inherits="Leave_Management.Leave" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Leave Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Leave Application Form</h2>
        Employee Name:
        <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>
        <br /><br />
        Leave Date:
        <asp:TextBox ID="txtLeaveDate" runat="server" ReadOnly="true"></asp:TextBox>
        <br /><br />
        Leave Type:
        <asp:DropDownList ID="ddlLeaveType" runat="server">
             <asp:ListItem>--Select--</asp:ListItem>
            <asp:ListItem>Casual Leave</asp:ListItem>
            <asp:ListItem>Sick Leave</asp:ListItem>
            <asp:ListItem>Emergency Leave</asp:ListItem>
            <asp:ListItem>Earned Leave</asp:ListItem>
        </asp:DropDownList>
        <br /><br />
        Reason:
        <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Rows="4"
               Columns="30"></asp:TextBox>
        <br /><br />
        <asp:CheckBox ID="chkRemember" runat="server" Text="Remember Name" />
        <br /><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Apply Leave"                      OnClick="btnSubmit_Click"/>
        <br /><br />

        <asp:Label ID="lblMsg" runat="server"  ForeColor="Black"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" ForeColor="Black" Font-Size="Medium"> </asp:Label>
    </form>
</body>
</html>

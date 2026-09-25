<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Event_Registration_Portal.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Registration Portal</title>
    <style type="text/css">
        body {
            font-family: Arial, Helvetica, sans-serif;
            background: #f5f7fb;
            margin: 0;
            padding: 20px;
            color: #111;
        }

        .wrapper {
            max-width: 640px;
            margin: 36px auto;
            padding: 20px;
            background: #ffffff;
            border-radius: 8px;
        }

        h2 {
            text-align: center;
            margin: 0 0 12px;
            font-size: 20px;
            width: 548px;
        }

        label {
            display: block;
            margin-top: 10px;
            font-size: 13px;
            color: #444;
        }

        input[type=text],
        input[type=password],
        input[type=email],
        textarea,
        select {
            padding: 8px;
            box-sizing: border-box;
            border: 1px solid #ddd;
            border-radius: 4px;
        }

        textarea {
            min-height: 80px;
            resize: vertical;
        }

        .btnRegister {
            display: inline-block;
            margin-top: 12px;
            padding: 8px 14px;
            background: #007bff;
            color: #fff;
            border: 0;
            border-radius: 4px;
            cursor: pointer;
        }
       .labelCol {
            width: 413px;
        }
       .summaryRow {
            height: 133px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
       <h2> Event Registration Portal </h2>
              <table style="width: 100%">

            <tr>
                <td class="abelCol">Name</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="230px" Height="30px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server"
                        ControlToValidate="TextBox1"
                        ErrorMessage="Name is required!"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorName"
                        runat="server"
                        ControlToValidate="TextBox1"
                        ValidationExpression="^[A-Za-z ]+$"
                        ErrorMessage="Name should contain only letters!"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td class="abelCol">Enrollment No</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="230px" Height="30px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                        runat="server"
                        ControlToValidate="TextBox2"
                        ErrorMessage="Enrollment No is required!"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEnroll"
                        runat="server"
                        ControlToValidate="TextBox2"
                       ValidationExpression="^[1-9][0-9]*$"
                        ErrorMessage="Invalid Enrollment No!"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td class="abelCol">Gender</td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="230px" Height="30px" RepeatDirection="Horizontal">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                        runat="server"
                        ControlToValidate="RadioButtonList1"
                        ErrorMessage="Gender is required!"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="abelCol">Branch</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="230px" Height="33px">
                        <asp:ListItem Value="">--Select Branch--</asp:ListItem>
                        <asp:ListItem>CE</asp:ListItem>
                        <asp:ListItem>CSE</asp:ListItem>
                        <asp:ListItem>IT</asp:ListItem>
                        <asp:ListItem>AIDS</asp:ListItem>
                        <asp:ListItem>AIML</asp:ListItem>
                        <asp:ListItem>EC</asp:ListItem>
                        <asp:ListItem>Civil</asp:ListItem>
                        <asp:ListItem>ICT</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                        runat="server"
                        ControlToValidate="DropDownList1"
                        InitialValue=""
                        ErrorMessage="Please Select Branch!"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="abelCol">Current Semester</td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="230px" Height="33px">
                        <asp:ListItem Value="">--Select Semester--</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                        runat="server"
                        ControlToValidate="DropDownList3"
                        InitialValue=""
                        ErrorMessage="Please Select Semester!"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="abelCol">Email</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="230px" Height="30px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                        runat="server"
                        ControlToValidate="TextBox3"
                        ErrorMessage="Email is required!"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        runat="server"
                        ControlToValidate="TextBox3"
                        ValidationExpression="\w+([-.+']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage="Invalid Email Id!"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td class="abelCol">Mobile No</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="230px" Height="30px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                        runat="server"
                        ControlToValidate="TextBox4"
                        ErrorMessage="Mobile No is required!"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                        runat="server"
                        ControlToValidate="TextBox4"
                        ValidationExpression="^[0-9]{10}$"
                        ErrorMessage="Enter a valid 10-digit Mobile No!"
                        ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td class="abelCol">Event</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="230px" Height="33px">
                        <asp:ListItem Value="">--Select Main Event--</asp:ListItem>
                        <asp:ListItem>Hackathon</asp:ListItem>
                        <asp:ListItem>TechFest</asp:ListItem>
                        <asp:ListItem>Blind Coding</asp:ListItem>
                        <asp:ListItem>Coding Challenge</asp:ListItem>
                        <asp:ListItem>Chess Event</asp:ListItem>
                        <asp:ListItem>Treasure Hunt</asp:ListItem>
                        <asp:ListItem>Code &amp; Clue Treasure Hunt</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                        runat="server"
                        ControlToValidate="DropDownList2"
                        InitialValue=""
                        ErrorMessage="Please Select Event!"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
             <td colspan="3" style="text-align:center;">
                 <asp:Button ID="btnRegister"
                     runat="server"
                     Text="Register Now"
                     CssClass="btnRegister"
                     OnClick="btnRegister_Click" />
            </td>
            </tr>

            <tr>
                <td colspan="3" style="text-align:center;">
                    <asp:Label ID="lblMessage"
                        runat="server"
                        Font-Size="Large">
                    </asp:Label>
                    <br />
                    <asp:Label ID="lblSummary" runat="server" />
                </td>
            </tr>

            <tr>
                <td class="summaryRow" colspan="3">
                   <asp:ValidationSummary ID="ValidationSummary"
                        runat="server"
                        HeaderText="Please correct the following errors:"
                        ForeColor="Red" Height="100px" Width="730px" />
                </td>
            </tr>
        </table>
            <hr />
            <p style="text-align:center;color:#666;">
    © 2026 Event Registration Portal | Developed by Anish Kumar
</p>
      </div>
    </form>
</body>
</html>

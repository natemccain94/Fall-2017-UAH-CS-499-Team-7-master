<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="loginStyle.css" />
    <style type="text/css">
        .auto-style5 {
            text-align: right;
            width: 201px;
            color: #00FF00;
        }
        .auto-style6 {
            text-align: right;
            width: 201px;
            color: #33CC33;
        }
    </style>
</head>
<body>
    <a href="../users/display_houses.aspx"> Viww Listings</a>
    <form id="form1" runat="server">
        <h1>Real Estate Agencies</h1>
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style6">Username:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxUN" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUN" ErrorMessage="Enter in Username" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Password:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxPW" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPW" ErrorMessage="Enter in Password" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>

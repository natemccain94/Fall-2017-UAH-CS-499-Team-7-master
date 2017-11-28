<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="loginStyle.css" />
</head>
<body>
<form id="login_page" runat="server">
     <div class="container">
    <div class="form-signin" id="form1" runat="server"> 
        <asp:TextBox Class="form-signin TextBox" placeholder="Username" ID="TextBoxUN" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUN" ErrorMessage="Enter in Username" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:TextBox Class="form-signin TextBox1" placeholder="Password" TextMode="Password" ID="TextBoxPW" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPW" ErrorMessage="Enter in Password" ForeColor="Red"></asp:RequiredFieldValidator>'
        <asp:Button class="form-signin btn-change " ID="btn_login" runat="server" OnClick="login_Click" Text="Login" />
        <button type="button" class="form-signin btn-change" onclick="cancel_btn();">Cancel</button> 
     </div>
     </div> 

    <!-- /container -->
</form>
</body>
<script>
    function cancel_btn()
    {
        window.location.href = "../users/display_houses.aspx";
    }
</script>
</html>

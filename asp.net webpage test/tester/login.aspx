<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login Page</h1><br />
            <p>Username: </p>
            <input id="Text1" type="text" /><br />
            <p>Password: </p>
            <input id="Password1" type="password" /><br />
            <asp:Button ID="Login" runat="server" Text="Login" />

        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="agent_forms.aspx.cs" Inherits="agents_agent_forms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agent form</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <link href="bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="gridview.css" rel="stylesheet" />
</head>
<body>
    <form id="agent_form" runat="server">
        <!--Begin NaVigation Bar-->
    <ul>
        <li><a href="agentMain.aspx" > Home</a></li>
        <li><a href="insert_listing.aspx"> Add a listing</a></li>
        <li><a class="active"  href="#" >Agent Forms</a></li>
        <li><a href="../users/display_houses.aspx" >Customer's Main</a></li>
        <li><a href="#"><asp:Button ID="logoutButton" runat="server" OnClick="logoutButton_Click" Text="Logout" /></a></li>
    </ul>
        <!--End NaVigation Bar-->

        <!--Begin...-->
        <!--End...-->
    </form>
</body>
</html>

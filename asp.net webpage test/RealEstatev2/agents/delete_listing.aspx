<%@ Page Language="C#" AutoEventWireup="true" CodeFile="delete_listing.aspx.cs" Inherits="agents_delete_listing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agent Main Page</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
</head>
<body>


    <ul>
        <li><a href="agentMain.aspx" > Home</a></li>
        <li><a href="insert_listing.aspx"> Add a listing</a></li>
        <li><a href="update_listing.aspx"> Update A listing</a></li>
        <li><a class="active" href="#"> Delete a listing</a></li>
        <li><a href="#"> <form id="form2" runat="server"><asp:Button ID="logoutButton" runat="server" OnClick="Button1_Click" Text="Logout" /></form></a></li>
    </ul>

         <tr>
            <th><button type="button" value="delete" onclick="" runat="server">Delete Listing</button></th>
        </tr>
    <h1>Delete Listing</h1>
</body>
</html>

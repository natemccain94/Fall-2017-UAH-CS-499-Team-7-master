<%@ Page Language="C#" AutoEventWireup="true" CodeFile="agentMain.aspx.cs" Inherits="agentMain" Debug="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agent Main Page</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <link href="bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="gridview.css" rel="stylesheet" />
</head>
<body>
    <form id="agent" runat="server">
       
   
   
    <ul>
        <li><a class="active" href="#" > Home</a></li>
        <li><a href="insert_listing.aspx" >Add a Listing</a></li>
        <li><a href="../users/display_houses.aspx" >Customer's Main</a></li>
        <li><a href="agent_forms.aspx" >Agent Forms</a></li>
        <li><a href="#"><asp:Button ID="logoutButton" runat="server" OnClick="Button1_Click" Text="Logout" /></a></li>

    </ul>
    <h1> Welcome Agent</h1>
    
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"/>
     <!--test gridview-->
         Search:
        <asp:TextBox ID="txtSearch" runat="server" />
        <asp:Button Text="Search" runat="server" OnClick="Search_Click" />
        <hr />
        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GridView1_PageIndexChanging" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
            runat="server" AllowPaging="true" PageSize="5" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="listing_id" HeaderText="Listing ID" ItemStyle-Width="150" />
                <asp:BoundField DataField="listing_price" HeaderText="Price" ItemStyle-Width="150" />
                <asp:BoundField DataField="listing_street" HeaderText="Street" ItemStyle-Width="250" />
                <asp:BoundField DataField="listing_city" HeaderText="City" ItemStyle-Width="150" />
                <asp:BoundField DataField="listing_zip" HeaderText="ZipCode" ItemStyle-Width="100" />
                <asp:BoundField DataField="listing_shortDescription" HeaderText="Short Description" ItemStyle-Width="250" />
                <asp:BoundField DataField="listing_alarmInfo" HeaderText="Alarm Info." ItemStyle-Width="100" />
               <asp:HyperLinkField DataNavigateUrlFields="listing_id" HeaderText="More details..."  DataNavigateUrlFormatString="update_listing.aspx?listing_id={0}" Text="View Details" />
            </Columns>
        </asp:GridView>
    <!--test gridview-->
    </form>
</body>
  
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="agentMain.aspx.cs" Inherits="agentMain" Debug="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agent Main Page</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
</head>
<body>
    <form id="agent" runat="server">
       
   
   
    <ul>
        <li><a class="active" href="#" > Home</a></li>
        <li><a href="insert_listing.aspx" >Add a Listing</a></li>
        <li><a href="#"><asp:Button ID="logoutButton" runat="server" OnClick="Button1_Click" Text="Logout" /></a></li>
    </ul>

    <h1> Welcome Agent</h1>
    <h2><a href="../users/display_houses.aspx"> View Listings </a></h2>
    
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"/>
    <asp:Button ID="getdata" runat="server" Onclick="GetAgentID_Click" Text="click me!"></asp:Button>
    <asp:Label runat="server" ID="updaterino" Text="..." />
     
    <div class="products">
    <asp:Repeater ID="d2" runat="server"> 
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
       
        <ItemTemplate>
            <li class="last">
              <div class="over">
                    <a id="listing_ID" href="update_listing.aspx?listing_id=<%#Eval("listing_id") %>">
                        <img src='data:image/jpg;base64,<%#Eval("pic1") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("pic1")) : string.Empty %>' alt="pic1" height="300" width="300" />
                    </a>
                     <div class="overlay">
                         <div class="text">
                            <h2>$<%#Eval("listing_price") %></h2>
                            <h5><%#Eval("listing_street") %></h5>
                            <p style=""font-color: white"><%#Eval("listing_city") %> , <%#Eval("listing_state") %>, <%#Eval("listing_zip") %></p>
                            <p>Agency: <%#Eval("agency_name") %></p>
                            <p>Agent: <%#Eval("agent_Fname") %> <%#Eval("agent_Lname") %></p>
                         </div> 
                    </div>
                </div>         
          </li>
       </ItemTemplate>
        
       <FooterTemplate>
            </ul>
       </FooterTemplate>
    </asp:Repeater>
    <!-- Repeater ends here-->
    </div>
    <!-- Product div ends here -->

    </form>
</body>
  
</html>

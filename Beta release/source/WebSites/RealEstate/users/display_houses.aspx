﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="display_houses.aspx.cs" Inherits="users_display_houses"  EnableEventValidation="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="display_listing.css" type="text/css" media="all" />
  
</head>
<body>
 <form id="f1" runat="server">
   
     
     <!-- This is the unordered list that will allow users to login if they wish to. Css is in the display_listing.css file -->
     <div class="navBar">
         <h1 style="padding-left:10px; padding-top:10px; color:white; text-align:center"> Real Estate Website</h1>
     <ul>
        <li><a id="login" href="../agents/login.aspx">Agent? Log In</a></li>   
    </ul>
    </div>
    <!-- This is the end of the unordered list (the bar at the top -->

     <!--The div searchbar is floated to the left side of the page. It allows the user to enter in specific parameters they would like for their houses to fall under -->
     <!--Things to notice inside this div are the aspDropDownList which reloads the page every time it is clicked with the command "AutoPostBack=true" -->
     <!--Another thing to note is the fact that we have a TextBox1 and a TextBox2 where user enters in values. RegularExpressionValidators allow only certaint things to be inputted -->
     <div class="searchBar">
         <p>SEARCH</p>

         <asp:DropDownList Width="200" Height="40" Font-Size="Large" Font-Bold="true" ID="search_req" runat="server" OnSelectedIndexChanged="search_req_SelectedIndexChanged" AutoPostBack="True">
             <asp:ListItem  Enabled="true" Text="Select an option" Value="-1"></asp:ListItem>
             <asp:ListItem Enabled="true" Text="Sqft Min" Value="1"></asp:ListItem>
             <asp:ListItem Enabled="true" Text="Price minimum" Value="2"></asp:ListItem>
             <asp:ListItem Enabled="true" Text="Zip Code" Value="3"></asp:ListItem>
             

         </asp:DropDownList>

         <ul>
         <li id="price_min">
             <asp:TextBox ID="TextBox1" runat="server" Height="30" Width="150px" Visible="False"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator01" ControlToValidate="TextBox1" runat="server" ErrorMessage="only numbers" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
             <br />
             <asp:TextBox ID="TextBox2" runat="server" Height="30" Width="150px" Visible="False"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TextBox2" runat="server" ErrorMessage="only numbers" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            <!-- The asp:RegularExpressionValidator is how we restrict users from entering anything but numbers -->
         </li>
             <li id="searchButton">
                 <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Height="32px"  Text="Search" />
             </li>
         </ul>
     </div>
  
    <!-- This is the beginning of where the products are displayed. It is called products and linked to a styling element in display_listing.css -->
    <!-- Repeater is a container that allows you to create custom lists out of any data that is available on the page  --> 
    <!-- This is what will allow us to post all houses in the database without wasting space-->
    
    <!-- Right now the repeater is only pulling from listing table. It also needs to display from the 
         agent, and agency table as well. To do this I will need to implement some type of join in the cs portion of this code
      
    -->
    
    <div class="products">
    <asp:Repeater ID="d1" runat="server"> 
        
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        
        <ItemTemplate>
            <li class="last">
               
                <div class="over">
                    <!-- id= whatever is how we are passing the specific listing id-->
                    <a id="login" href="detailed_display.aspx?id=<%#Eval("listing_id") %>"><img src='data:image/jpg;base64,<%#Eval("listing_largePhoto") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("listing_largePhoto")) : string.Empty %>' alt="pic1" height="300" width="300" /></a>
                     <div class="overlay">
                         <div class="text">
                            <h2>$<%#Eval("listing_price") %></h2>
                            <h5><%#Eval("listing_street") %></h5>
                            <p style=""font-color: white"><%#Eval("listing_city") %> , <%#Eval("listing_state") %>, <%#Eval("listing_zip") %></p>
                             <p>Square Feet: <%#Eval("listing_sqFT") %></p>
                            <p>Agency: <%#Eval("agency_name") %></p>
                            <p>Agent: <%#Eval("agent_Fname") %> <%#Eval("agent_Lname") %></p>
                             <p style="font-size:large">Today Views:  <%#Eval("listing_hitCount") %></p>
                         </div> 
                    </div>
                </div>  
          </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
      <!-- id= whatever is how we are passing the specific listing id-->
       <asp:Button class="btn-change" runat="server" Text="More..." Font-Bold="true" Font-Size="Large" ForeColor="Black" OnClick="Pagination_Click" ToolTip="More Listing..."/>
    <!-- Repeater ends here-->
    </div>
    <!-- Product div ends here -->
</form>
</body>
</html>

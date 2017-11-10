<%@ Page Language="C#" AutoEventWireup="true" CodeFile="agent_display.aspx.cs" Inherits="users_display_houses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="agent_display.css" type="text/css" media="all" />
  
</head>
<body>
 <form id="f1" runat="server">
   
     
     <!-- This is the unordered list that will allow users to login if they wish to. Css is in the display_listing.css file -->
     <div class="navBar">
     <ul>
         
        <li><a id="login" href="../agents/login.aspx">Agent? Log In</a></li>   
    </ul>
    </div>
    <!-- This is the end of the unordered list (the bar at the top -->

     <div class="searchBar">
         <p>SEARCH</p>

         <asp:DropDownList ID="search_req" runat="server" OnSelectedIndexChanged="search_req_SelectedIndexChanged" AutoPostBack="True">
             <asp:ListItem Enabled="true" Text="Select an option" Value="-1"></asp:ListItem>
             <asp:ListItem Enabled="true" Text="Sqft Min" Value="1"></asp:ListItem>
             <asp:ListItem Enabled="true" Text="Price minimum" Value="2"></asp:ListItem>
             <asp:ListItem Enabled="true" Text="Zip Code" Value="3"></asp:ListItem>
             

         </asp:DropDownList>

         <ul>
         <li id="price_min">
             <asp:TextBox ID="TextBox1" runat="server" Width="100px" Visible="False"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator01" ControlToValidate="TextBox1" runat="server" ErrorMessage="only numbers" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
             <br />
             <asp:TextBox ID="TextBox2" runat="server" Width="100px" Visible="False"></asp:TextBox>
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
                    <a id="login" href="update_listing.aspx?id=<%#Eval("listing_id") %>"><img src='data:image/jpg;base64,<%#Eval("pic1") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("pic1")) : string.Empty %>' alt="pic1" height="300" width="300" /></a>
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

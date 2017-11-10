<%@ Page Language="C#" AutoEventWireup="true" CodeFile="detailed_display.aspx.cs" Inherits="users_detailed_display" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="detailed_display.css" type="text/css" media="all" />
</head>
<body>
   
    <form id="form1" runat="server">
        

         
     <!-- This is the unordered list that will allow users to login if they wish to. Css is in the display_listing.css file -->
     <div class="navBar">
          
        <a id="listings" href="display_houses.aspx">Back To Listings</a>
        <a id="login" href="../agents/login.aspx">Agent? Log In</a>
    
   
    </div>
    <!-- This is the end of the unordered list (the bar at the top -->
        
        
        <div>

            <asp:Repeater ID="d1" runat="server"> 
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate> 
            
            <div style="height:450px; width:100%" >

                <div style="height:300px; width:200px; float:left; margin-top: 100px">
                    <img src='data:image/jpg;base64,<%#Eval("pic1") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("pic1")) : string.Empty %>' alt="pic1" height="300" width="300" /></a>       
                </div>

                
                
                <div style="height:320px; width:630px; float:left;  margin-top:100px; margin-left: 140px">
                   
                            
                            <img src='data:image/jpg;base64,<%#Eval("pic2") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("pic2")) : string.Empty %>' alt="pic2" height="150" width="200"/></a>                            
                            <img src='data:image/jpg;base64,<%#Eval("pic3") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("pic3")) : string.Empty %>' alt="pic3" height="150" width="200"/></a>                                                  
                            <img src='data:image/jpg;base64,<%#Eval("pic4") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("pic4")) : string.Empty %>' alt="pic4" height="150" width="200" /></a>                                                
                            <img src='data:image/jpg;base64,<%#Eval("pic5") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("pic5")) : string.Empty %>' alt="pic5" height="150" width="200" /></a>                                               
                            <img src='data:image/jpg;base64,<%#Eval("pic6") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("pic6")) : string.Empty %>' alt="pic6" height="150" width="200"/></a>

                           
                
               </div>        
                        
               

                
                
                
                <div style="height: 320px; width: 300px; margin-top: 100px; margin-right: 60px; background-color: black; float:right">
                    <p style="font-family:'Times New Roman', Times, serif; color: white; font-size: 25px; text-align: center">Contact Us!</p>
                    <br />
                    <p style="color:white">First Name <asp:TextBox ID="fName" runat="server"></asp:TextBox> </p>  
                    </br>
                    <p style="color:white">Last Name <asp:TextBox  ID="lName" runat="server"></asp:TextBox> </p>
                    </br> </br>
                    <asp:Button ID="submitButton" runat="server" Text="Submit"></asp:Button>
                    
                </div>
                
               
            </div>

                
                
                <!-- Bar that says more information -->
                <div style="width: 100%; height: 90px; margin-top: 130px; background-color: black; margin: 5px 0px 5px 0px">
                    <h1 style="position: relative; text-align: center; color: white; margin: 30px 0px 0px 0px">More Information</h1>
                </div>
 
                <!-- This container div has 3 divs inside of it, each containint differnt information -->
                <div class="container1" style="position: absolute; margin-top: 70px; width: 100%; height: 500px; overflow:hidden; background-image: url('../Pictures/South_Boston_Waterfront_Wallpaper_u9eow.jpg')" >

                
                    <div class="house_info" style="width:30%; height:100%; float:left; margin: 10px 20px 0px 20px; background-color:black; opacity: .6">

                         
                         <p style="color: white; opacity: 1">Price: $<%#Eval("listing_price") %></p> 
                         <p style="color: white; opacity: 1">Description: <%#Eval("listing_description") %></p>
                         <p style="color: white; opacity: 1">Room Description: <%#Eval("listing_roomDescription") %></p> 
                         <p style="color: white; opacity: 1">Address: <%#Eval("listing_street") %> </p> 
                         <p style="color: white; opacity: 1">City/State/ZIP: <%#Eval("listing_city") %>, <%#Eval("listing_state") %> <%#Eval("listing_zip") %> </p>
                         <p style="color: white; opacity: 1">Square Footage: <%#Eval("listing_sqFT") %></p>

                    </div>

            
            <!--    
                    <div class="house_info2" style="width:30%; height:100%; margin-bottom: 100px; float:left; margin: 10px 20px 0px 20px; background-color: black; opacity: .6">

                         <p style="color: white; opacity: 1">Subdivison: <%#Eval("listing_nameSubDivision") %></p>
            
                
                    </div>

                    -->
                
                    <div id="theDiv" runat="server" class="house_info3" style="width:30%; height:100%; float:right; margin-bottom: 100px; margin: 10px 20px 0px 0px; background-color: black; opacity: .6">
                
                            <p style="color: white; opacity: 1">Subdivison: <%#Eval("listing_nameSubDivision") %></p>
                            <p style="color: white; opacity: 1">Agency: <%#Eval("agent_Fname") %> <%#Eval("agent_Lname") %></p>
                            <p style="color: white; opacity: 1">Agent: <%#Eval("agency_name") %></p>
                
                    </div>
            
                </div>


        </ItemTemplate>
        <FooterTemplate>            
        </FooterTemplate>
    </asp:Repeater>


        </div>



    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="schedule_listing.aspx.cs" Inherits="agents_schedule_listing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        
        <div>
            <asp:GridView ID="GridView1" runat="server" Height="282px" Width="1272px">
                <Columns>
                    <asp:HyperLinkField HeaderText="See Review" ControlStyle-BackColor="White" datanavigateurlfields="schedule_id" datanavigateurlformatstring="listing_review.aspx?id={0}" Text="See Review" />
                    
                 
                </Columns>
            </asp:GridView>
        
        
        </div>

        <div style="background-color:black">

            <p>hello</p>

        </div>

          <div id="theDiv" runat="server" class="house_info3" style="width:30%; height:600px; float:right; margin-bottom: 100px; margin: 10px 40% 0px 40%; background-color: black">
                
                         
                
              <br />
              <asp:Label ID="Label1" runat="server" BackColor="Black" ForeColor="#99FF66" Text="Book A Schedule"></asp:Label>
              <br />
              <br />
              <br />
              <br />
                
                         
                
              <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="height: 25px">
                  <asp:ListItem Value="01"></asp:ListItem>
                  <asp:ListItem Value="02"></asp:ListItem>
                  <asp:ListItem Value="03"></asp:ListItem>
                  <asp:ListItem Value="04"></asp:ListItem>
                  <asp:ListItem Value="05"></asp:ListItem>
                  <asp:ListItem Value="06"></asp:ListItem>
                  <asp:ListItem Value="07"></asp:ListItem>
                  <asp:ListItem Value="08"></asp:ListItem>
                  <asp:ListItem Value="09"></asp:ListItem>
                  <asp:ListItem Value="10"></asp:ListItem>
                  <asp:ListItem Value="11"></asp:ListItem>
                  <asp:ListItem Value="12"></asp:ListItem>
              </asp:DropDownList>


              <asp:DropDownList ID="DropDownList2" runat="server" style="top:100%">
                  <asp:ListItem Value="01"></asp:ListItem>
                  <asp:ListItem Value="02"></asp:ListItem>
                  <asp:ListItem Value="03"></asp:ListItem>
                  <asp:ListItem Value="04"></asp:ListItem>
                  <asp:ListItem Value="05"></asp:ListItem>
                  <asp:ListItem Value="06"></asp:ListItem>
                  <asp:ListItem Value="07"></asp:ListItem>
                  <asp:ListItem Value="08"></asp:ListItem>
                  <asp:ListItem Value="09"></asp:ListItem>
                  <asp:ListItem Value="10"></asp:ListItem>
                  <asp:ListItem Value="11"></asp:ListItem>
                  <asp:ListItem Value="12"></asp:ListItem>
                  <asp:ListItem Value="13"></asp:ListItem>
                  <asp:ListItem Value="14"></asp:ListItem>
                  <asp:ListItem Value="15"></asp:ListItem>
                  <asp:ListItem Value="16"></asp:ListItem>
                  <asp:ListItem Value="17"></asp:ListItem>
                  <asp:ListItem Value="18"></asp:ListItem>
                  <asp:ListItem Value="19"></asp:ListItem>
                  <asp:ListItem Value="20"></asp:ListItem>
                  <asp:ListItem Value="21"></asp:ListItem>
                  <asp:ListItem Value="22"></asp:ListItem>
                  <asp:ListItem Value="23"></asp:ListItem>
                  <asp:ListItem Value="24"></asp:ListItem>
                  <asp:ListItem Value="25"></asp:ListItem>
                  <asp:ListItem Value="26"></asp:ListItem>
                  <asp:ListItem Value="27"></asp:ListItem>
                  <asp:ListItem Value="28"></asp:ListItem>
                  <asp:ListItem Value="29"></asp:ListItem>
                  <asp:ListItem Value="30"></asp:ListItem>
                  <asp:ListItem Value="31"></asp:ListItem>
            
              </asp:DropDownList>


               <asp:DropDownList ID="DropDownList3" runat="server">
                  <asp:ListItem Value="2017"></asp:ListItem>
                  <asp:ListItem Value="2018"></asp:ListItem>
                  <asp:ListItem Value="2019"></asp:ListItem>
                  <asp:ListItem Value="2020"></asp:ListItem>
                  <asp:ListItem Value="2021"></asp:ListItem>
                  <asp:ListItem Value="2022"></asp:ListItem>
                  <asp:ListItem Value="2023"></asp:ListItem>
                  <asp:ListItem Value="2024"></asp:ListItem>
                 
              </asp:DropDownList>
                
              
              <br />
              <br />

              
               <asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
            
                  <asp:ListItem Value="8"></asp:ListItem>
                 
                   <asp:ListItem Value="9"></asp:ListItem>
                   <asp:ListItem Value="10"></asp:ListItem>
                   <asp:ListItem Value="11"></asp:ListItem>
                   <asp:ListItem Value="12"></asp:ListItem>
                 
                   <asp:ListItem Value="13"></asp:ListItem>
                   <asp:ListItem Value="14"></asp:ListItem>
                   <asp:ListItem Value="15"></asp:ListItem>
                   <asp:ListItem Value="16"></asp:ListItem>
                   <asp:ListItem Value="17"></asp:ListItem>
                   <asp:ListItem Value="18"></asp:ListItem>
                   <asp:ListItem Value="19"></asp:ListItem>
                   <asp:ListItem Value="20"></asp:ListItem>
       
              </asp:DropDownList>
                

              
               <asp:DropDownList ID="DropDownList5" runat="server">
                   <asp:ListItem Value="00"></asp:ListItem>
                  <asp:ListItem Value="05"></asp:ListItem>
                  <asp:ListItem Value="10"></asp:ListItem>
                  <asp:ListItem Value="15"></asp:ListItem>
                  <asp:ListItem Value="20"></asp:ListItem>
                  <asp:ListItem Value="25"></asp:ListItem>
                  <asp:ListItem Value="30"></asp:ListItem>
                  <asp:ListItem Value="35"></asp:ListItem>
                  <asp:ListItem Value="40"></asp:ListItem>        
                  <asp:ListItem Value="45"></asp:ListItem>
                  <asp:ListItem Value="50"></asp:ListItem>
                  <asp:ListItem Value="55"></asp:ListItem>
                
                 
              </asp:DropDownList>
                

              
               <asp:DropDownList ID="DropDownList6" runat="server" Visible="False">
                  <asp:ListItem Value="AM"></asp:ListItem>
                  <asp:ListItem Value="PM"></asp:ListItem>

                 
              </asp:DropDownList>

              <br />
              <br />

              <asp:DropDownList ID="DropDownList7" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">

                  <asp:ListItem Value="8"></asp:ListItem>
                 
                   <asp:ListItem Value="9"></asp:ListItem>
                   <asp:ListItem Value="10"></asp:ListItem>
                   <asp:ListItem Value="11"></asp:ListItem>
                   <asp:ListItem Value="12"></asp:ListItem>
                 
                   <asp:ListItem Value="13"></asp:ListItem>
                   <asp:ListItem Value="14"></asp:ListItem>
                   <asp:ListItem Value="15"></asp:ListItem>
                   <asp:ListItem Value="16"></asp:ListItem>
                   <asp:ListItem Value="17"></asp:ListItem>
                   <asp:ListItem Value="18"></asp:ListItem>
                   <asp:ListItem Value="19"></asp:ListItem>
                   <asp:ListItem Value="20"></asp:ListItem>
      
                </asp:DropDownList>


                   <asp:DropDownList ID="DropDownList8" runat="server">
                       <asp:ListItem Value="00"></asp:ListItem>
                        <asp:ListItem Value="05"></asp:ListItem>
                        <asp:ListItem Value="10"></asp:ListItem>
                        <asp:ListItem Value="15"></asp:ListItem>
                        <asp:ListItem Value="20"></asp:ListItem>
                        <asp:ListItem Value="25"></asp:ListItem>
                        <asp:ListItem Value="30"></asp:ListItem>
                        <asp:ListItem Value="35"></asp:ListItem>
                        <asp:ListItem Value="40"></asp:ListItem>        
                        <asp:ListItem Value="45"></asp:ListItem>
                        <asp:ListItem Value="50"></asp:ListItem>
                        <asp:ListItem Value="55"></asp:ListItem>
                
                 
              </asp:DropDownList>
                
                

                 <asp:DropDownList ID="DropDownList9" runat="server" Visible="False">
                  <asp:ListItem Value="AM"></asp:ListItem>
                  <asp:ListItem Value="PM"></asp:ListItem>

                 
              </asp:DropDownList>

              <br />
              <br />
              <br />
              <asp:Button ID="Button1" runat="server" Text="Schedule" OnClick="Button1_Click" />

         </div>
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    </form>
</body>
</html>

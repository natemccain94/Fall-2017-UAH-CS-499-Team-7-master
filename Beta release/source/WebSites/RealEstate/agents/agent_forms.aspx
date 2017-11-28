<%@ Page Language="C#" AutoEventWireup="true" CodeFile="agent_forms.aspx.cs" Inherits="agents_agent_forms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agent forms</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css"/>
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

        <div class="container">
            <!--begin ROW 1 of update listing-->
            <div class="row">
                <div class="col">
                <asp:label ID="Label1" runat="server" Font-Bold="true">Customer's Firstname</asp:label><br />
                <asp:TextBox runat="server" ID="form_customer_fname"/>
          </div>
                 <div class="col">
                <asp:label ID="Label2" runat="server" Font-Bold="true">Customer's Lastname</asp:label><br />
                <asp:TextBox runat="server" ID="form_customer_lname"/>
          </div>
                 <div class="col">
                <asp:label ID="Label3" runat="server" Font-Bold="true">Customer's Phone#:</asp:label><br />
                <asp:TextBox runat="server" ID="form_customer_phone"/>
          </div>
                <div class="col">
                <asp:label ID="Label4" runat="server" Font-Bold="true">Customer's Email:</asp:label><br />
                <asp:TextBox runat="server" ID="form_customer_email"/>
          </div>
            </div>
            <div class="row">
                <div class="col">
                     <asp:label ID="Label5" runat="server" Font-Bold="true">Agent Firstname</asp:label><br />
                     <asp:TextBox ReadOnly="true" BackColor="GhostWhite" BorderColor="Red" runat="server" ID="front_agentfname"/>
                </div>
                <div class="col">
                     <asp:label ID="Label6" runat="server" Font-Bold="true">Agent Lastname</asp:label><br />
                     <asp:TextBox ReadOnly="true" BackColor="GhostWhite" BorderColor="Red"  runat="server" ID="front_agentlname"/>
                </div>
                <div class="col">
                     <asp:label ID="Label7" runat="server" Font-Bold="true">Agent Phone</asp:label><br />
                     <asp:TextBox ReadOnly="true" BackColor="GhostWhite" BorderColor="Red" runat="server" ID="front_agentphone"/>
                </div>
                <div class="col">
                     <asp:label ID="Label8" runat="server" Font-Bold="true">Agent Email</asp:label><br />
                     <asp:TextBox ReadOnly="true" BackColor="GhostWhite" BorderColor="Red"  runat="server" ID="front_agentemail"/>
                </div>
            </div>
             <div class="row">
                <div class="col">
                     <asp:label ID="Label9" runat="server" Font-Bold="true">Property Street</asp:label><br />
                     <asp:TextBox ReadOnly="true" BackColor="GhostWhite" BorderColor="Red" runat="server" ID="front_listing_street"/>
                </div>
                <div class="col">
                     <asp:label ID="Label10" runat="server" Font-Bold="true">Property City</asp:label><br />
                     <asp:TextBox ReadOnly="true" BackColor="GhostWhite" BorderColor="Red"  runat="server" ID="front_listing_city"/>
                </div>
                <div class="col">
                     <asp:label ID="Label11" runat="server" Font-Bold="true">Property State</asp:label><br />
                     <asp:TextBox ReadOnly="true" BackColor="GhostWhite" BorderColor="Red" runat="server" ID="front_listing_state"/>
                </div>
                <div class="col">
                     <asp:label ID="Label12" runat="server" Font-Bold="true">Property ZIP</asp:label><br />
                     <asp:TextBox ReadOnly="true" BackColor="GhostWhite" BorderColor="Red"  runat="server" ID="front_listing_zip"/>
                </div>
            </div>

          <div class="row">
              <div class="col">
                  <asp:Button 
                        class="btn-change" 
                        runat="server" 
                        ID="Cancel" 
                        Text="Cancel"
                        OnClientClick ="return confirm('Are you certain you want to Cancel?');"
                        OnClick="Cancel_Click"/>
                  </div>
            <div class="col">
                  <asp:Button 
                        class="btn-change" 
                        runat="server" 
                        ID="close_listing" 
                        Text="close listing"
                        OnClientClick ="return confirm('Are you certain you want to close this listing?');"
                       OnClick="close_listing_Click"/>
            </div>
           </div>
        </div>
        <!--End...-->
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="update_listing.aspx.cs" Inherits="agents_update_listing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agent Main Page</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css"/>
</head>
<body>
    <form id="update_listing" runat="server">
     <asp:Label runat="server" ID="listing_id_text" Text="..." />
    <ul>
        <li><a href="agentMain.aspx" > Home</a></li>
        <li><a href="insert_listing.aspx"> Add a listing</a></li>
        <li><a class="active" href="#"> Update A listing</a></li>
        <li><a href="#"><asp:Button ID="logoutButton" runat="server" OnClick="Button1_Click" Text="Logout" /></a></li>
    </ul>
        <div class="container">
            <!--begin ROW 1 of update listing-->
            <div class="row">
            <div class="col">
               <asp:label ID="price" runat="server" Font-Bold="true">listing Price</asp:label><br />
               <asp:TextBox runat="server" ID="listing_price"/>
                <!--check input for numbers only-->
               <asp:RegularExpressionValidator 
                     ID="RegularExpressionValidator1" 
                     ControlToValidate="listing_price" 
                     runat="server" 
                     ErrorMessage="Numbers Only" 
                     ForeColor="Red"
                     Font-Bold="true"
                     ValidationExpression="\d+">
               </asp:RegularExpressionValidator>
            </div>
            <div class="col">
                <asp:label ID="State" runat="server" Font-Bold="true">listing State</asp:label><br />
                <asp:TextBox runat="server" ID="listing_state"/>
            </div>
            <div class="col">
                 <asp:label ID="City" runat="server" Font-Bold="true">listing City</asp:label><br />
                <asp:TextBox runat="server" ID="listing_city"/>
            </div>
            <div class="col">
                 <asp:label ID="Street" runat="server" Font-Bold="true">listing Street</asp:label><br />
                <asp:TextBox runat="server" ID="listing_street"/>
            </div>
            </div>
            <br />
            <!--end ROW 1 of update listing-->
            <!--begin ROW 2 of update listing-->
            <div class="row">
            <div class="col">
               <asp:label ID="sqFT" runat="server" Font-Bold="true">listing SquareFeet</asp:label><br />
               <asp:TextBox runat="server" ID="listing_sqFT"/>
                <!--check input for numbers only-->
                 <asp:RegularExpressionValidator 
                     ID="validator" 
                     ControlToValidate="listing_sqFT" 
                     runat="server" 
                     ErrorMessage="Numbers Only" 
                     ForeColor="Red" 
                     Font-Bold="true"
                     ValidationExpression="\d+">
                 </asp:RegularExpressionValidator>
            </div>
             <div class="col">
               <asp:label ID="zip" runat="server" Font-Bold="true">listing ZipCode</asp:label><br />
                <asp:TextBox runat="server" ID="listing_zip"/>
                 <!--check input for numbers only-->
                 <asp:RegularExpressionValidator 
                     ID="RegularExpressionValidator2" 
                     ControlToValidate="listing_zip" 
                     runat="server" 
                     ErrorMessage="Numbers Only" 
                     ForeColor="Red"
                     Font-Bold="true"
                     ValidationExpression="\d+">
                 </asp:RegularExpressionValidator>
            </div>
            <div class="col">
               <asp:label ID="description" runat="server" Font-Bold="true">listing Description</asp:label><br />
                <asp:TextBox runat="server" ID="listing_description"/>
            </div>
            <div class="col">
                <asp:label ID="room_description" runat="server" Font-Bold="true">listing Room Description</asp:label><br />
                <asp:TextBox runat="server" ID="listing_roomDescription"/>
            </div>
            </div>
            <br />
            <!--end ROW 2 of update listing-->
             <!--begin ROW 3 of update listing-->
            <div class="row">
            <div class="col">
                <asp:label ID="Label3" runat="server" Font-Bold="true">SubDivision</asp:label><br />
                <asp:TextBox runat="server" ID="listing_nameSubDivision"/>
            </div>
            <div class="col">
                <asp:label ID="shortdescription" runat="server" Font-Bold="true">listing Short Description</asp:label><br />
                <asp:TextBox runat="server" ID="listing_shortDescription"/>
            </div>
            <div class="col">
                <asp:label ID="Label4" runat="server" Font-Bold="true">listing AlarmInfo</asp:label><br />
                <asp:TextBox runat="server" ID="listing_alarminfo"/>
            </div>
            <div class="col">
                <asp:label ID="occupied" runat="server" Font-Bold="true">listing Occupid(Yes/No)</asp:label><br />
                <asp:checkbox runat="server" ID="listing_occupied"/>
            </div>
            </div>
            <br />
            <!--end ROW 3 of update listing-->
             <!--begin ROW 4 of update listing-->
            <div class="row">
            <div class="col">
                <h1>Picture 1</h1>
                <asp:Image runat="server" ID="Image1"></asp:Image>
                <asp:FileUpload runat="server" ID="FileUpload1" />
            </div>
            <div class="col">
                <h1>Picture 2</h1>
                <asp:Image runat="server" ID="Image2"></asp:Image>
                <asp:FileUpload runat="server" ID="FileUpload2" />
            </div>
            <div class="col">
                <h1>Picture 3</h1>
                <asp:Image runat="server" ID="Image3"></asp:Image>
                <asp:FileUpload runat="server" ID="FileUpload3" />
            </div>
            </div>
            <br />
            <!--begin ROW 4 of update listing-->
            <!--begin ROW 5 of update listing-->
            <div class="row">
            <div class="col">
                <h1>Picture 4</h1>
                <asp:Image class="img-thumbnail" runat="server" ID="Image4"></asp:Image>
                <asp:FileUpload runat="server" ID="FileUpload4" />
            </div>
            <div class="col">
                <h1>Picture 5</h1>
                <asp:Image class="img-thumbnail" runat="server" ID="Image5"></asp:Image>
                <asp:FileUpload runat="server" ID="FileUpload5" />
            </div>
            <div class="col">
                <h1>Picture 6</h1>
                <asp:Image class="img-thumbnail" runat="server" ID="Image6"></asp:Image>
                <asp:FileUpload runat="server" ID="FileUpload6" />
            </div>
            </div>
            <br />
            <!--end ROW 5 of update listing-->
            <!--begin for buttons-->
            <div class="row">
            <div class="col">
                <asp:Button class="img-thumbnail" runat="server" ID="Cancel" OnClick="Cancel_Click" Text="Cancel" />
            </div>
            <div class="col">
                <asp:Button class="img-thumbnail" runat="server" ID="Update" Text="Update" />
            </div>
            <div class="col">
                <asp:Button class="img-thumbnail" runat="server" ID="Delete" Text="Delete" OnClick="Delete_Click" />
            </div>
            </div>
            <br />
            <br />
            <!--end for buttons-->
        </div>
                        
        <!--javascript code-->
        <script type="text/javascript">
            function uploadfile()
            {

            }
        </script>
    </form>
</body>
</html>

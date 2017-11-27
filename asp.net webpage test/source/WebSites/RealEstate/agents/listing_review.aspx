<%@ Page Language="C#" AutoEventWireup="true" CodeFile="listing_review.aspx.cs" Inherits="agents_listing_review" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <style type="text/css">
        .auto-style1 {
            height: 564px;
        }
        .auto-style2 {
            height: 593px;
        }
    </style>
   
</head>
<body style="height: 573px">
    <form id="form1" runat="server" class="auto-style1">
        <div class="auto-style2">
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="0">0</asp:ListItem>
                <asp:ListItem Value="1"></asp:ListItem>
                <asp:ListItem Value="2"></asp:ListItem>
                <asp:ListItem Value="3"></asp:ListItem>
                <asp:ListItem Value="4"></asp:ListItem>
                <asp:ListItem Value="5"></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Text="Customer Interest"></asp:Label>

            <br />
            <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Overall Experience"></asp:Label>

            <br />

            <asp:DropDownList ID="DropDownList3" runat="server">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Text="Customer Opinion of Price"></asp:Label>

            <br />
            <asp:DropDownList ID="DropDownList4" runat="server">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label4" runat="server" Text="Agent Opinion of price"></asp:Label>

            <br />
            <br />

            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="load values" />

            <br />

            <asp:TextBox ID="TextBox1"  runat="server" Height="125px" Width="257px" TextMode="MultiLine" ></asp:TextBox>
         
            Additional Notes<br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            Buyer First Name<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            Buyer Laste Name<br /> <br />

            <asp:Label ID="Label9" runat="server" Text="Showing Agent Email:   "></asp:Label><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label10" runat="server" Text="Showing Agent Number:   "></asp:Label><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Is House Occupied?  "></asp:Label><asp:CheckBox ID="CheckBox1" runat="server" Text="House Occupied" />
            <br />
             <br />
            <asp:Label ID="Label8" runat="server" Text="Lock Box Code:    "></asp:Label><asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
             <br />
            
            <br />
            <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />



            



            <asp:Button ID="Button2" runat="server" OnClientClick="return false" OnClick="Button2_Click" Text="Update" />



            



        </div>
        
        
    </form>
</body>
</html>

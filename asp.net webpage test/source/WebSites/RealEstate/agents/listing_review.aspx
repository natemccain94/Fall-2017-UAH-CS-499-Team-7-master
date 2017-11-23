<%@ Page Language="C#" AutoEventWireup="true" CodeFile="listing_review.aspx.cs" Inherits="agents_listing_review" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <style type="text/css">
        .auto-style1 {
            height: 508px;
        }
    </style>
   
</head>
<body style="height: 469px">
    <form id="form1" runat="server" class="auto-style1">
        <div class="auto-style1">
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="0"></asp:ListItem>
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

            <br />

            <asp:TextBox ID="TextBox1"  runat="server" Height="125px" Width="257px" TextMode="MultiLine"></asp:TextBox>
         
            Additional Notes<br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            Buyer First Name<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            Buyer Laste Name<br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Upload" />



        </div>
        
        
    </form>
</body>
</html>

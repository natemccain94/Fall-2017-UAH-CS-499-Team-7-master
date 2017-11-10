<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Client Page</h1>
            <p>all agents: </p>
             <p id="agents">...</p><br />

            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

            <asp:Button ID="Button1" runat="server" Text="Get all agents" OnClientClick = "getAllagents('TextBoxName'); return false;" />
            <br />
            Search agent id: <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            <br />
            <p id="agentOne">...</p><br />
            <asp:Button ID="Login" runat="server" Text="Login" OnClientClick = "toLogin();return false;" />

            <script type="text/javascript">

                function toLogin()
                {
                    window.location.href = "login.aspx";
                }
                function getAllagents(x)
                {
                    var x2 = document.getElementById(x).value;
                    PageMethods.getAllagents(x2, onsuccess, onfailed);
                    function onsuccess(result)
                    {
                        document.getElementById("agents").innerHTML = result;
                        //alert(result);
                    }
                    function onfailed(result)
                    {
                        alert("something go wrong!!!");
                    }
                }
            </script>

        </div>
    </form>
</body>
</html>

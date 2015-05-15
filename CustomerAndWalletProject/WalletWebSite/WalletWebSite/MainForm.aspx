<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainForm.aspx.cs" Inherits="WalletWebSite.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 44%;
        }
        .auto-style3 {
            width: 495px;
            text-align: right;
        }
        .auto-style4 {
            width: 358px;
            margin-left: 40px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        WELCOME TO BETSSON WALLET<br />
    
    </div>
        <br />
        <br />
        <table class="auto-style2" align="center">
            <tr>
                <td class="auto-style3" style="border-style: outset; border-width: thin">*Email Id</td>
                <td class="auto-style4" style="border-style: outset; border-width: thin">
                    <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" style="border-style: outset; border-width: thin">*Password</td>
                <td class="auto-style4" style="border-style: outset; border-width: thin">
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" Width="61px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="border-style: outset; border-width: thin">New User</td>
                <td class="auto-style4" style="border-style: outset; border-width: thin">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Sign Up" Width="61px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="border-style: outset; border-width: thin">&nbsp;</td>
                <td class="auto-style4" style="border-style: outset; border-width: thin">
                    <asp:Label ID="lblStatus" runat="server" BackColor="#CCCCCC" Width="270px"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

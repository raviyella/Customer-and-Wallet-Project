<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionForm.aspx.cs" Inherits="WalletWebSite.TransactionForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 306px;
        }
        .auto-style3 {
            width: 198px;
        }
    </style>
</head>
<body>
    <form id="transactionform" runat="server">
    <div>
    
        WELCOME TO BETSSON WALLET<br />
        <br />
        <br />
    
    </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">WELCOME&nbsp;
                    <asp:Label ID="lblUsername" runat="server" BorderStyle="Double" Width="200px"></asp:Label>
                </td>     
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Logout" Width="112px" />
                </td>           
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button1" runat="server" Text="View Balance" Width="155px" OnClick="Button1_Click" />
                </td>
                <td>
                    <asp:Label ID="lblBalance" runat="server" BorderStyle="Ridge" Width="125px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button2" runat="server" Text="Deposit Funds" Width="155px" OnClick="Button2_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button3" runat="server" Text="Withdraw Funds" Width="155px" OnClick="Button3_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <td>&nbsp;</td>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblFromAccount" runat="server" Text="From Account" Width="200px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFromAccountNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblAmount" runat="server" Text="Amount" Width="200px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="btnOk" runat="server" Text="OK" Width="126px" OnClick="btnOk_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="126px" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblStatus" runat="server" Width="200px"></asp:Label>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Asp7Examples.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
                <caption>Login Form</caption>
                <tr>
                    <td>UserName :</td>
                    <td><asp:TextBox ID="textName" runat="server" Width="150px" /> </td>
                </tr>
                <tr>
                    <td>Password :</td>
                    <td><asp:TextBox ID="textPwd" runat="server" Width="150px" /> </td>
                </tr>

                <tr>
                    <td align="right"><asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" /> </td>
                    <td> <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" /> </td>
                </tr>

                <tr>
                    <td colspan="2"><asp:Label ID="lblStatus" runat="server" ForeColor="Red" /> </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

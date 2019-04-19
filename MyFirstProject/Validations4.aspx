<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validations4.aspx.cs" Inherits="Asp7Examples.Validations4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>Company name :</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Official Email Id :</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1Email" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="invalid email id" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Company URL :</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2URL" runat="server" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="invalid website URL" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>officail phone No :</td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3No" runat="server" ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="invalid phone no" ForeColor="Red" ValidationExpression="\+963-0\d{9}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="Button1" runat="server" Text="save data" />
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="reset form" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

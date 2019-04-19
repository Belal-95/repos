<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validation6.aspx.cs" Inherits="Asp7Examples.Validation6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 251px;
        }
        .auto-style3 {
            height: 32px;
        }
        .auto-style4 {
            width: 251px;
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td colspan="3" align="center">Agent Login</td>
                    <td colspan="3" align="center">Customer Login</td>
                </tr>
                <tr>
                    <td class="auto-style3">Agent id</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="AgentGroup"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="can't leaev this field empty" ForeColor="Red" ValidationGroup="AgentGroup"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style3">Customer id</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox3" runat="server" ValidationGroup="CustomerGroup"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="can't leaev this field empty" ForeColor="Red" ValidationGroup="CustomerGroup"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" ValidationGroup="AgentGroup"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="can't leaev this field empty" ForeColor="Red" ValidationGroup="AgentGroup"></asp:RequiredFieldValidator>
                    </td>
                    <td>Customer password</td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" ValidationGroup="CustomerGroup"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="can't leaev this field empty" ForeColor="Red" ValidationGroup="CustomerGroup"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="Button1" runat="server" Text="login" OnClick="Button1_Click" ValidationGroup="AgentGroup" />
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="reset" ValidationGroup="AgentGroup" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td align="right">
                        <asp:Button ID="Button3" runat="server" Text="login" OnClick="Button3_Click" ValidationGroup="CustomerGroup" />
                    </td>
                    <td>
                        <asp:Button ID="Button4" runat="server" Text="reset" ValidationGroup="CustomerGroup" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </form>
</body>
</html>

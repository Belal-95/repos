<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PanelControl.WebForm1" %>

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
                        <asp:Button ID="btnagent" runat="server" Text="Agent Login" OnClick="btnagent_Click" />
                        <asp:Button ID="btncustomer" runat="server" Text="Customer Login" />
        </div>
        <asp:Panel ID="pnlagent" runat="server" Visible="False">
            <table class="auto-style1">
                <tr align="center">
                    <td colspan="3">Agent Login</td>
                </tr>
                <tr>
                    <td>Agent id :</td>
                    <td>
                        <asp:TextBox ID="txtagentid" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtagentid" Display="Dynamic" ErrorMessage="can't leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password :</td>
                    <td>
                        <asp:TextBox ID="txtagentpsw" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtagentpsw" Display="Dynamic" ErrorMessage="can't leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <asp:Button ID="btnagentlogin" runat="server" Text="Login" />
                    </td>
                    <td >
                        <asp:Button ID="btnagentreset" runat="server" Text="Reset" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlcustomer" runat="server" Visible="False">
            <table class="auto-style1">
                <tr align="center">
                    <td colspan="3">Customer Login</td>
                </tr>
                <tr>
                    <td>Customer id :</td>
                    <td>
                        <asp:TextBox ID="txtcustomerid0" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtcustomerid0" Display="Dynamic" ErrorMessage="can't leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password :</td>
                    <td>
                        <asp:TextBox ID="txtcustomerpsw0" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcustomerpsw0" Display="Dynamic" ErrorMessage="can't leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <asp:Button ID="btncustomerlogin" runat="server" Text="Login" />
                    </td>
                    <td >
                        <asp:Button ID="btncustomerreset0" runat="server" Text="Reset" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>

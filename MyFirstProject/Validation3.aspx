<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validation3.aspx.cs" Inherits="Asp7Examples.Validation3" %>

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
        <table class="auto-style1">
            <tr>
                <td>User name :</td>
                <td>
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Password :</td>
                <td>
                    <asp:TextBox ID="txtpwd" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Confirm Password :</td>
                <td>
                    <asp:TextBox ID="txtcpwd" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="cvpwd" runat="server" ErrorMessage="Cinform password should match with the password" ControlToCompare="txtpwd" ControlToValidate="txtcpwd" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>Select date :</td>
                <td>
                    <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                </td>
                <td>
                    <asp:CompareValidator ID="cvdateDTC" runat="server" ErrorMessage="Value entered should be of type data" ControlToValidate="txtdate" Display="Dynamic" ForeColor="Red" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                    <br />
                    <asp:CompareValidator ID="cvDateLTD" runat="server" ErrorMessage="Date can't be less than today's date" ControlToValidate="txtdate" ForeColor="Red" Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2"align="center">
                    <asp:Button ID="Button1" runat="server" Text="Save data" OnClick="Button1_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>

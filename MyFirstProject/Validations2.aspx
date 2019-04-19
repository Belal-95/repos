<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validations2.aspx.cs" Inherits="Asp7Examples.Validations2" %>

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
                <td>
                    <table class="auto-style1">
                        <tr>
                            <td>Name :</td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Age :</td>
                            <td>
                                <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="efvAge" runat="server" ControlToValidate="txtAge" ErrorMessage="Can't leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="txtAge" Display="Dynamic" ErrorMessage="Age should be between 18-60" ForeColor="Red" Type="Integer" MaximumValue="60" MinimumValue="18"></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Date Of Journy</td>
                            <td>
                                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" Height="23px" ImageUrl="~/Icons/calendar.png" OnClick="ImageButton1_Click" Width="32px" />
                                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False"></asp:Calendar>
                            </td>
                            <td>
                                <asp:RangeValidator ID="rvDate" runat="server" ControlToValidate="txtDate" Display="Dynamic" ErrorMessage="Date should be today and go days from now" ForeColor="Red" Type="Date"></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button ID="Button1" runat="server" Text="Confirm" OnClick="Button1_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="Reset" CausesValidation="False" OnClick="Button2_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>

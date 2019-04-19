<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validations5.aspx.cs" Inherits="Asp7Examples.Validations5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 32px;
        }
        .auto-style5 {
            width: 221px;
        }
        .auto-style6 {
            height: 32px;
            width: 221px;
        }
        .auto-style7 {
            width: 198px;
        }
        .auto-style8 {
            height: 32px;
            width: 198px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">Name :</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtname" Display="Dynamic" ErrorMessage="can't leave this field empty" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Mobile No :</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:RegularExpressionValidator ID="revMobile" runat="server" ControlToValidate="txtmobile" Display="Dynamic" ErrorMessage="Invalid mobile number" ForeColor="Red" ValidationExpression="\+91-0\d{10}">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Email Id :</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CustomValidator ID="cvMobileOrEmail" runat="server" ErrorMessage="Either Mobile number or Email id is maindatory" ClientValidationFunction="MobileOrEmail" Display="Dynamic" ForeColor="Red" OnServerValidate="cvMobileOrEmail_ServerValidate">*</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Comments :</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtcomments" runat="server" Height="100px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:CustomValidator ID="cvComments" runat="server" ErrorMessage="Comments should be minimum 50 cahr lenght" ClientValidationFunction="CheckMinLength" ControlToValidate="txtcomments" Display="Dynamic" ForeColor="Red" OnServerValidate="cvComments_ServerValidate">*</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="margin-left: 40px" align="right" class="auto-style5">
                    <asp:Button ID="Button1" runat="server" Text="save data" OnClick="Button1_Click" />
                </td>
                <td class="auto-style7">
                    <asp:Button ID="Button2" runat="server" Text="reset form" OnClick="Button2_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
    </form>
</body>
</html>

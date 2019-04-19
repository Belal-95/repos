<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsDetails.aspx.cs" Inherits="MyFirstProject.StudentsDetails" %>

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
                    <td align="right">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td align="right">: إسم الطالب </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                    <td align="right">: إسم احلقة </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                    <td align="right">: العنوان</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                    <td align="right">: رقم الهاتف</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </td>
                    <td align="right">: رقم هاتف ولي الأمر </td>
                </tr>
                 <tr>
                    <td align="right" >
                        <asp:Button ID="Button1" runat="server" Text="إدخال بيانات طالب جديد" Width="100%" />
                    </td>
                    <td align="left">
                        <asp:Button ID="Button2" runat="server" Text="تحديث بيانات الطالب" Width="100%" />
                     </td>
                </tr>
                 <tr>
                    <td align="right">
                        <asp:Button ID="Button3" runat="server" Text="بحث عن الطالب عير الإسم" Width="100%" />
                    </td>
                    <td align="left" >
                        <asp:Button ID="Button4" runat="server" Text="حذف بيانات الطالب" Width="100%" />
                     </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

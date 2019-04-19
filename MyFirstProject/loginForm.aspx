<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginForm.aspx.cs" Inherits="Asp7Examples.loginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
 body {
  margin: 0;
  font-size: 28px;
}

.header {
  background-color: #f1f1f1;
  padding: 30px;
  text-align: center;
}

#navbar {
  overflow: hidden;
  background-color: #333;
}

#navbar a {
  float: left;
  display: block;
  color: #f2f2f2;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
}

#navbar a:hover {
  background-color: #ddd;
  color: black;
}

#navbar a.active {
  background-color: #4CAF50;
  color: white;
}

.content {
  padding: 16px;
}

.sticky {
  position: fixed;
  top: 0;
  width: 100%;
}

.sticky + .content {
  padding-top: 60px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
             
        <div id="navbar">
  <a  href="#1">Home</a>
  <a  href="javascript:void(0)">News</a>
  <a href="javascript:void(0)">Contact</a>
  <a class="active" href="javascript:void(0)">Log in</a>
</div>

        <div>
             <table align="center">
                <caption>Login Form</caption>
                <tr>
                    <td>UserName :</td>
                    <td><asp:TextBox ID="textName" runat="server" Width="150px" /> </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textName" Display="Dynamic" ErrorMessage="You can't leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password :</td>
                    <td><asp:TextBox ID="textPwd" runat="server" Width="150px" TextMode="Password" /> </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="textPwd" Display="Dynamic" ErrorMessage="You can't leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td align="right"><asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" /> </td>
                    <td> <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" /> </td>
                    <td> &nbsp;</td>
                </tr>

                <tr>
                    <td colspan="2"><asp:Label ID="lblStatus" runat="server" ForeColor="Red" /> </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>

        <script>
window.onscroll = function() {myFunction()};

var navbar = document.getElementById("navbar");
var sticky = navbar.offsetTop;

function myFunction() {
  if (window.pageYOffset >= sticky) {
    navbar.classList.add("sticky")
  } else {
    navbar.classList.remove("sticky");
  }
}
</script>

    </form>
</body>
</html>

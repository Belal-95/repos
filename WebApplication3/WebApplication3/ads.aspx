<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ads.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="refresh" content="3" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/XMLFile1.xml" Width="100%" Height="1000" Target="_blank" />
        </div>
    </form>
</body>
</html>

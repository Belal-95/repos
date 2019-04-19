<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validation1.aspx.cs" Inherits="Asp7Examples.Validation1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter your name :
            <asp:TextBox ID="txtname" runat="server" />
            <asp:RequiredFieldValidator ID="rfvName" ControlToValidate="txtname" runat="server" Display="Dynamic" 
                ErrorMessage="you can't leave this field empty"  ForeColor="Red"/>
            <br />
            Select your country :
            <asp:DropDownList ID="ddlcountries" runat="server">
                <asp:ListItem Text="Select country" Value="0"/>
                <asp:ListItem Text="Syria" Value="1"/>
                <asp:ListItem Text="China" Value="2"/>
                <asp:ListItem Text="Sudan" Value="3"/>
                <asp:ListItem Text="India" Value="4"/>
                <asp:ListItem Text="Turkey" Value="5"/>
                <asp:ListItem Text="Japan" Value="6"/>

            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvCountry" ControlToValidate="ddlcountries" runat="server" ErrorMessage="you need to select a country" 
                Display="Dynamic" ForeColor="Red" InitialValue="0" />
            
            <br />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <br />
            <asp:Label ID="lblStatus" runat="server" ForeColor="green" />
        </div>
    </form>
</body>
</html>

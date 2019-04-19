<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MyFirstProject.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Contact us.</h3>

    <%--<address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>--%>

    <address>
        <strong>Contact:</strong>   <a href="mailto:belal-khanger@hotmail.com">belal-khanger@hotmail.com</a><br />
       <%-- <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>--%>
    </address>
</asp:Content>

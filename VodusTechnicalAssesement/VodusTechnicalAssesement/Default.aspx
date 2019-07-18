<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VodusTechnicalAssesement._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 align="center">VODUS</h1>
        <hr />
        <table style="border: none; width: 100%">
            <tr>
                <th>
                    <p align="center"><a href="/Task1.aspx" class="btn btn-primary btn-lg">Task1</a></p>
                </th>
                <th>
                    <p align="center"><a href="/Task2.aspx" class="btn btn-primary btn-lg">Task2</a></p>
                </th>
                <th>
                    <p align="center"><a href="/Task3.aspx" class="btn btn-primary btn-lg">Task3</a></p>
                </th>
            </tr>
        </table>
    </div>
</asp:Content>

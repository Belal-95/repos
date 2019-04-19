<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <h1 style="margin:0px;background-color:maroon;color:white;text-align:center">
        Student List
    </h1>
    <br />
    <asp:LinkButton ID="lnkBtnCreateNewStudent" runat="server" Text="Create New Student" OnClick="lnkBtnCreateNewStudent_Click" />
    <br />
    <asp:GridView ID="gvStudent" runat="server" Width="100%" GridLines="Both" 
        AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" OnRowCommand="gvStudent_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Student Id" DataField="StudentId" />
            <asp:BoundField HeaderText="Name" DataField="Name" />
            <asp:BoundField HeaderText="Address" DataField="Address" />
            <asp:BoundField HeaderText="State" DataField="State" />
            <asp:BoundField HeaderText="City" DataField="City" />
            <asp:BoundField HeaderText="PinCode" DataField="PinCode" />
            <asp:BoundField HeaderText="Standard" DataField="StandardName" />
            <asp:TemplateField HeaderText="Action" >
                <ItemTemplate>
                    <asp:LinkButton id="lnkBtnEdit" runat="server" Text="Edit"
                        CommandName="EditStudent" CommandArgument='<%# Eval("StudentId") %>'></asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton id="LinkBtnDelete" runat="server" Text="Delete"
                        CommandName="DeleteStudent"  CommandArgument='<%# Eval("StudentId") %>'
                        OnClientClick="return confirm('Are you sure? Do you want to delete students ddetails?');"></asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton id="LinkBtnDetails" runat="server" Text="Details"
                        CommandName="DetailsStudent"  CommandArgument='<%# Eval("StudentId") %>'></asp:LinkButton>
                </ItemTemplate>

            </asp:TemplateField>


        </Columns>
        <EmptyDataTemplate>
            <p style="border:1px solid red;color:red">
                No students Data Available ata present
            </p>
<%--      or      <image src="Images/" width="500" height="350"/>--%>
        </EmptyDataTemplate>
        <EmptyDataRowStyle BorderColor="Red" />
    </asp:GridView>
    <br />
    <asp:Panel ID="pnlCreateEdit" runat="server" Width="500" BorderWidth="1" BorderColor="Gray" GroupingText="Insert Student Details" style="Cellpadding" Visible="false">
        <p><asp:Label ID="lblstatus" runat="server"/></p>
        <b>Name: </b><br />
        <asp:TextBox ID="txtName" runat="server" />
        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter name" ForeColor="Red" SetFocusOnReeoe="true" ValidationGroup="Create"/>

        <br /><br />

        <b>Address: </b><br />
        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="5" Columns="30"/>
        <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please enter Address" ForeColor="Red" SetFocusOnReeoe="true" ValidationGroup="Create"/>

        <br /><br />

        <b>City: </b><br />
        <asp:TextBox ID="txtCity" runat="server" />
        <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtCity" ErrorMessage="Please enter City" ForeColor="Red" SetFocusOnReeoe="true" ValidationGroup="Create"/>
        <br /><br />

        <b>State: </b><br />
        <asp:TextBox ID="txtState" runat="server" />
        <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="txtState" ErrorMessage="Please enter state" ForeColor="Red" SetFocusOnReeoe="true" ValidationGroup="Create"/>

        <br /><br />

        <b>Pin Code: </b><br />
        <asp:TextBox ID="txtPinCode" runat="server" />
        <asp:RequiredFieldValidator ID="rfv5" runat="server" ControlToValidate="txtPinCode" ErrorMessage="Please enter pin code" ForeColor="Red" SetFocusOnReeoe="true" ValidationGroup="Create"/>

        <br /><br />

        <b>Standard: </b><br />
        <asp:DropDownList ID="ddlStandard" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfv6" runat="server" ControlToValidate="ddlStandard" InitialValue="0" ErrorMessage="Please Select standard" ForeColor="Red" SetFocusOnReeoe="true" ValidationGroup="Create"/>

        <br /><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" ValidationGroup="Create" />
        &nbsp;
          <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click"  />
        
    </asp:Panel> 

        


            <asp:Panel ID="PnlDetails" runat="server" Width="500" BorderWidth="1" BorderColor="Gray" GroupingText="Student Details" style="Cellpadding" Visible="false">
        <b>StudentId:</b><br />        
        <p><asp:Label ID="lblStudentId" runat="server"/></p>

        <b>Name: </b><br />
        <asp:Label ID="lblName" runat="server" />
        <br /><br />

        <b>Address: </b><br />
        <asp:Label ID="lblAddress" runat="server" />
        <br /><br />

        <b>City: </b><br />
        <asp:Label ID="lblCity" runat="server" />
        <br /><br />

        <b>State: </b><br />
        <asp:Label ID="lblState" runat="server" />
        <br /><br />

        <b>Pin Code: </b><br />
        <asp:Label ID="lblPinCode" runat="server" />
        <br /><br />

        <b>Standard: </b><br />
        <asp:Label ID="lblStandard" runat="server"></asp:Label>
        <br /><br />
        &nbsp;
          <asp:Button ID="btnCloseDetails" runat="server" Text="Close" OnClick="btnCloseDetails_Click"  />
        
    </asp:Panel>

</asp:Content>
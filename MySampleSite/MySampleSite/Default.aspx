<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <h1 style="background-color:maroon;color:white;text-align:center">Students List</h1>
    <br />
    <asp:LinkButton ID="lnkBtnCreateNewStudent" Text="Create Student" runat="server" OnClick="lnkBtnCreateNewStudent_Click" />
    <asp:GridView ID="gvStudent" runat="server" AllowPaging="true"  AllowSorting="true" AutoGenerateColumns="false" Width="100%" OnRowCommand="gvStudent_RowCommand" >
        <Columns>
            <asp:BoundField HeaderText="Student Id" DataField="StudentId" />
            <asp:BoundField HeaderText="Name" DataField="Name" />
            <asp:BoundField HeaderText="Address" DataField="Address" />
            <asp:BoundField HeaderText="Phone Number" DataField="PhoneNumber" />
            <asp:BoundField HeaderText="Family Number" DataField="FamilyNumber" />
            <asp:BoundField HeaderText="Teacher Name" DataField="TeacherName" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Edit" CommandName="EditStudent" CommandArgument='<%# Eval("StudentId")%>'></asp:LinkButton>
                    &nbsp
                    <asp:LinkButton ID="lnkBtnDelete" runat="server" Text="Delete" CommandName="DeleteStudent" CommandArgument='<%# Eval("StudentId") %>'  OnClientClick="return confirm('Are you sure that you want to delete this Student Details ?')" ></asp:LinkButton>
                    &nbsp
                    <asp:LinkButton ID="lnkBtnDetails" runat="server" Text="Details" CommandName="DetailsStudent" CommandArgument='<%# Eval("StudentId") %>' ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
             
        </Columns>
        <EmptyDataTemplate>
            <p style="border:1px solid red;color:red" align="center">
                No Students Data is Available ^__________________________________^
            </p> 
        </EmptyDataTemplate>
        <EmptyDataRowStyle BorderColor="Red" />
    </asp:GridView>
    <br />
    <asp:Panel ID="pnlCreate" runat="server" Width="500" BorderWidth="1" BorderColor="Gray" GroupingText="Insert Student Details" Visible="false">
        <p><asp:Label ID="lblStatus" runat="server"/></p>
        <b>Name:</b><br />
        <asp:TextBox id="txtName" runat="server" />
        <asp:RequiredFieldValidator ID="rfv1" runat="server" ValidationGroup="Create" ControlToValidate="txtName" ForeColor="Red" ErrorMessage="Please Enter Name" SetFocusOnError="true" />
        <br /><br />

        <b>Address:</b><br />
        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"/>
        <asp:RequiredFieldValidator ID="rfv2" runat="server"  ControlToValidate="txtAddress" ForeColor="Red" ErrorMessage="Please Enter Address" ValidationGroup="Create" SetFocusOnError="true" />
        <br /><br />

        <b>Phon Number:</b><br />
        <asp:TextBox ID="txtPhoneNo" runat="server" />
        <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtPhoneNo" ForeColor="Red" ErrorMessage="Please Enter Phon Number" ValidationGroup="Create" SetFocusOnError="true" />
        <br /><br />

        <b>Family Number:</b><br />
        <asp:TextBox ID="txtFamilyNo" runat="server" />
        <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="txtFamilyNo" ForeColor="Red" ErrorMessage="Please Enter Family Number" ValidationGroup="Create" SetFocusOnError="true" />
        <br /><br />
        
        <b>Grad:</b><br />
        <asp:DropDownList ID="ddlGrad" runat="server" />
        <asp:RequiredFieldValidator ID="rfv5" runat="server" ControlToValidate="ddlGrad" ForeColor="Red" ErrorMessage="Please Select Grad" ValidationGroup="Create" SetFocusOnError="true" InitialValue="0" />
        <br /><br />

        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" ValidationGroup="Create" />
        &nbsp
        <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" />

        <p></p>

    </asp:Panel>
    <asp:Panel ID="pnlEdit" runat="server" Visible="false" Width="500" BorderWidth="1" BorderColor="Gray" GroupingText="Update Student Detials" >
        <br />
       <p><asp:Label ID="lblEditStatus" runat="server" ></asp:Label></p> 
        <br />
        <b>Name:</b>
        <br />
        <asp:TextBox ID="txtEditName" runat="server" />
        <asp:RequiredFieldValidator ID="rfve1"  runat="server" ControlToValidate="txtEditName" ErrorMessage="Please Insert the Name" ValidationGroup="Edit" SetFocusOnError="true" ForeColor="Red" />
        <br /><br />
        <b>Address:</b>
        <br />
        <asp:TextBox  ID="txtEditAddress"  runat="server" />
        <asp:RequiredFieldValidator ID="rfve2" runat="server" ControlToValidate="txtEditAddress" ForeColor="Red" ErrorMessage="Please Insert the Address" ValidationGroup="Edit" SetFocusOnError="true" />
        <br /><br />
        <b>Phon Number</b>
        <br />
        <asp:TextBox ID="txtEditPhonNo" runat="server" />
        <asp:RequiredFieldValidator ID="rfve3" runat="server" ControlToValidate="txtEditPhonNo" ForeColor="Red" ErrorMessage="Please Insert the Phon Number" SetFocusOnError="true" ValidationGroup="Edit"/>
        <br /><br />
        <b>Family Number</b>
        <br />
        <asp:TextBox ID="txtEditFamilyNo" runat="server" />
        <asp:RequiredFieldValidator ID="rfve4" runat="server" ControlToValidate="txtEditFamilyNo" ForeColor="Red" ErrorMessage="Please Insert the Family Number" SetFocusOnError="true" ValidationGroup="Edit"  />
        <br /><br />
        <asp:DropDownList ID="ddlEGrad" runat="server"  />
        <asp:RequiredFieldValidator ID="rfve5" runat="server" ControlToValidate="txtEditFamilyNo" ForeColor="Red" ErrorMessage="Please Select Grad" ValidationGroup="Edit" SetFocusOnError="true" />
        <br /><br />
        <asp:Button ID="btnEditSave" runat="server" Text="Save" OnClick="btnEditSave_Click" ValidationGroup="Edit"/>
        &nbsp
        <asp:Button ID="btnEditClose" runat="server" Text="Close" OnClick="btnEditClose_Click" />

    </asp:Panel>


    <asp:Panel ID="pnlDetails" runat="server" Visible="false" Width="500" BorderWidth="1" BorderColor="Gray" GroupingText="Student Detials" >
        <br />
        <b>StudentId:</b>
        <br />
        <asp:Label ID="lblStudent" runat="server" />
        <br /><br />
        <b>Name:</b>
        <br />
        <asp:Label ID="lblName" runat="server" />
        <br /><br />
        <b>Address:</b>
        <br />
        <asp:Label  ID="lblAddress"  runat="server" />
        <br /><br />
        <b>Phon Number</b>
        <br />
        <asp:Label ID="lblPhonNo" runat="server" />
        <br /><br />
        <b>Family Number</b>
        <br />
        <asp:Label ID="lblFamilyNo" runat="server" />
        <br /><br />
        <b>Grad:</b>
        <br />
        <asp:Label ID="lblGrad" runat="server"  />
        <br /><br />
        <asp:Button ID="btnDetailsClose" runat="server" Text="Close" OnClick="btnDetailsClose_Click" />

    </asp:Panel>


</asp:Content>


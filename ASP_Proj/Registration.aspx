

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="UpdateCustomer" MasterPageFile="~/Template.master"%>

<asp:Content ID="content0" ContentPlaceHolderId="CPH1" runat="server">
    <!--
This was done by Paul Teixeira
    
This file denotes the asp and is the gui of the customer registration
-->


<%--The linking of the detail files to the mnaster as well as the necessary content 
and class tags was done by Jon.
    
Many inline styles had to be removed and either duplicated in the CSS or improved/streamlined
Paul's detail page was the easiest to restyle as he kept to standard style practices and tried not to style --%>


    <div class="paul">
        <table class="table">
            <tr class="HeaderStyle">
                <td colspan="2">
                    Registration
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="FirstNameTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row1">
                <td class="col1"><asp:Label ID="Label2" runat="server" Text="Last Name:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="LastNameTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="AddressTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row1">
                <td class="col1"><asp:Label ID="Label5" runat="server" Text="Province:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="ProvinceTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label4" runat="server" Text="City:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="CityTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row1">
                <td class="col1"><asp:Label ID="Label6" runat="server" Text="Postal Code:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="PostolCodeTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label7" runat="server" Text="Country:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="CountryTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row1">
                <td class="col1"><asp:Label ID="Label8" runat="server" Text="Home Phone:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="HomePhoneTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label9" runat="server" Text="Bussiness Phone:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="BussinessPhoneTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row1">
                <td class="col1"><asp:Label ID="Label10" runat="server" Text="Email:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="EmailTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>

        </table>
        <br />
        <asp:RequiredFieldValidator CSSClass="lblAlert" ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstNameTxt" EnableClientScript="False" ErrorMessage="First Name Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator CSSClass="lblAlert" ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastNameTxt" EnableClientScript="False" ErrorMessage="Last Name Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
    </div>
</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderId="CPH2" runat="server">
    <div class="paul">
        <h3>&nbsp;</h3>
        <p>Please fill in required information to register with us!</p>
    </div>
</asp:Content>

<asp:Content ID="content4" ContentPlaceHolderId="CPH4" runat="server">
    <div class="paul">
        <asp:Button ID="CancelBtn" runat="server" OnClick="CancelBtn_Click" Text="Cancel" Width="225px" />
        <asp:Button ID="SaveBtn" runat="server" Text="Register" Width="225px" OnClick="SaveBtn_Click" />
    </div>
</asp:Content>

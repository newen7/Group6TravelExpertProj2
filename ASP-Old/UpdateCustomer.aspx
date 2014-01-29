

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateCustomer.aspx.cs" Inherits="UpdateCustomer" MasterPageFile="~/Template.master"%>

<asp:Content ID="dropdown" ContentPlaceHolderId="CPH1" runat="server">
<!--
This was done by Paul Teixeira
    
This file denotes the asp and is the gui of the update customer functionality.
It has listboxes and labels for each feild of the "Customer object"
-->
    <h1>Edit Customer Information</h1>
    <div class="paul">
        <table style="width:50%;">
            <tr>
                <td class="auto-style2"><asp:Label ID="Label12" runat="server" Text="Customer Id:"></asp:Label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="CustIdTxt" runat="server" Width="100%" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="FirstNameTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Label2" runat="server" Text="Last Name:"></asp:Label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="LastNameTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="AddressTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Label5" runat="server" Text="Province:"></asp:Label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="ProvinceTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Label4" runat="server" Text="City:"></asp:Label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="CityTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Label6" runat="server" Text="Postal Code:"></asp:Label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="PostolCodeTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Label7" runat="server" Text="Country:"></asp:Label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="CountryTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Label8" runat="server" Text="Home Phone:"></asp:Label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="HomePhoneTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Label9" runat="server" Text="Bussiness Phone:"></asp:Label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="BussinessPhoneTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Label10" runat="server" Text="Email:"></asp:Label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="EmailTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Label ID="Label11" runat="server" Text="Agent Id:"></asp:Label></td>
                <td class="auto-style3">
                    <asp:TextBox ID="AgentIdTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstNameTxt" EnableClientScript="False" ErrorMessage="First Name Is Required"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastNameTxt" EnableClientScript="False" ErrorMessage="Last Name Is Required"></asp:RequiredFieldValidator>
        <br />
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="AgentIdTxt" EnableClientScript="False" ErrorMessage="Funny Id for an Agent!" MaximumValue="1000" MinimumValue="0" Type="Integer"></asp:RangeValidator>
        <br />
        <asp:Button ID="CancelBtn" runat="server" OnClick="CancelBtn_Click" Text="Cancel" Width="225px" />
        <asp:Button ID="SaveBtn" runat="server" Text="Save" Width="225px" OnClick="SaveBtn_Click" />
</asp:Content>

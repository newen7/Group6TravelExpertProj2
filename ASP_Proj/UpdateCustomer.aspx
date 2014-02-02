

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateCustomer.aspx.cs" Inherits="UpdateCustomer" MasterPageFile="~/Template.master"%>


<asp:Content ID="header" ContentPlaceHolderId="header" runat="server">
    Update Customer
</asp:Content>

<asp:Content ID="content0" ContentPlaceHolderId="CPH1" runat="server">
    <!--

        PLEASE STOP HERE THIS IS NOT PORKODIS UPDATE CUSTOMER FUNCTION THIS IS NOT IN USE FOR THE THREADED PROJECT

        THIS WAS A BACKUP INCASE WE COULD NOT USE PORKODIS ON PRESENTATION DAY


This was done by Paul Teixeira
    
This file denotes the asp and is the gui of the update customer functionality.
It has listboxes and labels for each field of the "Customer object"
-->


<%--The linking of the detail files to the mnaster as well as the necessary content 
and class tags was done by Jon.
    
Many inline styles had to be removed and either duplicated in the CSS or improved/streamlined
Paul's detail page was the easiest to restyle as he kept to standard style practices and tried not to style --%>


    <div class="paul">
        <table class="table">
            <tr class="HeaderStyle">
                <td colspan="2">
                    Edit Customer Information
                </td>
            </tr>
            <tr class="row1">
                <td class="col1"><asp:Label ID="Label12" runat="server" Text="Customer Id:"></asp:Label></td>
                <td class="col2">
                    <asp:TextBox ID="CustIdTxt" runat="server" Width="100%" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label></td>
                <td class="col2">
                    <asp:TextBox ID="FirstNameTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row1">
                <td class="col1"><asp:Label ID="Label2" runat="server" Text="Last Name:"></asp:Label></td>
                <td class="col2">
                    <asp:TextBox ID="LastNameTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label></td>
                <td class="col2">
                    <asp:TextBox ID="AddressTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row1">
                <td class="col1"><asp:Label ID="Label5" runat="server" Text="Province:"></asp:Label></td>
                <td class="col2">
                    <asp:TextBox ID="ProvinceTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label4" runat="server" Text="City:"></asp:Label></td>
                <td class="col2">
                    <asp:TextBox ID="CityTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row1">
                <td class="col1"><asp:Label ID="Label6" runat="server" Text="Postal Code:"></asp:Label></td>
                <td class="col2">
                    <asp:TextBox ID="PostolCodeTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label7" runat="server" Text="Country:"></asp:Label></td>
                <td class="col2">
                    <asp:TextBox ID="CountryTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row1">
                <td class="col1"><asp:Label ID="Label8" runat="server" Text="Home Phone:"></asp:Label></td>
                <td class="col2">
                    <asp:TextBox ID="HomePhoneTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label9" runat="server" Text="Bussiness Phone:"></asp:Label></td>
                <td class="col2">
                    <asp:TextBox ID="BussinessPhoneTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row1">
                <td class="col1"><asp:Label ID="Label10" runat="server" Text="Email:"></asp:Label></td>
                <td class="col2">
                    <asp:TextBox ID="EmailTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label11" runat="server" Text="Agent Id:"></asp:Label></td>
                <td class="col2">
                    <asp:TextBox ID="AgentIdTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:RequiredFieldValidator CSSClass="lblAlert" ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstNameTxt" EnableClientScript="False" ErrorMessage="First Name Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator CSSClass="lblAlert" ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastNameTxt" EnableClientScript="False" ErrorMessage="Last Name Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:RangeValidator CSSClass="lblAlert" ID="RangeValidator1" runat="server" ControlToValidate="AgentIdTxt" EnableClientScript="False" ErrorMessage="Funny Id for an Agent!" MaximumValue="1000" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
        <br />
    </div>
</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderId="CPH2" runat="server">
    <div class="paul">
        <h3>This is Paul&#39;s description</h3>
        <p>
            This file denotes the asp and is the gui of the update customer functionality. It has listboxes and labels for each field of the &quot;Customer object&quot;</p>
    
        <p>
            The update function is passed an object of Customers type and then builds an sql statment to do an update based on this information. Uses unified connection string from TravelDb and throws exception on failure to any try/catch block that called it.</p>
    </div>
</asp:Content>

<asp:Content ID="content4" ContentPlaceHolderId="CPH4" runat="server">
    <div class="paul">
        <asp:Button ID="CancelBtn" runat="server" OnClick="CancelBtn_Click" Text="Cancel" Width="225px" />
        <asp:Button ID="SaveBtn" runat="server" Text="Save" Width="225px" OnClick="SaveBtn_Click" />
    </div>
</asp:Content>

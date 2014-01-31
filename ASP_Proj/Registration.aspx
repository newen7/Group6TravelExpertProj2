

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="UpdateCustomer" MasterPageFile="~/Template.master"%>

<asp:Content ID="header" ContentPlaceHolderId="header" runat="server">
    Registration
</asp:Content>

<asp:Content ID="menu" ContentPlaceHolderId="menu" runat="server">
    
</asp:Content>

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
                <td class="col1"><asp:Label ID="Label11" runat="server" Text="Username:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="UsernameTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label12" runat="server" Text="Password:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="Password1Txt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label13" runat="server" Text="Password again:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="Password2Txt" runat="server" Width="100%"></asp:TextBox>
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
                <td class="col1" style="height: 27px"><asp:Label ID="Label7" runat="server" Text="Country:"></asp:Label></td>
                <td class="col2" style="width: 166px; height: 27px;">
                    <asp:DropDownList ID="CountryTxt" runat="server" Height="33px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="100%">
                        <asp:ListItem Selected="True">Canada</asp:ListItem>
                        <asp:ListItem>United States</asp:ListItem>
                    </asp:DropDownList>
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
        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="UsernameTxt" CssClass="lblAlert" ErrorMessage="One word only for username please" ForeColor="Red" ValidationExpression="^[A-Za-z]+$" EnableClientScript="False"></asp:RegularExpressionValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FirstNameTxt" CssClass="lblAlert" ErrorMessage="One word only for first name" ForeColor="Red" ValidationExpression="^[A-Za-z]+$" EnableClientScript="False"></asp:RegularExpressionValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="LastNameTxt" CssClass="lblAlert" ErrorMessage="One word only for last name" ForeColor="Red" ValidationExpression="^[A-Za-z]+$" EnableClientScript="False"></asp:RegularExpressionValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ProvinceTxt" CssClass="lblAlert" ErrorMessage="Please format Province/State such as TX-Texas BC-British Columbia" ForeColor="Red" ValidationExpression="^[A-Za-z][A-Za-z]$" EnableClientScript="False"></asp:RegularExpressionValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="PostolCodeTxt" CssClass="lblAlert" ErrorMessage="Postal Code format incorrect" ForeColor="Red" EnableClientScript="False" ValidationExpression="^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} *\d{1}[A-Z]{1}\d{1}$"></asp:RegularExpressionValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="HomePhoneTxt" CssClass="lblAlert" ErrorMessage="Phone number with area code" ForeColor="Red" EnableClientScript="False" ValidationExpression="^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$"></asp:RegularExpressionValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="EmailTxt" CssClass="lblAlert" ErrorMessage="Email in unknown format" ForeColor="Red" EnableClientScript="False" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator CSSClass="lblAlert" ID="RequiredFieldValidator8" runat="server" ControlToValidate="UsernameTxt" EnableClientScript="False" ErrorMessage="Username Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator CSSClass="lblAlert" ID="RequiredFieldValidator9" runat="server" ControlToValidate="Password1Txt" EnableClientScript="False" ErrorMessage="Password is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />

        <asp:CompareValidator CSSClass="lblAlert" ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match" ForeColor="Red" EnableClientScript="False" ControlToCompare="Password2Txt" ControlToValidate="Password1Txt"></asp:CompareValidator>

        <br />
        <asp:RequiredFieldValidator CSSClass="lblAlert" ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstNameTxt" EnableClientScript="False" ErrorMessage="First Name Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator CSSClass="lblAlert" ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastNameTxt" EnableClientScript="False" ErrorMessage="Last Name Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator CSSClass="lblAlert" ID="RequiredFieldValidator3" runat="server" ControlToValidate="AddressTxt" EnableClientScript="False" ErrorMessage="Address Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator CSSClass="lblAlert" ID="RequiredFieldValidator4" runat="server" ControlToValidate="ProvinceTxt" EnableClientScript="False" ErrorMessage="Province Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator CSSClass="lblAlert" ID="RequiredFieldValidator5" runat="server" ControlToValidate="CityTxt" EnableClientScript="False" ErrorMessage="City Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator CSSClass="lblAlert" ID="RequiredFieldValidator6" runat="server" ControlToValidate="PostolCodeTxt" EnableClientScript="False" ErrorMessage="Postal Code Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator CSSClass="lblAlert" ID="RequiredFieldValidator7" runat="server" ControlToValidate="HomePhoneTxt" EnableClientScript="False" ErrorMessage="Home Phone Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
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

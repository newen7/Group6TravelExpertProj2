<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="UpdateCustomer" MasterPageFile="~/Template.master"%>

<asp:Content ID="header" ContentPlaceHolderId="header" runat="server">
    Registration
</asp:Content>

<asp:Content ID="menu" ContentPlaceHolderId="menu" runat="server">
    <div class="menu">
        <ul>
            <li><a href="Default.aspx">Home</a></li>
            <li id="separator">
                <asp:Button ID="CancelBtn" runat="server" OnClick="CancelBtn_Click" Text="Cancel" Width="225px" />
                <asp:Button ID="SaveBtn" runat="server" Text="Register" Width="225px" OnClick="SaveBtn_Click" />
            </li>
            <li><a class="active" href="Registration.aspx">Registration</a></li>
            <li><a href="Login.aspx">Login</a></li>
        </ul>
    </div>
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
        <h3>Please fill in required information to register with us!</h3>
        <table class="table">
            <tr class="HeaderStyle">
                <td colspan="2">
                    Registration
                </td>
            </tr>
            <tr class="row1">
                <td class="col1"><asp:Label ID="Label11" runat="server" Text="Username:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="UsernameTxt" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr class="row2">
                <td class="col1"><asp:Label ID="Label12" runat="server" Text="Password:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="Password1Txt" runat="server" Width="100%" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr class="row1">
                <td class="col1"><asp:Label ID="Label13" runat="server" Text="Password again:"></asp:Label></td>
                <td class="col2" style="width: 166px">
                    <asp:TextBox ID="Password2Txt" runat="server" Width="100%" TextMode="Password"></asp:TextBox>
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

        <div class="errors">
            <asp:Label ID="Label14" runat="server" ForeColor="Red" Text="Username already in use!" Visible="False"></asp:Label>
          <br />
        <asp:RequiredFieldValidator 
            CSSClass="lblAlert" 
            ID="RequiredFieldValidator8" 
            runat="server" 
            ControlToValidate="UsernameTxt" 
            EnableClientScript="False" 
            ErrorMessage="Username Is Required">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator 
            CSSClass="lblAlert" 
            ID="RequiredFieldValidator9" 
            runat="server" 
            ControlToValidate="Password1Txt" 
            EnableClientScript="False" 
            ErrorMessage="Password is Required">
        </asp:RequiredFieldValidator>
        <br />
        <asp:CompareValidator 
            CSSClass="lblAlert" 
            ID="CompareValidator1" 
            runat="server" 
            ErrorMessage="Passwords do not match" 
            EnableClientScript="False" 
            ControlToCompare="Password2Txt" 
            ControlToValidate="Password1Txt">
        </asp:CompareValidator>
        <br />
        <asp:RequiredFieldValidator 
            CSSClass="lblAlert" 
            ID="RequiredFieldValidator1" 
            runat="server" 
            ControlToValidate="FirstNameTxt" 
            EnableClientScript="False" 
            ErrorMessage="First Name Is Required">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator 
            CSSClass="lblAlert" 
            ID="RequiredFieldValidator2" 
            runat="server" 
            ControlToValidate="LastNameTxt" 
            EnableClientScript="False" 
            ErrorMessage="Last Name Is Required">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator 
            CSSClass="lblAlert" 
            ID="RequiredFieldValidator3" 
            runat="server" 
            ControlToValidate="AddressTxt" 
            EnableClientScript="False" 
            ErrorMessage="Address Is Required">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator 
            CSSClass="lblAlert" 
            ID="RequiredFieldValidator4" 
            runat="server" 
            ControlToValidate="ProvinceTxt" 
            EnableClientScript="False" 
            ErrorMessage="Province Is Required">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator 
            CSSClass="lblAlert" 
            ID="RequiredFieldValidator5" 
            runat="server" 
            ControlToValidate="CityTxt" 
            EnableClientScript="False" 
            ErrorMessage="City Is Required">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator 
            CSSClass="lblAlert" 
            ID="RequiredFieldValidator6" 
            runat="server" 
            ControlToValidate="PostolCodeTxt" 
            EnableClientScript="False" 
            ErrorMessage="Postal Code Is Required">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator 
            CSSClass="lblAlert" 
            ID="RequiredFieldValidator7" 
            runat="server" 
            ControlToValidate="HomePhoneTxt" 
            EnableClientScript="False" 
            ErrorMessage="Home Phone Is Required">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator 
            ID="RegularExpressionValidator1" 
            runat="server" 
            ControlToValidate="FirstNameTxt" 
            CssClass="lblAlert" 
            ErrorMessage="One word only for first name" 
            ValidationExpression="^[A-Za-z]+$" 
            EnableClientScript="False">
        </asp:RegularExpressionValidator>
        <br />
        <asp:RegularExpressionValidator 
            ID="RegularExpressionValidator2" 
            runat="server" 
            ControlToValidate="LastNameTxt" 
            CssClass="lblAlert" 
            ErrorMessage="One word only for last name" 
            ValidationExpression="^[A-Za-z]+$" 
            EnableClientScript="False">
        </asp:RegularExpressionValidator>
        <br />
        <asp:RegularExpressionValidator 
            ID="RegularExpressionValidator3" 
            runat="server" 
            ControlToValidate="ProvinceTxt" 
            CssClass="lblAlert" 
            ErrorMessage="Please format Province/State such as TX-Texas BC-British Columbia" 
            ValidationExpression="^[A-Za-z][A-Za-z]$" 
            EnableClientScript="False">
        </asp:RegularExpressionValidator>
        <br />
        <asp:RegularExpressionValidator 
            ID="RegularExpressionValidator4" 
            runat="server" 
            ControlToValidate="PostolCodeTxt" 
            CssClass="lblAlert" 
            ErrorMessage="Postal Code format incorrect" 
            EnableClientScript="False" 
            ValidationExpression="^[A-Za-z]{1}\d{1}[A-Za-z]{1} *\d{1}[A-Za-z]{1}\d{1}$">
        </asp:RegularExpressionValidator>
        <br />
        <asp:RegularExpressionValidator 
            ID="RegularExpressionValidator5" 
            runat="server" 
            ControlToValidate="HomePhoneTxt" 
            CssClass="lblAlert" 
            ErrorMessage="Phone number with area code" 
            EnableClientScript="False" 
            ValidationExpression="^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$">
        </asp:RegularExpressionValidator>
        <br />
        <asp:RegularExpressionValidator 
            ID="RegularExpressionValidator6" 
            runat="server" 
            ControlToValidate="EmailTxt" 
            CssClass="lblAlert" 
            ErrorMessage="Email in unknown format" 
            EnableClientScript="False" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
        </asp:RegularExpressionValidator>
        <br />
        </div>
    </div>
</asp:Content>


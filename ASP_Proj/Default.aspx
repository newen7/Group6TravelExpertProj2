<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/Template.master" %>


<%--
The linking of the detail files to the master as well as the necessary content 
and class tags was done by Jon.
    
Many inline styles had to be removed and either duplicated in the CSS or improved/streamlined
--%>

<asp:Content ID="header" ContentPlaceHolderId="header" runat="server">
    Main Page
</asp:Content>

<asp:Content ID="menu" ContentPlaceHolderId="menu" runat="server">
    <div class="menu">
        <ul>
            <li><a class="active" href="Default.aspx">Home</a></li>
            <div id="separator"></div>
            <li><a href="Registration.aspx">Registration</a></li>
            <li><a href="Login.aspx">Login</a></li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="dropdown" ContentPlaceHolderId="CPH1" runat="server">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderId="CPH2" runat="server">

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderId="CPH3" runat="server">

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderId="CPH4" runat="server">

</asp:Content>

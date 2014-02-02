<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/Template.master"%>

<%----- Login Detail page -----
By: Jonathan Love               
 Student ID: 000655580          
 Description:                   
 sets the title and provides structure for the 
 content via the master template.  The design,  
 structure (header, menu, various content zones)
 and styling is all Jon.  Many inline styles had 
 to be removed and either duplicated in the CSS 
 or improved/streamlined
/*--------------------------------------------%>

<asp:Content ID="title" ContentPlaceHolderId="header" runat="server">
    Login
</asp:Content>

<asp:Content ID="menu" ContentPlaceHolderId="menu" runat="server">
    <div class="menu">
        <ul>
            <li><a href="Default.aspx">Home</a></li>
            <li id="separator"></li>
            <li><a href="Registration.aspx">Registration</a></li>
            <li><a class="active" href="Login.aspx">Login</a></li>
        </ul>
    </div>
</asp:Content>


<asp:Content ID="content0" ContentPlaceHolderId="CPH1" runat="server">
    <div class="login">
        <h3>Please provide your user name and password</h3>
        <br /><br />
        <asp:Label CSSClass="label" ID="Label1" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <br />
        <asp:Label CSSClass="label" ID="Label2" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox CSSClass="textbox" ID="txtPasswd" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log In" Width="94px" />
        <asp:Label CSSClass="label" ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <p>
        <img src="img/Img03.jpg" />
    </p>
</asp:Content>

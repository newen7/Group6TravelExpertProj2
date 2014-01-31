<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/Template.master"%>

<asp:Content ID="title" ContentPlaceHolderId="header" runat="server">
    Login
</asp:Content>

<asp:Content ID="menu" ContentPlaceHolderId="menu" runat="server">
    <div class="menu">
        <ul>
            <li><a href="Default.aspx">Home</a></li>
            <div id="separator"></div>
            <li><a href="Registration.aspx">Registration</a></li>
            <li><a class="active" href="Login.aspx">Login</a></li>
        </ul>
    </div>
</asp:Content>


<asp:Content ID="content0" ContentPlaceHolderId="CPH1" runat="server">
    <div style="text-align: left">
        <br />
        <table style="width: 39%">
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Log In</strong><br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
&nbsp;
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
&nbsp;
                    <asp:TextBox ID="txtPasswd" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log In" Width="94px" />
                </td>
            </tr>
        </table>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        <br />
    </div>
</asp:Content>

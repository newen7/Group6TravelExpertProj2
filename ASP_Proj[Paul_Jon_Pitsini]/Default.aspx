<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/Template.master" %>

<%----- Default (index) Detail page -----
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

<asp:Content ID="header" ContentPlaceHolderId="header" runat="server">
    Main Page
</asp:Content>

<asp:Content ID="menu" ContentPlaceHolderId="menu" runat="server">
    <div class="menu">
        <ul>
            <li><a class="active" href="Default.aspx">Home</a></li>
            <li id="separator"></li>
            <li><a href="Registration.aspx">Registration</a></li>
            <li><a href="Login.aspx">Login</a></li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="dropdown" ContentPlaceHolderId="CPH1" runat="server">
    <div class="circle">
        <img src="img/arr1.jpg" />
    </div>
    <div class="caption"></div>
    <div class="circle">
        <img src="img/arr2.jpg" />
    </div>
    <div class="caption">Ko Phi Phi, Krabi: one of the most naturally beautiful islands in the world</div>
    <div class="caption">Royal Grand Palace, Bangkok: at the top of every visitors "must-see" list</div>
    <div class="circle">
        <img src="img/arr3.jpg" />
    </div>
    <div class="circle">
        <img src="img/arr5.jpg" />
    </div>
    <div class="caption">Huai Nam Dang National Park, Chiang Mai: filled with attractive natural condition and virginal forest</div>
    <div class="caption">Enjoy a cool climate all year round and mountain scenery at Doi Ang Khang, Chiang Mai</div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderId="CPH2" runat="server">

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderId="CPH3" runat="server">

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderId="CPH4" runat="server">

</asp:Content>

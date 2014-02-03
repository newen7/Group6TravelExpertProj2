<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerUpdates.aspx.cs" Inherits="CustomerUpdates" MasterPageFile="~/Template.master"%>
<%----- Customer updates Detail page -----
By: Jonathan Love               
 Student ID: 000655580          
 Description:                   
 sets the title and provides structure for the 
 content via the master template.  The controls
 belong to my other team members but the 
 structure (header, menu, various content zones)
 and styling is all Jon
/*--------------------------------------------%>
<asp:Content ID="header" ContentPlaceHolderId="header" runat="server">
    Customer Updates
</asp:Content>

<asp:Content ID="menu" ContentPlaceHolderId="menu" runat="server">
    <div class="menu">

    </div>
</asp:Content>

<asp:Content ID="content0" ContentPlaceHolderId="CPH1" runat="server">
    <div class="porkodi">
        <div class="container">
        <br />
        <asp:DetailsView 
            ID="DetailsView" 
            runat="server" 
            AutoGenerateEditButton="True" 
            AutoGenerateRows="False" 
            CellPadding="4" 
            DataSourceID="ObjectDataSource2"
            HeaderText="Customer Information">

            <AlternatingRowStyle BackColor="#444444" />
            <EditRowStyle CSSClass="EditRowStyle" />
            <Fields>
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
                <asp:BoundField DataField="CustFirstName" HeaderText="CustFirstName" SortExpression="CustFirstName" />
                <asp:BoundField DataField="CustLastName" HeaderText="CustLastName" SortExpression="CustLastName" />
                <asp:BoundField DataField="CustAddress" HeaderText="CustAddress" SortExpression="CustAddress" />
                <asp:BoundField DataField="CustCity" HeaderText="CustCity" SortExpression="CustCity" />
                <asp:BoundField DataField="CustProv" HeaderText="CustProv" SortExpression="CustProv" />
                <asp:BoundField DataField="CustPostal" HeaderText="CustPostal" SortExpression="CustPostal" />
                <asp:BoundField DataField="CustCountry" HeaderText="CustCountry" SortExpression="CustCountry" />
                <asp:BoundField DataField="CustHomePhone" HeaderText="CustHomePhone" SortExpression="CustHomePhone" />
                <asp:BoundField DataField="CustBusPhone" HeaderText="CustBusPhone" SortExpression="CustBusPhone" />
                <asp:BoundField DataField="CustEmail" HeaderText="CustEmail" SortExpression="CustEmail" />
                <asp:BoundField DataField="AgentId" HeaderText="AgentId" SortExpression="AgentId" />
            </Fields>
            <FooterStyle CSSClass="FooterStyle" />
            <HeaderStyle CSSClass="HeaderStyle" />
            <PagerStyle CSSClass="PagerStyle" />
            <RowStyle CSSClass="RowStyle" />
        </asp:DetailsView>
        <asp:ObjectDataSource 
            ID="ObjectDataSource2" 
            runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetCustomerID" 
            TypeName="CustomersDB">
            <SelectParameters>
                <asp:SessionParameter 
                    Name="CustomerId" 
                    SessionField="CustID" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        </div>
    </div>
    <p>
        <img src="img/Img02.jpg" />
    </p>
</asp:Content>

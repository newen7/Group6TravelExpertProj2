﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/Template.master" %>

<asp:Content ID="dropdown" ContentPlaceHolderId="CPH1" runat="server">
    <div class="new">
        <asp:DropDownList 
            ID="ddlCustomer" 
            runat="server" 
            AutoPostBack="True" 
            DataSourceID="ObjectDataSource1" 
            DataTextField="CustomerID" 
            DataValueField="CustomerID" 
            CssClass="DropDownList">
        </asp:DropDownList>

        <asp:ObjectDataSource 
            ID="ObjectDataSource1" 
            runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetCustomers" 
            TypeName="CustomersDB">
        </asp:ObjectDataSource>

        <asp:DetailsView 
            ID="DetailsView" 
            runat="server" 
            AutoGenerateRows="False" 
            DataSourceID="ObjectDataSource2" 
            CellPadding="3" 
            CellSpacing="2"
            CssClass="DetailsList"
            HeaderText="Customer Information">
            <Fields>
                <asp:BoundField 
                    DataField="CustomerID" 
                    HeaderText="CustomerID" 
                    SortExpression="CustomerID" />
                <asp:BoundField 
                    DataField="CustFirstName" 
                    HeaderText="CustFirstName" 
                    SortExpression="CustFirstName" />
                <asp:BoundField 
                    DataField="CustLastName" 
                    HeaderText="CustLastName" 
                    SortExpression="CustLastName" />
                <asp:BoundField 
                    DataField="CustAddress" 
                    HeaderText="CustAddress" 
                    SortExpression="CustAddress" />
                <asp:BoundField 
                    DataField="CustCity" 
                    HeaderText="CustCity" 
                    SortExpression="CustCity" />
                <asp:BoundField 
                    DataField="CustProv" 
                    HeaderText="CustProv" 
                    SortExpression="CustProv" />
                <asp:BoundField 
                    DataField="CustPostal" 
                    HeaderText="CustPostal" 
                    SortExpression="CustPostal" />
                <asp:BoundField 
                    DataField="CustCountry" 
                    HeaderText="CustCountry" 
                    SortExpression="CustCountry" />
                <asp:BoundField 
                    DataField="CustHomePhone" 
                    HeaderText="CustHomePhone" 
                    SortExpression="CustHomePhone" />
                <asp:BoundField 
                    DataField="CustBusPhone" 
                    HeaderText="CustBusPhone" 
                    SortExpression="CustBusPhone" />
                <asp:BoundField 
                    DataField="CustEmail" 
                    HeaderText="CustEmail" 
                    SortExpression="CustEmail" />
                <asp:BoundField 
                    DataField="AgentId" 
                    HeaderText="AgentId" 
                    SortExpression="AgentId" />
            </Fields>
            <FooterStyle CSSClass="FooterStyle" />
            <HeaderStyle CSSClass="HeaderStyle" />
            <PagerStyle CSSClass="PagerStyle" />
            <RowStyle CSSClass="RowStyle" />
        </asp:DetailsView>
        
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerID" TypeName="CustomersDB" OnSelected="ObjectDataSource2_Selected">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCustomer" Name="CustomerId" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderId="CPH2" runat="server">
    <div class="new">
        <h3>This is New's description of her page</h3>
    <p>
        Lorem ipsum dolor sit amet, ex mea erant adolescens, graeci moderatius no mei, cum case delectus phaedrum te. 
        Vis rebum putent cetero te. No usu velit singulis scriptorem. Id delenit tacimates has. Consequat adversarium 
        repudiandae his in, id nam alienum laboramus consectetuer.
    </p>
    
    <p>
        Unum sonet conceptam ne qui, sea te electram consulatu deterruisset, diam soleat euismod duo eu. Feugait facilisi 
        gloriatur at ius. Ea pro consul eleifend consectetuer, soleat nominavi at pro, ne tamquam copiosae nominati vel. 
        Consetetur accommodare qui id, qui te dicta sonet. Odio ponderum probatus nam te, id dicat partem eum. Eum ea 
        similique comprehensam.
    </p>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderId="CPH4" runat="server">
    <div class="new">
        <asp:Button ID="btnUpdate" runat="server" Text="Update Customer Info" OnClick="btnUpdate_Click" CssClass="btn" />
        <asp:Button ID="btnProduct" runat="server" Text="View Products" OnClick="btnProduct_Click" CssClass="btn" />
        <asp:Label ID="lblAlert" runat="server" Font-Bold="True"></asp:Label>
    </div>
</asp:Content>

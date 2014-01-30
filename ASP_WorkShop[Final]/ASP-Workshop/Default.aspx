<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/Template.master" %>


<%--
The linking of the detail files to the master as well as the necessary content 
and class tags was done by Jon.
    
Many inline styles had to be removed and either duplicated in the CSS or improved/streamlined
--%>

<asp:Content ID="dropdown" ContentPlaceHolderId="CPH1" runat="server">
    <div class="porkodi">
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
            <AlternatingRowStyle BackColor="#444444" />

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
    <div class="porkodi">
        <h3>This is Porkodi&#39;s description </h3>
    <p>
        Porkodi:	- Default page for customer
	    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - Customers class
	    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - CustomerDB
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; + GetCustomers()
	    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; + GetCustomerID(CustomerId)
    </p>
    
    <p>
        &nbsp;</p>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderId="CPH4" runat="server">
    <div class="porkodi">
        <asp:Button ID="btnUpdate" runat="server" Text="Update Customer Info" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnProduct" runat="server" Text="View Products" OnClick="btnProduct_Click" />
        <asp:Label ID="lblAlert" runat="server" Font-Bold="True"></asp:Label>
    </div>
</asp:Content>

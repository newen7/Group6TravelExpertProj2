<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/Template.master" %>

<asp:Content ID="dropdown" ContentPlaceHolderId="CPH1" runat="server">
        <asp:DropDownList 
            ID="ddlCustomer" 
            runat="server" 
            AutoPostBack="True" 
            DataSourceID="ObjectDataSource1" 
            DataTextField="CustomerID" 
            DataValueField="CustomerID" CssClass="DropDownList" >
        </asp:DropDownList>
        <asp:ObjectDataSource 
            ID="ObjectDataSource1" 
            runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetCustomers" 
            TypeName="CustomersDB">
        </asp:ObjectDataSource>
        <asp:DetailsView 
            ID="DetailsView1" 
            runat="server" 
            AutoGenerateRows="False" 
            DataSourceID="ObjectDataSource2" 
            Height="50px" Width="401px" 
            BackColor="#DEBA84" 
            BorderColor="#DEBA84" 
            BorderStyle="None" 
            BorderWidth="1px" 
            CellPadding="3" 
            CellSpacing="2" 
            CssClass="DetailsList">
            <EditRowStyle 
                CssClass="EditRowStyle" />
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
            <FooterStyle CSSClass=".FooterStyle" />
            <HeaderStyle CSSClass=".HeaderStyle" />
            <PagerStyle CSSClass=".PagerStyle" />
            <RowStyle CSSClass=".RowStyle" />
        </asp:DetailsView>

        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerID" TypeName="CustomersDB" OnSelected="ObjectDataSource2_Selected">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCustomer" Name="CustomerId" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Button ID="btnUpdate" runat="server" Text="Update Customer Info" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnProduct" runat="server" Text="View Products" OnClick="btnProduct_Click" />
        <asp:Label ID="lblAlert" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
</asp:Content>

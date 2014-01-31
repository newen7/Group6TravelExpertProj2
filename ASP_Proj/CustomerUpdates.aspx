<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerUpdates.aspx.cs" Inherits="CustomerUpdates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateEditButton="True" AutoGenerateRows="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource2" Height="50px" Width="277px">
            <EditRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
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
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerID" TypeName="CustomersDB">
            <SelectParameters>
                <asp:SessionParameter Name="CustomerId" SessionField="CustID" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>

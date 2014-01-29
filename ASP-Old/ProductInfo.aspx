<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductInfo.aspx.cs" Inherits="ProductInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h6>
            <asp:Button ID="btnBack" runat="server" PostBackUrl="~/Default.aspx" Text="&lt;&lt; Choose another customer" Width="247px" Font-Size="Medium" OnClick="btnBack_Click" />
        </h6>
        <h1>Product Information</h1>
        <h2>Customer Information:</h2>
        <p>
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="ObjectDataSource1" GridLines="Horizontal" Height="50px" Width="365px">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <Fields>
                    <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
                    <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
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
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <FooterTemplate>
                    <asp:ListView ID="ListView1" runat="server">
                    </asp:ListView>
                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"></asp:ObjectDataSource>
                </FooterTemplate>
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            </asp:DetailsView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerFNameById" TypeName="CustomersDB">
                <SelectParameters>
                    <asp:SessionParameter Name="inputCustId" SessionField="CustID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </p>
        <h2>
            Product Information:</h2>
        <p>
            <asp:GridView ID="GridViewProduct" runat="server" DataSourceID="ObjectDataSource4" AutoGenerateColumns="False" OnRowDataBound="GridViewProduct_RowDataBound" ShowFooter="True" BackColor="White" BorderColor="#E7E7FF" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="1300px">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:BoundField DataField="BookingId" HeaderText="Booking ID" SortExpression="BookingId">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Destination" HeaderText="Destination" SortExpression="Destination">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BookingNo" HeaderText="Booking#" SortExpression="BookingNo">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ItineraryNo" HeaderText="Itinerary#" SortExpression="ItineraryNo">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TripStart" DataFormatString="{0:d}" HeaderText="Trip Start Date" SortExpression="Trip Start">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TripEnd" DataFormatString="{0:d}" HeaderText="Trip End Date" SortExpression="TripEnd">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BasePrice" DataFormatString="{0:c}" HeaderText="Base Price" SortExpression="BasePrice">
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProductId" HeaderText="Product ID" SortExpression="ProductId">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#B5C7DE" Font-Bold="True" ForeColor="Red" HorizontalAlign="Right" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductByID" TypeName="ProductDB">
                <SelectParameters>
                    <asp:SessionParameter Name="CustomerId" SessionField="CustID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </p>
    
    </div>
    </form>
</body>
</html>

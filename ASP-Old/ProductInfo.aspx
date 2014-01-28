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
            <asp:ListView ID="lstvProduct" runat="server" DataSourceID="ObjectDataSource2" OnLoad="Page_Load">
                <AlternatingItemTemplate>
                    <tr style="background-color:#FFF8DC;">
                        <td>
                            <asp:Label ID="BookingIdLabel" runat="server" Text='<%# Eval("BookingId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DestinationLabel" runat="server" Text='<%# Eval("Destination") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                        </td>
                        <td>
                            <asp:Label ID="BookingNoLabel" runat="server" Text='<%# Eval("BookingNo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ItineraryNoLabel" runat="server" Text='<%# Eval("ItineraryNo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TripStartLabel" runat="server" Text='<%# Eval("TripStart", "{0:d}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TripEndLabel" runat="server" Text='<%# Eval("TripEnd", "{0:d}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="BasePriceLabel" runat="server" Text='<%# Eval("BasePrice", "{0:c}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color:#008A8C;color: #FFFFFF;">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:TextBox ID="BookingIdTextBox" runat="server" Text='<%# Bind("BookingId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DestinationTextBox" runat="server" Text='<%# Bind("Destination") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="BookingNoTextBox" runat="server" Text='<%# Bind("BookingNo") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ItineraryNoTextBox" runat="server" Text='<%# Bind("ItineraryNo") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TripStartTextBox" runat="server" Text='<%# Bind("TripStart", "{0:d}") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TripEndTextBox" runat="server" Text='<%# Bind("TripEnd", "{0:d}") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="BasePriceTextBox" runat="server" Text='<%# Bind("BasePrice", "{0:c}") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ProductIdTextBox" runat="server" Text='<%# Bind("ProductId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                        <td>
                            <asp:TextBox ID="BookingIdTextBox" runat="server" Text='<%# Bind("BookingId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DestinationTextBox" runat="server" Text='<%# Bind("Destination") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="BookingNoTextBox" runat="server" Text='<%# Bind("BookingNo") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ItineraryNoTextBox" runat="server" Text='<%# Bind("ItineraryNo") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TripStartTextBox" runat="server" Text='<%# Bind("TripStart", "{0:d}") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TripEndTextBox" runat="server" Text='<%# Bind("TripEnd", "{0:d}") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="BasePriceTextBox" runat="server" Text='<%# Bind("BasePrice", "{0:c}") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ProductIdTextBox" runat="server" Text='<%# Bind("ProductId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color:#DCDCDC;color: #000000;">
                        <td>
                            <asp:Label ID="BookingIdLabel" runat="server" Text='<%# Eval("BookingId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DestinationLabel" runat="server" Text='<%# Eval("Destination") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                        </td>
                        <td>
                            <asp:Label ID="BookingNoLabel" runat="server" Text='<%# Eval("BookingNo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ItineraryNoLabel" runat="server" Text='<%# Eval("ItineraryNo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TripStartLabel" runat="server" Text='<%# Eval("TripStart", "{0:d}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TripEndLabel" runat="server" Text='<%# Eval("TripEnd", "{0:d}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="BasePriceLabel" runat="server" Text='<%# Eval("BasePrice", "{0:c}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                        <th runat="server">BookingId</th>
                                        <th runat="server">Destination</th>
                                        <th runat="server">Description</th>
                                        <th runat="server">BookingNo</th>
                                        <th runat="server">ItineraryNo</th>
                                        <th runat="server">TripStart</th>
                                        <th runat="server">TripEnd</th>
                                        <th runat="server">BasePrice</th>
                                        <th runat="server">ProductId</th>
                                        <th runat="server">ProductName</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                <asp:DataPager ID="DataPager1" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                        <td>
                            <asp:Label ID="BookingIdLabel" runat="server" Text='<%# Eval("BookingId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DestinationLabel" runat="server" Text='<%# Eval("Destination") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                        </td>
                        <td>
                            <asp:Label ID="BookingNoLabel" runat="server" Text='<%# Eval("BookingNo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ItineraryNoLabel" runat="server" Text='<%# Eval("ItineraryNo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TripStartLabel" runat="server" Text='<%# Eval("TripStart", "{0:d}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TripEndLabel" runat="server" Text='<%# Eval("TripEnd", "{0:d}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="BasePriceLabel" runat="server" Text='<%# Eval("BasePrice", "{0:c}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductByID" TypeName="ProductDB">
                <SelectParameters>
                    <asp:SessionParameter Name="CustomerId" SessionField="CustID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </p>
        <p>
            &nbsp;</p>
    
    </div>
    </form>
</body>
</html>

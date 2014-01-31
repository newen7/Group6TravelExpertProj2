<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductInfo.aspx.cs" Inherits="ProductInfo" MasterPageFile="~/Template.master"%>
<%--
The linking of the detail files to the master as well as the necessary content 
and class tags was done by Jon.
    
Many inline styles had to be removed and either duplicated in the CSS or improved/streamlined
--%>
<asp:Content ID="header" ContentPlaceHolderId="header" runat="server">
    Product Info
</asp:Content>

<asp:Content ID="menu" ContentPlaceHolderId="menu" runat="server">
    <div class="menu" style="text-align:right;">
        <asp:Button ID="Button1" runat="server" PostBackUrl="~/CustomerUpdates.aspx" Text="Update your information" Width="189px" />
        <asp:Button ID="btnSignOut" runat="server" PostBackUrl="~/Default.aspx" Text="Sign Out"  OnClick="btnBack_Click" />
    </div>
</asp:Content>

<asp:Content ID="content0" ContentPlaceHolderId="CPH1" runat="server">

    <div class="new">
        <div class="container">
        <asp:DetailsView ID="DetailsView" runat="server"
            CellPadding="3" 
            AutoGenerateRows="False"
            DataSourceID="ObjectDataSource1" 
            GridLines="Horizontal"
            CssClass="DetailsList"
            HeaderText="Customer Information" >
            <AlternatingRowStyle BackColor="#444444" />
               
            <Fields>
                <asp:BoundField 
                    DataField="CustomerID" 
                    HeaderText="Customer ID:" 
                    SortExpression="CustomerID" />
                <asp:BoundField 
                    DataField="FullName" 
                    HeaderText="Name:" 
                    SortExpression="FullName" />
                <asp:BoundField 
                    DataField="CustAddress" 
                    HeaderText="Address:" 
                    SortExpression="CustAddress" />
                <asp:BoundField 
                    DataField="CustCity" 
                    HeaderText="City:" 
                    SortExpression="CustCity" />
                <asp:BoundField 
                    DataField="CustProv" 
                    HeaderText="Province:" 
                    SortExpression="CustProv" />
                <asp:BoundField 
                    DataField="CustPostal" 
                    HeaderText="Postal:" 
                    SortExpression="CustPostal" />
                <asp:BoundField 
                    DataField="CustCountry" 
                    HeaderText="Country:" 
                    SortExpression="CustCountry" />
                <asp:BoundField 
                    DataField="CustHomePhone" 
                    HeaderText="Home Phone#:" 
                    SortExpression="CustHomePhone" />
                <asp:BoundField 
                    DataField="CustBusPhone" 
                    HeaderText="Business Phone#:" 
                    SortExpression="CustBusPhone" />
                <asp:BoundField 
                    DataField="CustEmail" 
                    HeaderText="Email:" 
                    SortExpression="CustEmail" />
            </Fields>

            <FooterStyle CSSClass="FooterStyle" />
            <FooterTemplate>
                <asp:ListView ID="ListView1" runat="server">
                </asp:ListView>
                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"></asp:ObjectDataSource>
            </FooterTemplate>

            <HeaderStyle CSSClass="HeaderStyle" />
            <PagerStyle CSSClass="PagerStyle" />
            <RowStyle CSSClass="RowStyle" />
        </asp:DetailsView>
        
     </div>   
        <asp:ObjectDataSource 
            ID="ObjectDataSource1" 
            runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetCustomerFNameById" 
            TypeName="CustomersDB">

            <SelectParameters>
                <asp:SessionParameter 
                    Name="inputCustId" 
                    SessionField="CustID" 
                    Type="Int32" />
            </SelectParameters>

        </asp:ObjectDataSource>
</div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderId="CPH2" runat="server">
    <div class="new">
        <h3>
            <asp:Label ID="lblWelcome" runat="server"></asp:Label>
        </h3>
        <p>
            <img alt="beach" src="img/Img01.jpg" style="width: 480px; height: 360px" />
        </p>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderId="CPH3" runat="server">
    <div class="new">   
            <p style="color:white;font-size:18px;">Product Information</p>
            <asp:GridView runat="server" 
                DataSourceID="ObjectDataSource4"
                AutoGenerateColumns="False" 
                OnRowDataBound="GridViewProduct_RowDataBound" 
                ShowFooter="True"
                CellPadding="3" 
                GridLines="Horizontal" ID="GridViewProduct" Width="100%" 
                >
                <AlternatingRowStyle BackColor="#444444" />
                <Columns>

                    <asp:BoundField 
                        DataField="BookingId" 
                        HeaderText="Booking ID" 
                        SortExpression="BookingId">
                        <ItemStyle HorizontalAlign="Center"/>
                    </asp:BoundField>

                    <asp:BoundField 
                        DataField="ProductName" 
                        HeaderText="Product Name" 
                        SortExpression="ProductName">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField 
                        DataField="Destination" 
                        HeaderText="Destination" 
                        SortExpression="Destination">
                        <ItemStyle Width="150px" HorizontalAlign="Center"/>
                    </asp:BoundField>

                    <asp:BoundField 
                        DataField="TripStart" 
                        DataFormatString="{0:d}" 
                        HeaderText="Start Date" 
                        SortExpression="Trip Start">
                    </asp:BoundField>

                    <asp:BoundField 
                        DataField="TripEnd" 
                        DataFormatString="{0:d}" 
                        HeaderText="End Date" 
                        SortExpression="TripEnd">
                    </asp:BoundField>

                    <asp:BoundField 
                        DataField="BookingNo" 
                        HeaderText="Booking#" 
                        SortExpression="BookingNo">
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>

                    <asp:BoundField 
                        DataField="Description" 
                        HeaderText="Description" 
                        SortExpression="Description">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField 
                        DataField="BasePrice" 
                        DataFormatString="{0:c}" 
                        HeaderText="Price" 
                        SortExpression="BasePrice">
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                </Columns>

                <FooterStyle CSSClass="FooterStyle" />
                <HeaderStyle CSSClass="HeaderStyle" />
                <PagerStyle CSSClass="PagerStyle" />
                <RowStyle CSSClass="RowStyle" />

                <SelectedRowStyle  CSSClass="SelectedRowStyle" />
                <SortedAscendingCellStyle BackColor="#444" />
                <SortedAscendingHeaderStyle BackColor="#555" />
                <SortedDescendingCellStyle BackColor="#444" />
                <SortedDescendingHeaderStyle BackColor="#555" />

            </asp:GridView>

            <asp:ObjectDataSource 
                ID="ObjectDataSource4" 
                runat="server" 
                OldValuesParameterFormatString="original_{0}" 
                SelectMethod="GetProductByID" 
                TypeName="ProductDB">
                <SelectParameters>
                    <asp:SessionParameter 
                        Name="CustomerId" 
                        SessionField="CustID" 
                        Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderId="CPH4" runat="server">
    <div class="new">

    </div>
</asp:Content>

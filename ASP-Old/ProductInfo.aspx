<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductInfo.aspx.cs" Inherits="ProductInfo" MasterPageFile="~/Template.master"%>


<asp:Content ID="content0" ContentPlaceHolderId="CPH1" runat="server">
    <div class="porkodi">
        <asp:DetailsView ID="DetailsView" runat="server"
            CellPadding="3" 
            AutoGenerateRows="False"
            DataSourceID="ObjectDataSource1" 
            GridLines="Horizontal"
            CssClass="DetailsList"
            HeaderText="Product Information">
            <AlternatingRowStyle BackColor="#444444" />
               
            <Fields>
                <asp:BoundField 
                    DataField="CustomerID" 
                    HeaderText="CustomerID" 
                    SortExpression="CustomerID" />
                <asp:BoundField 
                    DataField="FullName" 
                    HeaderText="FullName" 
                    SortExpression="FullName" />
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
            <FooterTemplate>
                <asp:ListView ID="ListView1" runat="server">
                </asp:ListView>
                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"></asp:ObjectDataSource>
            </FooterTemplate>

            <HeaderStyle CSSClass="HeaderStyle" />
            <PagerStyle CSSClass="PagerStyle" />
            <RowStyle CSSClass="RowStyle" />
        </asp:DetailsView>
        
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
    <div class="porkodi">
        <h3>This is Porkodi's description of her page</h3>
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

<asp:Content ID="Content3" ContentPlaceHolderId="CPH3" runat="server">
    <div class="porkodi">
            <asp:GridView 
                ID="GridViewProduct" 
                runat="server" 
                DataSourceID="ObjectDataSource4" 
                AutoGenerateColumns="False" 
                OnRowDataBound="GridViewProduct_RowDataBound" 
                ShowFooter="True"
                CellPadding="3" 
                GridLines="Horizontal"
                header-text="Product Information">
                <AlternatingRowStyle BackColor="#444444" />
                <Columns>

                    <asp:BoundField 
                        DataField="BookingId" 
                        HeaderText="Booking ID" 
                        SortExpression="BookingId">
                    </asp:BoundField>

                    <asp:BoundField 
                        DataField="Destination" 
                        HeaderText="Destination" 
                        SortExpression="Destination">
                    </asp:BoundField>

                    <asp:BoundField 
                        DataField="Description" 
                        HeaderText="Description" 
                        SortExpression="Description">
                    </asp:BoundField>

                    <asp:BoundField 
                        DataField="BookingNo" 
                        HeaderText="Booking#" 
                        SortExpression="BookingNo">
                    </asp:BoundField>

                    <asp:BoundField 
                        DataField="ItineraryNo" 
                        HeaderText="Itinerary#" 
                        SortExpression="ItineraryNo">
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
                        DataField="BasePrice" 
                        DataFormatString="{0:c}" 
                        HeaderText="Base Price" 
                        SortExpression="BasePrice">
                    </asp:BoundField>

                    <asp:BoundField 
                        DataField="ProductId" 
                        HeaderText="Product ID" 
                        SortExpression="ProductId">
                    </asp:BoundField>

                    <asp:BoundField 
                        DataField="ProductName" 
                        HeaderText="Product Name" 
                        SortExpression="ProductName">
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
    <div class="porkodi">
        <asp:Button 
            ID="btnBack" 
            runat="server" 
            PostBackUrl="~/Default.aspx" 
            Text="&lt;&lt; Choose another customer"  
            OnClick="btnBack_Click" CssClass="btn" />
    </div>
</asp:Content>

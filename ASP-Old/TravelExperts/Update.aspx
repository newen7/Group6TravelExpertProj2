<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="UpdateForm" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:FormView ID="FormView1" runat="server" DataSourceID="FormViewCustomer">
        </asp:FormView>
        <asp:ObjectDataSource ID="FormViewCustomer" runat="server" SelectMethod="GetCustomerInfo" TypeName="CustomerDb">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" DefaultValue="104" Name="custId" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

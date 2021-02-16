<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="OnlineMart.User.View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="b1" runat="server" Text="viewcart" OnClick="b1_Click" />
    <asp:DataList ID="d1" runat="server">
    <HeaderTemplate>
        <table>

        
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><img src="../<%#Eval("Product_images") %>" height="100" width="100" /></td>
            <td><%#Eval("Product_name") %></td>
            <td><%#Eval("Product_desc") %></td>
            <td><%#Eval("Product_price") %></td>
            <td><%#Eval("Product_qty") %></td>
        </tr>
    </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:DataList>
        </div>
    </form>
</body>
</html>

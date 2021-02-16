
<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="OnlineMart.User.ViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div align="center">
    <asp:DataList ID="d1" runat="server">

    <HeaderTemplate>
        <table align="center" border="1">
        <tr style="background-color:silver; color:white; font-weight:bold">
            <td>Product Image</td>
            <td>Product Name</td>
            <td>Product Description</td>
            <td>Product Price</td>
            <td>Product Quantity</td>
            <td>Delete</td>
        </tr>
        
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><img src="../<%#Eval("Product_images") %>" height="100" width="100" /></td>
            <td align="center"><%#Eval("Product_name") %></td>
            <td align="center"><%#Eval("Product_desc") %></td>
            <td align="center"><%#Eval("Product_price") %></td>
            <td align="center"><%#Eval("Product_qty") %></td>
            <td align="center"><a href="DeleteCart.aspx?id=<%#Eval("Id") %>">Delete</a></td>
        </tr>
    </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:DataList>
        <p align="center">
            <br />
            <br />
            <br />
        <asp:Label ID="l1" runat="server"></asp:Label><br /><br />
            <asp:Button ID="b2" runat="server" Text="CheckOut" OnClick="b1_Click1" />
        </p>
        </div>
</asp:Content>

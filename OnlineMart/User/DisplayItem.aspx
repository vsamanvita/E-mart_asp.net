<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="DisplayItem.aspx.cs" Inherits="OnlineMart.User.DisplayItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
                <li class="last">
                    <a href="ProductDesc.aspx?id=<%#Eval("Id") %>"><img src="../<%#Eval("Product_images") %>"" alt="" /></a>
                <div class="product-info">
                    <h3><%#Eval("Product_name") %></h3>
                    <div class="product-desc">
                       <h4>Available Qty:<%#Eval("Product_qty") %></h4>
                       <p><%#Eval("Product_desc") %></p>
                       <strong class="price">₹<%#Eval("Product_price") %></strong> 
                    </div>
                 </div>
                </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>

    </asp:Repeater>
</asp:Content>

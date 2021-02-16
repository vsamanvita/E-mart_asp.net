<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ProductDesc.aspx.cs" Inherits="OnlineMart.User.ProductDesc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">


    <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <div style="height:300px;width:600px; border-style:solid; border-width:1px;">
        <div style="height:300px;width:300px; float:left; border-style:solid; border-width:1px;">
            <img src="../<%#Eval("Product_images") %>" height="300" width="300" />

        </div>
        <div style="height:300px;width:295px; float:left; border-style:solid; border-width:1px;">
             Product Name       =<%#Eval("Product_name") %><br /><br />
             Product Description=<%#Eval("Product_desc") %><br /><br />
             Product Price      =<%#Eval("Product_price") %><br /><br />
             Available Quantity   =<%#Eval("Product_qty") %><br /><br />
        </div>
            
            
            </div>    
           
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>

    </asp:Repeater>
    <br />
    <table>
        <tr>
            <td><asp:Label ID="l2" runat="server" Text="Enter Quantity"></asp:Label></td>
            <td><asp:TextBox ID="t1" runat="server" Width="30"></asp:TextBox></td>
            <td><asp:Button ID="b1" runat="server" Text="Add to Cart" OnClick="b1_Click" /></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="l1" runat="server" ForeColor="" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    
</asp:Content>

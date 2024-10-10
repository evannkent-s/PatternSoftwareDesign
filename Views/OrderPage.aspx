<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="ProjectPSDLab.Views.OrderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h2>Place Your Order</h2>
    <asp:Label ID="LblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <asp:GridView ID="GridViewSupplements" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewSupplements_RowCommand">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Supplement Name" />
            <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Type" HeaderText="Type" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="TxtQuantity" runat="server" Text="1" Width="50"></asp:TextBox>
                    <asp:Button ID="BtnAddToCart" runat="server" CommandName="AddToCart" CommandArgument='<%# Eval("Id") %>' Text="Add to Cart" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

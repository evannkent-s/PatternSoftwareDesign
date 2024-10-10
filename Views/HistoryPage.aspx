<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="HistoryPage.aspx.cs" Inherits="ProjectPSDLab.Views.HistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h2>Your Transaction History</h2>
    <asp:GridView ID="GridViewTransactions" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewTransactions_RowCommand">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" DataFormatString="{0:d}" />
            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" DataFormatString="{0:C}" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="BtnViewDetails" runat="server" CommandName="ViewDetails" CommandArgument='<%# Eval("TransactionID") %>' Text="View Details" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

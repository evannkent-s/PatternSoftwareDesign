<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ProjectPSDLab.Views.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div>
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <table>
            <tr>
                <td>Username:</td>
                <td><asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Gender:</td>
                <td>
                    <asp:DropDownList ID="DdlGender" runat="server">
                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Date of Birth:</td>
                <td><asp:Calendar ID="TxtDOB" runat="server"></asp:Calendar></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="BtnUpdate" runat="server" Text="Update Profile" OnClick="BtnUpdate_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


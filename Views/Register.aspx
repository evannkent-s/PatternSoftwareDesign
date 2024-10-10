<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProjectPSDLab.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
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
                    <td>Password:</td>
                    <td><asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Confirm Password:</td>
                    <td><asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Date of Birth:</td>
                    <td><asp:TextBox ID="TxtDOB" runat="server" TextMode="date"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="BtnRegister" runat="server" Text="Register" OnClick="BtnRegister_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

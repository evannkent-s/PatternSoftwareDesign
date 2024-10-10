<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectPSDLab.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="username">
                <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="UsernameTB" runat="server"></asp:TextBox>
            </div>
            
            <div class="password">
                <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Label ID="Labels" runat="server" Text=""></asp:Label>
            </div>

            <div class="remembermee">
                <asp:CheckBox ID="rememberme" runat="server" />
                Remember Me
            </div>
            
            <asp:Button ID="LoginBTN" runat="server" Text="LogIn" OnClick="LoginBTN_Click"/>
            <asp:Button ID="RegisterBTN" runat="server" Text="Register" OnClick="RegisterBTN_Click"/>


        </div>
    </form>
</body>
</html>

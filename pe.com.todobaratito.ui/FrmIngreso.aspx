<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmIngreso.aspx.cs" Inherits="pe.com.todobaratito.ui.FrmIngreso" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ingreso Al Sistema</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="INGRESO AL SISTEMA"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Usuario:"></asp:Label>
        <asp:TextBox ID="txtUsu" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Contraseña:"></asp:Label>
        <asp:TextBox ID="txtCla" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" />
        <asp:Button ID="btnSalir" runat="server" Text="Salir" />
    </form>
</body>
</html>

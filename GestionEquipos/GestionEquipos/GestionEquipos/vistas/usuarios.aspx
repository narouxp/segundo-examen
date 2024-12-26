<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="GestionEquipos.vistas.usuarios" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Equipos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Gestión de Equipos</h2>
            <br />

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" />
            <br />

            
            <label for="ID">ID (Para actualizar):</label>
            <asp:TextBox ID="ID" runat="server"></asp:TextBox>
            <br />

            <label for="usuario">Usuario:</label>
            <asp:TextBox ID="usuario" runat="server"></asp:TextBox>
            <br />

            <label for="tecnicos">Técnicos:</label>
            <asp:TextBox ID="tecnicos" runat="server"></asp:TextBox>
            <br />

            <label for="equipos">Equipos:</label>
            <asp:TextBox ID="equipos" runat="server"></asp:TextBox>
            <br />

            <br />
            <br />
            <br />

            <asp:Button ID="agregar" runat="server" Text="Agregar" OnClick="Agregar_Click" />
            <asp:Button ID="eliminar" runat="server" Text="Eliminar" OnClick="Eliminar_Click" />
            <asp:Button ID="actualizar" runat="server" Text="Actualizar" OnClick="Actualizar_Click" />
        </div>
    </form>
</body>
</html>

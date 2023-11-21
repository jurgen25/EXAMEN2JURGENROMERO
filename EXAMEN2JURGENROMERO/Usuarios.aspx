<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="EXAMEN2JURGENROMERO.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Usuarios</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Usuarios</h1>
            <asp:GridView ID="GridViewUsuarios" runat="server" AutoGenerateColumns="False" DataKeyNames="UsuarioID" OnRowEditing="GridViewUsuarios_RowEditing"
                OnRowUpdating="GridViewUsuarios_RowUpdating"
                OnRowDeleting="GridViewUsuarios_RowDeleting"
                OnRowCancelingEdit="GridViewUsuarios_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="UsuarioID" HeaderText="UsuarioID" ReadOnly="True" SortExpression="UsuarioID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" SortExpression="CorreoElectronico" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnAgregarUsuario" runat="server" Text="Agregar Usuario" OnClick="btnAgregarUsuario_Click" />
        </div>
    </form>
</body>
</html>



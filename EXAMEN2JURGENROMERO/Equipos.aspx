<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="EXAMEN2JURGENROMERO.Equipos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Equipos</title>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        <link rel="stylesheet" href="styles.css" />
</head>
<body>
<form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="mb-4">Equipos</h2>
            <div class="row">
                <div class="col-md-8">
            <asp:GridView ID="GridViewEquipos" runat="server" AutoGenerateColumns="False" DataKeyNames="EquipoID" OnRowEditing="GridViewEquipos_RowEditing" OnRowUpdating="GridViewEquipos_RowUpdating" OnRowCancelingEdit="GridViewEquipos_RowCancelingEdit" OnRowDeleting="GridViewEquipos_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="EquipoID" HeaderText="EquipoID" ReadOnly="True" SortExpression="EquipoID" />
                    <asp:TemplateField HeaderText="Tipo de Equipo">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTipoEquipoEdit" runat="server" Text='<%# Bind("TipoEquipo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTipoEquipo" runat="server" Text='<%# Bind("TipoEquipo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Modelo">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtModeloEdit" runat="server" Text='<%# Bind("Modelo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblModelo" runat="server" Text='<%# Bind("Modelo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UsuarioID">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtUsuarioIDEdit" runat="server" Text='<%# Bind("UsuarioID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblUsuarioID" runat="server" Text='<%# Bind("UsuarioID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnAgregarEquipo" runat="server" Text="Agregar Equipo" OnClick="btnAgregarEquipo_Click" />
        </>
    </form>
</body>
</html>

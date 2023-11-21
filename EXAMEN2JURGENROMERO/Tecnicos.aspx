<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="EXAMEN2JURGENROMERO.Tecnicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Técnicos</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Técnicos</h2>
            <asp:GridView ID="GridViewTecnicos" runat="server" AutoGenerateColumns="False" DataKeyNames="TecnicoID" OnRowEditing="GridViewTecnicos_RowEditing" OnRowUpdating="GridViewTecnicos_RowUpdating" OnRowCancelingEdit="GridViewTecnicos_RowCancelingEdit" OnRowDeleting="GridViewTecnicos_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="TecnicoID" HeaderText="TecnicoID" ReadOnly="True" SortExpression="TecnicoID" />
                    <asp:TemplateField HeaderText="Nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreEdit" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Especialidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEspecialidadEdit" runat="server" Text='<%# Bind("Especialidad") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEspecialidad" runat="server" Text='<%# Bind("Especialidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnAgregarTecnico" runat="server" Text="Agregar Técnico" OnClick="btnAgregarTecnico_Click" />
        </div>
    </form>
</body>
</html>

using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace EXAMEN2JURGENROMERO
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListaUsuarios();
            }
        }

        private void CargarListaUsuarios()
        {
            using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=MantenimientoJurgen;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT UsuarioID, Nombre, CorreoElectronico, Telefono FROM Usuarios", con))
                {
                    con.Open();
                    GridViewUsuarios.DataSource = cmd.ExecuteReader();
                    GridViewUsuarios.DataBind();
                }
            }
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            // UsE los TextBoxes agregados para obtener los nuevos datos
            string nuevoNombre = ObtenerNuevoNombre();
            string nuevoCorreoElectronico = ObtenerNuevoCorreoElectronico();
            string nuevoTelefono = ObtenerNuevoTelefono();

            // Agrega al nuevo usuario en la base de datos
            using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=MantenimientoJurgen;Integrated Security=True"))
            {
                con.Open();

                string query = "INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono) VALUES (@Nombre, @CorreoElectronico, @Telefono)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nuevoNombre);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", nuevoCorreoElectronico);
                    cmd.Parameters.AddWithValue("@Telefono", nuevoTelefono);

                    cmd.ExecuteNonQuery();
                }
            }

            // Actualiza la GridView
            CargarListaUsuarios();
        }

        protected void GridViewUsuarios_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridViewUsuarios.EditIndex = e.NewEditIndex;
            CargarListaUsuarios();
        }

        protected void GridViewUsuarios_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            // Actualiza la fila editada
            int usuarioID = Convert.ToInt32(GridViewUsuarios.DataKeys[e.RowIndex].Value);
            string nuevoNombre = ((TextBox)GridViewUsuarios.Rows[e.RowIndex].FindControl("txtNombreEdit")).Text;
            string nuevoCorreoElectronico = ((TextBox)GridViewUsuarios.Rows[e.RowIndex].FindControl("txtCorreoEdit")).Text;
            string nuevoTelefono = ((TextBox)GridViewUsuarios.Rows[e.RowIndex].FindControl("txtTelefonoEdit")).Text;

            using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=MantenimientoJurgen;Integrated Security=True"))
            {
                con.Open();

                string query = "UPDATE Usuarios SET Nombre = @Nombre, CorreoElectronico = @CorreoElectronico, Telefono = @Telefono WHERE UsuarioID = @UsuarioID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nuevoNombre);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", nuevoCorreoElectronico);
                    cmd.Parameters.AddWithValue("@Telefono", nuevoTelefono);
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                    cmd.ExecuteNonQuery();
                }
            }

            GridViewUsuarios.EditIndex = -1;
            CargarListaUsuarios();
        }

        protected void GridViewUsuarios_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            // Elimina la fila seleccionada
            int usuarioID = Convert.ToInt32(GridViewUsuarios.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=MantenimientoJurgen;Integrated Security=True"))
            {
                con.Open();

                string query = "DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                    cmd.ExecuteNonQuery();
                }
            }

            CargarListaUsuarios();
        }

        protected void GridViewUsuarios_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            GridViewUsuarios.EditIndex = -1;
            CargarListaUsuarios();
        }

        // Métodos auxiliares para obtener nuevos datos
        private string ObtenerNuevoNombre()
        {
            return "NuevoNombre";
        }

        private string ObtenerNuevoCorreoElectronico()
        {
            return "NuevoCorreo@example.com";
        }

        private string ObtenerNuevoTelefono()
        {
            return "NuevoTelefono";
        }
    }
}

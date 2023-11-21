using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace EXAMEN2JURGENROMERO
{
    public partial class Equipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=MantenimientoJurgen;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos", con))
                {
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    GridViewEquipos.DataSource = rdr;
                    GridViewEquipos.DataBind();
                }
            }
        }

        protected void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            // Datos del nuevo equipo
            string tipoEquipo = ObtenerNuevoTipoEquipo();
            string modelo = ObtenerNuevoModelo();
            int usuarioID = ObtenerIDUsuario();

            // Inserta el nuevo equipo en la base de datos
            using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=MantenimientoJurgen;Integrated Security=True"))
            {
                con.Open();
                string query = "INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID) VALUES (@TipoEquipo, @Modelo, @UsuarioID)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TipoEquipo", tipoEquipo);
                    cmd.Parameters.AddWithValue("@Modelo", modelo);
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    cmd.ExecuteNonQuery();
                }
            }

            // Actualiza la GridView
            BindGrid();
        }

        // Métodos auxiliares para obtener datos
        private string ObtenerNuevoTipoEquipo()
        {
            return "NuevoTipoEquipo";
        }

        private string ObtenerNuevoModelo()
        {
            return "NuevoModelo";
        }

        private int ObtenerIDUsuario()
        {
            return 1;
        }

        protected void GridViewEquipos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewEquipos.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridViewEquipos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewEquipos.EditIndex = -1;
            BindGrid();
        }

        protected void GridViewEquipos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int equipoID = Convert.ToInt32(GridViewEquipos.DataKeys[e.RowIndex].Values["EquipoID"]);
            string nuevoTipoEquipo = ((TextBox)GridViewEquipos.Rows[e.RowIndex].FindControl("txtTipoEquipoEdit")).Text;
            string nuevoModelo = ((TextBox)GridViewEquipos.Rows[e.RowIndex].FindControl("txtModeloEdit")).Text;
            int nuevoUsuarioID = Convert.ToInt32(((TextBox)GridViewEquipos.Rows[e.RowIndex].FindControl("txtUsuarioIDEdit")).Text);

            using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=MantenimientoJurgen;Integrated Security=True"))
            {
                con.Open();
                string query = "UPDATE Equipos SET TipoEquipo=@TipoEquipo, Modelo=@Modelo, UsuarioID=@UsuarioID WHERE EquipoID=@EquipoID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TipoEquipo", nuevoTipoEquipo);
                    cmd.Parameters.AddWithValue("@Modelo", nuevoModelo);
                    cmd.Parameters.AddWithValue("@UsuarioID", nuevoUsuarioID);
                    cmd.Parameters.AddWithValue("@EquipoID", equipoID);
                    cmd.ExecuteNonQuery();
                }
            }

            GridViewEquipos.EditIndex = -1;
            BindGrid();
        }

        protected void GridViewEquipos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int equipoID = Convert.ToInt32(GridViewEquipos.DataKeys[e.RowIndex].Values["EquipoID"]);

            using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=MantenimientoJurgen;Integrated Security=True"))
            {
                con.Open();
                string query = "DELETE FROM Equipos WHERE EquipoID=@EquipoID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EquipoID", equipoID);
                    cmd.ExecuteNonQuery();
                }
            }

            BindGrid();
        }
    }
}



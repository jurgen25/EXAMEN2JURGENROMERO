using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace EXAMEN2JURGENROMERO
{
    public partial class Tecnicos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos", con))
                {
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    GridViewTecnicos.DataSource = rdr;
                    GridViewTecnicos.DataBind();
                }
            }
        }

        protected void btnAgregarTecnico_Click(object sender, EventArgs e)
        {
            // Saca los datos del nuevo técnico
            string nombre = ObtenerNuevoNombreTecnico();
            string especialidad = ObtenerNuevaEspecialidad();

            // Inserta el nuevo técnico en la base de datos
            using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=MantenimientoJurgen;Integrated Security=True"))
            {
                con.Open();
                string query = "INSERT INTO Tecnicos (Nombre, Especialidad) VALUES (@Nombre, @Especialidad)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Especialidad", especialidad);
                    cmd.ExecuteNonQuery();
                }
            }

            // Actualiza la GridView
            BindGrid();
        }

        // Métodos auxiliares para obtener datos
        private string ObtenerNuevoNombreTecnico()
        {
            return "NuevoNombreTecnico";
        }

        private string ObtenerNuevaEspecialidad()
        {
            return "NuevaEspecialidad";
        }

        protected void GridViewTecnicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewTecnicos.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridViewTecnicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTecnicos.EditIndex = -1;
            BindGrid();
        }

        protected void GridViewTecnicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int tecnicoID = Convert.ToInt32(GridViewTecnicos.DataKeys[e.RowIndex].Values["TecnicoID"]);
            string nuevoNombre = ((TextBox)GridViewTecnicos.Rows[e.RowIndex].FindControl("txtNombreEdit")).Text;
            string nuevaEspecialidad = ((TextBox)GridViewTecnicos.Rows[e.RowIndex].FindControl("txtEspecialidadEdit")).Text;

            using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=MantenimientoJurgen;Integrated Security=True"))
            {
                con.Open();
                string query = "UPDATE Tecnicos SET Nombre=@Nombre, Especialidad=@Especialidad WHERE TecnicoID=@TecnicoID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nuevoNombre);
                    cmd.Parameters.AddWithValue("@Especialidad", nuevaEspecialidad);
                    cmd.Parameters.AddWithValue("@TecnicoID", tecnicoID);
                    cmd.ExecuteNonQuery();
                }
            }

            GridViewTecnicos.EditIndex = -1;
            BindGrid();
        }

        protected void GridViewTecnicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int tecnicoID = Convert.ToInt32(GridViewTecnicos.DataKeys[e.RowIndex].Values["TecnicoID"]);

            using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=MantenimientoJurgen;Integrated Security=True"))
            {
                con.Open();
                string query = "DELETE FROM Tecnicos WHERE TecnicoID=@TecnicoID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TecnicoID", tecnicoID);
                    cmd.ExecuteNonQuery();
                }
            }

            BindGrid();
        }
    }
}

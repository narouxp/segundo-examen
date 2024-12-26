using GestionEquipos.capamodelo;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using GestionEquipos.capalogica;
using System.Web.UI;

namespace GestionEquipos.vistas
{
    public partial class usuarios : System.Web.UI.Page
    {
        Usuarios us = new Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridView();
            }
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            int resultado = us.AgregarEquipo(usuario.Text, tecnicos.Text, equipos.Text);

            if (resultado > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Equipo agregado correctamente.');", true);
                LimpiarCampos();
                CargarGridView();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Error al agregar el equipo.');", true);
            }
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            string nombrePersona = usuario.Text;

            if (!string.IsNullOrEmpty(nombrePersona))
            {
                int resultado = us.EliminarEquipo(nombrePersona);

                if (resultado > 0)
                {
                    Response.Write("<script>alert('Equipo eliminado exitosamente');</script>");
                    LimpiarCampos();
                    CargarGridView();
                }
                else
                {
                    Response.Write("<script>alert('Error al eliminar el equipo');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Por favor ingrese el nombre de la persona a eliminar');</script>");
            }
        }


        protected void Actualizar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ID.Text))
            {
                int equipoID;
                if (int.TryParse(ID.Text, out equipoID))
                {
                    string nombrePersona = usuario.Text; 
                    string nombreTecnico = tecnicos.Text; 
                    string nombreEquipo = equipos.Text;  

                    int resultado = us.ActualizarEquipo(equipoID, nombrePersona, nombreTecnico, nombreEquipo);

                    if (resultado > 0)
                    {
                        Response.Write("<script>alert('Equipo actualizado exitosamente');</script>");
                        LimpiarCampos(); 
                        CargarGridView(); 
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al actualizar el equipo');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Por favor ingrese un ID válido');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('El campo ID es obligatorio para actualizar');</script>");
            }
        }

        private void LimpiarCampos()
        {
            ID.Text = "";
            usuario.Text = "";
            tecnicos.Text = "";
            equipos.Text = "";
        }

        private void CargarGridView()
        {
            SqlConnection Conn = DBConn.obtenerConexion();
            using (SqlCommand cmd = new SqlCommand("sp_LeerEquipos", Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

    }
}

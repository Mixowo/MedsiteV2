using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedsiteV2
{
    public partial class FrmMedicos : Form
    {
        Conexiones conexion = new Conexiones();
        SqlConnection cn;

        public FrmMedicos()
        {
            InitializeComponent();
            cn = conexion.AbrirConexion();
            CargarEspecialidades();
            MostrarMedicos();
        }

        private void CargarEspecialidades()
        {
            try
            {
                string query = "SELECT IdEspecialidad, NombreEspecialidad FROM Especialidades";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbEspecialidad.DataSource = dt;
                cmbEspecialidad.DisplayMember = "NombreEspecialidad";
                cmbEspecialidad.ValueMember = "IdEspecialidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especialidades: " + ex.Message);
            }
        }

        private void FrmMedicos_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                {
                    
                    string query = @"INSERT INTO Medicos 
                            (NombreCompleto, IdEspecialidad, Telefono, CorreoElectronico, Disponible) 
                            VALUES 
                            (@Nombre, @IdEspecialidad, @Telefono, @Correo, @Disponible)";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@IdEspecialidad", cmbEspecialidad.SelectedValue);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text.Trim());

                    // Convertir "Sí"/"No" a BIT
                    bool disponible = cmbDisponible.SelectedItem.ToString() == "Sí";
                    cmd.Parameters.AddWithValue("@Disponible", disponible);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Médico registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarMedicos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarMedicos()
        {
            string query = "SELECT m.IdMedico, m.NombreCompleto AS Nombre, m.Telefono, m.CorreoElectronico AS Correo, " +
                           "e.NombreEspecialidad AS Especialidad, m.Disponible AS Estado " +
                           "FROM Medicos m JOIN Especialidades e ON m.IdEspecialidad = e.IdEspecialidad";

            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvMedicos.DataSource = dt;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            cmbEspecialidad.SelectedIndex = -1;
            cmbDisponible.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}

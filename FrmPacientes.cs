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
    public partial class FrmPacientes : Form
    {
        Conexiones conexion = new Conexiones();
        SqlConnection cn;

        public FrmPacientes()
        {
            InitializeComponent();
            cn = conexion.AbrirConexion();
            MostrarPacientes();
        }

        private void MostrarPacientes()
        {
            string query = "SELECT * FROM Pacientes";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPacientes.DataSource = dt;
        }

        private void AgregarPaciente()
        {
            try
            {
                string nombre = txtNombre.Text;
                DateTime fechaNacimiento = dtpFechaNacimiento.Value;
                string genero = cmbGenero.SelectedItem?.ToString();
                string telefono = txtTelefono.Text;
                string direccion = txtDireccion.Text;
                string historial = txtHistorial.Text;

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(genero))
                {
                    MessageBox.Show("Nombre y Género son obligatorios.");
                    return;
                }

                string query = "INSERT INTO Pacientes (NombreCompleto, FechaNacimiento, Genero, Telefono, Direccion, HistorialMedico) " +
                               "VALUES (@NombreCompleto, @FechaNacimiento, @Genero, @Telefono, @Direccion, @HistorialMedico)";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@NombreCompleto", nombre);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@HistorialMedico", historial);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Paciente registrado correctamente.");
                        LimpiarCampos();
                        MostrarPacientes(); // si tienes una función para listar
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar paciente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtHistorial.Clear();
            cmbGenero.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Now;
        }

        private void FrmPacientes_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            AgregarPaciente();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}

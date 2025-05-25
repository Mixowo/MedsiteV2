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
using System.Collections;

namespace MedsiteV2
{
    public partial class FrmReportes : Form
    {
        Conexiones conexion = new Conexiones();
        SqlConnection cn;

        public FrmReportes()
        {
            InitializeComponent();
            cn = conexion.AbrirConexion();
            CargarPacientes(); // Llena el ComboBox al iniciar
        }

        private void CargarPacientes()
        {
            try
            {
                string query = "SELECT IdPaciente, NombreCompleto FROM Pacientes ORDER BY NombreCompleto";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbPacienteReporte.DataSource = dt;
                cmbPacienteReporte.DisplayMember = "NombreCompleto"; // Muestra nombres
                cmbPacienteReporte.ValueMember = "IdPaciente";       // Valor interno: ID
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pacientes: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnBuscarReporte_Click(object sender, EventArgs e)
        {
            if (cmbPacienteReporte.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un paciente.", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPaciente = Convert.ToInt32(cmbPacienteReporte.SelectedValue);
            MostrarReporte(idPaciente);
        }

        private void MostrarReporte(int idPaciente)
        {
            try
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                string query = @"SELECT C.IdCita, 
                                       M.NombreCompleto AS Médico, 
                                       E.NombreEspecialidad AS Especialidad, 
                                       C.FechaHora AS [Fecha y Hora],
                                       C.Estado,
                                       D.Descripcion AS Diagnóstico
                                FROM Citas C
                                JOIN Medicos M ON C.IdMedico = M.IdMedico
                                JOIN Especialidades E ON M.IdEspecialidad = E.IdEspecialidad
                                LEFT JOIN Diagnosticos D ON C.IdCita = D.IdCita
                                WHERE C.IdPaciente = @IdPaciente
                                ORDER BY C.FechaHora DESC";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdPaciente", idPaciente); // ¡Parámetro habilitado!

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvReporte.DataSource = dt;
                dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }
    }
}

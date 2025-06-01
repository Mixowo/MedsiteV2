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
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                string query = "SELECT IdPaciente, NombreCompleto FROM Pacientes ORDER BY NombreCompleto";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbPacienteReporte.DataSource = dt;
                cmbPacienteReporte.DisplayMember = "NombreCompleto";
                cmbPacienteReporte.ValueMember = "IdPaciente";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pacientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarReporte_Click(object sender, EventArgs e)
        {
            if (cmbPacienteReporte.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un paciente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPaciente = Convert.ToInt32(cmbPacienteReporte.SelectedValue);
            DateTime fechaInicio = dtpInicio.Value.Date;
            DateTime fechaFin = dtpFin.Value.Date;

            try
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                // 1. Obtener total de citas usando la función
                string funcion = "SELECT dbo.ContarCitasPaciente(@IdPaciente, @FechaInicio, @FechaFin)";
                SqlCommand cmd = new SqlCommand(funcion, cn);
                cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                int total = (int)cmd.ExecuteScalar();
                lblTotal.Text = $"Total de citas: {total}";

                // 2. Mostrar detalle de citas
                string detalle = @"SELECT C.IdCita, M.NombreCompleto AS Medico, C.FechaHora, C.Estado
                           FROM Citas C
                           INNER JOIN Medicos M ON C.IdMedico = M.IdMedico
                           WHERE C.IdPaciente = @IdPaciente AND
                                 CAST(C.FechaHora AS DATE) BETWEEN @FechaInicio AND @FechaFin
                           ORDER BY C.FechaHora";

                SqlDataAdapter da = new SqlDataAdapter(detalle, cn);
                da.SelectCommand.Parameters.AddWithValue("@IdPaciente", idPaciente);
                da.SelectCommand.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                da.SelectCommand.Parameters.AddWithValue("@FechaFin", fechaFin);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvReporte.DataSource = dt;
                dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar citas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

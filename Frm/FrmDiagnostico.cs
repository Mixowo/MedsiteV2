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
    public partial class FrmDiagnostico : Form
    {
        Conexiones conexion = new Conexiones();
        SqlConnection cn;

        public FrmDiagnostico()
        {
            InitializeComponent();
            cn = new Conexiones().AbrirConexion();
            CargarCitasConfirmadas();
            CargarDiagnosticos();
        }

        private void CargarCitasConfirmadas()
        {
            try
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                string query = @"SELECT C.IdCita, 
                                       P.NombreCompleto + ' - ' + CONVERT(VARCHAR, C.FechaHora, 103) AS InfoCita
                                FROM Citas C
                                JOIN Pacientes P ON C.IdPaciente = P.IdPaciente
                                WHERE C.Estado = 'Confirmada' 
                                AND NOT EXISTS (SELECT 1 FROM Diagnosticos WHERE IdCita = C.IdCita)";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCita.DataSource = dt;
                cmbCita.DisplayMember = "InfoCita";
                cmbCita.ValueMember = "IdCita";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar citas: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDiagnosticos()
        {
            try
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                string query = @"SELECT D.IdDiagnostico, 
                                       P.NombreCompleto AS Paciente,
                                       M.NombreCompleto AS Médico,
                                       C.FechaHora AS Fecha,
                                       D.Descripcion AS Diagnóstico
                                FROM Diagnosticos D
                                JOIN Citas C ON D.IdCita = C.IdCita
                                JOIN Pacientes P ON C.IdPaciente = P.IdPaciente
                                JOIN Medicos M ON C.IdMedico = M.IdMedico";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDiagnosticos.DataSource = dt;
                dgvDiagnosticos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar diagnósticos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbCita.SelectedValue == null || string.IsNullOrWhiteSpace(txtDiagnostico.Text))
            {
                MessageBox.Show("Selecciona una cita y escriba el diagnóstico.", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                string query = @"INSERT INTO Diagnosticos (IdCita, Descripcion, Receta)
                        VALUES (@IdCita, @Descripcion, @Receta)";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdCita", cmbCita.SelectedValue);
                cmd.Parameters.AddWithValue("@Descripcion", txtDiagnostico.Text.Trim());
                cmd.Parameters.AddWithValue("@Receta", txtReceta.Text.Trim());
                cmd.ExecuteNonQuery();

                // Marcar cita como completada
                string updateCita = "UPDATE Citas SET Estado = 'Completada' WHERE IdCita = @IdCita";
                SqlCommand cmdCita = new SqlCommand(updateCita, cn);
                cmdCita.Parameters.AddWithValue("@IdCita", cmbCita.SelectedValue);
                cmdCita.ExecuteNonQuery();

                MessageBox.Show("Diagnóstico guardado exitosamente.", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarCitasConfirmadas();
                CargarDiagnosticos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtDiagnostico.Clear();
            txtReceta.Clear();
        }

        private void FrmDiagnostico_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cn != null && cn.State == ConnectionState.Open)
                cn.Close();
        }
    }
}

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
    public partial class FrmCitas : Form
    {
        Conexiones conexion = new Conexiones();
        SqlConnection cn;
        private int? citaSeleccionadaId = null;
        private int? medicoSeleccionadoId = null;

        public FrmCitas()
        {
            InitializeComponent();
            cn = conexion.AbrirConexion();
            CargarPacientes();
            CargarMedicos();
            ConfigurarEstadoCita(nueva: true);
            MostrarCitas();
            dtpFechaHora.Format = DateTimePickerFormat.Custom;
            dtpFechaHora.CustomFormat = "dd/MM/yyyy hh:mm tt";
            dtpFechaHora.ShowUpDown = true;
        }

        private void CargarMedicos(int? idMedicoSeleccionado = null)
        {
            string query = "SELECT IdMedico, NombreCompleto FROM Medicos WHERE Disponible = 1";

            if (idMedicoSeleccionado.HasValue)
            {
                query = "SELECT IdMedico, NombreCompleto FROM Medicos WHERE Disponible = 1 " +
                        $"UNION SELECT IdMedico, NombreCompleto FROM Medicos WHERE IdMedico = {idMedicoSeleccionado.Value}";
            }

            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbMedico.DataSource = dt;
            cmbMedico.DisplayMember = "NombreCompleto";
            cmbMedico.ValueMember = "IdMedico";
        }

        private void CargarPacientes()
        {
            string query = "SELECT IdPaciente, NombreCompleto FROM Pacientes";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbPaciente.DataSource = dt;
            cmbPaciente.DisplayMember = "NombreCompleto";
            cmbPaciente.ValueMember = "IdPaciente";
        }

        private void ConfigurarEstadoCita(bool nueva)
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Confirmada");
            if (!nueva)
                cmbEstado.Items.Add("Cancelada");

            cmbEstado.SelectedIndex = 0;
        }

        private void MostrarCitas()
        {
            string query = @"SELECT c.IdCita, c.IdMedico, c.IdPaciente, c.FechaHora, 
                            m.NombreCompleto AS Medico, p.NombreCompleto AS Paciente, c.Estado 
                     FROM Citas c 
                     JOIN Medicos m ON c.IdMedico = m.IdMedico
                     JOIN Pacientes p ON c.IdPaciente = p.IdPaciente";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCitas.DataSource = dt;

            dgvCitas.Columns["IdMedico"].Visible = false;
            dgvCitas.Columns["IdPaciente"].Visible = false;
        }

        private void LimpiarCampos()
        {
            cmbMedico.Enabled = true;
            cmbMedico.SelectedIndex = 0;
            dtpFechaHora.Value = DateTime.Now;
            ConfigurarEstadoCita(nueva: true);
            citaSeleccionadaId = null;
            medicoSeleccionadoId = null;
            CargarMedicos();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            if (cmbMedico.SelectedValue == null || cmbEstado.SelectedItem == null || cmbPaciente.SelectedValue == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            int idMedico = Convert.ToInt32(cmbMedico.SelectedValue);
            int idPaciente = Convert.ToInt32(cmbPaciente.SelectedValue);
            DateTime fechaHora = dtpFechaHora.Value;
            string estado = cmbEstado.SelectedItem.ToString();

            if (citaSeleccionadaId == null)
            {
                using (SqlCommand cmd = new SqlCommand("RegistrarCita", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                    cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                    cmd.Parameters.AddWithValue("@FechaHora", fechaHora);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                string query = "UPDATE Citas SET IdMedico = @IdMedico, FechaHora = @FechaHora, Estado = @Estado WHERE IdCita = @IdCita";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                    cmd.Parameters.AddWithValue("@FechaHora", fechaHora);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.Parameters.AddWithValue("@IdCita", citaSeleccionadaId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Cita guardada correctamente.");
            LimpiarCampos();
            CargarMedicos();
            MostrarCitas();
        }

        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvCitas.Rows[e.RowIndex];
                citaSeleccionadaId = Convert.ToInt32(fila.Cells["IdCita"].Value);
                dtpFechaHora.Value = Convert.ToDateTime(fila.Cells["FechaHora"].Value);

                int idMedico = Convert.ToInt32(fila.Cells["IdMedico"].Value);
                CargarMedicos(idMedico); 
                cmbMedico.SelectedValue = idMedico;

                int idPaciente = Convert.ToInt32(fila.Cells["IdPaciente"].Value);
                cmbPaciente.SelectedValue = idPaciente;

                cmbEstado.Text = fila.Cells["Estado"].Value.ToString();

                ConfigurarEstadoCita(nueva: false);
                cmbMedico.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!citaSeleccionadaId.HasValue)
            {
                MessageBox.Show("Seleccione una cita para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Está seguro de eliminar esta cita?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.No)
                return;

            try
            {
          
                int idMedico = -1;
                string consultaMedico = "SELECT IdMedico FROM Citas WHERE IdCita = @IdCita";
                using (SqlCommand cmdMedico = new SqlCommand(consultaMedico, cn))
                {
                    cmdMedico.Parameters.AddWithValue("@IdCita", citaSeleccionadaId.Value);
                    object resultado = cmdMedico.ExecuteScalar();
                    if (resultado != null)
                    {
                        idMedico = Convert.ToInt32(resultado);
                    }
                }

                string queryEliminar = "DELETE FROM Citas WHERE IdCita = @IdCita";
                using (SqlCommand cmd = new SqlCommand(queryEliminar, cn))
                {
                    cmd.Parameters.AddWithValue("@IdCita", citaSeleccionadaId.Value);
                    cmd.ExecuteNonQuery();
                }

                string verificarOtrasCitas = @"
            SELECT COUNT(*) 
            FROM Citas 
            WHERE IdMedico = @IdMedico AND Estado IN ('Pendiente', 'Confirmada')";

                using (SqlCommand cmdVerificar = new SqlCommand(verificarOtrasCitas, cn))
                {
                    cmdVerificar.Parameters.AddWithValue("@IdMedico", idMedico);
                    int cantidad = (int)cmdVerificar.ExecuteScalar();

                    if (cantidad == 0)
                    {
                        string actualizarMedico = "UPDATE Medicos SET Disponible = 1 WHERE IdMedico = @IdMedico";
                        using (SqlCommand cmdActualizar = new SqlCommand(actualizarMedico, cn))
                        {
                            cmdActualizar.Parameters.AddWithValue("@IdMedico", idMedico);
                            cmdActualizar.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Cita eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarCitas();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la cita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    
        private void cmbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaHora_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmCitas_Load(object sender, EventArgs e)
        {

        }

        
    }
}

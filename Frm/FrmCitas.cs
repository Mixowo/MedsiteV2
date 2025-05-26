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
            string query = "SELECT c.IdCita, c.IdMedico, c.FechaHora, m.NombreCompleto AS Medico, c.Estado " +
                           "FROM Citas c JOIN Medicos m ON c.IdMedico = m.IdMedico";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCitas.DataSource = dt;
            dgvCitas.Columns["IdMedico"].Visible = false;
        }

        private void LimpiarCampos()
        {
            cmbMedico.SelectedIndex = 0;
            dtpFechaHora.Value = DateTime.Now;
            ConfigurarEstadoCita(nueva: true);
            citaSeleccionadaId = null;
            medicoSeleccionadoId = null;
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            if (cmbMedico.SelectedValue == null || cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            int idMedico = Convert.ToInt32(cmbMedico.SelectedValue);
            DateTime fechaHora = dtpFechaHora.Value;
            string estado = cmbEstado.SelectedItem.ToString();

            string query;

            if (citaSeleccionadaId == null)
            {
                query = "INSERT INTO Citas (IdMedico, IdPaciente, FechaHora, Estado) VALUES (@IdMedico, @IdPaciente, @FechaHora, @Estado)";
            }
            else
            {
                query = "UPDATE Citas SET IdMedico = @IdMedico, FechaHora = @FechaHora, Estado = @Estado WHERE IdCita = @IdCita";
            }

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                cmd.Parameters.AddWithValue("@IdPaciente", Convert.ToInt32(cmbPaciente.SelectedValue));
                cmd.Parameters.AddWithValue("@FechaHora", fechaHora);
                cmd.Parameters.AddWithValue("@Estado", estado);
                if (citaSeleccionadaId != null)
                    cmd.Parameters.AddWithValue("@IdCita", citaSeleccionadaId);

                cmd.ExecuteNonQuery();
            }

            ActualizarDisponibilidadMedico(idMedico, estado);
            MessageBox.Show("Cita guardada correctamente.");
            LimpiarCampos();
            MostrarCitas();
        }

        private void ActualizarDisponibilidadMedico(int idMedico, string estado)
        {
            bool disponible = estado == "Cancelada";
            string query = "UPDATE Medicos SET Disponible = @Disponible WHERE IdMedico = @IdMedico";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Disponible", disponible);
                cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                cmd.ExecuteNonQuery();
            }
        }

        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvCitas.Rows[e.RowIndex];
                citaSeleccionadaId = Convert.ToInt32(fila.Cells["IdCita"].Value);
                dtpFechaHora.Value = Convert.ToDateTime(fila.Cells["FechaHora"].Value);

                int idMedico = Convert.ToInt32(fila.Cells["IdMedico"].Value);
                CargarMedicos(idMedico); // Mostrar aunque esté no disponible
                cmbMedico.SelectedValue = idMedico;
                cmbEstado.Text = fila.Cells["Estado"].Value.ToString();

                ConfigurarEstadoCita(nueva: false); // Mostrar "Cancelada"
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
    }
}

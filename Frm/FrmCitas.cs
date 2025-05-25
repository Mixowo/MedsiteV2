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

        public FrmCitas()
        {
            InitializeComponent();
            cn = conexion.AbrirConexion();
            CargarPacientes();
            CargarMedicos();
            MostrarCitas();
        }


        private void FrmCitas_Load(object sender, EventArgs e)
        {

        }

        private void CargarPacientes()
        {
            SqlCommand cmd = new SqlCommand("SELECT IdPaciente, NombreCompleto FROM Pacientes", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbPaciente.DataSource = dt;
            cmbPaciente.DisplayMember = "NombreCompleto";
            cmbPaciente.ValueMember = "IdPaciente";
        }

        private void CargarMedicos()
        {
            SqlCommand cmd = new SqlCommand("SELECT IdMedico, NombreCompleto FROM Medicos WHERE Disponible = 1", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbMedico.DataSource = dt;
            cmbMedico.DisplayMember = "NombreCompleto";
            cmbMedico.ValueMember = "IdMedico";
        }

        private void MostrarCitas()
        {
            SqlCommand cmd = new SqlCommand(@"
        SELECT C.IdCita, P.NombreCompleto AS Paciente, M.NombreCompleto AS Medico, 
               C.FechaHora, C.Estado
        FROM Citas C
        INNER JOIN Pacientes P ON C.IdPaciente = P.IdPaciente
        INNER JOIN Medicos M ON C.IdMedico = M.IdMedico", cn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCitas.DataSource = dt;
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPaciente = Convert.ToInt32(cmbPaciente.SelectedValue);
                int idMedico = Convert.ToInt32(cmbMedico.SelectedValue);
                DateTime fechaHora = dtpFechaHora.Value;
                string estado = cmbEstado.SelectedItem.ToString();

                string query = "INSERT INTO Citas (IdPaciente, IdMedico, FechaHora, Estado) " +
                               "VALUES (@IdPaciente, @IdMedico, @FechaHora, @Estado)";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                cmd.Parameters.AddWithValue("@FechaHora", fechaHora);
                cmd.Parameters.AddWithValue("@Estado", estado);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cita registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarCitas(); // Puedes actualizar el DataGridView si tienes uno
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar cita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}

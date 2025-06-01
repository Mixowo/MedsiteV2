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

        private int? pacienteSeleccionadoId = null;

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
                    MessageBox.Show("Por favor complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int resultadoValidacion = ValidarPacienteDuplicado(nombre, genero, telefono);

                if (resultadoValidacion == 0) // Existe duplicado
                {
                    MessageBox.Show("Ya existe un paciente con estos datos registrado",
                                  "Paciente Duplicado",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }
                else if (resultadoValidacion == -1) // Error
                {
                    MessageBox.Show("Error al verificar paciente",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }

                string query;

                if (pacienteSeleccionadoId.HasValue)
                {
                    query = @"UPDATE Pacientes 
                      SET NombreCompleto = @NombreCompleto, FechaNacimiento = @FechaNacimiento, 
                          Genero = @Genero, Telefono = @Telefono, Direccion = @Direccion, HistorialMedico = @HistorialMedico 
                      WHERE IdPaciente = @IdPaciente";
                }
                else
                {
                    query = @"INSERT INTO Pacientes (NombreCompleto, FechaNacimiento, Genero, Telefono, Direccion, HistorialMedico) 
                      VALUES (@NombreCompleto, @FechaNacimiento, @Genero, @Telefono, @Direccion, @HistorialMedico)";
                }

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@NombreCompleto", nombre);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@HistorialMedico", historial);

                    if (pacienteSeleccionadoId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@IdPaciente", pacienteSeleccionadoId.Value);
                    }

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        string mensaje = pacienteSeleccionadoId.HasValue ? "Paciente actualizado correctamente." : "Paciente registrado correctamente.";
                        MessageBox.Show(mensaje);
                        LimpiarCampos();
                        MostrarPacientes();
                        pacienteSeleccionadoId = null;
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar paciente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private int ValidarPacienteDuplicado(string nombre, string genero, string telefono)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM Pacientes 
                    WHERE 
                    LOWER(TRIM(NombreCompleto)) = LOWER(TRIM(@Nombre))
                    AND LOWER(TRIM(Genero)) = LOWER(TRIM(@Genero))
                    AND TRIM(Telefono) = TRIM(@Telefono)";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0 ? 0 : 1; // 0 = existe, 1 = no existe
                }
            }
            catch
            {
                return -1; // Error en la consulta
            }
        }


        private void LimpiarCampos()
        {
            dtpFechaNacimiento.Enabled = true;
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtHistorial.Clear();
            cmbGenero.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Now;
            pacienteSeleccionadoId = null;
        }

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPacientes.Rows[e.RowIndex];
                pacienteSeleccionadoId = Convert.ToInt32(row.Cells["IdPaciente"].Value);
                txtNombre.Text = row.Cells["NombreCompleto"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(row.Cells["FechaNacimiento"].Value);
                cmbGenero.SelectedItem = row.Cells["Genero"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtHistorial.Text = row.Cells["HistorialMedico"].Value.ToString();
                dtpFechaNacimiento.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPaciente = Convert.ToInt32(dgvPacientes.CurrentRow.Cells["IdPaciente"].Value);
            DialogResult confirmar = MessageBox.Show(
                "¿Está seguro de eliminar el paciente seleccionado?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmar == DialogResult.Yes)
            {
                try
                {
                    conexion.AbrirConexion();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Pacientes WHERE IdPaciente = @Id", cn);
                    cmd.Parameters.AddWithValue("@Id", idPaciente);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Paciente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarPacientes();
                    LimpiarCampos();
                }
                catch (SqlException ex) when (ex.Number == 547)
                {
                    MessageBox.Show("No se puede eliminar: este paciente está relacionado con otros registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != (char)127)
            {
                e.Handled = true; // Bloquear el carácter
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            txtTelefono.Text = new string(txtTelefono.Text.Where(c => char.IsDigit(c)).ToArray());
            txtTelefono.SelectionStart = txtTelefono.Text.Length; // Mover cursor al final
        }

        private void FrmPacientes_Load(object sender, EventArgs e)
        {
            dgvPacientes.CellClick += dgvPacientes_CellClick;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            AgregarPaciente();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

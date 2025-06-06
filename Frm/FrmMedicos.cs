﻿using System;
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

        private int? medicoSeleccionadoId = null;

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                int idEspecialidad = Convert.ToInt32(cmbEspecialidad.SelectedValue);
                string telefono = txtTelefono.Text.Trim();
                string correo = txtCorreo.Text.Trim();
                bool disponible = cmbDisponible.SelectedItem.ToString() == "Sí";

                int resultadoValidacion = ValidarMedicoDuplicado(nombre, idEspecialidad, telefono, correo, disponible);

                if (resultadoValidacion == 0)
                {
                    MessageBox.Show("Ya existe un médico con estos datos registrado",
                                  "Médico Duplicado",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }
                else if (resultadoValidacion == -1)
                {
                    MessageBox.Show("Error al verificar médico",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbEspecialidad.SelectedIndex == -1 || cmbDisponible.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (medicoSeleccionadoId.HasValue)
                {
                    string query = @"UPDATE Medicos SET 
                             NombreCompleto = @Nombre, 
                             IdEspecialidad = @IdEspecialidad, 
                             Telefono = @Telefono, 
                             CorreoElectronico = @Correo, 
                             Disponible = @Disponible 
                             WHERE IdMedico = @Id";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@IdEspecialidad", cmbEspecialidad.SelectedValue);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Disponible", cmbDisponible.SelectedItem.ToString() == "Sí");
                    cmd.Parameters.AddWithValue("@Id", medicoSeleccionadoId.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Médico actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
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
                    cmd.Parameters.AddWithValue("@Disponible", cmbDisponible.SelectedItem.ToString() == "Sí");

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Médico registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                MostrarMedicos();
                LimpiarCampos();
                medicoSeleccionadoId = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ValidarMedicoDuplicado(string nombre, int idEspecialidad, string telefono, string correo, bool disponible)
        {
            try
            {
                string query = @"
            SELECT COUNT(*) 
            FROM Medicos 
            WHERE 
            LOWER(TRIM(NombreCompleto)) = LOWER(TRIM(@Nombre))
            AND IdEspecialidad = @IdEspecialidad
            AND TRIM(Telefono) = TRIM(@Telefono)
            AND TRIM(CorreoElectronico) = TRIM(@Correo)
            AND Disponible = @Disponible";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre.Trim().ToLower());
                    cmd.Parameters.AddWithValue("@IdEspecialidad", idEspecialidad);
                    cmd.Parameters.AddWithValue("@Telefono", telefono.Trim());
                    cmd.Parameters.AddWithValue("@Correo", correo.Trim());
                    cmd.Parameters.AddWithValue("@Disponible", disponible);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0 ? 0 : 1;
                }
            }
            catch
            {
                return -1;
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
            medicoSeleccionadoId = null;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMedicos.Rows[e.RowIndex];
                medicoSeleccionadoId = Convert.ToInt32(row.Cells["IdMedico"].Value);
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = row.Cells["Correo"].Value.ToString();
                cmbEspecialidad.Text = row.Cells["Especialidad"].Value.ToString();
                cmbDisponible.SelectedItem = (bool)row.Cells["Estado"].Value ? "Sí" : "No";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!medicoSeleccionadoId.HasValue)
            {
                MessageBox.Show("Seleccione un médico para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmar = MessageBox.Show("¿Está seguro de eliminar al médico seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM Medicos WHERE IdMedico = @Id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id", medicoSeleccionadoId.Value);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Médico eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarMedicos();
                    LimpiarCampos();
                    medicoSeleccionadoId = null;
                }
                catch (SqlException ex) when (ex.Number == 547)
                {
                    MessageBox.Show("No se puede eliminar: el médico tiene datos relacionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmMedicos_Load(object sender, EventArgs e)
        {

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != (char)127)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            txtTelefono.Text = new string(txtTelefono.Text.Where(c => char.IsDigit(c)).ToArray());
            txtTelefono.SelectionStart = txtTelefono.Text.Length;
        }
    }
}

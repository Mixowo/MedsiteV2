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
    public partial class FrmEspecialidades : Form
    {
        Conexiones conexion = new Conexiones();
        SqlConnection cn;

        private int? especialidadSeleccionadaId = null;

        public FrmEspecialidades()
        {
            InitializeComponent();
            cn = conexion.AbrirConexion();
            CargarEspecialidades();
            ConfigurarDataGridView();
        }

        private void FrmEspecialidades_Load(object sender, EventArgs e)
        {

        }

        private void ConfigurarDataGridView()
        {
            dgvEspecialidades.AutoGenerateColumns = false;
            dgvEspecialidades.Columns.Clear();

            dgvEspecialidades.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdEspecialidad",
                HeaderText = "ID",
                DataPropertyName = "IdEspecialidad",
                ReadOnly = true
            });

            dgvEspecialidades.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreEspecialidad",
                HeaderText = "Especialidad",
                DataPropertyName = "NombreEspecialidad",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void CargarEspecialidades()
        {
            try
            {
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("SELECT IdEspecialidad, NombreEspecialidad FROM Especialidades", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEspecialidades.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar especialidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtEspecialidad.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre de la especialidad no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conexion.AbrirConexion();

                // Verificar si ya existe otra especialidad con ese nombre (ignorando mayúsculas/minúsculas)
                SqlCommand verificar = new SqlCommand("SELECT COUNT(*) FROM Especialidades WHERE LOWER(NombreEspecialidad) = LOWER(@Nombre) AND (@Id IS NULL OR IdEspecialidad != @Id)", cn);
                verificar.Parameters.AddWithValue("@Nombre", nombre);
                verificar.Parameters.AddWithValue("@Id", (object)especialidadSeleccionadaId ?? DBNull.Value);

                int existe = (int)verificar.ExecuteScalar();

                if (existe > 0)
                {
                    MessageBox.Show("Ya existe una especialidad con ese nombre.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlCommand cmd;

                if (especialidadSeleccionadaId.HasValue)
                {
                    // EDITAR
                    cmd = new SqlCommand("UPDATE Especialidades SET NombreEspecialidad = @Nombre WHERE IdEspecialidad = @Id", cn);
                    cmd.Parameters.AddWithValue("@Id", especialidadSeleccionadaId.Value);
                }
                else
                {
                    // NUEVO
                    cmd = new SqlCommand("INSERT INTO Especialidades (NombreEspecialidad) VALUES (@Nombre)", cn);
                }

                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.ExecuteNonQuery();

                string mensaje = especialidadSeleccionadaId.HasValue ? "Especialidad actualizada." : "Especialidad registrada.";
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtEspecialidad.Clear();
                especialidadSeleccionadaId = null;
                CargarEspecialidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una especialidad para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEspecialidad = Convert.ToInt32(dgvEspecialidades.CurrentRow.Cells["IdEspecialidad"].Value);
            DialogResult confirmar = MessageBox.Show(
                $"¿Está seguro de eliminar la especialidad seleccionada?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmar == DialogResult.Yes)
            {
                try
                {
                    conexion.AbrirConexion();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Especialidades WHERE IdEspecialidad = @Id", cn);
                    cmd.Parameters.AddWithValue("@Id", idEspecialidad);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Especialidad eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarEspecialidades();
                }
                catch (SqlException ex) when (ex.Number == 547)
                {
                    MessageBox.Show("No se puede eliminar: esta especialidad está asignada a médicos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //SELECCIONAR ESPECIALIDAD PARA BORRAR (AGREGAR PODER EDITARLA)
        private void dgvEspecialidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtEspecialidad.Text = dgvEspecialidades.Rows[e.RowIndex].Cells["NombreEspecialidad"].Value.ToString();
                especialidadSeleccionadaId = Convert.ToInt32(dgvEspecialidades.Rows[e.RowIndex].Cells["IdEspecialidad"].Value);
            }
        }

        private void dgvEspecialidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtEspecialidad.Text = dgvEspecialidades.Rows[e.RowIndex].Cells["NombreEspecialidad"].Value.ToString();
                especialidadSeleccionadaId = Convert.ToInt32(dgvEspecialidades.Rows[e.RowIndex].Cells["IdEspecialidad"].Value);
            }
        }
    }
}

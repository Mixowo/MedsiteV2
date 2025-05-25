namespace MedsiteV2
{
    partial class FrmPacientes
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.TextBox txtHistorial;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvPacientes;

        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblGenero = new System.Windows.Forms.Label();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.txtHistorial = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(20, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre Completo";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(182, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.Location = new System.Drawing.Point(20, 60);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(145, 23);
            this.lblFechaNacimiento.TabIndex = 2;
            this.lblFechaNacimiento.Text = "Fecha de Nacimiento";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(182, 60);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaNacimiento.TabIndex = 3;
            // 
            // lblGenero
            // 
            this.lblGenero.Location = new System.Drawing.Point(20, 100);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(100, 23);
            this.lblGenero.TabIndex = 4;
            this.lblGenero.Text = "Género";
            // 
            // cmbGenero
            // 
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.Items.AddRange(new object[] {
            "Masculino",
            "Femenino",
            "Otro"});
            this.cmbGenero.Location = new System.Drawing.Point(182, 100);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(121, 24);
            this.cmbGenero.TabIndex = 5;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Location = new System.Drawing.Point(20, 140);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(100, 23);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(182, 140);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 22);
            this.txtTelefono.TabIndex = 7;
            // 
            // lblDireccion
            // 
            this.lblDireccion.Location = new System.Drawing.Point(20, 180);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(100, 23);
            this.lblDireccion.TabIndex = 8;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(182, 180);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(300, 22);
            this.txtDireccion.TabIndex = 9;
            // 
            // lblHistorial
            // 
            this.lblHistorial.Location = new System.Drawing.Point(20, 220);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(100, 23);
            this.lblHistorial.TabIndex = 10;
            this.lblHistorial.Text = "Historial Médico";
            // 
            // txtHistorial
            // 
            this.txtHistorial.Location = new System.Drawing.Point(182, 220);
            this.txtHistorial.Multiline = true;
            this.txtHistorial.Name = "txtHistorial";
            this.txtHistorial.Size = new System.Drawing.Size(300, 60);
            this.txtHistorial.TabIndex = 11;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(307, 300);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(407, 300);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.ColumnHeadersHeight = 29;
            this.dgvPacientes.Location = new System.Drawing.Point(20, 350);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.RowHeadersWidth = 51;
            this.dgvPacientes.Size = new System.Drawing.Size(600, 200);
            this.dgvPacientes.TabIndex = 14;
            // 
            // FrmPacientes
            // 
            this.ClientSize = new System.Drawing.Size(650, 570);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.txtHistorial);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgvPacientes);
            this.Name = "FrmPacientes";
            this.Text = "Gestión de Pacientes";
            this.Load += new System.EventHandler(this.FrmPacientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
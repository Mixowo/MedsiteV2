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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPacientes));
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
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(28, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre Completo";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(29, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(300, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaNacimiento.Location = new System.Drawing.Point(28, 102);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(170, 27);
            this.lblFechaNacimiento.TabIndex = 2;
            this.lblFechaNacimiento.Text = "Fecha de Nacimiento";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(31, 132);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.ShowUpDown = true;
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(300, 22);
            this.dtpFechaNacimiento.TabIndex = 3;
            this.dtpFechaNacimiento.ValueChanged += new System.EventHandler(this.dtpFechaNacimiento_ValueChanged);
            // 
            // lblGenero
            // 
            this.lblGenero.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenero.Location = new System.Drawing.Point(28, 168);
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
            this.cmbGenero.Location = new System.Drawing.Point(31, 194);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(300, 24);
            this.cmbGenero.TabIndex = 5;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(28, 230);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(100, 23);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(31, 256);
            this.txtTelefono.MaxLength = 12;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(300, 22);
            this.txtTelefono.TabIndex = 7;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // lblDireccion
            // 
            this.lblDireccion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(28, 293);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(100, 23);
            this.lblDireccion.TabIndex = 8;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(31, 319);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(300, 22);
            this.txtDireccion.TabIndex = 9;
            // 
            // lblHistorial
            // 
            this.lblHistorial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorial.Location = new System.Drawing.Point(28, 357);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(100, 23);
            this.lblHistorial.TabIndex = 10;
            this.lblHistorial.Text = "Historial Médico";
            // 
            // txtHistorial
            // 
            this.txtHistorial.Location = new System.Drawing.Point(31, 383);
            this.txtHistorial.Multiline = true;
            this.txtHistorial.Name = "txtHistorial";
            this.txtHistorial.Size = new System.Drawing.Size(300, 122);
            this.txtHistorial.TabIndex = 11;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnGuardar.Location = new System.Drawing.Point(32, 525);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 33);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.PowderBlue;
            this.btnLimpiar.Location = new System.Drawing.Point(132, 525);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(97, 33);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.AllowUserToAddRows = false;
            this.dgvPacientes.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvPacientes.ColumnHeadersHeight = 29;
            this.dgvPacientes.Location = new System.Drawing.Point(379, 18);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.RowHeadersWidth = 51;
            this.dgvPacientes.Size = new System.Drawing.Size(754, 540);
            this.dgvPacientes.TabIndex = 14;
            this.dgvPacientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellClick);
            this.dgvPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellContentClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnEliminar.Location = new System.Drawing.Point(232, 525);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(97, 33);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FrmPacientes
            // 
            this.ClientSize = new System.Drawing.Size(1145, 570);
            this.Controls.Add(this.btnEliminar);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPacientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pacientes";
            this.Load += new System.EventHandler(this.FrmPacientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnEliminar;
    }
}
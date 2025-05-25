namespace MedsiteV2
{
    partial class FrmCitas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cmbPaciente;
        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.DateTimePicker dtpFechaHora;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.DataGridView dgvCitas;

        private void InitializeComponent()
        {
            this.lblPaciente = new System.Windows.Forms.Label();
            this.cmbPaciente = new System.Windows.Forms.ComboBox();
            this.lblMedico = new System.Windows.Forms.Label();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.dtpFechaHora = new System.Windows.Forms.DateTimePicker();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPaciente
            // 
            this.lblPaciente.Location = new System.Drawing.Point(20, 20);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(100, 23);
            this.lblPaciente.TabIndex = 0;
            this.lblPaciente.Text = "Paciente";
            // 
            // cmbPaciente
            // 
            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.Location = new System.Drawing.Point(120, 20);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(121, 24);
            this.cmbPaciente.TabIndex = 1;
            this.cmbPaciente.SelectedIndexChanged += new System.EventHandler(this.cmbPaciente_SelectedIndexChanged);
            // 
            // lblMedico
            // 
            this.lblMedico.Location = new System.Drawing.Point(20, 60);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(100, 23);
            this.lblMedico.TabIndex = 2;
            this.lblMedico.Text = "Médico";
            // 
            // cmbMedico
            // 
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.Location = new System.Drawing.Point(120, 60);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(121, 24);
            this.cmbMedico.TabIndex = 3;
            this.cmbMedico.SelectedIndexChanged += new System.EventHandler(this.cmbMedico_SelectedIndexChanged);
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.Location = new System.Drawing.Point(20, 100);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(100, 23);
            this.lblFechaHora.TabIndex = 4;
            this.lblFechaHora.Text = "Fecha y Hora";
            // 
            // dtpFechaHora
            // 
            this.dtpFechaHora.Location = new System.Drawing.Point(120, 100);
            this.dtpFechaHora.Name = "dtpFechaHora";
            this.dtpFechaHora.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaHora.TabIndex = 5;
            this.dtpFechaHora.ValueChanged += new System.EventHandler(this.dtpFechaHora_ValueChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(20, 140);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 23);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "Estado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Items.AddRange(new object[] {
            "Pendiente",
            "Confirmada",
            "Cancelada",
            "Completada"});
            this.cmbEstado.Location = new System.Drawing.Point(120, 140);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 24);
            this.cmbEstado.TabIndex = 7;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // btnAgendar
            // 
            this.btnAgendar.Location = new System.Drawing.Point(120, 180);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(75, 23);
            this.btnAgendar.TabIndex = 8;
            this.btnAgendar.Text = "Agendar";
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);
            // 
            // dgvCitas
            // 
            this.dgvCitas.ColumnHeadersHeight = 29;
            this.dgvCitas.Location = new System.Drawing.Point(20, 230);
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.RowHeadersWidth = 51;
            this.dgvCitas.Size = new System.Drawing.Size(600, 200);
            this.dgvCitas.TabIndex = 9;
            // 
            // FrmCitas
            // 
            this.ClientSize = new System.Drawing.Size(650, 460);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.cmbPaciente);
            this.Controls.Add(this.lblMedico);
            this.Controls.Add(this.cmbMedico);
            this.Controls.Add(this.lblFechaHora);
            this.Controls.Add(this.dtpFechaHora);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.btnAgendar);
            this.Controls.Add(this.dgvCitas);
            this.Name = "FrmCitas";
            this.Text = "Gestión de Citas";
            this.Load += new System.EventHandler(this.FrmCitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
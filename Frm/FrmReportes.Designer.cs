namespace MedsiteV2
{
    partial class FrmReportes
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPacienteReporte;
        private System.Windows.Forms.ComboBox cmbPacienteReporte;
        private System.Windows.Forms.Button btnBuscarReporte;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.Label lblTotal;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportes));
            this.lblPacienteReporte = new System.Windows.Forms.Label();
            this.cmbPacienteReporte = new System.Windows.Forms.ComboBox();
            this.btnBuscarReporte = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFin = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPacienteReporte
            // 
            this.lblPacienteReporte.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacienteReporte.Location = new System.Drawing.Point(43, 21);
            this.lblPacienteReporte.Name = "lblPacienteReporte";
            this.lblPacienteReporte.Size = new System.Drawing.Size(74, 23);
            this.lblPacienteReporte.TabIndex = 0;
            this.lblPacienteReporte.Text = "Paciente";
            // 
            // cmbPacienteReporte
            // 
            this.cmbPacienteReporte.Location = new System.Drawing.Point(123, 20);
            this.cmbPacienteReporte.Name = "cmbPacienteReporte";
            this.cmbPacienteReporte.Size = new System.Drawing.Size(180, 24);
            this.cmbPacienteReporte.TabIndex = 1;
            // 
            // btnBuscarReporte
            // 
            this.btnBuscarReporte.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBuscarReporte.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnBuscarReporte.Location = new System.Drawing.Point(123, 52);
            this.btnBuscarReporte.Name = "btnBuscarReporte";
            this.btnBuscarReporte.Size = new System.Drawing.Size(180, 25);
            this.btnBuscarReporte.TabIndex = 6;
            this.btnBuscarReporte.Text = "Buscar";
            this.btnBuscarReporte.Click += new System.EventHandler(this.btnBuscarReporte_Click);
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvReporte.ColumnHeadersHeight = 29;
            this.dgvReporte.Location = new System.Drawing.Point(22, 88);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.Size = new System.Drawing.Size(605, 297);
            this.dgvReporte.TabIndex = 7;
            // 
            // lblInicio
            // 
            this.lblInicio.Font = new System.Drawing.Font("Arial", 9F);
            this.lblInicio.Location = new System.Drawing.Point(320, 22);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(90, 23);
            this.lblInicio.TabIndex = 2;
            this.lblInicio.Text = "Fecha inicio:";
            // 
            // lblFin
            // 
            this.lblFin.Font = new System.Drawing.Font("Arial", 9F);
            this.lblFin.Location = new System.Drawing.Point(320, 52);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(90, 23);
            this.lblFin.TabIndex = 4;
            this.lblFin.Text = "Fecha fin:";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(410, 20);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 22);
            this.dtpInicio.TabIndex = 3;
            // 
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(410, 50);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(200, 22);
            this.dtpFin.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Arial", 9F);
            this.lblTotal.Location = new System.Drawing.Point(17, 396);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(600, 23);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Total de citas: 0";
            // 
            // FrmReportes
            // 
            this.ClientSize = new System.Drawing.Size(650, 430);
            this.Controls.Add(this.lblPacienteReporte);
            this.Controls.Add(this.cmbPacienteReporte);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.lblFin);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.btnBuscarReporte);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.lblTotal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
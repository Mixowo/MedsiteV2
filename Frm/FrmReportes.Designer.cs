namespace MedsiteV2
{
    partial class FrmReportes
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPacienteReporte;
        private System.Windows.Forms.ComboBox cmbPacienteReporte;
        private System.Windows.Forms.Button btnBuscarReporte;
        private System.Windows.Forms.DataGridView dgvReporte;

        private void InitializeComponent()
        {
            this.lblPacienteReporte = new System.Windows.Forms.Label();
            this.cmbPacienteReporte = new System.Windows.Forms.ComboBox();
            this.btnBuscarReporte = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPacienteReporte
            // 
            this.lblPacienteReporte.Location = new System.Drawing.Point(20, 20);
            this.lblPacienteReporte.Name = "lblPacienteReporte";
            this.lblPacienteReporte.Size = new System.Drawing.Size(100, 23);
            this.lblPacienteReporte.TabIndex = 0;
            this.lblPacienteReporte.Text = "Paciente";
            // 
            // cmbPacienteReporte
            // 
            this.cmbPacienteReporte.Location = new System.Drawing.Point(120, 20);
            this.cmbPacienteReporte.Name = "cmbPacienteReporte";
            this.cmbPacienteReporte.Size = new System.Drawing.Size(121, 24);
            this.cmbPacienteReporte.TabIndex = 1;
            // 
            // btnBuscarReporte
            // 
            this.btnBuscarReporte.Location = new System.Drawing.Point(280, 20);
            this.btnBuscarReporte.Name = "btnBuscarReporte";
            this.btnBuscarReporte.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarReporte.TabIndex = 2;
            this.btnBuscarReporte.Text = "Buscar";
            this.btnBuscarReporte.Click += new System.EventHandler(this.btnBuscarReporte_Click);
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.ColumnHeadersHeight = 29;
            this.dgvReporte.Location = new System.Drawing.Point(20, 70);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.Size = new System.Drawing.Size(600, 300);
            this.dgvReporte.TabIndex = 3;
            // 
            // FrmReportes
            // 
            this.ClientSize = new System.Drawing.Size(650, 400);
            this.Controls.Add(this.lblPacienteReporte);
            this.Controls.Add(this.cmbPacienteReporte);
            this.Controls.Add(this.btnBuscarReporte);
            this.Controls.Add(this.dgvReporte);
            this.Name = "FrmReportes";
            this.Text = "Reportes Médicos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
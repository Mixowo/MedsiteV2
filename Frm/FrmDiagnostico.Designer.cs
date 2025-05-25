namespace MedsiteV2
{
    partial class FrmDiagnostico
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCita;
        private System.Windows.Forms.ComboBox cmbCita;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label lblReceta;
        private System.Windows.Forms.TextBox txtReceta;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvDiagnosticos;

        private void InitializeComponent()
        {
            this.lblCita = new System.Windows.Forms.Label();
            this.cmbCita = new System.Windows.Forms.ComboBox();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.lblReceta = new System.Windows.Forms.Label();
            this.txtReceta = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvDiagnosticos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagnosticos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCita
            // 
            this.lblCita.Location = new System.Drawing.Point(20, 20);
            this.lblCita.Name = "lblCita";
            this.lblCita.Size = new System.Drawing.Size(100, 23);
            this.lblCita.TabIndex = 0;
            this.lblCita.Text = "Cita";
            // 
            // cmbCita
            // 
            this.cmbCita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCita.Location = new System.Drawing.Point(120, 20);
            this.cmbCita.Name = "cmbCita";
            this.cmbCita.Size = new System.Drawing.Size(121, 24);
            this.cmbCita.TabIndex = 1;
            // 
            // lblDiagnostico
            // 
            this.lblDiagnostico.Location = new System.Drawing.Point(20, 60);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(100, 23);
            this.lblDiagnostico.TabIndex = 2;
            this.lblDiagnostico.Text = "Diagnóstico";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Location = new System.Drawing.Point(120, 60);
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(300, 22);
            this.txtDiagnostico.TabIndex = 3;
            // 
            // lblReceta
            // 
            this.lblReceta.Location = new System.Drawing.Point(20, 100);
            this.lblReceta.Name = "lblReceta";
            this.lblReceta.Size = new System.Drawing.Size(100, 23);
            this.lblReceta.TabIndex = 4;
            this.lblReceta.Text = "Receta";
            // 
            // txtReceta
            // 
            this.txtReceta.Location = new System.Drawing.Point(120, 100);
            this.txtReceta.Name = "txtReceta";
            this.txtReceta.Size = new System.Drawing.Size(300, 22);
            this.txtReceta.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(120, 140);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvDiagnosticos
            // 
            this.dgvDiagnosticos.ColumnHeadersHeight = 29;
            this.dgvDiagnosticos.Location = new System.Drawing.Point(20, 190);
            this.dgvDiagnosticos.Name = "dgvDiagnosticos";
            this.dgvDiagnosticos.RowHeadersWidth = 51;
            this.dgvDiagnosticos.Size = new System.Drawing.Size(600, 200);
            this.dgvDiagnosticos.TabIndex = 7;
            // 
            // FrmDiagnostico
            // 
            this.ClientSize = new System.Drawing.Size(650, 420);
            this.Controls.Add(this.lblCita);
            this.Controls.Add(this.cmbCita);
            this.Controls.Add(this.lblDiagnostico);
            this.Controls.Add(this.txtDiagnostico);
            this.Controls.Add(this.lblReceta);
            this.Controls.Add(this.txtReceta);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvDiagnosticos);
            this.Name = "FrmDiagnostico";
            this.Text = "Diagnóstico Médico";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagnosticos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

}
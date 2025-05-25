namespace MedsiteV2
{
    partial class FrmMostrar
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnMedicos;
        private System.Windows.Forms.Button btnEspecialidades;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnDiagnosticos;
        private System.Windows.Forms.Button btnReportes;

        private void InitializeComponent()
        {
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnMedicos = new System.Windows.Forms.Button();
            this.btnEspecialidades = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnDiagnosticos = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPacientes
            // 
            this.btnPacientes.Location = new System.Drawing.Point(30, 30);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(150, 40);
            this.btnPacientes.TabIndex = 0;
            this.btnPacientes.Text = "Pacientes";
            // 
            // btnMedicos
            // 
            this.btnMedicos.Location = new System.Drawing.Point(30, 80);
            this.btnMedicos.Name = "btnMedicos";
            this.btnMedicos.Size = new System.Drawing.Size(150, 40);
            this.btnMedicos.TabIndex = 1;
            this.btnMedicos.Text = "Médicos";
            // 
            // btnEspecialidades
            // 
            this.btnEspecialidades.Location = new System.Drawing.Point(30, 130);
            this.btnEspecialidades.Name = "btnEspecialidades";
            this.btnEspecialidades.Size = new System.Drawing.Size(150, 40);
            this.btnEspecialidades.TabIndex = 2;
            this.btnEspecialidades.Text = "Especialidades";
            // 
            // btnCitas
            // 
            this.btnCitas.Location = new System.Drawing.Point(30, 180);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(150, 40);
            this.btnCitas.TabIndex = 3;
            this.btnCitas.Text = "Citas";
            // 
            // btnDiagnosticos
            // 
            this.btnDiagnosticos.Location = new System.Drawing.Point(30, 230);
            this.btnDiagnosticos.Name = "btnDiagnosticos";
            this.btnDiagnosticos.Size = new System.Drawing.Size(150, 40);
            this.btnDiagnosticos.TabIndex = 4;
            this.btnDiagnosticos.Text = "Diagnósticos";
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(30, 280);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(150, 40);
            this.btnReportes.TabIndex = 5;
            this.btnReportes.Text = "Reportes";
            // 
            // FrmMostrar
            // 
            this.ClientSize = new System.Drawing.Size(355, 360);
            this.Controls.Add(this.btnPacientes);
            this.Controls.Add(this.btnMedicos);
            this.Controls.Add(this.btnEspecialidades);
            this.Controls.Add(this.btnCitas);
            this.Controls.Add(this.btnDiagnosticos);
            this.Controls.Add(this.btnReportes);
            this.Name = "FrmMostrar";
            this.Text = "Menú Principal - MedsiteV2";
            this.ResumeLayout(false);

        }
    }
}
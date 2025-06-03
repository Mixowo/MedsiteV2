namespace MedsiteV2
{
    partial class FrmEspecialidades
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvEspecialidades;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEspecialidades));
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvEspecialidades = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspecialidad.Location = new System.Drawing.Point(27, 25);
            this.lblEspecialidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(95, 17);
            this.lblEspecialidad.TabIndex = 5;
            this.lblEspecialidad.Text = "Especialidad:";
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Location = new System.Drawing.Point(143, 23);
            this.txtEspecialidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(265, 22);
            this.txtEspecialidad.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnGuardar.Location = new System.Drawing.Point(143, 56);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(129, 33);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnEliminar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnEliminar.Location = new System.Drawing.Point(280, 56);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(128, 33);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvEspecialidades
            // 
            this.dgvEspecialidades.AllowUserToAddRows = false;
            this.dgvEspecialidades.AllowUserToDeleteRows = false;
            this.dgvEspecialidades.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspecialidades.Location = new System.Drawing.Point(27, 111);
            this.dgvEspecialidades.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEspecialidades.Name = "dgvEspecialidades";
            this.dgvEspecialidades.ReadOnly = true;
            this.dgvEspecialidades.RowHeadersWidth = 51;
            this.dgvEspecialidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEspecialidades.Size = new System.Drawing.Size(549, 270);
            this.dgvEspecialidades.TabIndex = 4;
            this.dgvEspecialidades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEspecialidades_CellClick);
            this.dgvEspecialidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEspecialidades_CellContentClick);
            // 
            // FrmEspecialidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 394);
            this.Controls.Add(this.dgvEspecialidades);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtEspecialidad);
            this.Controls.Add(this.lblEspecialidad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmEspecialidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Especialidades";
            this.Load += new System.EventHandler(this.FrmEspecialidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
namespace MedsiteV2
{
    partial class FrmMostrar
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMostrar));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menupacientes = new FontAwesome.Sharp.IconMenuItem();
            this.menumedicos = new FontAwesome.Sharp.IconMenuItem();
            this.menuespecialidades = new FontAwesome.Sharp.IconMenuItem();
            this.menucitas = new FontAwesome.Sharp.IconMenuItem();
            this.menudiagnostico = new FontAwesome.Sharp.IconMenuItem();
            this.menureportes = new FontAwesome.Sharp.IconMenuItem();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menupacientes,
            this.menumedicos,
            this.menuespecialidades,
            this.menucitas,
            this.menudiagnostico,
            this.menureportes});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(637, 83);
            this.menu.TabIndex = 12;
            this.menu.Text = "menuStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MedsiteV2.Properties.Resources.pngtree_health_logo_vector_illustration_png_image_6580780;
            this.pictureBox1.Location = new System.Drawing.Point(141, 143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 341);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // menupacientes
            // 
            this.menupacientes.AutoSize = false;
            this.menupacientes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menupacientes.IconChar = FontAwesome.Sharp.IconChar.UserInjured;
            this.menupacientes.IconColor = System.Drawing.Color.Black;
            this.menupacientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menupacientes.IconSize = 50;
            this.menupacientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menupacientes.Name = "menupacientes";
            this.menupacientes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menupacientes.Size = new System.Drawing.Size(100, 79);
            this.menupacientes.Text = "Pacientes";
            this.menupacientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menupacientes.Click += new System.EventHandler(this.menupacientes_Click);
            // 
            // menumedicos
            // 
            this.menumedicos.AutoSize = false;
            this.menumedicos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menumedicos.IconChar = FontAwesome.Sharp.IconChar.UserMd;
            this.menumedicos.IconColor = System.Drawing.Color.Black;
            this.menumedicos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menumedicos.IconSize = 50;
            this.menumedicos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menumedicos.Name = "menumedicos";
            this.menumedicos.Size = new System.Drawing.Size(100, 79);
            this.menumedicos.Text = "Medicos";
            this.menumedicos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menumedicos.Click += new System.EventHandler(this.menumedicos_Click);
            // 
            // menuespecialidades
            // 
            this.menuespecialidades.AutoSize = false;
            this.menuespecialidades.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuespecialidades.IconChar = FontAwesome.Sharp.IconChar.BookMedical;
            this.menuespecialidades.IconColor = System.Drawing.Color.Black;
            this.menuespecialidades.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuespecialidades.IconSize = 50;
            this.menuespecialidades.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuespecialidades.Name = "menuespecialidades";
            this.menuespecialidades.Size = new System.Drawing.Size(130, 79);
            this.menuespecialidades.Text = "Especialidades";
            this.menuespecialidades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuespecialidades.Click += new System.EventHandler(this.menuespecialidades_Click);
            // 
            // menucitas
            // 
            this.menucitas.AutoSize = false;
            this.menucitas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menucitas.IconChar = FontAwesome.Sharp.IconChar.UserClock;
            this.menucitas.IconColor = System.Drawing.Color.Black;
            this.menucitas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucitas.IconSize = 50;
            this.menucitas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menucitas.Name = "menucitas";
            this.menucitas.Size = new System.Drawing.Size(100, 79);
            this.menucitas.Text = "Citas";
            this.menucitas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menucitas.Click += new System.EventHandler(this.menucitas_Click);
            // 
            // menudiagnostico
            // 
            this.menudiagnostico.AutoSize = false;
            this.menudiagnostico.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menudiagnostico.IconChar = FontAwesome.Sharp.IconChar.UserCheck;
            this.menudiagnostico.IconColor = System.Drawing.Color.Black;
            this.menudiagnostico.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menudiagnostico.IconSize = 50;
            this.menudiagnostico.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menudiagnostico.Name = "menudiagnostico";
            this.menudiagnostico.Size = new System.Drawing.Size(100, 79);
            this.menudiagnostico.Text = "Diagnostico";
            this.menudiagnostico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menudiagnostico.Click += new System.EventHandler(this.menudiagnostico_Click);
            // 
            // menureportes
            // 
            this.menureportes.AutoSize = false;
            this.menureportes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menureportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.menureportes.IconColor = System.Drawing.Color.Black;
            this.menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menureportes.IconSize = 50;
            this.menureportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menureportes.Name = "menureportes";
            this.menureportes.Size = new System.Drawing.Size(100, 79);
            this.menureportes.Text = "Reportes";
            this.menureportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menureportes.Click += new System.EventHandler(this.menureportes_Click);
            // 
            // FrmMostrar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(637, 522);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMostrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedsiteV2";
            this.Load += new System.EventHandler(this.FrmMostrar_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.MenuStrip menu;
        private FontAwesome.Sharp.IconMenuItem menupacientes;
        private FontAwesome.Sharp.IconMenuItem menumedicos;
        private FontAwesome.Sharp.IconMenuItem menuespecialidades;
        private FontAwesome.Sharp.IconMenuItem menucitas;
        private FontAwesome.Sharp.IconMenuItem menudiagnostico;
        private FontAwesome.Sharp.IconMenuItem menureportes;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
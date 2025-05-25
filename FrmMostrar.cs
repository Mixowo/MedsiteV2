using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedsiteV2
{
    public partial class FrmMostrar : Form
    {
        public FrmMostrar()
        {
            InitializeComponent();

            // Asociar eventos a los botones
            btnPacientes.Click += BtnPacientes_Click;
            btnMedicos.Click += BtnMedicos_Click;
            btnEspecialidades.Click += BtnEspecialidades_Click;
            btnCitas.Click += BtnCitas_Click;
            btnDiagnosticos.Click += BtnDiagnosticos_Click;
            btnReportes.Click += BtnReportes_Click;
        }

        private void BtnPacientes_Click(object sender, EventArgs e)
        {
            FrmPacientes frm = new FrmPacientes();
            frm.ShowDialog();
        }

        private void BtnMedicos_Click(object sender, EventArgs e)
        {
            FrmMedicos frm = new FrmMedicos();
            frm.ShowDialog();
        }

        private void BtnEspecialidades_Click(object sender, EventArgs e)
        {
            FrmEspecialidades frm = new FrmEspecialidades();
            frm.ShowDialog();
        }

        private void BtnCitas_Click(object sender, EventArgs e)
        {
            FrmCitas frm = new FrmCitas();
            frm.ShowDialog();
        }

        private void BtnDiagnosticos_Click(object sender, EventArgs e)
        {
            FrmDiagnostico frm = new FrmDiagnostico();
            frm.ShowDialog();
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            FrmReportes frm = new FrmReportes();
            frm.ShowDialog();
        }
    }
}

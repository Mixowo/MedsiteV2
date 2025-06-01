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

        private void menupacientes_Click(object sender, EventArgs e)
        {
            FrmPacientes frm = new FrmPacientes();
            frm.ShowDialog();
        }

        private void menumedicos_Click(object sender, EventArgs e)
        {
            FrmMedicos frm = new FrmMedicos();
            frm.ShowDialog();
        }

        private void menuespecialidades_Click(object sender, EventArgs e)
        {
            FrmEspecialidades frm = new FrmEspecialidades();
            frm.ShowDialog();
        }

        private void menucitas_Click(object sender, EventArgs e)
        {
            FrmCitas frm = new FrmCitas();
            frm.ShowDialog();
        }

        private void menudiagnostico_Click(object sender, EventArgs e)
        {
            FrmDiagnostico frm = new FrmDiagnostico();
            frm.ShowDialog();
        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            FrmReportes frm = new FrmReportes();
            frm.ShowDialog();
        }

        private void FrmMostrar_Load(object sender, EventArgs e)
        {

        }
    }
}

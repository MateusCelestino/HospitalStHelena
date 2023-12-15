using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalStHelena
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            // Cria um instancia do formulário de cargos
            fmCargos cargos = new fmCargos();
            //test
            cargos.ShowDialog();
        }

        private void funcioáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastra funcianrio = new Cadastra();
            funcianrio.ShowDialog();
        }
    }
}

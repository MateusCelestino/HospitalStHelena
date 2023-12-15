using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalStHelena
{
    public partial class Cadastra : Form
    {
        ConexaoDB conexaoDB;
        public Cadastra()
        {
            InitializeComponent();
            conexaoDB = new ConexaoDB();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string nome = txtNome.Text;
            string data_nascimento = txtDataNasceu.Text;
            string cpf = txtCpf.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            string cargo_id = txt_cargo_id.Text;


        }       
    }
}

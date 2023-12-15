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
            //ssa
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

            if(id. >)
            {

            }
            
            if (nome.Length > 255)
            {
                MessageBox.Show("O comprimento máximo do texto é 255 caracteres");
                return;
            }

            if (nome == "")
            {
                MessageBox.Show("O titulo não pode ficar em branco");
                return;
            }
            if (data_nascimento. >)
            {

            }
            if (cpf.Length > 11)
            {
                MessageBox.Show("O comprimento máximo do texto é 11 caracteres");
                return;
            }
            if (email.Length > 255)
            {
                MessageBox.Show("O comprimento máximo do texto é 255 caracteres");
                return;
            }
            if (senha.Length > 10)
            {
                MessageBox.Show("O comprimento máximo do texto é 10 caracteres");
                return;
            }
            if (cargo_id. >)
            {

            }

            // Cria um dicionário com os parametros.
            var parametros = new Dictionary<string, object> {
                { "id", id },
                { "nome", nome},
                { "data  nascimento", data_nascimento},
                { "cpf", cpf},
                { "email", email},
                { "senha", senha}
            };
            bool resultado = conexaoDB.Inserir2("funcionario", parametros);

            // Verifica se deu certo
            if (resultado)
            {
                MessageBox.Show("Salvo com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao salvar");
            }

        }

        private void Cadastra_Load(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show
            (
                "Deseja cancelar o cadastro?",
                "Cancelando cadastro",
                MessageBoxButtons.YesNo
            );

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

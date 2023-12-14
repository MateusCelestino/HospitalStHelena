using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalStHelena
{
    public partial class fmCargos : Form
    {
        ConexaoDB conexaoDB;
        public fmCargos()
        {
            InitializeComponent();
            conexaoDB = new ConexaoDB();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void fmCargos_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            var resultado = MessageBox.Show
                (
                "Deseja cancelar o cadastro?",
                "Cancelando cadastro", 
                MessageBoxButtons.YesNo
                );

            if(resultado ==  DialogResult.Yes) 
            {
                this.Close();
            }
            
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;
            string descricao = txtDescricao.Text;

            if(titulo.Length > 255)
            {
                MessageBox.Show("O comprimento máximo do texto é 255 caracteres");
                return;
            }

            if(titulo == "")
            {
                MessageBox.Show("O titulo não pode ficar em branco");
                return;
            }

            if(descricao.Length > 255)
            {
                MessageBox.Show("O comprimento máximo do descrção é 255 caracteres");
                return;
            }

            // Cria uma nova instancia de comando do Mysql
            using(var comando = new MySqlCommand())
            {
                // Define em qual coneão vai ser executado o comando
                comando.Connection = conexaoDB.conexao;
                //Cria a SQL que vai ser executada;
                comando.CommandText = "INSERT INTO cargos (titulo, descricao) VALUE (@titulo, @descricao)";
                
                // Adiciona os valores aos parameters
                comando.Parameters.AddWithValue("titulo", titulo);
                comando.Parameters.AddWithValue("descricao", descricao);
               
                // Executa o comando
                int linhasFetadas = await comando.ExecuteNonQueryAsync();
                try
                {

                    if (linhasFetadas > 0)
                    {
                        MessageBox.Show("Salvo com sucesso!");
                        // Fecha o Formulário
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Houve um problema na hora de salvar");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro greve! \n" + ex.ToString());
                }
            }

        }
    }
}

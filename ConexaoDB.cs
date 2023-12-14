using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalStHelena
{
    internal class ConexaoDB
    {
        MySqlConnectionStringBuilder builder;
        public MySqlConnection conexao;

        public ConexaoDB()
        {
            builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "12345",
                Database = "hospital",
                Port = 3306
            };
            //Executa a conexão com banco de dados
            conectar();
        }

        private async void conectar()
        {   
            // Passa os dados de conexão para o MysqlConnector
            conexao = new MySqlConnection(builder.ConnectionString);

            // faz a conexão com banco de dados.
            await conexao.OpenAsync();
        }

        public bool Inserir(string tabela, Dictionary<string, object> parametros)
        {
            using (var comando = new MySqlCommand())
            {
                // Define em qual coneão vai ser executado o comando
                comando.Connection = this.conexao;
                //Cria a SQL que vai ser executada;

                string camposTabela = string.Join(",", parametros.Keys);

                IEnumerable<string> chavesModificadas = parametros.Keys.Select(chave => "@" + chave);
                string chavesComArroba = string.Join(",", parametrosString)


                comando.CommandText = $"INSERT INTO {tabela}{camposTabela} (titulo, descricao) VALUE (@titulo, @descricao)";

                // Adiciona os valores aos parameters
                foreach (var item in parametros.Keys)
                {
                    comando.Parameters.AddWithValue(Key)
            }


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
                return false;
            }                
        }
    }
}

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

                IEnumerable<string> parametrosString = parametros.Keys.Select(chave => "@" + chave);
                string chavesComArroba = string.Join(",", parametrosString);


                comando.CommandText = $"INSERT INTO {tabela} ({camposTabela}) VALUES ({chavesComArroba})";

                // Adiciona os valores aos parameters
                foreach (var key in parametros.Keys)
                {
                    comando.Parameters.AddWithValue(key, parametros[key]);
                }


                // Executa o comando

                try
                {
                    int linhasAfetadas = comando.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                       return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }

            }                
        }
    }
}

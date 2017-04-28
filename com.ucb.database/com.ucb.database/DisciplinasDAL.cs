using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace com.ucb.database
{
    /// <summary>
    /// Classe que trabalha com a tabela Disciplinas
    /// do banco de dados
    /// </summary>
    public class DisciplinasDAL
    {
        /// <summary>
        /// Método que busca todas as disciplinas 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable buscarTodasDisciplinas()
        {
            try
            {
                using (SqlConnection _connection = new
                    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString()))
                {
                    DataSet _dtSet = new DataSet();

                    //abrir a conexao com o banco de dados
                    _connection.Open();

                    //usando objeto desconectado e informando o parametro com a variavel de conexao
                    SqlDataAdapter _dtAdapter = new SqlDataAdapter();
                    _dtAdapter.SelectCommand = new SqlCommand("SELECT * FROM Disciplinas", _connection);

                    //preenche o objeto para ficar desconectado
                    _dtAdapter.Fill(_dtSet);

                    //retorna o data table na posicao 0
                    return _dtSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using com.ucb.DataTransferObject;

namespace com.ucb.database
{
    /// <summary>
    /// Classe que trabalha com a tabela Disciplinas
    /// do banco de dados
    /// </summary>
    public class DisciplinasDAL
    {
        public Boolean deleteDisciplina(DisciplinasDTO dto)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString()))
                {
                    var sql = "DELETE FROM Disciplinas WHERE IDDisc = @IdDisc";

                    using (SqlCommand _command = new SqlCommand(sql, _connection))
                    {
                        _command.Parameters.Add("@IdDisc", SqlDbType.VarChar).Value = dto.idDisc;

                        _connection.Open();
                        _command.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean insertDisciplina(DisciplinasDTO dto)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString()))
                {
                    var sql = "INSERT INTO Disciplinas (NomeDisc) VALUES (@Nome)";

                    using (SqlCommand _command = new SqlCommand(sql, _connection))
                    {
                        _command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = dto.nomeDisc;

                        _connection.Open();
                        _command.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

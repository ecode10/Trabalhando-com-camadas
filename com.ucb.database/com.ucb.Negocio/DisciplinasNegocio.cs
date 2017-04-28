
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ucb.database;
using System.Data;

namespace com.ucb.Negocio
{
    public class DisciplinasNegocio : ucb.database.DisciplinasDAL
    {
        //criando variável protegida
        private DisciplinasDAL _displinasDAL;

        /// <summary>
        /// Gerando método construtor
        /// </summary>
        public DisciplinasNegocio()
        {
            if (_displinasDAL == null)
                _displinasDAL = new DisciplinasDAL();
        }
        /// <summary>
        /// Método que busca todas as disciplinas
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable buscarTodasDisciplinas()
        {
            try
            {
                return _displinasDAL.buscarTodasDisciplinas();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

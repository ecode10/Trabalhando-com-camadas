using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ucb.Negocio;
using com.ucb.DataTransferObject;

namespace WebFormUCB
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                preencherGridViewDisciplinas();
            }
        }

        private void preencherGridViewDisciplinas()
        {
            DisciplinasNegocio _disciplinas = new DisciplinasNegocio();
            grdDisciplinas.DataSource = _disciplinas.buscarTodasDisciplinas();
            grdDisciplinas.DataBind();
        }

        protected void btnSalvarDisciplina_Click(object sender, EventArgs e)
        {
            //preenchendo a dto
            DisciplinasDTO _dto = new DisciplinasDTO();
            _dto.nomeDisc = txtNomeDisciplina.Text;

            //chamando a camada de negocio
            DisciplinasNegocio _negocio = new DisciplinasNegocio();

            if (_negocio.insertDisciplina(_dto))
            {
                preencherGridViewDisciplinas();
                txtNomeDisciplina.Text = "";

            }

        }
    }
}
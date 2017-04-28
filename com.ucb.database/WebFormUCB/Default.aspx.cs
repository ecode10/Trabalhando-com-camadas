using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ucb.Negocio;

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
    }
}
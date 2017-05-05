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

        protected void grdDisciplinas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                //index da linha
                var index = int.Parse((string)(e.CommandArgument));

                //a chave da tabela baseado no index da linha
                var chave = this.grdDisciplinas.DataKeys[index]["IdDisc"].ToString();

                //chamar o método que deleta passando os parmetros
                DisciplinasDTO _dto = new DisciplinasDTO();
                _dto.idDisc = int.Parse(chave);

                DisciplinasNegocio _negocio = new DisciplinasNegocio();
                if (_negocio.deleteDisciplina(_dto))
                    Response.Redirect("Default");
            }
        }
    }
}
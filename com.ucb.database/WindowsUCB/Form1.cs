using com.ucb.DataTransferObject;
using com.ucb.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsUCB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            preencherGridView();
        }

        private void preencherGridView()
        {
            DisciplinasNegocio _discplinas = new DisciplinasNegocio();
            grdDisciplinas.DataSource = _discplinas.buscarTodasDisciplinas();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DisciplinasDTO _dto = new DisciplinasDTO();
            _dto.nomeDisc = txtNomeDisciplina.Text;

            DisciplinasNegocio _negocio = new DisciplinasNegocio();
            if (_negocio.insertDisciplina(_dto))
            {
                txtNomeDisciplina.Text = "";
                MessageBox.Show("Disciplina inserida com sucesso", "Disciplina", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                preencherGridView();
            }
        }
    }
}

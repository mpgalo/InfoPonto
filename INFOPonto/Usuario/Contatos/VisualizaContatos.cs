using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using INFOPonto.RN;
using INFOPonto.MODEL;

namespace INFOPonto.Usuario.Contatos
{
    public partial class VisualizaContatos : Form
    {
        public VisualizaContatos()
        {
            InitializeComponent();
        }

        private ContatoRN contatoRn;

        private void VisualizaContatos_Load(object sender, EventArgs e)
        {

            contatoRn = new ContatoRN();

            List<ContatoModel> contatos = contatoRn.ObterContatos(Util.UsuarioLogado.Perfil);

            if (contatos != null)
            {
                bsContatos.DataSource = contatos;
                Util.BindAutoComplete<ContatoModel>(txtNome, contatos, "Nome");
            }
            else
                MessageBox.Show("Erro ao consultar contatos.\nFavor tente novamente mais tarde.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
      

        private void btnFiltrar_Click(object sender, EventArgs e)
        {                

            List<ContatoModel> contatos = contatoRn.ObterContatosPorFiltro(txtNome.Text,Util.UsuarioLogado.Perfil);
            if (contatos != null)
            {
                bsContatos.DataSource = contatos;
            }
            else
            {
                MessageBox.Show("Erro ao filtrar contatos.\nFavor tente novamente mais tarde.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
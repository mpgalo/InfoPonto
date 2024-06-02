using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using INFOPonto.MODEL;
using INFOPonto.RN;

namespace INFOPonto.Administrativo.Cadastros
{
    public partial class Contato : Form
    {

        private bool isInsert = false;
        private ContatoRN contatoRn;

        public Contato()
        {
            InitializeComponent();
            contatoRn = new ContatoRN();
        }

        private void Contato_Load(object sender, EventArgs e)
        {
            List<ContatoModel> contato = contatoRn.ObterContatos();
            bsContato.DataSource = contato;
            txtNome.DataBindings.Add("Text", bsContato, "Nome", true, DataSourceUpdateMode.Never);
            txtTelefone.DataBindings.Add("Text", bsContato, "Telefone", true, DataSourceUpdateMode.Never);
            txtCelular.DataBindings.Add("Text", bsContato, "Celular", true, DataSourceUpdateMode.Never);
            txtEmail.DataBindings.Add("Text", bsContato, "Email", true, DataSourceUpdateMode.Never);
            chkExibirUsuario.DataBindings.Add("Checked", bsContato, "ExibirContato", true, DataSourceUpdateMode.Never);

            if (bsContato.Count > 0)
                bindingNavigatorDeleteItem.Visible = true;
            else
                bindingNavigatorDeleteItem.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (isInsert)
            {
                grdContatos.Enabled = true;
                contatoNavigator.Enabled = true;
                bsContato.RemoveCurrent();
                isInsert = false;
            }
            else
            {
                bsContato.ResetCurrentItem();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaContato())
            {
                ContatoModel contato = (ContatoModel)bsContato.List[bsContato.Position];
                contato.Nome = txtNome.Text.Trim();

                if (txtTelefone.Text != "(  )    -")
                    contato.Telefone = txtTelefone.Text.Trim();
                else
                    contato.Telefone = null;

                if (txtCelular.Text != "(  )    -")
                    contato.Celular = txtCelular.Text.Trim();
                else
                    contato.Celular = null;

                contato.ExibirContato = chkExibirUsuario.Checked;

                if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
                    contato.Email = txtEmail.Text.Trim();
                else
                    contato.Email = null;

                if (isInsert)
                {
                    grdContatos.Enabled = true;
                    contatoNavigator.Enabled = true;
                    this.insereContato(contato);
                }
                else
                {
                    this.atualizaContato(contato);
                }
            }
        }

        private void atualizaContato(ContatoModel contato)
        {
            if (contatoRn.AtualizarContato(contato))
            {
                MessageBox.Show("Contato atualizado com sucesso.", "Sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bsContato.ResetCurrentItem();
            }
            else
                MessageBox.Show("Erro ao atualizar contato.\nFavor procure o administrador do sistema.", "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void insereContato(ContatoModel contato)
        {
            if (contatoRn.InserirContato(contato))
            {
                MessageBox.Show("Contato inserido com sucesso.", "Sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindingNavigatorDeleteItem.Visible = true;
                isInsert = false;
            }
            else
                MessageBox.Show("Erro ao inserir contato.\nFavor procure o administrador do sistema.", "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool validaContato()
        {
            bool validate = true;

            string errorMessage = "";

            if (grdContatos.Rows.Count == 0)
            {
                errorMessage = ("É necessário adicionar um novo item antes de salvar.");
                validate = false;
            }

            if (string.IsNullOrEmpty(txtNome.Text.Trim()))
            {
                errorMessage = "Nome Obrigatório.";
                txtNome.Focus();
                validate = false;
            }

            if (txtTelefone.Text != "(  )    -" && !txtTelefone.MaskCompleted)
            {
                errorMessage = string.Concat(errorMessage, "\n", "Preencha o telefone corretamente.");

                if (validate)
                    txtTelefone.Focus();

                validate = false;
            }

            if (txtCelular.Text != "(  )    -" && !txtCelular.MaskCompleted)
            {
                errorMessage = string.Concat(errorMessage, "\n", "Preencha o celular corretamente.");

                if (validate)
                    txtCelular.Focus();

                validate = false;
            }

            if (!txtTelefone.MaskCompleted && !txtCelular.MaskCompleted && string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                errorMessage = string.Concat(errorMessage, "\n", "Preencha pelo menos uma informação de contato.");

                if (validate)
                    txtTelefone.Focus();

                validate = false;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                if (!Util.ValidateEmail(txtEmail.Text.Trim()))
                {
                    errorMessage = string.Concat(errorMessage, "\n", "Email inválido.");

                    if (validate)
                        txtEmail.Focus();

                    validate = false;
                }
            }


            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return validate;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            grdContatos.Enabled = false;
            contatoNavigator.Enabled = false;
            isInsert = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este item?", "Atenção.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ContatoModel contato = (ContatoModel)bsContato.Current;

                if (contatoRn.ExcluirContato(contato))
                {
                    MessageBox.Show("Contato excluido com sucesso.", "Sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsContato.RemoveCurrent();
                }
                else
                {

                    MessageBox.Show("Não foi possivel excluir contato\nFavor procure o administrador do sistema.", "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
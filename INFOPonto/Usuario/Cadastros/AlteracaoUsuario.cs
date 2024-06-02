using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using INFOPonto.MODEL;
using INFOPonto.RN;

namespace INFOPonto.Usuario.Cadastros
{
    public partial class AlteracaoUsuario : Form
    {
        public AlteracaoUsuario()
        {
            InitializeComponent();
        }

        private void AlteracaoUsuario_Load(object sender, EventArgs e)
        {
            this.bindUsuario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.bindUsuario();
        }

        private void bindUsuario()
        {
            UsuarioModel usuario = Util.UsuarioLogado;
            txtNome.Text = usuario.Nome;
            txtRG.Text = usuario.Rg;
            txtCPF.Text = usuario.Cpf;
            txtLogin.Text = usuario.Login;
            txtEmail.Text = usuario.Email;
            txtTelefone.Text = usuario.Telefone;
            txtCelular.Text = usuario.Celular;
            txtLogradouro.Text = usuario.Endereco.Logradouro;
            txtNumero.Text = usuario.Endereco.Numero;
            txtComplemento.Text = usuario.Endereco.Complemento;
            txtBairro.Text = usuario.Endereco.Bairro;
            txtCidade.Text = usuario.Endereco.Cidade;
            txtEstado.Text = usuario.Endereco.Estado;
        }

        private UsuarioModel GetUserInfo()
        {
            UsuarioModel usuario = Util.UsuarioLogado;

            usuario.Login = txtLogin.Text.Trim();

            if (!string.IsNullOrEmpty(txtSenha.Text.Trim()))
                usuario.Senha = txtSenha.Text.Trim();

            usuario.Nome = txtNome.Text.Trim();
            usuario.Rg = txtRG.Text.Trim();
            usuario.Cpf = txtCPF.Text.Trim();

            usuario.Email = txtEmail.Text.Trim();

            if (txtTelefone.Text != "(  )    -")
                usuario.Telefone = txtTelefone.Text.Trim();
            else
                usuario.Telefone = string.Empty;

            if (txtCelular.Text != "(  )    -")
                usuario.Celular = txtCelular.Text.Trim();
            else
                usuario.Celular = string.Empty;

            usuario.Endereco.Logradouro = txtLogradouro.Text.Trim();
            usuario.Endereco.Numero = txtNumero.Text.Trim();
            usuario.Endereco.Complemento = txtComplemento.Text.Trim();
            usuario.Endereco.Bairro = txtBairro.Text.Trim();
            usuario.Endereco.Cidade = txtCidade.Text.Trim();
            usuario.Endereco.Estado = txtEstado.Text.Trim();

            return usuario;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaUsuario())
            {
                UsuarioRN usuarioRn = new UsuarioRN();
                UsuarioModel usuario = this.GetUserInfo();

                string msgErro = null;
                if (usuarioRn.AtualizarUsuario(usuario, ref msgErro))
                {
                    MessageBox.Show("Cadastro de usuário alterado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Util.UsuarioLogado = usuario;
                    Util.ClearControls(txtSenhaAtual, txtSenha, txtConfirmaSenha);
                }
                else
                {
                    if (string.IsNullOrEmpty(msgErro))
                        MessageBox.Show("Falha ao atualizar cadastro de usuário.\nFavor procure o administrador do sistema.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show(string.Format("Falha ao ao atualizar cadastro de usuário.\n{0}", msgErro), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLogin.Focus();
                    }
                }
            }
        }

        private bool validaUsuario()
        {
            bool validate = true;

            string errorMessage = "";

            if (string.IsNullOrEmpty(txtNome.Text.Trim()))
            {
                errorMessage = "Nome Obrigatório.";
                txtNome.Focus();
                validate = false;
            }


            if (string.IsNullOrEmpty(txtLogin.Text.Trim()))
            {
                errorMessage = string.Concat(errorMessage, "\n", "Login Obrigatório.");

                if (validate)
                    txtLogin.Focus();

                validate = false;
            }


            if (!string.IsNullOrEmpty(txtSenhaAtual.Text.Trim()))
            {
                if (!txtSenhaAtual.Text.Trim().Equals(Util.UsuarioLogado.Senha))
                {
                    errorMessage = string.Concat(errorMessage, "\n", "Senha Atual Inválida.");

                    if (validate)
                        txtSenhaAtual.Focus();

                    validate = false;
                }
            }


            if (!txtSenha.Text.Trim().Equals(txtConfirmaSenha.Text.Trim()))
            {
                errorMessage = string.Concat(errorMessage, "\n", "Senha e confirmação devem ser iguais.");

                if (validate)
                    txtSenha.Focus();

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



            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return validate;
        }
    }
}
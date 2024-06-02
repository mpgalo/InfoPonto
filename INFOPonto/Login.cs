using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using INFOPonto.RN;
using INFOPonto.MODEL;

namespace INFOPonto
{
    public partial class Login : Common.DefaultForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

            if (validaLogin(txtLogin.Text, txtSenha.Text))
            {
                UsuarioRN usuarioRn = new UsuarioRN();
                Util.UsuarioLogado = usuarioRn.ObterUsuarioPorLogin(txtLogin.Text.Trim());
                if (Util.UsuarioLogado == null)
                {
                    MessageBox.Show("Erro ao conectar ao banco de dados.\nFavor procurar o administrador do sistema", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }


            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private bool validaLogin(string usuario, string senha)
        {
            bool validate = true;
            if (string.IsNullOrEmpty(usuario.Trim()))
            {
                errorProvider1.SetError(txtLogin, "Login Obrigatório.");
                validate = false;
            }
            else
            {
                errorProvider1.SetError(txtLogin, "");
            }

            if (string.IsNullOrEmpty(senha.Trim()))
            {
                errorProvider1.SetError(txtSenha, "Senha Obrigatória.");
                validate = false;
            }
            else
            {
                errorProvider1.SetError(txtSenha, "");
            }

            if (validate)
            {
                UsuarioRN usuarioRn = new UsuarioRN();
                if (!usuarioRn.AutenticarUsuario(usuario, senha))
                {
                    errorProvider1.SetError(txtLogin, "Login ou senha inválido.");
                    validate = false;
                    this.DialogResult = DialogResult.None;
                }

            }
            else
                this.DialogResult = DialogResult.None;


            return validate;

        }

        private void Login_Load(object sender, EventArgs e)
        {
            btnLogin.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            this.AcceptButton = btnLogin;
            this.CancelButton = btnCancelar;

        }

    }
}
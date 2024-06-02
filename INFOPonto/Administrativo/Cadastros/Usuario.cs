using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using INFOPonto.RN;
using INFOPonto.MODEL;


namespace INFOPonto.Administrativo.Cadastros
{
    public partial class Usuario : Common.DefaultForm
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void CadastroUsuario_Load(object sender, EventArgs e)
        {
            CargoRN cargoRn = new CargoRN();
            Util.BindList(cmbCargo, cargoRn.ObterCargos(), "IdCargo", "NomeCargo", true);
            this.BindPerfil();

        }

        private void BindPerfil()
        {
            Util.LimparCombos(cmbPerfil);
            cmbPerfil.Items.Add("USU�RIO");
            cmbPerfil.Items.Add("ADMINISTRADOR");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


            if (validaUsuario())
            {
                UsuarioRN usuarioRn = new UsuarioRN();
                UsuarioModel usuario = this.GetUserInfo();

                string msgErro = null;
                if (usuarioRn.RegistrarUsuario(usuario, ref msgErro))
                {
                    //if (!string.IsNullOrEmpty(usuario.Email))
                    //{
                    //    if (usuarioRn.EnviaEmailCadastroUsuario(usuario))
                    //        MessageBox.Show("Usu�rio cadastrado com sucesso.\nEmail enviado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    else
                    //        MessageBox.Show("Usu�rio cadastrado com sucesso.\nFalha ao enviar email.", "Aten��o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                    //else
                    //{
                    MessageBox.Show("Usu�rio cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                    Util.ClearControls(this.Controls);
                    
                }
                else
                {
                    if (string.IsNullOrEmpty(msgErro))
                        MessageBox.Show("Falha ao cadastrar usu�rio.\nFavor procure o administrador do sistema.", "Aten��o", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show(string.Format("Falha ao cadastrar usu�rio.\n{0}", msgErro), "Aten��o", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLogin.Focus();
                    }
                }
            }

            Cursor.Current = Cursors.Default;

        }

        private UsuarioModel GetUserInfo()
        {
            UsuarioModel usuario = new UsuarioModel();
            usuario.Login = txtLogin.Text.Trim();
            usuario.Perfil = cmbPerfil.SelectedIndex + 1;
            usuario.Senha = txtSenha.Text.Trim();

            usuario.Nome = txtNome.Text.Trim();
            usuario.Rg = txtRG.Text.Trim();
            usuario.Cpf = txtCPF.Text.Trim();
            usuario.Cargo.IdCargo = (int)cmbCargo.SelectedValue;

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

        private bool validaUsuario()
        {
            bool validate = true;

            string errorMessage = "";

            if (string.IsNullOrEmpty(txtNome.Text.Trim()))
            {
                errorMessage = "Nome Obrigat�rio.";
                txtNome.Focus();
                validate = false;
            }

            if (cmbCargo.Text.Equals("-- Selecione --"))
            {
                errorMessage = string.Concat(errorMessage, "\n", "Cargo Obrigat�rio.");

                if (validate)
                    cmbCargo.Focus();

                validate = false;
            }

            if (string.IsNullOrEmpty(txtLogin.Text.Trim()))
            {
                errorMessage = string.Concat(errorMessage, "\n", "Login Obrigat�rio.");

                if (validate)
                    txtLogin.Focus();

                validate = false;
            }

            if (cmbPerfil.Text.Equals("-- Selecione --"))
            {
                errorMessage = string.Concat(errorMessage, "\n", "Perfil Obrigat�rio.");

                if (validate)
                    cmbPerfil.Focus();

                validate = false;
            }

            if (string.IsNullOrEmpty(txtSenha.Text.Trim()))
            {
                errorMessage = string.Concat(errorMessage, "\n", "Senha Obrigat�ria.");

                if (validate)
                    txtSenha.Focus();

                validate = false;
            }

            if (string.IsNullOrEmpty(txtConfirmaSenha.Text.Trim()))
            {
                errorMessage = string.Concat(errorMessage, "\n", "Confirma��o de Senha Obrigat�ria.");

                if (validate)
                    txtConfirmaSenha.Focus();

                validate = false;
            }

            if (!txtSenha.Text.Trim().Equals(txtConfirmaSenha.Text.Trim()))
            {
                errorMessage = string.Concat(errorMessage, "\n", "Senha e confirma��o devem ser iguais.");

                if (validate)
                    txtSenha.Focus();

                validate = false;
            }


            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                if (!Util.ValidateEmail(txtEmail.Text.Trim()))
                {
                    errorMessage = string.Concat(errorMessage, "\n", "Email inv�lido.");

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
                MessageBox.Show(errorMessage, "Aten��o.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return validate;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Util.ClearControls(this.Controls);
            
        }

    }
}
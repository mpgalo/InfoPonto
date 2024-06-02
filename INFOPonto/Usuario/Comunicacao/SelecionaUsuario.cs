using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using INFOPonto.RN;
using INFOPonto.MODEL;

namespace INFOPonto.Usuario.Comunicacao
{
    public partial class SelecionaUsuario : Form
    {
        Recados recados;

        public SelecionaUsuario()
        {
            InitializeComponent();

        }

        private void Seleciona_Usuario_Load(object sender, EventArgs e)
        {
            recados = (Recados)this.Owner.ActiveMdiChild;
            btnConfirmaSelecao.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            this.AcceptButton = btnConfirmaSelecao;
            this.CancelButton = btnCancelar;
            this.bindCheked();
            this.checkSelecteds();

        }

        private void checkSelecteds()
        {
            if (recados.UsuariosSelecionados != null)
            {
                foreach (UsuarioModel usuario in recados.UsuariosSelecionados)
                {
                    clUsuarios.SetItemChecked(clUsuarios.FindStringExact(usuario.Nome), true);
                }
            }
            else
            {
                clUsuarios.ClearSelected();
            }
        }

        private void bindCheked()
        {
            UsuarioRN usuarioRn = new UsuarioRN();
            List<UsuarioModel> usuarios = usuarioRn.ObterUsuarios();

            if (usuarios != null)
            {
                Util.BindList(clUsuarios, usuarios, "IdUsuario", "Nome", false);
            }
            else
                MessageBox.Show("Erro ao preencher lista de usuários.\nFavor procure o administrador do sistema", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnConfirmaSelecao_Click(object sender, EventArgs e)
        {
            if (clUsuarios.CheckedItems.Count > 0)
            {
                List<UsuarioModel> usuarios = new List<UsuarioModel>();

                foreach (UsuarioModel usuario in clUsuarios.CheckedItems)
                {
                    usuarios.Add(usuario);
                }

                recados.UsuariosSelecionados = usuarios;
            }
            else
            {
                recados.UsuariosSelecionados = null;
            }

        }

        private void lnkSelecionarTodos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
            for (int i = 0; i < clUsuarios.Items.Count; i++)
            {
                clUsuarios.SetItemChecked(i, true);
            }
        }
    }
}
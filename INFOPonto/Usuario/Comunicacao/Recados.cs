using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using INFOPonto.MODEL;
using INFOPonto.RN;

namespace INFOPonto.Usuario.Comunicacao
{
    public partial class Recados : Form
    {
        private List<UsuarioModel> usuariosSelecionados = null;
        int numeroRecadosNaoLidos = 0;
        bool calculaNaoLidos = false;
        byte tabIndexInicial = 0;

        public List<UsuarioModel> UsuariosSelecionados
        {
            set { usuariosSelecionados = value; }
            get { return usuariosSelecionados; }
        }

        public Recados()
        {
            InitializeComponent();
        }

        public Recados(byte tabIndex)
        {
            InitializeComponent();
            tabIndexInicial = tabIndex;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            SelecionaUsuario selecaoUsuario = new SelecionaUsuario();

            if (selecaoUsuario.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnEnviarRecado_Click(object sender, EventArgs e)
        {

            if (validaRecado())
            {
                RecadoModel recado = this.BindRecado();
                RecadoRN recadoRn = new RecadoRN();
                string errorMessage = string.Empty;
                if (recadoRn.InserirRecado(recado, ref errorMessage))
                {
                    MessageBox.Show("Recado enviado com sucesso.", "Sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        MessageBox.Show("Erro ao enviar recado.\nFavor Procure o administrador do sistema", "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(errorMessage, "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.ClearControls();
            }

        }


        public bool validaRecado()
        {
            bool validate = true;

            string errorMessage = "";

            if (usuariosSelecionados == null)
            {
                errorMessage = "Antes de enviar o recado selecione o(s) destinatário(s).";
                btnSelecionar.Focus();
                validate = false;
            }

            if (string.IsNullOrEmpty(txtAssunto.Text.Trim()))
            {
                errorMessage = string.Concat(errorMessage, "\n", "Assunto Obrigatório.");

                if (validate)
                    txtAssunto.Focus();

                validate = false;
            }

            if (string.IsNullOrEmpty(txtConteudoRecado.Text.Trim()))
            {
                errorMessage = string.Concat(errorMessage, "\n", "Recado Obrigatório.");

                if (validate)
                    txtConteudoRecado.Focus();

                validate = false;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return validate;
        }

        private RecadoModel BindRecado()
        {
            RecadoModel recado = new RecadoModel();
            recado.Assunto = txtAssunto.Text.Trim();
            recado.Descricao = txtConteudoRecado.Text.Trim();
            recado.UsuarioRemetente = new UsuarioModel();
            //recado.UsuarioRemetente.IdUsuario = 1;
            recado.UsuarioRemetente = Util.UsuarioLogado;
            recado.UsuariosDestinatarios = usuariosSelecionados;
            recado.DataRecado = DateTime.Now;


            foreach (string anexo in lstArquivos.Items)
            {
                ArquivoModel arquivo = new ArquivoModel(anexo);
                recado.Arquivos.Add(arquivo);
            }

            return recado;
        }

        private void btnArquivo_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Filter = "All files (*.*)|*.*";


            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lstArquivos.Items.Add(openFileDialog1.FileName);
            }
        }

        private void ClearControls()
        {
            Util.ClearControls(tabPage1.Controls);
            lstArquivos.Items.Clear();
            usuariosSelecionados = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ClearControls();
        }

        private void Recados_Load(object sender, EventArgs e)
        {
            RecadoRN recadoRn = new RecadoRN();
            List<RecadoModel> recados = recadoRn.ObterRecadosPorDestinatario(Util.UsuarioLogado);
            bsRecados.DataSource = recados;

            txtDescricao.DataBindings.Add("Text", bsRecados, "Descricao");

            if (bsRecados.Current == null)
                btnAnexos.Enabled = false;

            tabControl1.SelectedIndex = tabIndexInicial;

        }

        private void btnAnexos_Click(object sender, EventArgs e)
        {
            RecadoModel recadoSelecionado = (RecadoModel)bsRecados.Current;
            BaixaAnexo baixarAnexo = new BaixaAnexo(recadoSelecionado.Arquivos);
            baixarAnexo.ShowDialog(this);
        }

        private void grdRecados_SelectionChanged(object sender, EventArgs e)
        {
            if (calculaNaoLidos)
            {
                RecadoModel recadoSelecionado = (RecadoModel)bsRecados.Current;
                btnAnexos.Enabled = recadoSelecionado.HasAnexo;

                if (!recadoSelecionado.FlLido)
                {
                    this.LerRecado(recadoSelecionado);
                }
            }
        }

        private void LerRecado(RecadoModel recadoSelecionado)
        {
            recadoSelecionado.UsuariosDestinatarios.Add(new UsuarioModel());
            recadoSelecionado.UsuariosDestinatarios[0] = Util.UsuarioLogado;

            RecadoRN recadoRn = new RecadoRN();
            if (recadoRn.LerRecado(recadoSelecionado))
            {
                grdRecados.Rows[bsRecados.Position].DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 8.25F, FontStyle.Regular);
                numeroRecadosNaoLidos--;
                recadoSelecionado.FlLido = true;
                lblRecadosNaoLidos.Text = string.Format("{0} não lidos", numeroRecadosNaoLidos);
            }
            else
            {
                MessageBox.Show("Não foi possivel definir a mensagem como lida, favor procure o administrador do sistema.",
                   "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0)
            {
                foreach (DataGridViewRow row in grdRecados.Rows)
                {
                    RecadoModel recado = (RecadoModel)bsRecados.List[row.Index];

                    if (!recado.FlLido)
                    {
                        numeroRecadosNaoLidos++;
                        if (row.Index == 0)
                        {
                            LerRecado(recado);
                            btnAnexos.Enabled = recado.HasAnexo;

                        }

                    }

                }
                lblRecadosNaoLidos.Text = string.Format("{0} não lidos", numeroRecadosNaoLidos);
                calculaNaoLidos = true;

                tabControl1.SelectedIndexChanged -= tabControl1_SelectedIndexChanged;
            }
        }

        private void grdRecados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            RecadoModel recado = (RecadoModel)bsRecados.List[e.RowIndex];
            string i = e.Value.ToString();
            if (!recado.FlLido && e.ColumnIndex == 0 && e.Value != null)
            {
                if (e.RowIndex > 0)
                {
                    grdRecados.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 8.25F, FontStyle.Bold);
                }
            }
        }       
    }
}
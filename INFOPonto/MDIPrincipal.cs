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

    public partial class MDIPrincipal : Common.DefaultForm
    {
        private PontoModel _ponto;
        private int childFormNumber = 0;



        public MDIPrincipal()
        {
            InitializeComponent();
            this.Text = "InfoPonto - Painel Principal";
            lblData.Text = DateTime.Today.ToString("dd/MM/yyyy");
            _ponto = new PontoModel();
            _ponto.Usuario = Util.UsuarioLogado;

            if (_ponto.Usuario.Perfil != 2)
                administrativoToolStripMenuItem.Visible = false;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            // Create a new instance of the child form.
            Form childForm = new Form();
            // Make it a child of this MDI form before showing it.
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
            this.Close();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                // TODO: Add code here to open the file.
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                // TODO: Add code here to save the current contents of the form to a file.
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard.GetText() or System.Windows.Forms.GetData to retrieve information from the clipboard.
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void btnFechaHoras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FecharPonto()
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

            PontoRN pontoRN = new PontoRN();
            _ponto.HoraFim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            if (pontoRN.FecharPonto(_ponto))
            {
                MessageBox.Show("Ponto Fechado com sucesso.\nPara reabrir o ponto efetue novamento o login no sistema", "Ponto Fechado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Util.LockWorkStation();
            }
            else
            {
                MessageBox.Show("Erro ao fechar ponto, favor procurar o administrador do sistema.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            System.Windows.Forms.Cursor.Current = Cursors.Default;


        }

        private void MDIPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown)
                this.FecharPonto();
        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
            PontoRN pontoRn = new PontoRN();

            _ponto.DataPonto = DateTime.Today;
            _ponto.HoraInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            _ponto.HoraFim = new DateTime();

            if (pontoRn.RegistrarPonto(_ponto))
            {
                lblBoasVindas.Text = string.Format("Bem Vindo {0} - ", _ponto.Usuario.Nome);
                this.ExibirNumeroRecadosNaoLidos();
            }
            else
            {
                MessageBox.Show("Erro ao registrar ponto. Favor procure o administrador do sistema.", "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void ExibirNumeroRecadosNaoLidos()
        {
            RecadoRN recadoRn = new RecadoRN();

            int numeroRecadosNaoLidos = recadoRn.ObterNumeroRecadosNaoLidos(Util.UsuarioLogado);
            if (numeroRecadosNaoLidos != -1)
            {
                if (numeroRecadosNaoLidos > 0)
                {
                    if (MessageBox.Show(string.Format("Você possui {0} recados não lidos.\nDeseja visualizar os recados agora?", numeroRecadosNaoLidos), "Atenção.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Usuario.Comunicacao.Recados recadosForm = new INFOPonto.Usuario.Comunicacao.Recados(1);
                        Util.ShowInMdi(this, recadosForm);
                    }
                }
            }
            else
            {
                MessageBox.Show("Erro ao consultar recados não lidos. Favor procure o administrador do sistema.","Atenção.",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void horasTrabalhadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrativo.Relatorios.RelatorioHorasTrabalhadas relatorioHorasTrabalhadas = new Administrativo.Relatorios.RelatorioHorasTrabalhadas();
            Util.ShowInMdi(this, relatorioHorasTrabalhadas, true);
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrativo.Cadastros.Usuario cadastroUsuario = new Administrativo.Cadastros.Usuario();
            Util.ShowInMdi(this, cadastroUsuario);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void horasTrabalhadasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Usuario.Relatorios.RelatorioHorasTrabalhadas relatorioHorasTrabalhadas = new Usuario.Relatorios.RelatorioHorasTrabalhadas();
            Util.ShowInMdi(this, relatorioHorasTrabalhadas, true);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.maximizarTela();
        }

        private void MDIPrincipal_Resize(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Minimized)
            {

                notifyIcon1.Visible = true;

                notifyIcon1.Text = "InfoPonto - Painel Principal";

                notifyIcon1.BalloonTipTitle = "InfoPonto - Painel Principal";

                notifyIcon1.BalloonTipText = "Clique duas vezes no ícone para retornar à aplicação!";

                this.ShowInTaskbar = false;

                notifyIcon1.ShowBalloonTip(0);

            }

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.maximizarTela();
        }

        private void maximizarTela()
        {
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void fecharPontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecados_Click(object sender, EventArgs e)
        {
            Usuario.Comunicacao.Recados recados = new INFOPonto.Usuario.Comunicacao.Recados();
            Util.ShowInMdi(this, recados);
        }

        private void dadosCadastraisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario.Cadastros.AlteracaoUsuario alteracao = new INFOPonto.Usuario.Cadastros.AlteracaoUsuario();
            Util.ShowInMdi(this, alteracao);
        }

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrativo.Cadastros.Cargo cargo = new INFOPonto.Administrativo.Cadastros.Cargo();
            Util.ShowInMdi(this, cargo);
        }

        private void pontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrativo.Cadastros.Ponto ponto = new INFOPonto.Administrativo.Cadastros.Ponto();
            Util.ShowInMdi(this, ponto);
        }

        private void contatoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Administrativo.Cadastros.Contato contato = new INFOPonto.Administrativo.Cadastros.Contato();
            Util.ShowInMdi(this, contato);
        } 

        private void contatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario.Contatos.VisualizaContatos visualizaContato = new INFOPonto.Usuario.Contatos.VisualizaContatos();
            Util.ShowInMdi(this, visualizaContato);
        }

        private void MDIPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                e.Cancel = true;
                MessageBox.Show("Favor feche o ponto antes de desligar o windows.", "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

             
    }
}

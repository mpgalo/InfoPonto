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
    public partial class Ponto : Form
    {
        public Ponto()
        {
            InitializeComponent();
            pontoRn = new PontoRN();
        }

        private bool isInsert = false;
        private PontoRN pontoRn;

        private void Ponto_Load(object sender, EventArgs e)
        {

            UsuarioRN usuarioRn = new UsuarioRN();
            List<UsuarioModel> usuarios = usuarioRn.ObterUsuarios();

            if (usuarios != null)
            {
                Util.BindList(cmbUsuario, usuarios, "IdUsuario", "Nome", true);

            }
            else
                MessageBox.Show("Erro ao preencher lista de usuários.\nFavor procure o administrador do sistema.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnFiltar_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                PontoRN pontoRn = new PontoRN();
                List<PontoModel> pontos = pontoRn.ObterHorasTrabalhasPorFiltro(this.bindPonto());

                if (pontos != null)
                {
                    bsPonto.DataSource = pontos;
                    lblTotalGeral.Text = CalcularTotalHoras(pontos).ToString();


                    if (txtEntrada.DataBindings.Count == 0)
                        txtEntrada.DataBindings.Add("Text", bsPonto, "HoraInicio", true, DataSourceUpdateMode.Never).FormatString = "T";

                    if (txtSaida.DataBindings.Count == 0)
                        txtSaida.DataBindings.Add("Text", bsPonto, "HoraFim", true, DataSourceUpdateMode.Never).FormatString = "T";


                    bindingNavigatorAddNewItem.Visible = true;

                    if (bsPonto.Count > 0)
                        bindingNavigatorDeleteItem.Visible = true;
                    else
                        bindingNavigatorDeleteItem.Visible = false;


                }
                else
                    MessageBox.Show("Erro ao realizar consulta.\nFavor tente novamente mais tarde.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TimeSpan CalcularTotalHoras(List<PontoModel> pontos)
        {
            TimeSpan totalHoras = new TimeSpan();

            foreach (PontoModel ponto in pontos)
            {
                if (ponto.TotalPonto.HasValue)
                    totalHoras += ponto.TotalPonto.Value;
            }

            return totalHoras;
        }

        private PontoModel bindPonto()
        {
            PontoModel ponto = new PontoModel();
            ponto.DataPonto = dtpData.Value.Date;
            ponto.Usuario.IdUsuario = (int)cmbUsuario.SelectedValue;
            return ponto;
        }

        private bool validate()
        {
            bool validate = true;

            string errorMessage = "";

            if (cmbUsuario.Text.Equals("-- Selecione --"))
            {
                errorMessage = "Usuário Obrigatório.";
                cmbUsuario.Focus();
                validate = false;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return validate;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaPonto())
            {

                PontoModel ponto = (PontoModel)bsPonto.List[bsPonto.Position];
                ponto.DataPonto = dtpData.Value.Date;
                ponto.Usuario.IdUsuario = int.Parse(cmbUsuario.SelectedValue.ToString());

                try
                {
                    ponto.HoraInicio = DateTime.Parse(txtEntrada.Text.Trim());
                    ponto.HoraFim = DateTime.Parse(txtSaida.Text.Trim());

                    if (isInsert)
                    {
                        grdPonto.Enabled = true;
                        pontoNavigator.Enabled = true;
                        this.inserePonto(ponto);
                    }
                    else
                    {
                        this.atualizaPonto(ponto);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Favor insira valores válidos para as horas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        }

        private void atualizaPonto(PontoModel ponto)
        {
            if (pontoRn.AtualizarPonto(ponto))
            {
                MessageBox.Show("Ponto atualizado com sucesso.", "Sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bsPonto.ResetCurrentItem();

            }
            else
                MessageBox.Show("Erro ao atualizar ponto.\nFavor procure o administrador do sistema.", "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void inserePonto(PontoModel ponto)
        {
            if (pontoRn.InserirPonto(ponto))
            {
                MessageBox.Show("Ponto inserido com sucesso.", "Sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindingNavigatorDeleteItem.Visible = true;


                isInsert = false;
            }
            else
                MessageBox.Show("Erro ao inserir ponto.\nFavor procure o administrador do sistema.", "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            grdPonto.Enabled = false;
            pontoNavigator.Enabled = false;
            isInsert = true;
            txtEntrada.Focus();
        }

        private bool validaPonto()
        {
            bool validate = true;

            string errorMessage = "";


            if (grdPonto.Rows.Count == 0)
            {
                errorMessage = ("É necessário adicionar um novo item antes de salvar.");
                validate = false;
            }


            if (!txtEntrada.MaskCompleted)
            {
                errorMessage = string.Concat(errorMessage, "\n", "Entrada Obrigatória.");
                txtEntrada.Focus();
                validate = false;
            }

            if (!txtSaida.MaskCompleted)
            {
                errorMessage = string.Concat(errorMessage, "\n", "Saída Obrigatória.");

                if (validate)
                    txtSaida.Focus();

                validate = false;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return validate;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (isInsert)
            {
                grdPonto.Enabled = true;
                pontoNavigator.Enabled = true;
                bsPonto.RemoveCurrent();
                isInsert = false;
            }
            else
            {
                bsPonto.ResetCurrentItem();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este item?", "Atenção.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PontoModel ponto = (PontoModel)bsPonto.Current;

                if (pontoRn.ExcluirPonto(ponto))
                {
                    MessageBox.Show("Ponto excluido com sucesso.", "Sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsPonto.RemoveCurrent();
                }
                else
                {
                    MessageBox.Show("Não foi possivel excluir registro\nFavor procure oadministrador do sistema.", "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
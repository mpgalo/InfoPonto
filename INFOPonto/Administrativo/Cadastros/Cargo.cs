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
    public partial class Cargo : Form
    {
        private bool isInsert = false;
        private CargoRN cargoRn;

        public Cargo()
        {
            InitializeComponent();
            cargoRn = new CargoRN();
        }


        private void Cargo_Load(object sender, EventArgs e)
        {
            List<CargoModel> cargos = cargoRn.ObterCargos();
            bsCargo.DataSource = cargos;
            txtCargo.DataBindings.Add("Text", bsCargo, "NomeCargo", true, DataSourceUpdateMode.Never);
            txtSalarioHora.DataBindings.Add("Text", bsCargo, "SalarioHora", true, DataSourceUpdateMode.Never).FormatString = "N2";
            txtSalarioMes.DataBindings.Add("Text", bsCargo, "SalarioMes", true, DataSourceUpdateMode.Never).FormatString = "N2";

            if (bsCargo.Count > 0)
                bindingNavigatorDeleteItem.Visible = true;
            else
                bindingNavigatorDeleteItem.Visible = false;

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (isInsert)
            {
                grdCargos.Enabled = true;
                cargoNavigator.Enabled = true;
                bsCargo.RemoveCurrent();
                isInsert = false;
            }
            else
            {
                bsCargo.ResetCurrentItem();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaCargo())
            {
                CargoModel cargo = (CargoModel)bsCargo.List[bsCargo.Position];
                cargo.NomeCargo = txtCargo.Text.Trim();

                if (!string.IsNullOrEmpty(txtSalarioHora.Text.Trim()))
                    cargo.SalarioHora = double.Parse(txtSalarioHora.Text.Trim());
                else
                    cargo.SalarioHora = null;

                if (!string.IsNullOrEmpty(txtSalarioMes.Text.Trim()))
                    cargo.SalarioMes = double.Parse(txtSalarioMes.Text.Trim());
                else
                    cargo.SalarioMes = null;

                if (isInsert)
                {
                    grdCargos.Enabled = true;
                    cargoNavigator.Enabled = true;

                    this.insereCargo(cargo);
                }
                else
                {
                    this.atualizaCargo(cargo);
                }
            }
        }

        private void atualizaCargo(CargoModel cargo)
        {
            if (cargoRn.AtualizarCargo(cargo))
            {
                MessageBox.Show("Cargo atualizado com sucesso.", "Sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bsCargo.ResetCurrentItem();

            }
            else
                MessageBox.Show("Erro ao atualizar cargo.\nFavor procure o administrador do sistema.", "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void insereCargo(CargoModel cargo)
        {
            if (cargoRn.InserirCargo(cargo))
            {
                MessageBox.Show("Cargo inserido com sucesso.", "Sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindingNavigatorDeleteItem.Visible = true;
                isInsert = false;
            }
            else
                MessageBox.Show("Erro ao inserir cargo.\nFavor procure o administrador do sistema.", "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            grdCargos.Enabled = false;
            cargoNavigator.Enabled = false;
            isInsert = true;
        }

        private bool validaCargo()
        {
            bool validate = true;

            string errorMessage = "";

            if (grdCargos.Rows.Count == 0)
            {
                errorMessage = ("É necessário adicionar um novo item antes de salvar.");
                validate = false;
            }

            if (string.IsNullOrEmpty(txtCargo.Text.Trim()))
            {
                errorMessage = "Cargo Obrigatório.";
                txtCargo.Focus();
                validate = false;
            }

            if (string.IsNullOrEmpty(txtSalarioHora.Text.Trim()) && string.IsNullOrEmpty(txtSalarioMes.Text.Trim()))
            {
                errorMessage = string.Concat(errorMessage, "\n", "Salário Hora ou Salario mês obrigatório.");                

                if (validate)
                    txtSalarioHora.Focus();

                validate = false;
            }


            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return validate;

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este item?", "Atenção.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CargoModel cargo = (CargoModel)bsCargo.Current;

                string erroMessage = "";
                if (cargoRn.ExcluirCargo(cargo, ref erroMessage))
                {
                    MessageBox.Show("Cargo excluido com sucesso.", "Sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsCargo.RemoveCurrent();
                }
                else
                {
                    if (!string.IsNullOrEmpty(erroMessage))
                    {
                        MessageBox.Show(string.Format("{0}\n{1}", "Não foi possivel excluir cargo", erroMessage), "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel excluir cargo\nFavor procure o administrador do sistema.", "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.OleDb;

namespace INFOPonto.Usuario.Relatorios
{
    public partial class RelatorioHorasTrabalhadas : Common.DefaultForm
    {
        public RelatorioHorasTrabalhadas()
        {
            InitializeComponent();
        }

        private void RelatorioHorasTrabalhadas_Load(object sender, EventArgs e)
        {
            dtpDataInicial.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDataFinal.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            this.loadReport();
        }

        private void loadReport()
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            Administrativo.Rpt.RelatorioHorasTrabalhadas rptHorasTrabalhadas = new Administrativo.Rpt.RelatorioHorasTrabalhadas();

            rptHorasTrabalhadas.SetParameterValue("@DATA_INICIAL", dtpDataInicial.Value);
            rptHorasTrabalhadas.SetParameterValue("@DATA_FINAL", dtpDataFinal.Value);
            rptHorasTrabalhadas.SetParameterValue("@NOME_USUARIO", null);
            rptHorasTrabalhadas.SetParameterValue("@ID_USUARIO", Util.UsuarioLogado.IdUsuario);

            rptHorasTrabalhadas.SetDatabaseLogon(Util.GetAppKey("rptLogin").ToString(), Util.GetAppKey("rptPwd").ToString());

            crystalReportViewer1.ReportSource = rptHorasTrabalhadas;

            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.loadReport();
        }
    }
}
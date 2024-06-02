using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using INFOPonto.MODEL;
using System.IO;

namespace INFOPonto.Usuario.Comunicacao
{
    public partial class BaixaAnexo : Form
    {
        public BaixaAnexo(List<ArquivoModel> arquivos)
        {
            InitializeComponent();
            Util.BindList(lstAnexos, arquivos, "CaminhoArquivoServidor", "NomeArquivo", false);
            //this.AcceptButton = btnBaixar;
            this.CancelButton = btnCancelar;
            
        }

        private void btnBaixar_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog1.FileName = ((ArquivoModel)lstAnexos.SelectedItem).NomeArquivo;
                if (Rede.NetworkHelper.mapearUnidadeRede(Util.GetAppKey("redeLogin").ToString(), Util.GetAppKey("redeSenha").ToString(), Util.GetAppKey("pastaArquivosServidor").ToString()))
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        FileInfo serverFile = new FileInfo(lstAnexos.SelectedValue.ToString());
                        serverFile.CopyTo(saveFileDialog1.FileName, true);
                        MessageBox.Show("Arquivo baixado com sucesso.", "Sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Erro ao acessar sistema de arquivos InfoPonto.\nFavor, procure o adiministrator do sistema"
                        , "Atenção.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Não é possivel salvar o arquivo no local especificado.\n" +
                    "Favor tente salvar o arquivo em outra pasta.\n"
                    + "Se o problema persistir, favor procure o administrador do sistema.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Não é possivel salvar o arquivo.\nFavor procure o administrador do sistema.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
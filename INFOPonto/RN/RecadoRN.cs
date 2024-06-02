using System;
using System.Collections.Generic;
using System.Text;
using INFOPonto.MODEL;
using INFOPonto.DAO;
using INFOPonto.Rede;
using System.IO;

namespace INFOPonto.RN
{
    public class RecadoRN
    {
        public bool InserirRecado(RecadoModel recado,ref string errorMessage)
        {
            try
            {

                string pastaArquivosRecado = string.Format(@"{0}\{1}", Util.GetAppKey("pastaArquivosServidor").ToString(), Guid.NewGuid().ToString());
                if (recado.Arquivos.Count > 0)
                {
                    if (NetworkHelper.mapearUnidadeRede(Util.GetAppKey("redeLogin").ToString(), Util.GetAppKey("redeSenha").ToString(), Util.GetAppKey("pastaArquivosServidor").ToString()))
                    {
                        if (!Directory.Exists(pastaArquivosRecado))
                            Directory.CreateDirectory(pastaArquivosRecado);

                        foreach (ArquivoModel arquivo in recado.Arquivos)
                        {
                            FileInfo fileLocal = new FileInfo(arquivo.CaminhoArquivoLocal);
                            arquivo.CaminhoArquivoServidor = string.Format(@"{0}\{1}",
                              pastaArquivosRecado, fileLocal.Name);

                            fileLocal.CopyTo(arquivo.CaminhoArquivoServidor, true);
                        }
                    }
                    else
                    {
                        errorMessage = "Erro ao acessar sistema de arquivos infoponto.\nFavor, procure o adiministrator do sistema";
                        return false;
                    }
                }

                RecadoDAO recadoDao = new RecadoDAO();
                recadoDao.InserirRecado(recado);


                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LerRecado(RecadoModel recado)
        {
            try
            {
                new RecadoDAO().LerRecado(recado);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<RecadoModel> ObterRecadosPorDestinatario(UsuarioModel usuario)
        {
            try
            {
                return new RecadoDAO().ObterRecadosPorDestinatario(usuario);
            }
            catch
            {
                return null;
            }
        }

        public int ObterNumeroRecadosNaoLidos(UsuarioModel usuario)
        {
            try
            {
                return new RecadoDAO().ObterNumeroRecadosNaoLidos(usuario);
            }
            catch
            {
                return -1;
            }
        }


    }
}

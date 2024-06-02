using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace INFOPonto.MODEL
{
    public class ArquivoModel
    {
        public ArquivoModel()
        {
        }

        public ArquivoModel(string caminhoArquivoLocal)
        {
            this._caminhoArquivoLocal = caminhoArquivoLocal;
        }

        private int _idArquivo;

        public int IdArquivo
        {
            get { return _idArquivo; }
            set { _idArquivo = value; }
        }

        private string _caminhoArquivoServidor;

        public string CaminhoArquivoServidor
        {
            get { return _caminhoArquivoServidor; }
            set { _caminhoArquivoServidor = value; }
        }

        private string _caminhoArquivoLocal;

        public string CaminhoArquivoLocal
        {
            get { return _caminhoArquivoLocal; }
            set { _caminhoArquivoLocal = value; }
        }

        public string NomeArquivo
        {
            get
            {
                FileInfo arquivo = new FileInfo(this.CaminhoArquivoServidor);
                return arquivo.Name;
            }

        }
    }
}

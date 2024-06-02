using System;
using System.Collections.Generic;
using System.Text;

namespace INFOPonto.MODEL
{
    public class EnderecoModel
    {
        private string _logradouro;

        public string Logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value; }
        }

        private string _numero;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private string _complemento;

        public string Complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }

        private string _bairro;

        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }

        private string _cidade;

        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }

        private string _estado;

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}

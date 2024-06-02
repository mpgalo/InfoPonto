using System;
using System.Collections.Generic;
using System.Text;

namespace INFOPonto.MODEL
{
    public class ContatoModel
    {
        private int _idContato;

        public int IdContato
        {
            get { return _idContato; }
            set { _idContato = value; }
        }

        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }



        private string _telefone;

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        private string _celular;

        public string Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private bool _exibirContato;


        public bool ExibirContato
        {
            get { return _exibirContato; }
            set { _exibirContato = value; }
        }
    }
}

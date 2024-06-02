using System;
using System.Collections.Generic;
using System.Text;

namespace INFOPonto.MODEL
{
    public class UsuarioModel
    {


        public UsuarioModel()
        {
            _cargo = new CargoModel();
            _endereco = new EnderecoModel();
        }

        public UsuarioModel(string login)
        {
            _login = login;
            _cargo = new CargoModel();
            _endereco = new EnderecoModel();
        }     


        private CargoModel _cargo;

        public CargoModel Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }

        private EnderecoModel _endereco;

        public EnderecoModel Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

        private int _perfil;

        public int Perfil
        {
            get { return _perfil; }
            set { _perfil = value; }
        }


        private int _idUsuario;

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
        private string _login;

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        private string _senha;


        //Futuramente utilizar criptografia
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }      

        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
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

        private string _rg;

        public string Rg
        {
            get { return _rg; }
            set { _rg = value; }
        }

        private string _cpf;

        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
      
    }
}

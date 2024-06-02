using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace INFOPonto.MODEL
{
    public class RecadoModel
    {
        public RecadoModel()
        {
            _usuarioRemetente = new UsuarioModel();
            _usuariosDestinatarios = new List<UsuarioModel>();
            _arquivos = new List<ArquivoModel>();
        }

        private int _idRecado;

        public int IdRecado
        {
            get { return _idRecado; }
            set { _idRecado = value; }
        }

        private UsuarioModel _usuarioRemetente;

        public UsuarioModel UsuarioRemetente
        {
            get { return _usuarioRemetente; }
            set { _usuarioRemetente = value; }
        }

        public string NomeRemetente
        {
            get { return _usuarioRemetente.Nome; }
        }

        private List<UsuarioModel> _usuariosDestinatarios;

        public List<UsuarioModel> UsuariosDestinatarios
        {
            get { return _usuariosDestinatarios; }
            set { _usuariosDestinatarios = value; }
        }



        private List<ArquivoModel> _arquivos;

        public List<ArquivoModel> Arquivos
        {
            get { return _arquivos; }
            set { _arquivos = value; }
        }

        private string _assunto;

        public string Assunto
        {
            get { return _assunto; }
            set { _assunto = value; }
        }

        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private bool _flLido;

        public bool FlLido
        {
            get { return _flLido; }
            set { _flLido = value; }
        }

        private DateTime _dataRecado;

        public DateTime DataRecado
        {
            get { return _dataRecado; }
            set { _dataRecado = value; }
        }

        public bool HasAnexo
        {
            get { return this.Arquivos.Count > 0; }
        }
    }
}

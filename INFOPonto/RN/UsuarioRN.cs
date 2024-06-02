using System;
using System.Collections.Generic;
using System.Text;
using INFOPonto.MODEL;
using INFOPonto.DAO;


namespace INFOPonto.RN
{
    class UsuarioRN
    {
        //private ErrorProvider _errorProviderUsuario;

        public UsuarioRN()
        {

        }

        public bool AutenticarUsuario(string login, string senha)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            bool isAutenticated =  usuarioDao.AutenticarUsuario(login, senha);
            return isAutenticated;
        }

        public bool RegistrarUsuario(UsuarioModel usuario, ref string msgErro)
        {
            try
            {
                UsuarioDAO usuarioDao = new UsuarioDAO();
                usuarioDao.InserirNovoUsuario(usuario);
                return true;
            }
            catch (System.Data.SqlClient.SqlException sEx)
            {
                if (sEx.Message.Contains("IX_USUARIO"))
                    msgErro = "Login existente.";

                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool AtualizarUsuario(UsuarioModel usuario, ref string msgErro)
        {
            try
            {
                UsuarioDAO usuarioDao = new UsuarioDAO();
                usuarioDao.AtualizarUsuario(usuario);
                return true;
            }
            catch (System.Data.SqlClient.SqlException sEx)
            {
                if (sEx.Message.Contains("IX_USUARIO"))
                    msgErro = "Login existente.";

                return false;
            }
            catch
            {
                return false;
            }
        }


        public bool EnviaEmailCadastroUsuario(UsuarioModel usuario)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("$LOGIN$", usuario.Login);
                parameters.Add("$SENHA$", usuario.Senha);
                parameters.Add("$NOME$", usuario.Nome);
                string body = Util.GetTemplate(@"EmailTemplates\CadastroUsuario.htm", parameters);
                Util.EnviaEmail("Cadastro InfoPonto", body, usuario.Email, Util.GetAppKey("email").ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public UsuarioModel ObterUsuarioPorLogin(string login)
        {
            try
            {
                UsuarioDAO usuarioDao = new UsuarioDAO();
                return usuarioDao.ObterUsuarioPorLogin(login);
            }
            catch
            {
                return null;
            }
        }

        public List<UsuarioModel> ObterUsuarios()
        {
            try
            {
                return new UsuarioDAO().ObterUsuarios();
            }
            catch
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using INFOPonto.MODEL;

namespace INFOPonto.DAO
{
    public class UsuarioDAO : BaseDAO
    {
        public bool AutenticarUsuario(string login, string senha)
        {
            bool isAutenticated = false;
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.AUTENTICAR_USUARIO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LOGIN", login);
                    cmd.Parameters.AddWithValue("@SENHA", senha);

                    try
                    {
                        conn.Open();
                        int estaLogado = (int)cmd.ExecuteScalar();
                        if (estaLogado > 0)
                        {
                            isAutenticated = true;
                        }
                        else
                        {
                            isAutenticated = false;
                        }

                    }
                    catch
                    {
                        throw;
                    }                    
                }
            }

            return isAutenticated;
        }

        public void InserirNovoUsuario(UsuarioModel usuario)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.INSERIR_USUARIO",conn))
                {
                    //usuario.Senha = System.Web.Security.Membership.GeneratePassword(6,0);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@ID_CARGO", usuario.Cargo.IdCargo);
                    cmd.Parameters.AddWithValue("@PERFIL", usuario.Perfil);
                    cmd.Parameters.AddWithValue("@LOGIN", usuario.Login);
                    cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);
                    cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                    cmd.Parameters.AddWithValue("@RG", usuario.Rg);
                    cmd.Parameters.AddWithValue("@CPF", usuario.Cpf);
                    cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
                    cmd.Parameters.AddWithValue("@TELEFONE", usuario.Telefone);
                    cmd.Parameters.AddWithValue("@CELULAR", usuario.Celular);
                    cmd.Parameters.AddWithValue("@LOGRADOURO", usuario.Endereco.Logradouro);
                    cmd.Parameters.AddWithValue("@NUMERO", usuario.Endereco.Numero);
                    cmd.Parameters.AddWithValue("@COMPLEMENTO", usuario.Endereco.Complemento);
                    cmd.Parameters.AddWithValue("@BAIRRO", usuario.Endereco.Bairro);
                    cmd.Parameters.AddWithValue("@CIDADE", usuario.Endereco.Cidade);
                    cmd.Parameters.AddWithValue("@ESTADO", usuario.Endereco.Estado);


                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        public void AtualizarUsuario(UsuarioModel usuario)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.ATUALIZAR_USUARIO",conn))
                {
                    //usuario.Senha = System.Web.Security.Membership.GeneratePassword(6,0);

                    cmd.CommandType = CommandType.StoredProcedure;                   

                    if (!string.IsNullOrEmpty(usuario.Senha))
                        cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);

                    cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                    cmd.Parameters.AddWithValue("@RG", usuario.Rg);
                    cmd.Parameters.AddWithValue("@CPF", usuario.Cpf);
                    cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
                    cmd.Parameters.AddWithValue("@TELEFONE", usuario.Telefone);
                    cmd.Parameters.AddWithValue("@CELULAR", usuario.Celular);
                    cmd.Parameters.AddWithValue("@LOGRADOURO", usuario.Endereco.Logradouro);
                    cmd.Parameters.AddWithValue("@NUMERO", usuario.Endereco.Numero);
                    cmd.Parameters.AddWithValue("@COMPLEMENTO", usuario.Endereco.Complemento);
                    cmd.Parameters.AddWithValue("@BAIRRO", usuario.Endereco.Bairro);
                    cmd.Parameters.AddWithValue("@CIDADE", usuario.Endereco.Cidade);
                    cmd.Parameters.AddWithValue("@ESTADO", usuario.Endereco.Estado);
                    cmd.Parameters.AddWithValue("@ID_USUARIO", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@LOGIN", usuario.Login);


                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }


        public List<UsuarioModel> ObterUsuarios()
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.OBTER_USUARIOS",conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    List<UsuarioModel> usuarios = new List<UsuarioModel>();

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        UsuarioModel usuario = new UsuarioModel();
                        usuario.IdUsuario = (int)reader["ID_USUARIO"];
                        usuario.Nome = reader["NOME"].ToString();
                        usuario.Email = reader["EMAIL"].ToString();
                        usuarios.Add(usuario);

                    }

                    reader.Close();
                    return usuarios;

                }
            }
        }

        public UsuarioModel ObterUsuarioPorLogin(string login)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.OBTER_USUARIO_POR_LOGIN",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LOGIN", login);

                    UsuarioModel usuario = new UsuarioModel();
                    usuario.Login = login;

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        usuario.IdUsuario = (int)reader["ID_USUARIO"];
                        usuario.Cargo.IdCargo = (int)reader["ID_CARGO"];
                        usuario.Perfil = (int)reader["PERFIL"];
                        usuario.Senha = reader["SENHA"].ToString();
                        usuario.Nome = reader["NOME"].ToString();
                        usuario.Rg = reader["RG"].ToString();
                        usuario.Cpf = reader["CPF"].ToString();
                        usuario.Email = reader["EMAIL"].ToString();
                        usuario.Telefone = reader["TELEFONE"].ToString();
                        usuario.Celular = reader["CELULAR"].ToString();
                        usuario.Endereco.Logradouro = reader["LOGRADOURO"].ToString();
                        usuario.Endereco.Numero = reader["NUMERO"].ToString();
                        usuario.Endereco.Complemento = reader["COMPLEMENTO"].ToString();
                        usuario.Endereco.Bairro = reader["BAIRRO"].ToString();
                        usuario.Endereco.Cidade = reader["CIDADE"].ToString();
                        usuario.Endereco.Estado = reader["ESTADO"].ToString();

                    }
                    reader.Close();
                    return usuario;
                }
            }
        }
    }
}

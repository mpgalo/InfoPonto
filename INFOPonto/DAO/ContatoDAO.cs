using System;
using System.Collections.Generic;
using System.Text;
using INFOPonto.MODEL;
using System.Data;
using System.Data.SqlClient;

namespace INFOPonto.DAO
{
    public class ContatoDAO : BaseDAO
    {
        public List<ContatoModel> ObterContatosPorFiltro(string nomeContato, int perfil)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.OBTER_CONTATOS_POR_FILTRO", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!string.IsNullOrEmpty(nomeContato))
                    {
                        cmd.Parameters.AddWithValue("@NOME", nomeContato);
                    }

                    cmd.Parameters.AddWithValue("@PERFIL", perfil);

                    List<ContatoModel> contatos = new List<ContatoModel>();

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        ContatoModel contato = new ContatoModel();
                        contato.Nome = reader["NOME"].ToString();
                        contato.Email = reader["EMAIL"].ToString();
                        contato.Telefone = reader["TELEFONE"].ToString();
                        contato.Celular = reader["CELULAR"].ToString();
                        contatos.Add(contato);

                    }

                    reader.Close();
                    return contatos;

                }
            }
        }

        public List<ContatoModel> ObterContatos()
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.OBTER_CONTATOS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    List<ContatoModel> contatos = new List<ContatoModel>();

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        ContatoModel contato = new ContatoModel();
                        contato.IdContato = (int)reader["ID_CONTATO"];
                        contato.Nome = reader["NOME"].ToString();
                        contato.Email = reader["EMAIL"].ToString();
                        contato.Telefone = reader["TELEFONE"].ToString();
                        contato.Celular = reader["CELULAR"].ToString();
                        contato.ExibirContato = (bool)reader["EXIBIR_USUARIO"];
                        contatos.Add(contato);

                    }

                    reader.Close();
                    return contatos;

                }
            }
        }

        public void InserirContato(ContatoModel contato)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("DBO.INSERIR_CONTATO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOME", contato.Nome);
                    cmd.Parameters.AddWithValue("@TELEFONE", contato.Telefone);
                    cmd.Parameters.AddWithValue("@CELULAR", contato.Celular);
                    cmd.Parameters.AddWithValue("@EMAIL", contato.Email);
                    cmd.Parameters.AddWithValue("@EXIBIR_USUARIO", contato.ExibirContato);
                    SqlParameter retornoParameter = new SqlParameter("@ID_CONTATO", SqlDbType.Int, 4, "ID_CONTATO");
                    retornoParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(retornoParameter);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        contato.IdContato = (int)retornoParameter.Value;
                    }
                    catch
                    {
                        throw;
                    }

                }
            }
        }

        public void AtualizarContato(ContatoModel contato)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("DBO.ATUALIZAR_CONTATO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_CONTATO", contato.IdContato);
                    cmd.Parameters.AddWithValue("@NOME", contato.Nome);
                    cmd.Parameters.AddWithValue("@TELEFONE", contato.Telefone);
                    cmd.Parameters.AddWithValue("@CELULAR", contato.Celular);
                    cmd.Parameters.AddWithValue("@EMAIL", contato.Email);
                    cmd.Parameters.AddWithValue("@EXIBIR_USUARIO", contato.ExibirContato);

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

        public void ExcluirContato(ContatoModel contato)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.EXCLUIR_CONTATO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_CONTATO", contato.IdContato);

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
    }
}

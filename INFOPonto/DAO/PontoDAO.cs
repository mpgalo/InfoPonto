using System;
using System.Collections.Generic;
using System.Text;
using INFOPonto.MODEL;
using System.Data;
using System.Data.SqlClient;

namespace INFOPonto.DAO
{
    class PontoDAO : BaseDAO
    {
        public void InserirPonto(PontoModel ponto)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.INSERIR_PONTO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_USUARIO", ponto.Usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@DATA_PONTO", ponto.DataPonto);
                    cmd.Parameters.AddWithValue("@HORA_INICIO", ponto.HoraInicio);

                    if (ponto.HoraFim != null)
                        cmd.Parameters.AddWithValue("@HORA_FIM", ponto.HoraFim);

                    SqlParameter retornoParameter = new SqlParameter("@ID_PONTO", SqlDbType.Int, 4, "ID_PONTO");
                    retornoParameter.Direction = System.Data.ParameterDirection.Output;

                    cmd.Parameters.Add(retornoParameter);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        ponto.IdPonto = (int)retornoParameter.Value;
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        public void ExcluirPonto(PontoModel ponto)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.EXCLUIR_PONTO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_PONTO", ponto.IdPonto);


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

        public void AtualizarPonto(PontoModel ponto)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.ATUALIZAR_PONTO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_PONTO", ponto.IdPonto);
                    cmd.Parameters.AddWithValue("@ID_USUARIO", ponto.Usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@DATA_PONTO", ponto.DataPonto);
                    cmd.Parameters.AddWithValue("@HORA_INICIO", ponto.HoraInicio);
                    cmd.Parameters.AddWithValue("@HORA_FIM", ponto.HoraFim);

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

        public void RegistrarPonto(PontoModel ponto)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.REGISTRAR_PONTO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_USUARIO", ponto.Usuario.IdUsuario);

                    SqlParameter retornoParameter = new SqlParameter("@ID_PONTO", SqlDbType.Int, 4, "ID_PONTO");
                    retornoParameter.Direction = System.Data.ParameterDirection.Output;

                    cmd.Parameters.Add(retornoParameter);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        ponto.IdPonto = (int)retornoParameter.Value;
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        public void FecharPonto(PontoModel ponto)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.FECHAR_PONTO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PONTO", ponto.IdPonto);

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

        public List<PontoModel> ObterHorasTrabalhasPorFiltro(PontoModel pPonto)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "dbo.OBTER_HORAS_TRABALHADAS_POR_FILTRO";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DATA_INICIAL", pPonto.DataPonto);
                    cmd.Parameters.AddWithValue("@DATA_FINAL", pPonto.DataPonto);
                    cmd.Parameters.AddWithValue("@ID_USUARIO", pPonto.Usuario.IdUsuario);

                    List<PontoModel> pontos = new List<PontoModel>();

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        PontoModel ponto = new PontoModel();
                        ponto.IdPonto = (int)reader["ID_PONTO"];
                        ponto.DataPonto = Convert.ToDateTime(reader["DATA_PONTO"]);
                        if (reader["HORA_INICIO"] != DBNull.Value)
                            ponto.HoraInicio = Convert.ToDateTime(reader["HORA_INICIO"]);

                        if (reader["HORA_FIM"] != DBNull.Value)
                            ponto.HoraFim = Convert.ToDateTime(reader["HORA_FIM"]);

                        ponto.Usuario.IdUsuario = (int)reader["ID_USUARIO"];
                        ponto.Usuario.Nome = reader["NOME"].ToString();

                        pontos.Add(ponto);

                    }

                    reader.Close();
                    return pontos;

                }
            }
        }

    }
}

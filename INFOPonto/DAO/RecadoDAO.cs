using System;
using System.Collections.Generic;
using System.Text;
using INFOPonto.MODEL;
using System.Data;
using System.Data.SqlClient;

namespace INFOPonto.DAO
{
    public class RecadoDAO : BaseDAO
    {
        public void InserirRecado(RecadoModel recado)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("DBO.INSERIR_RECADO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_USUARIO_REMETENTE", recado.UsuarioRemetente.IdUsuario);
                    cmd.Parameters.AddWithValue("@ASSUNTO", recado.Assunto);
                    cmd.Parameters.AddWithValue("@DESCRICAO", recado.Descricao);
                    cmd.Parameters.AddWithValue("@DATA_RECADO", recado.DataRecado);

                    SqlParameter retornoParameter = new SqlParameter("@ID_RECADO", SqlDbType.Int, 4, "ID_RECADO");
                    retornoParameter.Direction = System.Data.ParameterDirection.Output;

                    cmd.Parameters.Add(retornoParameter);

                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {                        
                        cmd.Transaction = transaction;                  
                        cmd.ExecuteNonQuery();

                        int idRecado = (int)retornoParameter.Value;

                        cmd.Parameters.Clear();
                        cmd.CommandText = "dbo.INSERIR_RECADO_DESTINATARIO";
                        cmd.Parameters.AddWithValue("@ID_RECADO", idRecado);
                        SqlParameter variableParameter = new SqlParameter();
                        variableParameter.ParameterName = "@ID_USUARIO_DESTINATARIO";
                        cmd.Parameters.Add(variableParameter);

                        foreach (UsuarioModel usuario in recado.UsuariosDestinatarios)
                        {
                            cmd.Parameters["@ID_USUARIO_DESTINATARIO"].Value = usuario.IdUsuario;
                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandText = "dbo.INSERIR_ARQUIVO_RECADO";
                        variableParameter.ParameterName = "@CAMINHO_ARQUIVO";

                        foreach (ArquivoModel arquivo in recado.Arquivos)
                        {
                            cmd.Parameters["@CAMINHO_ARQUIVO"].Value = arquivo.CaminhoArquivoServidor;
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }

                }
            }
        }

        public void LerRecado(RecadoModel recado)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.LER_RECADO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_RECADO",recado.IdRecado);
                    cmd.Parameters.AddWithValue("@ID_USUARIO_DESTINATARIO", recado.UsuariosDestinatarios[0].IdUsuario);                 

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

        public List<RecadoModel> ObterRecadosPorDestinatario(UsuarioModel usuario)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.OBTER_RECADOS_POR_DESTINATARIO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_USUARIO_DESTINATARIO", usuario.IdUsuario);

                    List<RecadoModel> recados = new List<RecadoModel>();

                    conn.Open();
                    SqlDataReader readerRecado = cmd.ExecuteReader(CommandBehavior.CloseConnection);                    
                    while (readerRecado.Read())
                    {
                        RecadoModel recado = new RecadoModel();
                        recado.IdRecado = (int)readerRecado["ID_RECADO"];
                        recado.Assunto = readerRecado["ASSUNTO"].ToString();
                        recado.Descricao = readerRecado["DESCRICAO"].ToString();
                        recado.FlLido = (bool)readerRecado["FLAG_LIDO"];

                        recado.UsuarioRemetente.Nome = readerRecado["NOME"].ToString();
                        recado.DataRecado = DateTime.Parse(readerRecado["DATA_RECADO"].ToString());

                        string arquivos = readerRecado["ARQUIVOS"].ToString();


                        if (!string.IsNullOrEmpty(arquivos))
                        {
                            foreach (string caminhoArquivo in arquivos.Split('|'))
                            {
                                if (!string.IsNullOrEmpty(caminhoArquivo))
                                {
                                    ArquivoModel arquivo = new ArquivoModel();
                                    arquivo.CaminhoArquivoServidor = caminhoArquivo;
                                    recado.Arquivos.Add(arquivo);
                                }
                            }
                        }

                        recados.Add(recado);
                    }

                    readerRecado.Close();

                    return recados;

                }
            }
        }

        public int  ObterNumeroRecadosNaoLidos(UsuarioModel usuario)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.OBTER_NUMERO_RECADOS_NAO_LIDOS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_USUARIO_DESTINATARIO", usuario.IdUsuario);                   

                    conn.Open();
                    int numeroRecadosNaoLidos = (int)cmd.ExecuteScalar();

                    return numeroRecadosNaoLidos;
                }
            }
        }
    }
}

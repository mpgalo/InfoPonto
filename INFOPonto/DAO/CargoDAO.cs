using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using INFOPonto.MODEL;

namespace INFOPonto.DAO
{
    class CargoDAO : BaseDAO
    {
        public List<CargoModel> ObterCargos()
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.OBTER_CARGOS", conn))
                {
                    List<CargoModel> cargos = new List<CargoModel>();

                    conn.Open();
                    SqlDataReader readerCargo = cmd.ExecuteReader(CommandBehavior.CloseConnection);                    
                    while (readerCargo.Read())
                    {
                        CargoModel cargo = new CargoModel((int)readerCargo["ID_CARGO"], readerCargo["NOME_CARGO"].ToString());

                        if (readerCargo["SALARIO_HORA"] != DBNull.Value)
                            cargo.SalarioHora = Convert.ToDouble(readerCargo["SALARIO_HORA"]);

                        if (readerCargo["SALARIO_MENSAL"] != DBNull.Value)
                            cargo.SalarioMes = Convert.ToDouble(readerCargo["SALARIO_MENSAL"]);

                        cargos.Add(cargo);
                    }

                    readerCargo.Close();

                    return cargos;
                }
            }
        }

        public void InserirCargo(CargoModel cargo)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.INSERIR_CARGO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NOME_CARGO", cargo.NomeCargo);

                    if (cargo.SalarioHora.HasValue)
                        cmd.Parameters.AddWithValue("@SALARIO_HORA", cargo.SalarioHora);

                    if (cargo.SalarioMes.HasValue)
                        cmd.Parameters.AddWithValue("@SALARIO_MENSAL", cargo.SalarioMes);

                    SqlParameter retornoParameter = new SqlParameter("@ID_CARGO", SqlDbType.Int, 4, "ID_CARGO");
                    retornoParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(retornoParameter);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        cargo.IdCargo = (int)retornoParameter.Value;
                    }
                    catch
                    {
                        throw;
                    }

                }
            }
        }

        public void AtualizarCargo(CargoModel cargo)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.ATUALIZAR_CARGO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_CARGO", cargo.IdCargo);
                    cmd.Parameters.AddWithValue("@NOME_CARGO", cargo.NomeCargo);

                    if (cargo.SalarioHora.HasValue)
                        cmd.Parameters.AddWithValue("@SALARIO_HORA", cargo.SalarioHora);
                  

                    if (cargo.SalarioMes.HasValue)
                        cmd.Parameters.AddWithValue("@SALARIO_MENSAL", cargo.SalarioMes);
                   

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

        public void ExcluirCargo(CargoModel cargo)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("dbo.EXCLUIR_CARGO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_CARGO", cargo.IdCargo);

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

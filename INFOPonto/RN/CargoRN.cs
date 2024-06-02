using System;
using System.Collections.Generic;
using System.Text;
using INFOPonto.MODEL;
using INFOPonto.DAO;

namespace INFOPonto.RN
{
    class CargoRN
    {
        public List<CargoModel> ObterCargos()
        {
            try
            {
                return new CargoDAO().ObterCargos();
            }
            catch
            {
                return null;
            }
        }

        public bool InserirCargo(CargoModel cargo)
        {
            try
            {
                new CargoDAO().InserirCargo(cargo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AtualizarCargo(CargoModel cargo)
        {
            try
            {

                new CargoDAO().AtualizarCargo(cargo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ExcluirCargo(CargoModel cargo, ref string erroMessage)
        {
            try
            {
                new CargoDAO().ExcluirCargo(cargo);
                return true;
            }
            catch (System.Data.SqlClient.SqlException sEx)
            {
                if (sEx.Message.Contains("FK_USUARIO_CARGO"))
                    erroMessage = "Existem usuários para este cargo.";

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using INFOPonto.DAO;
using INFOPonto.MODEL;

namespace INFOPonto.RN
{
    public class PontoRN
    {

        public bool InserirPonto(PontoModel pPonto)
        {
            try
            {
                PontoDAO pontoDao = new PontoDAO();
                pontoDao.InserirPonto(pPonto);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AtualizarPonto(PontoModel pPonto)
        {
            try
            {
                PontoDAO pontoDao = new PontoDAO();
                pontoDao.AtualizarPonto(pPonto);
                return true;
            }
            catch
            {
                return false;
            }
        }   



        public bool RegistrarPonto(PontoModel pPonto)
        {
            try
            {
                PontoDAO pontoDao = new PontoDAO();
                pontoDao.RegistrarPonto(pPonto);
                return true;
            }
            catch
            {
                return false;
            }
        }       


        public bool FecharPonto(PontoModel pPonto)
        {
            try
            {
                PontoDAO pontoDao = new PontoDAO();
                pontoDao.FecharPonto(pPonto);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<PontoModel> ObterHorasTrabalhasPorFiltro(PontoModel pPonto)
        {
            try
            {
                return new PontoDAO().ObterHorasTrabalhasPorFiltro(pPonto);
            }
            catch
            {
                return null;
            }
        }

        public bool ExcluirPonto(PontoModel ponto)
        {
            try
            {
                new PontoDAO().ExcluirPonto(ponto);
                return true;
            }            
            catch
            {
                return false;
            }
        }          
    }
}


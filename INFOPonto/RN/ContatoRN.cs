using System;
using System.Collections.Generic;
using System.Text;
using INFOPonto.MODEL;
using INFOPonto.DAO;

namespace INFOPonto.RN
{
    public class ContatoRN
    {
        public List<ContatoModel> ObterContatosPorFiltro(string nomeContato, int perfil)
        {
            try
            {
                return new ContatoDAO().ObterContatosPorFiltro(nomeContato, perfil);
            }
            catch
            {
                return null;
            }
        }

        public List<ContatoModel> ObterContatos(int perfil)
        {
            try
            {
                return new ContatoDAO().ObterContatosPorFiltro(null, perfil);
            }
            catch
            {
                return null;
            }
        }

        public List<ContatoModel> ObterContatos()
        {
            try
            {
                return new ContatoDAO().ObterContatos();
            }
            catch
            {
                return null;
            }
        }

        public bool InserirContato(ContatoModel contato)
        {
            try
            {
                new ContatoDAO().InserirContato(contato);                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AtualizarContato(ContatoModel contato)
        {
            try
            {
                new ContatoDAO().AtualizarContato(contato);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ExcluirContato(ContatoModel contato)
        {
            try
            {
                new ContatoDAO().ExcluirContato(contato);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

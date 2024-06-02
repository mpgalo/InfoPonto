using System;
using System.Collections.Generic;
using System.Text;

namespace INFOPonto.MODEL
{
    public class PontoModel
    {
        public PontoModel()
        {
            _usuario = new UsuarioModel();
        }

        private int _idPonto;

        public int IdPonto
        {
            get { return _idPonto; }
            set { _idPonto = value; }
        }
        private DateTime _dataPonto;

        public DateTime DataPonto
        {
            get { return _dataPonto; }
            set { _dataPonto = value; }
        }
        private UsuarioModel _usuario;

        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        private DateTime? _horaInicio;

        public DateTime? HoraInicio
        {
            get { return _horaInicio; }
            set { _horaInicio = value; }
        }
        private DateTime? _horaFim;

        public DateTime? HoraFim
        {
            get { return _horaFim; }
            set { _horaFim = value; }
        }

        public TimeSpan? TotalPonto
        {
            get
            {
                if (HoraFim.HasValue && HoraInicio.HasValue)
                    return _horaFim.Value.Subtract(Convert.ToDateTime(_horaInicio));
                else
                    return null;
            }
        }
    }
}

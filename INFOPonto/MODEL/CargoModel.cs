using System;
using System.Collections.Generic;
using System.Text;

namespace INFOPonto.MODEL
{
    public class CargoModel
    {
        public CargoModel(int idCargo, string nomeCargo)
        {
            this._idCargo = idCargo;
            this._nomeCargo = nomeCargo;

        }       

        public CargoModel()
        {
        }

        private int _idCargo;

        public int IdCargo
        {
            get { return _idCargo; }
            set { _idCargo = value; }
        }
        private string _nomeCargo;

        public string NomeCargo
        {
            get { return _nomeCargo; }
            set { _nomeCargo = value; }
        }
        private double? _salarioHora;

        public double? SalarioHora
        {
            get { return _salarioHora; }
            set { _salarioHora = value; }
        }
        private double? _salarioMes;

        public double? SalarioMes
        {
            get { return _salarioMes; }
            set { _salarioMes = value; }
        }
    }      
}

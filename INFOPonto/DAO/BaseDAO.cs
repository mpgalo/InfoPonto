using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace INFOPonto.DAO
{
    public class BaseDAO
    {
        private Properties.Settings _settings;


        public BaseDAO()
        {
            this._settings = new INFOPonto.Properties.Settings();
        }

        protected SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(_settings.connectionstring);   
            return conn;
        }

    }
}

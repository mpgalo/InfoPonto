using System;
using System.Collections.Generic;
using System.Text;


namespace INFOPonto.Rede
{
    public static class NetworkHelper
    {
        public static bool mapearUnidadeRede(string login, string senha, string caminhoRede)
        {
            bool mapeado;
            NetworkDrive oNetDrive = new NetworkDrive();
            try
            {
                //set propertys
                oNetDrive.Force = true;
                oNetDrive.Persistent = true;
                oNetDrive.LocalDrive = "Z:";
                oNetDrive.PromptForCredentials = false;
                oNetDrive.ShareName = caminhoRede;
                oNetDrive.SaveCredentials = true;
                oNetDrive.MapDrive(login, senha);
                mapeado = true;
            }
            catch
            {
                mapeado = false;
            }

            oNetDrive = null;
            return mapeado;
        }
    }
}

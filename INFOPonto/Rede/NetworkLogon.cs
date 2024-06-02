using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace INFOPonto.Rede
{
    public class NetworkLogon
    {
        const int LOGON32_LOGON_INTERACTIVE = 2;

        const int LOGON32_LOGON_NETWORK = 3;

        const int LOGON32_LOGON_BATCH = 4;

        const int LOGON32_LOGON_SERVICE = 5;

        const int LOGON32_LOGON_UNLOCK = 7;

        const int LOGON32_LOGON_NETWORK_CLEARTEXT = 8;

        const int LOGON32_LOGON_NEW_CREDENTIALS = 9;

        const int LOGON32_PROVIDER_DEFAULT = 0;

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);

        public bool Login(string Username, string Password, string Domain)
        {

            IntPtr token = IntPtr.Zero;

            if (LogonUser(Username, Domain, Password, LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_DEFAULT, out token))
            {

                return true;

            }

            else
            {

                return false;

            }
        }
    }
}

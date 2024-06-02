using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace INFOPonto
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Mutex mu = null;
            try
            {
                mu = Mutex.OpenExisting("RUNMEONCE");
            }
            catch (WaitHandleCannotBeOpenedException)
            {
            }
            if (mu == null)
            {
                mu = new Mutex(true, "RUNMEONCE");
            }
            else
            {
                mu.Close();
                return;
            } 

            Application.EnableVisualStyles();  
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Administrativo.Cadastros.Contato());

            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
                Application.Run(new MDIPrincipal());

        }
    }
}
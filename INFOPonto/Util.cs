using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using INFOPonto.MODEL;
using System.Runtime.InteropServices;
using System.Reflection;

namespace INFOPonto
{
    public class Util
    {
        private static UsuarioModel usuarioLogado;

        public static UsuarioModel UsuarioLogado
        {
            get { return Util.usuarioLogado; }
            set { Util.usuarioLogado = value; }
        }


        public static string GetHourFromSeconds(int seconds)
        {
            double hour = Math.Truncate(Convert.ToDouble(seconds / 3600));
            double minutes = Math.Truncate(Convert.ToDouble((seconds % 3600) / 60));
            double segundos = Math.Truncate(Convert.ToDouble((seconds % 3600) % 60));

            string strHour = hour <= 9 ? "0" + hour.ToString() : hour.ToString();
            string strMinutes = minutes <= 9 ? "0" + minutes.ToString() : minutes.ToString();
            string strSeconds = segundos <= 9 ? "0" + segundos.ToString() : segundos.ToString();

            return strHour + ":" + strMinutes + ":" + strSeconds;

        }

        public static void BindList(ListControl listControl, object dataSource, string valueField, string textField,bool includeSelect)
        {
            listControl.DataSource = dataSource;
            listControl.DisplayMember = textField;
            listControl.ValueMember = valueField;

            if (includeSelect)
                listControl.Text = "-- Selecione --";
        }

        public static void BindToolStripDropDown<T>(ToolStripComboBox toolStripComboBox, List<T> dataSource, bool includeSelect)
        {
            foreach (T item in dataSource)
            {
                toolStripComboBox.Items.Add(item.ToString());
            }

            if (includeSelect)
                toolStripComboBox.Text = "-- Selecione --";
        }

       

        public static void ShowInMdi(Form mdiForm, Form formToShow)
        {
            formToShow.MdiParent = mdiForm;
            formToShow.Show();
        }

        public static void ShowInMdi(Form mdiForm, Form formToShow, bool isMaximized)
        {
            formToShow.MdiParent = mdiForm;
            if (isMaximized)
                formToShow.WindowState = FormWindowState.Maximized;
            formToShow.Show();
        }

        public static void BindAutoComplete<T>(ToolStripTextBox textBox,List<T> dataSource, string valueField)
        {
            AutoCompleteStringCollection listaNomes = new AutoCompleteStringCollection();
            foreach(T item in dataSource)
            {
                Type type = item.GetType();
                PropertyInfo propertyValue = type.GetProperty(valueField);
                listaNomes.Add(propertyValue.GetValue(item, null).ToString());

            }

            textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox.AutoCompleteCustomSource = listaNomes;
        }      
      


        public static void ClearControls(Control.ControlCollection controls)
        {


            foreach (Control control in controls)
            {
                if (control is ContainerControl || control is GroupBox)
                    Util.ClearControls(control.Controls);

                if (control is TextBoxBase)
                    ((TextBoxBase)control).Text = string.Empty;

                if (control is ComboBox)
                    control.Text = "-- Selecione --";

                if (control is CheckedListBox)
                    ((CheckedListBox)control).ClearSelected();

                if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                
            }
        }

        public static void ClearControls(params Control[] controls)
        {
            foreach (Control control in controls)
            {

                if (control is TextBoxBase)
                    ((TextBoxBase)control).Text = string.Empty;

                if (control is ComboBox)
                    control.Text = "-- Selecione --";

                if (control is CheckedListBox)
                    ((CheckedListBox)control).ClearSelected();

                if (control is CheckBox)
                    ((CheckBox)control).Checked = false;

            }
        }


        public static string GetTemplate(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    path = System.AppDomain.CurrentDomain.BaseDirectory + path;
                }

                return File.ReadAllText(path);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Ativa ou desativa comboboxes de acordo com a quantidade de itens inseridos.
        /// Se não houver valores além do default "-- Selecione --", o campo fica desabilitado.
        /// </summary>
        /// <param name="comboBoxes"></param>
        public static void UpdateCombos(params ComboBox[] comboBoxes)
        {
            foreach (ComboBox combo in comboBoxes)
            {
                combo.Enabled = combo.Items.Count > 1;
            }
        }

        public static void LimparCombos(params ComboBox[] comboBoxes)
        {
            foreach (ComboBox combo in comboBoxes)
            {
                combo.Items.Clear();
                combo.Text = "-- Selecione --";
            }
        }



        public static string GetTemplate(string path, Dictionary<string, string> templateParameters)
        {

            try
            {
                if (!File.Exists(path))
                {
                    path = System.AppDomain.CurrentDomain.BaseDirectory + path;
                }

                StringBuilder sbBody = new StringBuilder(File.ReadAllText(path, Encoding.GetEncoding("iso-8859-1")));

                foreach (KeyValuePair<string, string> item in templateParameters)
                {
                    sbBody.Replace(item.Key, item.Value);
                }

                return sbBody.ToString(); ;
            }
            catch
            {
                return null;
            }
        }

        public static void EnviaEmail(string subject, string body, string to, string cc)
        {
            Properties.Settings settings = new Properties.Settings();
            using (System.Net.Mail.MailMessage objEmail = new System.Net.Mail.MailMessage())
            {
                objEmail.From = new System.Net.Mail.MailAddress(settings.email);
                objEmail.To.Add(to);

                if (!string.IsNullOrEmpty(cc))
                    objEmail.CC.Add(cc);

                objEmail.Priority = System.Net.Mail.MailPriority.Normal;
                objEmail.IsBodyHtml = true;
                objEmail.Subject = subject.Trim();
                objEmail.Body = body.Trim();

                System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

                objSmtp.Host = settings.smtp;
                objSmtp.Credentials = new System.Net.NetworkCredential(settings.loginSmtp, settings.senhaSmtp);
                objSmtp.Port = settings.porta;
                objSmtp.EnableSsl = settings.enableSsl;

                try
                {
                    objSmtp.Send(objEmail);
                }
                catch
                {
                    throw new Exception("Falha ao enviar Email. Favor tente novamente.");
                }

            }
        }

        public static object GetAppKey(string key)
        {
            Properties.Settings settings = new Properties.Settings();
            return settings[key];
        }

        public static void EnviaEmail(string subject, string body, string to)
        {
            Util.EnviaEmail(subject, body, to, null);
        }

        public static bool ValidateEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[a-zA-Z0-9]{1}([\._a-zA-Z0-9-]+)(\.[_a-zA-Z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+){1,3}$"))
                return true;
            else
                return false;

        }

        
        [DllImport("user32.dll")]
        public static extern void LockWorkStation();

    }


}

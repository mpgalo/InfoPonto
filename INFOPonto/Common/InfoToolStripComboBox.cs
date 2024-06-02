using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Reflection;

namespace INFOPonto.Common
{
    public class InfoToolStripComboBox : System.Windows.Forms.ToolStripComboBox
    {
        public InfoToolStripComboBox()
        {
            this.TextChanged += new EventHandler(InfoCombo_TextChanged);
            this.Text = "-- Selecione --";

        }

        private void InfoCombo_TextChanged(object sender, EventArgs e)
        {
            base.Text = "-- Selecione --";
        }

        public void BindToolStripDropDown<T>(List<T> dataSource, string valueField, string textField, bool includeSelect)
        {

            //PropertyInfo propertyValue = 

            foreach (T item in dataSource)
            {
                Type type = item.GetType();
                PropertyInfo propertyValue = type.GetProperty(valueField);
                PropertyInfo propertyText = type.GetProperty(textField);                

                this.Items.Add(propertyValue.GetValue(item, null).ToString() + "-" + propertyText.GetValue(item, null).ToString());
            }


            if (includeSelect)
                this.Text = "-- Selecione --";
        }

        public object SelectedValue
        {
            get
            {
                if (this.SelectedIndex > -1)
                {
                    return this.SelectedText.Substring(0, this.SelectedText.IndexOf("-"));
                }
                else
                {
                    return "";
                }
            }
        }

    }
}

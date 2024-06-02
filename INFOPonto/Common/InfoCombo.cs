using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace INFOPonto.Common
{
    public class InfoCombo : System.Windows.Forms.ComboBox
    {
        public InfoCombo()
        {
            this.TextChanged += new EventHandler(InfoCombo_TextChanged);
            this.Text = "-- Selecione --";
        }      

        private void InfoCombo_TextChanged(object sender, EventArgs e)
        {
            base.Text = "-- Selecione --";
        }
    }
}

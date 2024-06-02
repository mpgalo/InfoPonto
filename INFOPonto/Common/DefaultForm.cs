using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;

namespace INFOPonto.Common
{
    public class DefaultForm:Form
    {
        public DefaultForm()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIPrincipal));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            
        }

      

        

    }

     
}

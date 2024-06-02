using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace INFOPonto.Common
{
    public class NumericTextBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != ',')
                {
                    e.Handled = true;
                }
                else
                {
                    if (this.Text.Contains(","))
                    {
                        e.Handled = true;
                    }
                }
            }


            base.OnKeyPress(e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwoLab.Model;

namespace TwoLab.View
{
    public partial class AddFabrica : Form
    {
       public Fabrica fabrica { get; set; }

        public AddFabrica()
        {
            InitializeComponent();
            TextBox[] textBoxes = { textBoxName, textBoxCW, textBoxCWH, textBoxWM, textBoxWW };
            textBoxCW.KeyPress += CW_KeyPress;
            textBoxCWH.KeyPress += CWH_KeyPress;
            textBoxWM.KeyPress += TextBoxWM_KeyPress;
            textBoxWW.KeyPress += TextBoxWW_KeyPress;
        }

        private void TextBoxWW_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void TextBoxWM_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void CWH_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void CW_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            TextBox[] textBoxes = { textBoxName, textBoxCW, textBoxCWH, textBoxWM, textBoxWW };
            if (textBoxes.All(tb => !string.IsNullOrWhiteSpace(tb.Text)))
            {
                fabrica = new Fabrica().SetNameCompany(textBoxName.Text)
                    .SetCountWorking(Convert.ToUInt32(textBoxCW.Text))
                    .SetCountWorkShop(Convert.ToUInt32(textBoxCWH.Text))
                    .SetCountWagesWorking(Convert.ToDecimal(textBoxWW.Text))
                    .SetCountWagesMaster(Convert.ToDecimal(textBoxWM.Text));
                fabrica.CountMasterMethod();
                fabrica.TotalSumSet();
                fabrica.SetWageOfMouthW();
                fabrica.SetWageOfMouthM();
                fabrica.SetContribution(5000);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorExt2fs
{
    public class Class1
    {

        private bool checkValidation() {

            if (dimParTextBox.Text != "" && Convert.ToString(dataBlockCombo.SelectedItem) != "" && dimInodeTextBox.Text != ""
                && blockIndexTextBox.Text != "" && Convert.ToString(indrNumComboBox.SelectedItem) != "" &&
                (KBRadioButton.Checked || MBRadioButton.Checked)) {
                return true;
            }

            return false;

        }

    }
}

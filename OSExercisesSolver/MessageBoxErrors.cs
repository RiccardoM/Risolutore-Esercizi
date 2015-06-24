using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSExercisesSolver;

namespace CheckErrors {
    
    class Validator {

        // Controlla che siano inseriti tutti i dati negli esercizi Ext2fs
        public bool checkValidationExt2( string dimParTextBox, string dataBlockCombo, string dimInodeTextBox, string blockIndexTextBox, string indrNumComboBox,
                                         bool KBRadioButton, bool MBRadioButton) {

            if ( dimParTextBox != "" && dimParTextBox != "0" && dataBlockCombo != "" && dimInodeTextBox != "" && dimInodeTextBox != "0" &&
                 blockIndexTextBox != "" && blockIndexTextBox != "0" && indrNumComboBox != "" && (KBRadioButton || MBRadioButton)) {
                
                return true;
            
            }

            MessageBox.Show("Controlla di aver inserito correttamente tutti i dati", "Errore");
            return false;

        }


        // Controlla che siano inseriti tutti i dati negli esercizi Fat
        public bool checkValidationFat( string dimParTextBoxFat, string dataBlockComboFat, string dimFileTextBoxFat, bool BRadioButtonFat,
                                        bool KBRadioButtonFat, bool MBRadioButtonFat, bool GBRadioButtonFat ) {

            if( dimParTextBoxFat != "" && dimParTextBoxFat != "0" && dataBlockComboFat != "" && dataBlockComboFat != "0" &&  dimFileTextBoxFat != "" &&
                (BRadioButtonFat || KBRadioButtonFat || MBRadioButtonFat || GBRadioButtonFat) ){
                    
                    return true;

                }

            MessageBox.Show("Controlla di aver inserito correttamente tutti i dati", "Errore");
            return false;

        }

        // Controlla che siano inseriti tutti i dati negli esercizi NTFS
        public bool checkValidationNTFS(string dimParTextBoxNTFS, string dataBlockComboNTFS, string dimFileTextBoxNTFS, bool BRadioButtonNTFS, bool KBRadioButtonNTFS,
                                        bool MBRadioButtonNTFS, bool GBRadioButtonNTFS, string dimRecordTextBox, string reservedBytePrinNTFS, string reservedByteSecNTFS) {

            if (dimParTextBoxNTFS != "" && dimParTextBoxNTFS != "0" && dataBlockComboNTFS != "" && dataBlockComboNTFS != "0" && dimFileTextBoxNTFS != "" &&
                (BRadioButtonNTFS || KBRadioButtonNTFS || MBRadioButtonNTFS || GBRadioButtonNTFS) && dimRecordTextBox != "" && dimRecordTextBox!="0" && 
                reservedBytePrinNTFS!="" && reservedBytePrinNTFS!="0" && reservedByteSecNTFS!="" && reservedByteSecNTFS!="0") {

                return true;

            }

            MessageBox.Show("Controlla di aver inserito correttamente tutti i dati", "Errore");
            return false;

        }

    }


}


﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolveExercises;
using System.Net;
using CheckErrors;

namespace OSExercisesSolver {

        public partial class Risolutore : Form {
            
            
            public Risolutore() {
                InitializeComponent();
            }

            

            // ###################################################################
            // ###################      VISIONE DEI MENU       ###################
            // ###################################################################

            // Mostra pannello esercizi Ext2fs alla pressione del correlato bottone nel menu
            private void ext2fsToolStripMenuItem_Click(object sender, EventArgs e) {
                
                pannelloExt2fs.Visible = true;
                pannelloFAT.Visible = false;
                pannelloNTFS.Visible = false;

            }

            private void FATToolStripMenuItem_Click(object sender, EventArgs e){

                pannelloExt2fs.Visible = true;
                pannelloNTFS.Visible = false;
                pannelloFAT.Visible = true;

            }

            private void nTFSToolStripMenuItem_Click(object sender, EventArgs e) {
                pannelloExt2fs.Visible = true;
                pannelloFAT.Visible = true;
                pannelloNTFS.Visible = true;

            }

            private void homeToolStripMenuItem_Click(object sender, EventArgs e) {
                pannelloExt2fs.Visible = false;
                pannelloFAT.Visible = false;
            }

            Validator validate = new Validator();



            // ####################################################################
            // ###############      PERMESSI INSERIMENTO DATI       ############### 
            // ####################################################################

            // Lascia inserire solo numeri nel textbox della dimensione di partizione
            private void dimPar_KeyPress(object sender, KeyPressEventArgs e) {
                e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
            }

            // Lascia inserire solo numeri nel textbox della dimensione dell'i-node
            private void dimInodeTextBox_KeyPress(object sender, KeyPressEventArgs e) {
                e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
            }

            // Lascia inserire solo numeri nel textbox della dimensione di partizione
            private void dimParTextBoxFat_KeyPress(object sender, KeyPressEventArgs e) {
                e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
            }

            private void reservedByteSecNTFS_KeyPress(object sender, KeyPressEventArgs e) {
                e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
            }

            private void reservedBytePrinNTFS_KeyPress(object sender, KeyPressEventArgs e) {
                e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
            }

            private void recordDimTextBox_KeyPress(object sender, KeyPressEventArgs e) {
                e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
            }

            private void parDimNTFS_KeyPress(object sender, KeyPressEventArgs e) {
                e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
            }

            private void FileDimNTFS_KeyPress(object sender, KeyPressEventArgs e) {
                e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
            }

            

            // ####################################################################
            // ###################      ESERCIZIO EXT2FS        ###################
            // ####################################################################

            // ####################################
            // #######  Genera dati random  #######
            // ####################################
            
            public void randGenButton_Click(object sender, EventArgs e) {

                // Genero dimensione partizione
                Random rand = new Random();
                dimParTextBox.Text = Math.Pow(2, rand.Next(5, 10)).ToString();

                // Genero dimensione blocco dati
                dataBlockCombo.SelectedIndex = rand.Next(0, 3);

                // Genero dimensione i-node
                int potInode = rand.Next(0, 17);

                // Se supero 2^9 KB allora saranno MB
                if (potInode > 9) {
                    dimInodeTextBox.Text = (Math.Pow(2, (potInode - 10))).ToString();
                    MBRadioButton.Checked = true;
                }

                // Se sono 2^9 KB o meno allora saranno KB
                else {
                    dimInodeTextBox.Text = Math.Pow(2, potInode).ToString();
                    KBRadioButton.Checked = true;
                }

                // Genero numero di indici di blocco i-node principale
                blockIndexTextBox.Text = rand.Next(10, 13).ToString();

                // Genero numero di indirezioni
                indrNumComboBox.SelectedIndex = rand.Next(0, 4);
            }


            // ####################################
            // ############  Risolvi   ############
            // ####################################
            public void solveButton_Click(object sender, EventArgs e) {

                //Controlla che siano inseriti tutti i dati
                try {
                    bool valid = validate.checkValidationExt2(dimParTextBox.Text, dataBlockCombo.SelectedItem.ToString(), dimInodeTextBox.Text, blockIndexTextBox.Text,
                                                               indrNumComboBox.SelectedItem.ToString(), KBRadioButton.Checked, MBRadioButton.Checked);
                
                    // Se valido risolvi
                    if (valid) {

                        string selected;

                        if(KBRadioButton.Checked){
                            selected = "KB";
                        }

                        else{
                            selected = "MB";
                        }

                        SolveExt2fs SExt2fs = new SolveExt2fs();

                        SExt2fs.Solve( Convert.ToInt32(dimParTextBox.Text), Convert.ToInt32(dataBlockCombo.SelectedItem), Convert.ToInt32(dimInodeTextBox.Text), selected,
                                       Convert.ToInt32(blockIndexTextBox.Text), Convert.ToInt32(indrNumComboBox.SelectedItem) );

                    }

                }

                catch (NullReferenceException) {
                    MessageBox.Show("Controlla di aver inserito correttamente tutti i dati", "Errore");
                }


            }



            // ####################################################################
            // #####################      ESERCIZIO FAT        ####################
            // ####################################################################

            // ####################################
            // #######  Genera dati random  #######
            // ####################################

            private void randGenFatButton_Click(object sender, EventArgs e) {

                // Genero dimensione partizione
                Random rand = new Random();
                dimParTextBoxFat.Text = Math.Pow(2, rand.Next(5, 10)).ToString();

                // Genero dimensione blocco dati
                dataBlockComboFat.SelectedIndex = rand.Next(0, 3);


                int potFile = rand.Next(0, 39);


                if (potFile < 10) {
                    dimFileTextBoxFat.Text = (Math.Pow(2, potFile)).ToString();
                    BRadioButtonFat.Checked = true;
                }

                else if (potFile > 10 && potFile < 20) {
                    dimFileTextBoxFat.Text = (Math.Pow(2, (potFile - 10))).ToString();
                    KBRadioButtonFat.Checked = true;

                }

                else if(potFile > 20 && potFile < 30){
                    dimFileTextBoxFat.Text = (Math.Pow(2, (potFile - 20))).ToString();
                    MBRadioButtonFat.Checked = true;
                }

                else if(potFile > 30){
                    dimFileTextBoxFat.Text = (Math.Pow(2, (potFile - 30))).ToString();
                    GBRadioButtonFat.Checked = true;
                }

            }


            // ####################################
            // #####  Preleva dati da Ext2fs  #####
            // ####################################

            private void dataTakeButtonFat_Click(object sender, EventArgs e) {

                try {
                    dimParTextBoxFat.Text = dimParTextBox.Text;
                    dataBlockComboFat.SelectedItem = dataBlockCombo.SelectedItem;
                    

                    SolveExt2fs SolveExt = new SolveExt2fs();
                    string selected;

                    if (KBRadioButton.Checked) {
                        selected = "KB";
                    }

                    else {
                        selected = "MB";
                    }

                    dimFileTextBoxFat.Text = SolveExt.MaxFileDimExt2fs(Convert.ToInt32(dimParTextBox.Text), Convert.ToInt32(dataBlockCombo.SelectedItem),
                                                                        Convert.ToInt32(dimInodeTextBox.Text), selected, Convert.ToInt32(blockIndexTextBox.Text),
                                                                        Convert.ToInt32(indrNumComboBox.SelectedItem)).ToString();

                    BRadioButtonFat.Checked = true;
                }

                catch (FormatException) {
                    MessageBox.Show("Controlla di aver inserito correttamente tutti i dati nel pannello Ext2fs", "Errore");
                }
               
            }


            // ####################################
            // ############  Risolvi   ############
            // ####################################

            public void solveButtonFat_Click(object sender, EventArgs e) {

                try {

                    //Controlla che siano inseriti tutti i dati
                    bool validFat = validate.checkValidationFat(dimParTextBoxFat.Text, dataBlockComboFat.SelectedItem.ToString(), dimFileTextBoxFat.Text, BRadioButtonFat.Checked,
                                                                  KBRadioButtonFat.Checked, MBRadioButtonFat.Checked, GBRadioButtonFat.Checked);


                    // Se valido risolvi
                    if (validFat) {

                        string selected = "";

                        if (BRadioButtonFat.Checked) {
                            selected = "B";
                        }

                        else if (KBRadioButtonFat.Checked) {
                            selected = "KB";
                        }

                        else if (MBRadioButtonFat.Checked) {
                            selected = "MB";
                        }

                        else if (GBRadioButtonFat.Checked) {
                            selected = "GB";
                        }

                        SolveFat SFat = new SolveFat();

                        SFat.Solve(Convert.ToInt32(dimParTextBoxFat.Text), Convert.ToInt32(dataBlockComboFat.SelectedItem), Convert.ToDouble(dimFileTextBoxFat.Text), selected);

                    }

                }

                catch (NullReferenceException) {
                    MessageBox.Show("Controlla di aver inserito correttamente tutti i dati", "Errore");
                }

            }

            



            // ####################################################################
            // ####################      ESERCIZIO NTFS        ####################
            // ####################################################################

            // ####################################
            // #######  Genera dati random  #######
            // ####################################

            private void randGenButtonNTFS_Click(object sender, EventArgs e) {
                
                // Genero dimensione partizione
                Random rand = new Random();
                dimParTextBoxNTFS.Text = Math.Pow(2, rand.Next(5, 10)).ToString();

                // Genero dimensione blocco dati
                dataBlockComboNTFS.SelectedIndex = rand.Next(0, 3);


                int potFile = rand.Next(0, 39);


                if (potFile < 10) {
                    dimFileTextBoxNTFS.Text = (Math.Pow(2, potFile)).ToString();
                    BRadioButtonNTFS.Checked = true;
                }

                else if (potFile > 10 && potFile < 20) {
                    dimFileTextBoxNTFS.Text = (Math.Pow(2, (potFile - 10))).ToString();
                    KBRadioButtonNTFS.Checked = true;

                }

                else if (potFile > 20 && potFile < 30) {
                    dimFileTextBoxNTFS.Text = (Math.Pow(2, (potFile - 20))).ToString();
                    MBRadioButtonNTFS.Checked = true;
                }

                else if (potFile > 30) {
                    dimFileTextBoxNTFS.Text = (Math.Pow(2, (potFile - 30))).ToString();
                    GBRadioButtonNTFS.Checked = true;
                }

                //Genero dimensione record
                dimRecordTextBox.Text = Math.Pow(2, rand.Next(6, 10)).ToString();

                //Calcolo spazio record principale
                switch (dimRecordTextBox.Text) {
                    case "64":
                        reservedBytePrinNTFS.Text = "28";
                        reservedByteSecNTFS.Text = "40";
                        break;

                    case "128":
                        reservedBytePrinNTFS.Text = "58";
                        reservedByteSecNTFS.Text = "100";
                        break;

                    case "256":
                        reservedBytePrinNTFS.Text = "128";
                        reservedByteSecNTFS.Text = "240";
                        break;

                    case "512":
                        reservedBytePrinNTFS.Text = "208";
                        reservedByteSecNTFS.Text = "400";
                        break;

                    case "1024":
                        reservedBytePrinNTFS.Text = "458";
                        reservedByteSecNTFS.Text = "900";
                        break;
                }

            }

            // ####################################
            // #####  Preleva dati da Ext2fs  #####
            // ####################################

            private void dataTakeButtonNTFS_Click(object sender, EventArgs e) {

                try {
                    dimParTextBoxNTFS.Text = dimParTextBox.Text;
                    dataBlockComboNTFS.SelectedItem = dataBlockCombo.SelectedItem;
                    
                    SolveExt2fs SolveExt = new SolveExt2fs();
                    string selected;

                    if (KBRadioButton.Checked) {
                        selected = "KB";
                    }

                    else {
                        selected = "MB";
                    }

                    dimFileTextBoxNTFS.Text = SolveExt.MaxFileDimExt2fs(Convert.ToInt32(dimParTextBox.Text), Convert.ToInt32(dataBlockCombo.SelectedItem),
                                                                        Convert.ToInt32(dimInodeTextBox.Text), selected, Convert.ToInt32(blockIndexTextBox.Text),
                                                                        Convert.ToInt32(indrNumComboBox.SelectedItem)).ToString();

                    BRadioButtonNTFS.Checked = true;
                }

                catch (FormatException) {
                    MessageBox.Show("Controlla di aver inserito correttamente tutti i dati nel pannello Ext2fs", "Errore");
                }
            }


            // ####################################
            // ############  Risolvi   ############
            // ####################################

            private void solveButtonNTFS_Click(object sender, EventArgs e) {

                try {
                    //Controlla che siano inseriti tutti i dati
                    bool validNTFS = validate.checkValidationNTFS(dimParTextBoxNTFS.Text, dataBlockComboNTFS.SelectedItem.ToString(), dimFileTextBoxNTFS.Text, BRadioButtonNTFS.Checked,
                                                                  KBRadioButtonNTFS.Checked, MBRadioButtonNTFS.Checked, GBRadioButtonNTFS.Checked, dimRecordTextBox.Text,
                                                                  reservedBytePrinNTFS.Text, reservedByteSecNTFS.Text);


                    // Se valido risolvi
                    if (validNTFS) {

                        string selected = "";

                        if (BRadioButtonNTFS.Checked) {
                            selected = "B";
                        }

                        else if (KBRadioButtonNTFS.Checked) {
                            selected = "KB";
                        }

                        else if (MBRadioButtonNTFS.Checked) {
                            selected = "MB";
                        }

                        else if (GBRadioButtonNTFS.Checked) {
                            selected = "GB";
                        }

                        SolveNTFS SNTFS = new SolveNTFS();

                        SNTFS.Solve(Convert.ToInt32(dimParTextBoxNTFS.Text), Convert.ToInt32(dataBlockComboNTFS.SelectedItem), Convert.ToDouble(dimFileTextBoxNTFS.Text), selected,
                                    Convert.ToInt32(dimRecordTextBox.Text), Convert.ToInt32(reservedBytePrinNTFS.Text), Convert.ToInt32(reservedByteSecNTFS.Text));

                    }

                }

                catch (NullReferenceException nullExep) {
                    MessageBox.Show("Controlla di aver inserito correttamente tutti i dati", "Errore");
                }

            }

            
            


            


            



            

        }


}

namespace OSExercisesSolver {
    partial class FAT {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dataBlockCombo = new System.Windows.Forms.ComboBox();
            this.labelKB = new System.Windows.Forms.Label();
            this.labelDataBlock = new System.Windows.Forms.Label();
            this.dimParTextBoxFat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelGB = new System.Windows.Forms.Label();
            this.labelInDimPar = new System.Windows.Forms.Label();
            this.randGenButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.solveButton = new System.Windows.Forms.Button();
            this.dataTakeButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dataBlockCombo
            // 
            this.dataBlockCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataBlockCombo.FormattingEnabled = true;
            this.dataBlockCombo.Items.AddRange(new object[] {
            "1",
            "2",
            "4"});
            this.dataBlockCombo.Location = new System.Drawing.Point(220, 89);
            this.dataBlockCombo.MaxLength = 1;
            this.dataBlockCombo.Name = "dataBlockCombo";
            this.dataBlockCombo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataBlockCombo.Size = new System.Drawing.Size(40, 21);
            this.dataBlockCombo.TabIndex = 33;
            // 
            // labelKB
            // 
            this.labelKB.AutoSize = true;
            this.labelKB.Location = new System.Drawing.Point(266, 92);
            this.labelKB.Name = "labelKB";
            this.labelKB.Size = new System.Drawing.Size(21, 13);
            this.labelKB.TabIndex = 32;
            this.labelKB.Text = "KB";
            // 
            // labelDataBlock
            // 
            this.labelDataBlock.AutoSize = true;
            this.labelDataBlock.Location = new System.Drawing.Point(23, 92);
            this.labelDataBlock.Name = "labelDataBlock";
            this.labelDataBlock.Size = new System.Drawing.Size(110, 13);
            this.labelDataBlock.TabIndex = 31;
            this.labelDataBlock.Text = "Ampiezza blocco dati:";
            // 
            // dimParTextBoxFat
            // 
            this.dimParTextBoxFat.Location = new System.Drawing.Point(220, 54);
            this.dimParTextBoxFat.MaxLength = 3;
            this.dimParTextBoxFat.Name = "dimParTextBoxFat";
            this.dimParTextBoxFat.Size = new System.Drawing.Size(40, 20);
            this.dimParTextBoxFat.TabIndex = 30;
            this.dimParTextBoxFat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "1. A.  Inserici dati di un esercizio";
            // 
            // labelGB
            // 
            this.labelGB.AutoSize = true;
            this.labelGB.Location = new System.Drawing.Point(266, 57);
            this.labelGB.Name = "labelGB";
            this.labelGB.Size = new System.Drawing.Size(22, 13);
            this.labelGB.TabIndex = 24;
            this.labelGB.Text = "GB";
            // 
            // labelInDimPar
            // 
            this.labelInDimPar.AutoSize = true;
            this.labelInDimPar.Location = new System.Drawing.Point(23, 57);
            this.labelInDimPar.Name = "labelInDimPar";
            this.labelInDimPar.Size = new System.Drawing.Size(103, 13);
            this.labelInDimPar.TabIndex = 23;
            this.labelInDimPar.Text = "Ampiezza partizione:";
            // 
            // randGenButton
            // 
            this.randGenButton.Location = new System.Drawing.Point(12, 348);
            this.randGenButton.Name = "randGenButton";
            this.randGenButton.Size = new System.Drawing.Size(448, 46);
            this.randGenButton.TabIndex = 45;
            this.randGenButton.Text = "Genera dati casuali (in arrivo)";
            this.randGenButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 44;
            this.label3.Text = "2. Risolvi l\'eserczio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "1. C.  Genera a caso dati di un esercizio";
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(12, 426);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(448, 46);
            this.solveButton.TabIndex = 42;
            this.solveButton.Text = "Risolvi esercizio";
            this.solveButton.UseVisualStyleBackColor = true;
            // 
            // dataTakeButton
            // 
            this.dataTakeButton.Location = new System.Drawing.Point(12, 265);
            this.dataTakeButton.Name = "dataTakeButton";
            this.dataTakeButton.Size = new System.Drawing.Size(448, 46);
            this.dataTakeButton.TabIndex = 47;
            this.dataTakeButton.Text = "Preleva dati";
            this.dataTakeButton.UseVisualStyleBackColor = true;
            this.dataTakeButton.Visible = false;
            this.dataTakeButton.Click += new System.EventHandler(this.dataTakeButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 16);
            this.label5.TabIndex = 46;
            this.label5.Text = "1. B.  Preleva dati da esercizio Ext2fs";
            this.label5.Visible = false;
            // 
            // FAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataTakeButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.randGenButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.dataBlockCombo);
            this.Controls.Add(this.labelKB);
            this.Controls.Add(this.labelDataBlock);
            this.Controls.Add(this.dimParTextBoxFat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelGB);
            this.Controls.Add(this.labelInDimPar);
            this.Name = "FAT";
            this.Size = new System.Drawing.Size(472, 484);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox dataBlockCombo;
        private System.Windows.Forms.Label labelKB;
        private System.Windows.Forms.Label labelDataBlock;
        private System.Windows.Forms.TextBox dimParTextBoxFat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelGB;
        private System.Windows.Forms.Label labelInDimPar;
        private System.Windows.Forms.Button randGenButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Button dataTakeButton;
        private System.Windows.Forms.Label label5;
    }
}

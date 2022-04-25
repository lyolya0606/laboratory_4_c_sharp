namespace laboratory_4 {
    partial class AddAndEditForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.labelNumber = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.labelSurname = new System.Windows.Forms.Label();
            this.textBoxBalance = new System.Windows.Forms.TextBox();
            this.labelBalance = new System.Windows.Forms.Label();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.labelPercent = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.numericUpDownPercent = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(27, 32);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(52, 16);
            this.labelNumber.TabIndex = 0;
            this.labelNumber.Text = "number";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(120, 84);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 22);
            this.textBoxName.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(27, 87);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 16);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "name";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(120, 138);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(100, 22);
            this.textBoxSurname.TabIndex = 5;
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Location = new System.Drawing.Point(27, 141);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(59, 16);
            this.labelSurname.TabIndex = 4;
            this.labelSurname.Text = "surname";
            // 
            // textBoxBalance
            // 
            this.textBoxBalance.Location = new System.Drawing.Point(120, 194);
            this.textBoxBalance.Name = "textBoxBalance";
            this.textBoxBalance.Size = new System.Drawing.Size(100, 22);
            this.textBoxBalance.TabIndex = 7;
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Location = new System.Drawing.Point(27, 197);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(56, 16);
            this.labelBalance.TabIndex = 6;
            this.labelBalance.Text = "balance";
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Location = new System.Drawing.Point(27, 250);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(58, 16);
            this.labelCurrency.TabIndex = 8;
            this.labelCurrency.Text = "currency";
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Location = new System.Drawing.Point(27, 306);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(52, 16);
            this.labelPercent.TabIndex = 10;
            this.labelPercent.Text = "percent";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(227, 362);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 12;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Items.AddRange(new object[] {
            "$",
            "€",
            "₽",
            "¥",
            "₿",
            "₪"});
            this.comboBoxCurrency.Location = new System.Drawing.Point(120, 247);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(100, 24);
            this.comboBoxCurrency.TabIndex = 13;
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(120, 29);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(100, 22);
            this.textBoxNumber.TabIndex = 1;
            // 
            // numericUpDownPercent
            // 
            this.numericUpDownPercent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownPercent.Location = new System.Drawing.Point(120, 299);
            this.numericUpDownPercent.Name = "numericUpDownPercent";
            this.numericUpDownPercent.Size = new System.Drawing.Size(100, 22);
            this.numericUpDownPercent.TabIndex = 14;
            // 
            // AddAndEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 399);
            this.Controls.Add(this.numericUpDownPercent);
            this.Controls.Add(this.comboBoxCurrency);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelPercent);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.textBoxBalance);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.labelNumber);
            this.Name = "AddAndEditForm";
            this.Text = "AddAndEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.TextBox textBoxBalance;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.NumericUpDown numericUpDownPercent;
    }
}
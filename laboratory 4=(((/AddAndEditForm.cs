using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace laboratory_4 {
    public partial class AddAndEditForm : Form {
        private readonly bool isAdd;
        private List<string> keys;

        public AddAndEditForm(bool isAdd, string number = null, string name = null, string surname = null, string balance = null, string currency = null, decimal percent = 0) {
            InitializeComponent();
            if (!isAdd) {
                textBoxNumber.Text = number;
                textBoxName.Text = name;
                textBoxSurname.Text = surname;
                textBoxBalance.Text = balance;
                comboBoxCurrency.Text = currency;
                numericUpDownPercent.Value = percent;
                textBoxNumber.ReadOnly = true;
            }
            this.isAdd = isAdd;
        }

        private void ButtonOkClick(object sender, EventArgs e) {
            Check check = new Check();            
            string number = textBoxNumber.Text;
            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            string balance = textBoxBalance.Text;
            string currency = comboBoxCurrency.Text;
            decimal percent = numericUpDownPercent.Value;

            if (number == "" || name == "" || surname == "" || balance == "" || currency == "" || !check.CheckAll(number, name, surname, balance)) {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("You entered bad data", "Warning!", buttons, MessageBoxIcon.Error);
                return;
            }
            DatabaseWork databaseWork = new DatabaseWork();
            
           
            if (isAdd) {
                if (!CheckKey()) {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("The field 'number' must be unique", "Warning!", buttons, MessageBoxIcon.Error);
                    return;
                }
                databaseWork.Add(number, name, surname, balance, currency, percent, "DefaultConnection");
               
            } else {
                databaseWork.Edit(number, name, surname, balance, currency, percent, "DefaultConnection");
            }
            Close();
        }

        public void SetKeys(List<string> keys) {
            this.keys = keys;
        }

        private bool CheckKey() {
            foreach (string key in keys) {
                if (key == textBoxNumber.Text) {
                    return false;
                }
            }
            return true;
        }       
    }
}

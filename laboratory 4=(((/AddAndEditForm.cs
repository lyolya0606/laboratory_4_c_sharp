using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;

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
                MessageBox.Show("You entered bad data", "Warning!");
                return;
            }

            SQLiteConnection sqLiteConnection = new SQLiteConnection("data source=BankAccounts.db");

            if (isAdd) {
                if (!CheckKey()) {
                    MessageBox.Show("The field 'number' must be unique", "Warning!");
                    return;
                }

                sqLiteConnection.Open();
                string addAccount = "insert into BankAccounts (number, name, surname, balance, currency, percent)" +
                                    $"values ({number}, '{name}', '{surname}', '{balance}', '{currency}', '{percent}');";
            
                SQLiteCommand sqLiteCommand = new SQLiteCommand(addAccount, sqLiteConnection);
                sqLiteCommand.ExecuteNonQuery();
                sqLiteConnection.Close();
            } else {
                
                sqLiteConnection.Open();
                string addAccount = $"update BankAccounts set name = '{name}', surname = '{surname}', balance = {balance}, " +
                    $"currency = '{currency}', percent = '{percent}' where number = {number};";

                SQLiteCommand sqLiteCommand = new SQLiteCommand(addAccount, sqLiteConnection);
                sqLiteCommand.ExecuteNonQuery();
                sqLiteConnection.Close();
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

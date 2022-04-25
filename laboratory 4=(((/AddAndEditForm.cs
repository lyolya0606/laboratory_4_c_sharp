using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace laboratory_4 {
    public partial class AddAndEditForm : Form {
        private bool isAdd;

        public AddAndEditForm(bool isAdd, string number = null, string name = null, string surname = null, string balance = null, string currency = null, decimal percent = 0) {
            InitializeComponent();
            if (!isAdd) {
                textBoxNumber.Text = number;
                textBoxName.Text = name;
                textBoxSurname.Text = surname;
                textBoxBalance.Text = balance;
                comboBoxCurrency.Text = currency;
                numericUpDownPercent.Value = percent;                
            }
            this.isAdd = isAdd;
        }

        private void ButtonOkClick(object sender, EventArgs e) {
            string number = textBoxNumber.Text;
            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            string balance = textBoxBalance.Text;
            string currency = comboBoxCurrency.Text;
            decimal percent = numericUpDownPercent.Value;
            SQLiteConnection sqLiteConnection = new SQLiteConnection("data source=BankAccounts.db");

            if (isAdd) {                
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
    }
}

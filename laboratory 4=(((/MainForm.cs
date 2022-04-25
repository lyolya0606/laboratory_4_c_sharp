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
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            GreetingWorker();
            InitializeConnection();
        }

        private void InitializeConnection() {
            SQLiteConnection sqLiteConnection = new SQLiteConnection("data source=BankAccounts.db");

            string query = "SELECT* from BankAccounts";
            SQLiteCommand cmd = new SQLiteCommand(query, sqLiteConnection);

            DataTable dataTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dataTable);
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.UseColumnTextForButtonValue = true;
            dataGridView.DataSource = dataTable;
           
        }


        private void AskingForClosing(object sender, FormClosingEventArgs e) {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Do you really want to exit?", "Exit", buttons);
            e.Cancel = result != DialogResult.Yes;
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e) {            
            About about = new About(true);
            about.SavingChoice();
            about.ShowDialog();            
        }

        private void AddButtonClick(object sender, EventArgs e) {
            AddAndEditForm addAndEditForm = new AddAndEditForm(true);
            addAndEditForm.ShowDialog();
            InitializeConnection();
        }

        private void DeleteButtonClick(object sender, EventArgs e) {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Do you really want to delete highlighted line?", "Delete", buttons);
            if (result == DialogResult.No) {
                return;
            }

            int i = dataGridView.CurrentCell.RowIndex;
            string numberForDelete = dataGridView[0, i].Value.ToString();


            SQLiteConnection sqLiteConnection = new SQLiteConnection("data source=BankAccounts.db");
            sqLiteConnection.Open();
            string addAccount = $"delete from BankAccounts where number = '{numberForDelete}'";

            SQLiteCommand sqLiteCommand = new SQLiteCommand(addAccount, sqLiteConnection);
            sqLiteCommand.ExecuteNonQuery();
            sqLiteConnection.Close();
            InitializeConnection();
        }

        private void DataGridViewCellClick(object sender, DataGridViewCellEventArgs e) {
            deleteButton.Enabled = true;
            editButton.Enabled = true;
        }

        private void EditButtonClick(object sender, EventArgs e) {
            int i = dataGridView.CurrentCell.RowIndex;
            string numberForDelete = dataGridView[0, i].Value.ToString();
            AddAndEditForm addAndEditForm = new AddAndEditForm(false, dataGridView[0, i].Value.ToString(), dataGridView[1, i].Value.ToString(), dataGridView[2, i].Value.ToString(),
                dataGridView[3, i].Value.ToString(), dataGridView[4, i].Value.ToString(), decimal.Parse(dataGridView[5, i].Value.ToString()));
            addAndEditForm.ShowDialog();
            InitializeConnection();
        }
    }
}

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
using System.IO;

namespace laboratory_4 {
    public partial class MainForm : Form {
        private const int NUM_OF_COLUMNS = 6;
        public MainForm() {
            InitializeComponent();
            GreetingWorker();
            InitializeConnection();
        }

        private void InitializeConnection() {
            SQLiteConnection sqLiteConnection = new SQLiteConnection("data source=BankAccounts.db");

            string query = "select* from BankAccounts";
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
            AddAndEditForm addAndEditForm = new AddAndEditForm(false, dataGridView[0, i].Value.ToString(), dataGridView[1, i].Value.ToString(), dataGridView[2, i].Value.ToString(),
                dataGridView[3, i].Value.ToString(), dataGridView[4, i].Value.ToString(), decimal.Parse(dataGridView[5, i].Value.ToString()));
            addAndEditForm.ShowDialog();
            InitializeConnection();
        }

        private void FileToolStripMenuItemClick(object sender, EventArgs e) {
            if (dataGridView.Rows.Count == 0) {
                saveToTxtToolStripMenuItem.Enabled = false;
            } else {
                saveToTxtToolStripMenuItem.Enabled = true;
            }
        }

        private void SaveToTxtToolStripMenuItemClick(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog() {
                InitialDirectory = @"C:\Users\lyolya\source\repos\laboratory 4=(((\laboratory 4=(((\bin\Debug"
            };
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                if (saveFileDialog.FileName == @"C:\Users\lyolya\source\repos\laboratory 4=(((\laboratory 4=(((\bin\Debug\CheckBox.txt") {
                    MessageBox.Show("This file cannot be opened!", "Warning!");
                    return;
                }

                using (var sr = new StreamWriter(saveFileDialog.FileName)) {
                    for (int i = 0; i < dataGridView.Columns.Count; i++) {
                        sr.Write(dataGridView.Columns[i].HeaderText + " ");
                    }
                    sr.WriteLine();
                    for (int i = 0; i < dataGridView.Rows.Count; i++) {
                        for (int j = 0; j < dataGridView.Columns.Count; j++) {
                            sr.Write(dataGridView.Rows[i].Cells[j].Value + " ");
                        }
                        sr.WriteLine();
                    }

                }
                MessageBox.Show("File was successfully saved!", "Saving!");
            }
            else {
                MessageBox.Show("File was not saved!", "Warning!");
            }
        }
    }
}

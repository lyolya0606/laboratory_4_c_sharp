using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace laboratory_4 {
    public class DatabaseWork {
        public void Add(string number, string name, string surname, string balance, string currency, decimal percent, string conn) {
            SQLiteConnection sqLiteConnection = new SQLiteConnection(ConfigurationManager.ConnectionStrings[conn].ConnectionString);
            //SQLiteConnection sqLiteConnection = new SQLiteConnection("DefaultConnection");
            sqLiteConnection.Open();
            SQLiteCommand command = sqLiteConnection.CreateCommand();
            command.CommandText = "insert into BankAccounts (number, name, surname, balance, currency, percent)" +
                               $"values (@number, @name, @surname, @balance, @currency, @percent)";
            command.Parameters.Add(new SQLiteParameter("@number", number));
            command.Parameters.Add(new SQLiteParameter("@name", name));
            command.Parameters.Add(new SQLiteParameter("@surname", surname));
            command.Parameters.Add(new SQLiteParameter("@balance", balance));
            command.Parameters.Add(new SQLiteParameter("@currency", currency));
            command.Parameters.Add(new SQLiteParameter("@percent", percent));
            command.ExecuteNonQuery();
            sqLiteConnection.Close();
        }

        public void Edit(string number, string name, string surname, string balance, string currency, decimal percent, string conn) {
            SQLiteConnection sqLiteConnection = new SQLiteConnection(ConfigurationManager.ConnectionStrings[conn].ConnectionString);
            sqLiteConnection.Open();
            SQLiteCommand command = sqLiteConnection.CreateCommand();
            command.CommandText = "update BankAccounts set name = @name, surname = @surname, balance = @balance, " +
                    $"currency = @currency, percent = @percent where number = @number";
            command.Parameters.Add(new SQLiteParameter("@number", number));
            command.Parameters.Add(new SQLiteParameter("@name", name));
            command.Parameters.Add(new SQLiteParameter("@surname", surname));
            command.Parameters.Add(new SQLiteParameter("@balance", balance));
            command.Parameters.Add(new SQLiteParameter("@currency", currency));
            command.Parameters.Add(new SQLiteParameter("@percent", percent));
            command.ExecuteNonQuery();
            sqLiteConnection.Close();
        }

        public void Delete(string number, string conn) {
            SQLiteConnection sqLiteConnection = new SQLiteConnection(ConfigurationManager.ConnectionStrings[conn].ConnectionString);
            sqLiteConnection.Open();
            SQLiteCommand command = sqLiteConnection.CreateCommand();
            command.CommandText = "delete from BankAccounts where number = @number";
            command.Parameters.Add(new SQLiteParameter("@number", number));
            command.ExecuteNonQuery();
            sqLiteConnection.Close();
        }

        public int GetCount(string conn) {
            string stmt = "select* from BankAccounts";
            int count;
            SQLiteConnection sqLiteConnection = new SQLiteConnection(ConfigurationManager.ConnectionStrings[conn].ConnectionString);
            SQLiteCommand cmd = new SQLiteCommand(stmt, sqLiteConnection);

            DataTable dataTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dataTable);
            count = dataTable.Rows.Count;
            return count;           
        }
    }
}

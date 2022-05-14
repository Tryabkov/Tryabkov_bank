using System;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tryabkov_bank
{
    public class User:Person
    {
        public User(string name, string surname, string email, string phoneNumber, string birdthDate, string password)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.birdthDate = birdthDate;
            this.password = password;
            this.balance = 0;
            Add_to_database();
        }
        public int balance { get; set; } 

        private void Add_to_database()
        {
            DB DataBase = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO users (name, surname, email, phoneNumber, birdthDate, password, balance) VALUES (@name, @surname, @email, @phoneNumber, @birdthDate, @password, @balance)", DataBase.GetConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar, 50).Value = name;
            command.Parameters.Add("@surname", MySqlDbType.VarChar, 50).Value = surname;
            command.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = email;
            command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar, 11).Value = phoneNumber;
            command.Parameters.Add("@birdthDate", MySqlDbType.VarChar, 11).Value = birdthDate;
            command.Parameters.Add("@password", MySqlDbType.VarChar, 50).Value = password;
            command.Parameters.Add("@balance", MySqlDbType.Int32, 13).Value = balance;
            
            DataBase.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("success");
            }
            DataBase.CloseConnection();
        }

    }
}

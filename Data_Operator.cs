using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace Tryabkov_bank
{
    public static class Data_Operator
    {
        public static void Create_new_client(string name, string surname, string email, string phoneNumber, string birdthDate, string password)
        {
            if (CheckDBConnection())
            {
                User client = new User(name, surname, email, phoneNumber, birdthDate, password);
            }
        }

        public static int PasswordEmailComparer(string email, string password)
        {
            if (CheckDBConnection())
            {
                DataTable table = new DataTable();
                DB DataBase = new DB();

                MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE email = @email", DataBase.GetConnection());
                command.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = email;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(table);
                DataRow[] rows = table.Select();

                if (Convert.ToString(rows[0].ItemArray[6]) == password)
                {

                    return 1;
                }
                else return 0;
            }
                return -1;
        }

        public static bool IsEmailExist(string email)
        {
            if (CheckDBConnection())
            {
                DataTable table = new DataTable();
                DB DataBase = new DB();

                MySqlCommand command = new MySqlCommand("SELECT @email FROM users", DataBase.GetConnection());
                command.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = email;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(table);
                DataRow[] rows = table.Select();
            }
            return false;
        }

        private static bool CheckDBConnection()
        {
            DB DataBase = new DB();
            try
            {
                DataBase.OpenConnection();
                DataBase.CloseConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("Check your Internet connection");
                return false;
            }          
            return true;
        }//Tries connect to database

    }
}

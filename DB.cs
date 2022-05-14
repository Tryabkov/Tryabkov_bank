using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tryabkov_bank
{
    public class DB
    {
        const string SERVER = "remotemysql.com";
        const string PORT = "3306";
        const string USERNAME = "y7T7GLgIm0";
        const string PASSWORD = "mzTofdxLVh";
        const string DATABASE = "y7T7GLgIm0";

        MySqlConnection connection = new MySqlConnection($"server={SERVER};port={PORT};username={USERNAME};password={PASSWORD};database={DATABASE}");
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
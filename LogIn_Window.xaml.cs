using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tryabkov_bank
{
    /// <summary>
    /// Логика взаимодействия для LogIn_Window.xaml
    /// </summary>
    public partial class LogIn_Window : Window
    {
        public LogIn_Window()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {           
            var SignIn = new SignIn_Window();
            SignIn.Show();
            this.Close();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            int passwordComparingStatus = Data_Operator.PasswordEmailComparer(EmailTextBox.Text, PasswordTextBox.Password);
            if (passwordComparingStatus == 1)
            {
                var MainWindow = new MainWindow();
                MainWindow.Show();
                this.Close();
            }
            if (passwordComparingStatus == 0) MessageBox.Show("Email or password don`t match");
        }
    }
}

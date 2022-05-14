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
    /// Логика взаимодействия для SignIn_Window.xaml
    /// </summary>
    public partial class SignIn_Window : Window
    {
        const string EMPTY_FILDS = "Please, full all filds right";
        const string FIRST_ERROR = "Incorrect value in phone box";
        const string SECOND_ERROR = "Passwords do not match";
        const string THIRD_ERROR = "User with same email already exist";
        public SignIn_Window()
        {
            InitializeComponent();
        }

        private void FinishRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != "" && SurnameTextBox.Text != "" && EmailTextBox.Text != "" && PhoneNumberTextBox.Text != "" && Calendar.SelectedDate != null && PasswordTextBox.Password != "")
            {
                int errorNuber = 0;
                for (int i = 0; i < PhoneNumberTextBox.Text.Length; i++)
                {
                    if (char.IsNumber(Convert.ToChar(PhoneNumberTextBox.Text[i])))
                    {

                    }
                    else errorNuber = 1;
                }
                if (PasswordTextBox.Password != ConfirmePasswordTextBox.Password) errorNuber = 2;

                switch (errorNuber)
                {
                    case 0: //without errors
                        {
                            Data_Operator.Create_new_client(NameTextBox.Text, SurnameTextBox.Text, EmailTextBox.Text, PhoneNumberTextBox.Text, Convert.ToString(Calendar.SelectedDate)[..10], PasswordTextBox.Password);
                            break;
                        }
                    case 1:
                        {
                            MessageBox.Show(FIRST_ERROR);
                            break;
                        }
                    case 2:
                        {
                            MessageBox.Show(SECOND_ERROR);
                            break;
                        }
                    case 3:
                        {
                            MessageBox.Show(THIRD_ERROR);
                            EmailTextBox.Text = "";
                            break;
                        }


                }
            }
            else
            {
                MessageBox.Show(EMPTY_FILDS);
            }
        }

        private void LogInButton_LeftMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            var LogIn = new LogIn_Window();
            LogIn.Show();
            this.Close();
        }
    }
}


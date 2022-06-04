using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> TransfersButtons = new List<Button>();
        List<string> ButtonsContent = new List<string>();

        public bool LicenseExpired { get; set; } = true;
        public MainWindow()
        {
            InitializeComponent();
            ButtonsContent.Add("Transfer to card");
            ButtonsContent.Add("Transfer by phone number");
                
        }

        private Button InitiainitializeButton(string content)
        {
            Button button = new Button();
            button.Content = content;
            button.Click += TransferButton_Click;
            return button;
        }

        private void TransferButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CreateButton(string content = null)
        {
            TransfersButtons.Add(InitiainitializeButton(content));
        }
    }
}

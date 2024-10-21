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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordGenerator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            int passwordLength = (int)PLS.Value;
            
            bool includeSpecialCharacters = IncludeSpecialCharactersCheckBox.IsChecked == true;

            string password = GeneratePassword(passwordLength, includeSpecialCharacters);
                ;
            PasswordTextBox.Text = password;

        }
        private string GeneratePassword(int lenght, bool includeSpecialCharacters)
        {
            Random random = new Random();

            string digits = "0123456789";
            string upperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowerLetters = "abcdefghijklmnopqrstuvwxyz";
            string specialChars = "!@#$%^&*";

            string allChars = digits + upperLetters + lowerLetters;
            if (includeSpecialCharacters)
            {
                allChars += specialChars;
            }

           
            string password = new string(Enumerable.Range(0, lenght).Select(_ => allChars[random.Next(allChars.Length)]).ToArray());

            return password;
        }
    }
; }

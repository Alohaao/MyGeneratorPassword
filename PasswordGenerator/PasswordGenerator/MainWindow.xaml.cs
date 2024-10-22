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
            if (!int.TryParse(Enter.Text, out int passwordLength) || passwordLength <= 0)
            {
                MessageBox.Show("Выбирите длину пароля.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool includeRUL = IncludeRULCheckBox.IsChecked == true;
            bool includeRLL = IncludeRLLCheckBox.IsChecked == true; 
            bool includeSpecialCharacters = IncludeSpecialCharactersCheckBox.IsChecked == true;
            bool includeUE = IncludeUECheckBox.IsChecked == true;
            bool includeLE= IncludeLECheckBox.IsChecked == true;
            bool includeNum = IncludeNumCheckBox.IsChecked == true;

            string password = GeneratePassword(passwordLength, includeSpecialCharacters, includeLE, includeUE, includeNum, includeRUL, includeRLL);
                ;
            PasswordTextBox.Text = password;

        }
        private string GeneratePassword(int lenght, bool includeSpecialCharacters, bool includeUE, bool includeLE, bool includeNum, bool includeRUL, bool includeRLL)
        {
            Random random = new Random();

            string RUL = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string RLL = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string digits = "0123456789";
            string upperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowerLetters = "abcdefghijklmnopqrstuvwxyz";
            string specialChars = "!@#$%^&*";

            string allChars = "";
            if (includeRUL)
            {
                allChars += RLL;
            }
            if (includeRLL)
            {
                allChars += RUL;
            }
            if (includeLE) 
            { 
                allChars += lowerLetters; 
            }
            if (includeUE) 
            { 
                allChars += upperLetters; 
            }
            if (includeNum) 
            { 
                allChars += digits;
            }
            if (includeSpecialCharacters)
            {
                allChars += specialChars;
            }
            if (allChars.Length == 0)
            {
                MessageBox.Show("Пожалуйста, выбирите хотя бы один тип", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return string.Empty;
            }

           
            string password = new string(Enumerable.Range(0, lenght).Select(_ => allChars[random.Next(allChars.Length)]).ToArray());

            return password;
        }

        private void CopyPass_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                Clipboard.SetText(PasswordTextBox.Text);
                MessageBox.Show("Пароль скопирован в буфер обмена!", "Принять", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Нет пароля, который можно скопировать.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Enterr_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}

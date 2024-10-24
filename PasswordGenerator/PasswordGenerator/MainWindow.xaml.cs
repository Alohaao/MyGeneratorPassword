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

            int hyphenFrequency = 0;
            if (IncludeHyphenCheckBox.IsChecked == true)
            {
                if (!int.TryParse(HyphenFrequencyTextBox.Text, out hyphenFrequency) || hyphenFrequency <= 0)
                {
                    MessageBox.Show("Введите корректную частоту дефиса.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            bool includeRUL = IncludeRULCheckBox.IsChecked == true;
            bool includeRLL = IncludeRLLCheckBox.IsChecked == true; 
            bool includeSpecialCharacters = IncludeSpecialCharactersCheckBox.IsChecked == true;
            bool includeUE = IncludeUECheckBox.IsChecked == true;
            bool includeLE= IncludeLECheckBox.IsChecked == true;
            bool includeNum = IncludeNumCheckBox.IsChecked == true;

            string password = GeneratePassword(passwordLength, includeSpecialCharacters, includeLE, includeUE, includeNum, includeRUL, includeRLL, hyphenFrequency, IncludeHyphenCheckBox.IsChecked == true);
            PasswordTextBox.Text = password;

        }
        private string GeneratePassword(int length, bool includeSpecialCharacters, bool includeUE, bool includeLE, bool includeNum, bool includeRUL, bool includeRLL, int hyphenFrequency, bool includeHyphen)
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


            StringBuilder password = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                if (includeHyphen && i > 0 && i % hyphenFrequency == 0 && i != length) // Добавление дефиса
                {
                    password.Append('-');
                }
                password.Append(allChars[random.Next(allChars.Length)]);
            }

            return password.ToString();
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
    }
}

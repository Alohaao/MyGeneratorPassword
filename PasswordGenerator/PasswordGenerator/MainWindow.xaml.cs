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
            string password = GeneratePassword();
            PasswordTextBox.Text = password;

        }
        private string GeneratePassword()
        {
            Random random = new Random();
            
            /*Генерация 2х цифр*/
            string digits = new string(Enumerable.Range(0, 2).Select(_ => (char)random.Next('0', '9' + 1)).ToArray());

            /* Генерация 3х заглавных букв*/
            string upperLetters = new string(Enumerable.Range(0, 3).Select(_ => (char)random.Next('A', 'Z' + 1)).ToArray());

            /* Генерация 4х строчных букв*/
            string lowerLetters = new string(Enumerable.Range(0, 4).Select(_ => (char)random.Next('a', 'z' + 1)).ToArray());

            /* Объеденим всё вместе */

            string password = digits + upperLetters + lowerLetters;

            /* Сделаем рандомное распределение символов */
            return new string(password.OrderBy(_ => random.Next()).ToArray());
        }
    }
}

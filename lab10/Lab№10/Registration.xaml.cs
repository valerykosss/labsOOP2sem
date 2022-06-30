using Microsoft.Win32;
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

namespace Lab_10
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private string avatar;
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text;
            string surname = SurnameBox.Text;
            string email = EmailBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            
            if (password != confirmPassword)
                MessageBox.Show("Passwords do not match");
            else
            {
                DataBase db = new DataBase();
                if (db.CheckUserAuth(email, password) == -1)
                {
                    db.AddUser(name, surname, avatar, email, password);
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("User with this email already exists");
            }
        }

        private void Avatar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                avatar = openFileDialog.FileName;
            }
        }
    }
}

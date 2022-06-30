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
    /// Interaction logic for WriteMessage.xaml
    /// </summary>
    public partial class WriteMessage : Window
    {
        private int senderId;
        public WriteMessage(int id)
        {
            InitializeComponent();
            senderId = id;
            DataBase db = new DataBase();
            UsersGrid.ItemsSource = db.GetUsers();
        }

        private void Write_Click(object sender, RoutedEventArgs e)
        {
            if (MessageText.Text != "" && UsersGrid.SelectedItem != null)
            {
                DataBase db = new DataBase();
                db.WriteMessage(senderId, ((Model.User)UsersGrid.SelectedItem).Id, MessageText.Text);
                MessageText.Text = "";
            }
            else
            {
                MessageBox.Show("Выберите получателя и введите текст сообщения");
            }
        }
    }
}

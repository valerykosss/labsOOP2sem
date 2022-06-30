using Lab_10.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
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

namespace Lab_10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User currentUser;
        private List<Message> messages;
        public MainWindow(int id)
        {
            InitializeComponent();
            DataBase db = new DataBase();
            currentUser = db.FindUser(id);
            UserInfo.DataContext = currentUser;
            Update();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Message message = (Message)MessagesGrid.SelectedItem;
            if (message != null & (message.Sender == currentUser.Surname))
            {
                DataBase db = new DataBase();
                db.EditMessage(message.Id, EditText.Text);
                Update();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Message message = (Message)MessagesGrid.SelectedItem;
            if (message != null)
            {
                DataBase db = new DataBase();
                db.DeleteMessage(message.Id);
                Update();
            }
        }

        private void Write_Click(object sender, RoutedEventArgs e)
        {
            WriteMessage wm = new WriteMessage(currentUser.Id);
            wm.Show();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (UndoRedoManager.State > 0)
            {
                messages = UndoRedoManager.Undo();
                MessagesGrid.ItemsSource = messages;
            }
            else
            {
                MessageBox.Show("Nothing to undo");
            }
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            if (UndoRedoManager.State < UndoRedoManager.Length - 1)
            {
                messages = UndoRedoManager.Redo();
                MessagesGrid.ItemsSource = messages;
            }
            else
            {
                MessageBox.Show("Nothing to redo");
            }
        }

        private void Update()
        {
            DataBase db = new DataBase();
            messages = db.GetMessages(currentUser.Id);
            MessagesGrid.ItemsSource = messages;
            UndoRedoManager.Add(messages);
        }
    }
}

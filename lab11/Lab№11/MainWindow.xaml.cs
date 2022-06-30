using Lab_11.Models;
using Lab_11.Patterns;
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

namespace Lab_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UnitOfWork unit;
        private Library library;
        private List<Book> books;
        public MainWindow()
        {
            InitializeComponent();

            unit = new UnitOfWork();
            library = unit.Libraries.Get(1);
            books = unit.Books.GetFromLibrary(library).ToList();
            currentLibrary.ItemsSource = books;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (currentLibrary.SelectedItems.Count != 0)
            {
                foreach (Book book in currentLibrary.SelectedItems)
                {
                    unit.Books.Delete(book);
                    books.Remove(book);
                }
                unit.Save();
                currentLibrary.ItemsSource = books.Where(b => b.Title.Contains(titleBox.Text) & b.Author.Contains(authorBox.Text)).ToList();
            }
            else
            {
                MessageBox.Show("No books selected");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            unit.BeginTran();
            Book book = new Book { Author = authorBox.Text, Title = titleBox.Text, LibraryId = library.Id };
            unit.Books.Create(book);
            unit.Save();
            books.Add(book);
            currentLibrary.ItemsSource = books.Where(b => b.Title.Contains(titleBox.Text) & b.Author.Contains(authorBox.Text)).ToList();
            unit.Commit();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Book> books = unit.Books.GetFromLibrary(library);
            foreach (Book dbBook in books)
            {
                foreach (Book tableBook in currentLibrary.ItemsSource)
                {
                    if (dbBook.Id == tableBook.Id)
                    {
                        dbBook.Author = tableBook.Author;
                        dbBook.Title = tableBook.Title;
                        unit.Books.Update(dbBook);
                    }
                }
            }
            unit.Save();
        }

        private void serch_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentLibrary.ItemsSource = books.Where(b => b.Title.Contains(titleBox.Text) & b.Author.Contains(authorBox.Text)).ToList();
        }

        private void Lib34_Click(object sender, RoutedEventArgs e)
        {
            library = unit.Libraries.Get(1);
            books = unit.Books.GetFromLibrary(library).ToList();
            currentLibrary.ItemsSource = books;
            currentLibrary.ItemsSource = books.Where(b => b.Title.Contains(titleBox.Text) & b.Author.Contains(authorBox.Text)).ToList();
        }

        private void Lib12_Click(object sender, RoutedEventArgs e)
        {
            library = unit.Libraries.Get(2);
            books = unit.Books.GetFromLibrary(library).ToList();
            currentLibrary.ItemsSource = books;
            currentLibrary.ItemsSource = books.Where(b => b.Title.Contains(titleBox.Text) & b.Author.Contains(authorBox.Text)).ToList();
        }

        private void Lib46_Click(object sender, RoutedEventArgs e)
        {
            library = unit.Libraries.Get(3);
            books = unit.Books.GetFromLibrary(library).ToList();
            currentLibrary.ItemsSource = books;
            currentLibrary.ItemsSource = books.Where(b => b.Title.Contains(titleBox.Text) & b.Author.Contains(authorBox.Text)).ToList();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            unit.Dispose();
            base.OnClosing(e);
        }
    }
}

using Knihovna.Managers;
using Knihovna.Model;
using Knihovna.ViewModel;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Knihovna.Views
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : UserControl
    {
        public static Book book = null;
        public AddBook()
        {
            InitializeComponent();
            Thread threadAdd = new Thread(() =>
            {
                if (book!= null)
            {
                    Dispatcher.Invoke(() => Name.Text = book.Name);
                    Dispatcher.Invoke(() => auth.Text = book.Author);
                    Dispatcher.Invoke(() => isbn.Text = book.ISBN);
                    Dispatcher.Invoke(() => Pridat.Content = "Editovat");
            }
            });
            threadAdd.Start();
        }


        private void AddBookToList(object sender, RoutedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                if (book != null)
            {
                Book a = BookViewModel.Books.Where(x => x == book).First();
                    Dispatcher.Invoke(() => a.Name = Name.Text);
                    Dispatcher.Invoke(() => a.Author = auth.Text);
                    Dispatcher.Invoke(() => a.ISBN = isbn.Text);
                    BookViewModel.BookManager.editKniha(a);


                    Dispatcher.Invoke(() => AddKnihaW.GetWindow(this).Close());
            }
            else
            {


                if (Dispatcher.Invoke(() => Name.Text.Length != 0  && auth.Text.Length != 0 && isbn.Text.Length != 0))
                {
                        Dispatcher.Invoke(() => BookViewModel.Books.Add(new Model.Book { Name = Name.Text, Author = auth.Text, ISBN = isbn.Text, lbId = LibraryDetail.lib.Id}));
                        BookViewModel.BookManager.addBook(BookViewModel.Books[BookViewModel.Books.Count - 1]);
                        Dispatcher.Invoke(()=> AddKnihaW.GetWindow(this).Close());
                    }
                else
                {
                    MessageBox.Show("Nejsou vyplněny všechny položky", "Chyba");
                }
                book = null;
            }
            });
            threadAdd.Start();
        }
    }
}

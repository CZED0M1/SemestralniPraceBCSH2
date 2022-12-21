using Knihovna.Model;
using Knihovna.ViewModel;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for LibraryDetail.xaml
    /// </summary>
    public partial class LibraryDetail : UserControl
    {
        public static string name;
        public static Library lib;
        public LibraryDetail()
        {
            InitializeComponent();
            Thread threadAdd = new Thread(() =>
            {
                foreach (var item in LibraryViewModel.Libraries)
            {
                    Dispatcher.Invoke(() => CB.Items.Add(item.Name));
            }
                Dispatcher.Invoke(() => CB.SelectedItem = lib.Name);
                Dispatcher.Invoke(() => lv1.ItemsSource = Knihovna.ViewModel.CustomerViewModel.Customers);
                Dispatcher.Invoke(() => lv2.ItemsSource = Knihovna.ViewModel.BookViewModel.Books);
            });
            threadAdd.Start();
        }

        public bool FilterCustomer(object obj)
        {
            Customer k = (Customer)obj;
            if (k.LibraryId == lib.Id-1) return true;
            return false;
        }
        public bool FilterBook(object obj)
        {
            Book k = (Book)obj;
            if (k.lbId == lib.Id) return true;
            return false;
        }
        private void addBook(object sender, RoutedEventArgs e)
        {
            AddBook.book = null;
            AddKnihaW page = new AddKnihaW();
            page.Show();
        }

        private void openCustomer(object sender, MouseButtonEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                if (Dispatcher.Invoke(() => lv1.SelectedItems.Count > 0))
            {
                    Dispatcher.Invoke(() => Borrow.cust = (Customer)lv1.SelectedItem);

                VypujckyW page = Dispatcher.Invoke(() => new VypujckyW());
                    Dispatcher.Invoke(() => page.ShowDialog());
                    Dispatcher.Invoke(() => lv2.Items.Filter = FilterBook);
            }else
            {
                MessageBox.Show("Není vybrán zákazník", "Chyba");
            }
            });
            threadAdd.Start();
        }

        private void OpenBook(object sender, MouseButtonEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                if (Dispatcher.Invoke(() => lv2.SelectedItems.Count > 0))
            {
                AddBook.book = Dispatcher.Invoke(() => (Book)lv2.SelectedItem);
                AddKnihaW page = Dispatcher.Invoke(() => new AddKnihaW());
                    Dispatcher.Invoke(() => page.ShowDialog());
            }
            else
            {
                MessageBox.Show("Není vybrána book", "Chyba");
            }
            });
            threadAdd.Start();
        }

        private void ChangeLibrary(object sender, SelectionChangedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {

                Dispatcher.Invoke(() => lib = LibraryViewModel.Libraries.Where(k => k.Name == CB.SelectedItem.ToString()).First());
                Dispatcher.Invoke(() => lv1.Items.Filter = FilterCustomer);

                Dispatcher.Invoke(() => lv2.Items.Filter = FilterBook);
            });
            threadAdd.Start();
        }

        private void addCustomer(object sender, RoutedEventArgs e)
        {
                AddCustomer.customer = null;
            Knihovna.AddZakaznik page = new Knihovna.AddZakaznik();
            page.Show();

        }
        private void editBook(object sender, RoutedEventArgs e)
        {
                if (lv2.SelectedItems.Count > 0)
            {
                AddBook.book = (Book)lv2.SelectedItem;
                AddKnihaW page = new AddKnihaW();
                page.ShowDialog();
            }
            else
            {
                MessageBox.Show("Není vybrána book", "Chyba");
            }
        }

        private void editCustomer(object sender, RoutedEventArgs e)
        {
                if (lv1.SelectedItems.Count > 0)
            {
                AddCustomer.customer = (Customer)lv1.SelectedItem;
                Knihovna.AddZakaznik page = new Knihovna.AddZakaznik();
                page.ShowDialog();
                lv1.Items.Refresh();

            }
            else
            {
                MessageBox.Show("Není vybrán zákazník", "Chyba");
            }
        }

        private void deleteBook(object sender, RoutedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
            if (Dispatcher.Invoke(() => lv2.SelectedItems.Count > 0))
            {
                    Book a = Dispatcher.Invoke(() => (Book)lv2.SelectedItem);
                    BookViewModel.BookManager.removeBook(a);

                    Dispatcher.Invoke(() => BookViewModel.Books.Remove(a));
            }
            else
            {
                MessageBox.Show("Není vybrána book", "Chyba");
            }
            });
            threadAdd.Start();
        }

        private void deleteCustomer(object sender, RoutedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
            Customer z = Dispatcher.Invoke(() => (Customer)lv1.SelectedItem);
                if (Dispatcher.Invoke(() => lv1.SelectedItems.Count > 0))
                {
                    Dispatcher.Invoke(() => CustomerViewModel.Customers.Remove(z));

                    CustomerViewModel.CustomerManager.removeCustomer(z);
                }
                else
                {
                    MessageBox.Show("Není vybrán zákazník", "Chyba");
                }

            });
            threadAdd.Start();

        }
    }
}

using Knihovna.Model;
using Knihovna.ViewModel;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Borrowing.xaml
    /// </summary>
    public partial class Borrow : UserControl
    {
        public static Customer cust=null;
        public Borrow()
        {
            InitializeComponent();
            Thread threadAdd = new Thread(() =>
            {
                lv1.Items.Filter = FilterAll;
            lv1.Items.Refresh();
            foreach (var item in CustomerViewModel.Customers)
            {
                    Dispatcher.Invoke(() => CB.Items.Add(item.NameSur));
            }
                Dispatcher.Invoke(() => CB.SelectedItem = cust.NameSur);

                Dispatcher.Invoke(() => lv1.ItemsSource = BookViewModel.Books);
                Dispatcher.Invoke(() => lv2.ItemsSource = BorrowingsViewModel.Borrowings);
            });
            threadAdd.Start();
        }

        private void ChangeCustomer(object sender, SelectionChangedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                
                if (Dispatcher.Invoke(() => CustomerViewModel.Customers.Where(z => z.NameSur == CB.SelectedItem.ToString()).Any()))
            {
                cust = Dispatcher.Invoke(() => CustomerViewModel.Customers.Where(z => z.NameSur == CB.SelectedItem.ToString()).First());
                    Dispatcher.Invoke(() => lv2.Items.Filter = FilterBorrow);
            }
            });
            threadAdd.Start();
        }
        public bool FilterAll(object obj)
        {
            return true;
        }
        public bool FilterBorrow(object obj)
        {
            Model.Borrowing vypujcka = (Model.Borrowing)obj;
            if (vypujcka.Customer.NameSur.Equals(cust.NameSur))
            {
                return true;
            }
            return false;
        }



        private void ReturnBook(object sender, RoutedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                if (Dispatcher.Invoke(() => lv2.SelectedItems.Count > 0))
                {
                    Model.Borrowing vyp = Dispatcher.Invoke(() => (Model.Borrowing)lv2.SelectedItem);
                    Book k = vyp.Book;
                    Dispatcher.Invoke(() => BookViewModel.Books.Add(k));

                    BookViewModel.BookManager.addBook(k);


                    BorrowingsViewModel.BorrowingManager.removeBorrowing(vyp);

                    Dispatcher.Invoke(() => BorrowingsViewModel.Borrowings.Remove(vyp));




                    Dispatcher.Invoke(() => cust = CustomerViewModel.Customers.Where(z => z.NameSur == CB.SelectedItem.ToString()).First());
                    Dispatcher.Invoke(() => cust.Borrowed = cust.Borrowed - 1);
                    CustomerViewModel.CustomerManager.editCustomer(cust);
                }
                else
                {
                    MessageBox.Show("Není vybrána vypůjčená book", "Chyba");
                }
            });
            threadAdd.Start();


        }

        private void BorrowBook(object sender, RoutedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                if (Dispatcher.Invoke(() => lv1.SelectedItems.Count > 0))
            {
                Book k = Dispatcher.Invoke(() => (Book)lv1.SelectedItem);
                cust = Dispatcher.Invoke(() => CustomerViewModel.Customers.Where(z => z.NameSur == CB.SelectedItem.ToString()).First());
                Model.Borrowing vyp = new Model.Borrowing { Book = k, Customer=cust };

                    BookViewModel.BookManager.removeBook(k);

                    BorrowingsViewModel.BorrowingManager.addBorrowing(vyp);
                    Dispatcher.Invoke(() => BookViewModel.Books.Remove(k));
                    Dispatcher.Invoke(() => BorrowingsViewModel.Borrowings.Add(vyp));
                    Dispatcher.Invoke(() => cust.Borrowed = cust.Borrowed +1);
                    CustomerViewModel.CustomerManager.editCustomer(cust);
                }
            else
            {
                MessageBox.Show("Není vybrána book", "Chyba");
            }
            });
            threadAdd.Start();


        }
    }
}

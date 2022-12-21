using Knihovna.Model;
using Knihovna.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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
    /// Interaction logic for LibraryControl.xaml
    /// </summary>
    public partial class LibraryControl : UserControl
    {
        public LibraryControl()
        {
            Repository repository = new();

            InitializeComponent();
            ViewModel.LibraryViewModel.Libraries = new();
            ViewModel.BookViewModel.Books = new();
            ViewModel.CustomerViewModel.Customers = new();
            ViewModel.BorrowingsViewModel.Borrowings = new();
            ViewModel.LibraryViewModel.LoadLibrary(repository);
            ViewModel.BookViewModel.LoadBook(repository);
            ViewModel.CustomerViewModel.LoadZakaznici(repository);
            ViewModel.BorrowingsViewModel.LoadBorrows(repository);
            
            lv1.ItemsSource = LibraryViewModel.Libraries;
           
        }

        //ADD
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add page = new Add();
            page.Show(); 
            lv1.Items.Refresh();


        }

        //DELETE
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                if (Dispatcher.Invoke(() => lv1.SelectedItems.Count > 0))
            {
                    Dispatcher.Invoke(() => LibraryViewModel.removeLibrary((Library)lv1.SelectedItem));
            }
            else
            {
                MessageBox.Show("Není vybráno oddělení", "Chyba");
            }
            });
            threadAdd.Start();
        }

        //EDIT
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                if (Dispatcher.Invoke(() => lv1.SelectedItems.Count > 0))
            {
                Library knihovna = Dispatcher.Invoke(() => (Library)lv1.SelectedItem);
                AddEditControl.name = knihovna.Name;
                    Add page = Dispatcher.Invoke(() => new Add());
                    Dispatcher.Invoke(() => page.Show());
               
            }
            else
            {
                MessageBox.Show("Není vybráno oddělení", "Chyba");
            }
            });
            threadAdd.Start();
        }

        //doubleClick
        private void detailOpen(object sender, MouseButtonEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                if (Dispatcher.Invoke(() => lv1.SelectedItems.Count > 0))
            {
                     Library knihovna = Dispatcher.Invoke(() => (Library)lv1.SelectedItem);
            LibraryDetail.name = knihovna.Name;
            LibraryDetail.lib = knihovna;
            detailOdd page = Dispatcher.Invoke(() => new detailOdd());
            Dispatcher.Invoke(() => page.Show());
            }
            else
            {
                MessageBox.Show("Není vybráno Oddělení", "Chyba");
            }
            });
            threadAdd.Start();
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                if (e.Key == Key.Delete) {
                if (lv1.SelectedItems.Count > 0)
                {
                    LibraryViewModel.Libraries.Remove((Library)lv1.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Není vybráno Oddělení", "Chyba");
                }
            }else if(e.Key == Key.Enter) {
                if (lv1.SelectedItems.Count > 0)
                {
                    Library knihovna = (Library)lv1.SelectedItem;
                    LibraryDetail.name = knihovna.Name;
                    LibraryDetail.lib = knihovna;
                    detailOdd page = new detailOdd();
                    page.Show();
                }
                else
                {
                    MessageBox.Show("Není vybráno Oddělení", "Chyba");
                }
           
        }
            });
            threadAdd.Start();

        }
    }
}

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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : UserControl
    {
        public static Customer customer=null;
        public AddCustomer()
        {
            InitializeComponent();
                if (customer !=null)
            {
                Name.Text = customer.Name;
                Surr.Text = customer.Surrname;
                Pridat.Content = "Editovat";
            }
        }

        private void addCustomer(object sender, RoutedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                if (customer != null)
            {
                Customer a = CustomerViewModel.Customers.Where(x => x == customer).First();
                    Dispatcher.Invoke(() => a.Name = Name.Text);
                    Dispatcher.Invoke(() => a.Surrname = Surr.Text);
                    Dispatcher.Invoke(() => Knihovna.AddZakaznik.GetWindow(this).Close());
                    CustomerViewModel.CustomerManager.editCustomer(a);
                }

            else
            {
                if (Dispatcher.Invoke(() => Name.Text.Length != 0 && Surr.Text.Length != 0))
                {
                        Customer a=null;
                        Dispatcher.Invoke(() => a = new Model.Customer { Name = Name.Text, Surrname = Surr.Text, LibraryId = LibraryDetail.lib.Id - 1, Borrowed = 0 });
                        Dispatcher.Invoke(() => CustomerViewModel.Customers.Add(a));


                        Dispatcher.Invoke(() => CustomerViewModel.CustomerManager.addCustomer(new Model.Customer { Name = Name.Text, Surrname = Surr.Text, LibraryId = LibraryDetail.lib.Id - 1, Borrowed = 0 }));

                        Dispatcher.Invoke(() => Knihovna.AddZakaznik.GetWindow(this).Close());
                }
                else
                {
                    MessageBox.Show("Nejsou vyplněny všechny položky", "Chyba");
                }
            }
            });
            threadAdd.Start();

        }
    }
}

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
    /// Interaction logic for KnihovnaControl.xaml
    /// </summary>
    public partial class KnihovnaControl : UserControl
    {
        public KnihovnaControl()
        {
            Repository repository = new();

            InitializeComponent();
            ViewModel.KnihovnaViewModel.Knihovny = new();
            ViewModel.KnihaViewModel.Knihy = new();
            ViewModel.ZakazniciViewModel.Zakaznici = new();
            ViewModel.VypujckyViewModel.Vypujcky = new();
            ViewModel.KnihovnaViewModel.LoadKnihovny(repository);
            ViewModel.KnihaViewModel.LoadKnihy(repository);
            ViewModel.ZakazniciViewModel.LoadZakaznici(repository);
            ViewModel.VypujckyViewModel.LoadVypujcky(repository);
            
            lv1.ItemsSource = KnihovnaViewModel.Knihovny;
           
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
                    Dispatcher.Invoke(() => KnihovnaViewModel.removeKnihovny((Knihovny)lv1.SelectedItem));
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
                Knihovny knihovna = Dispatcher.Invoke(() => (Knihovny)lv1.SelectedItem);
                AddEditControl.nazev = knihovna.Nazev;
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
                     Knihovny knihovna = Dispatcher.Invoke(() => (Knihovny)lv1.SelectedItem);
            DetailOddeleni.nazev = knihovna.Nazev;
            DetailOddeleni.odd = knihovna;
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
                    KnihovnaViewModel.Knihovny.Remove((Knihovny)lv1.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Není vybráno Oddělení", "Chyba");
                }
            }else if(e.Key == Key.Enter) {
                if (lv1.SelectedItems.Count > 0)
                {
                    Knihovny knihovna = (Knihovny)lv1.SelectedItem;
                    DetailOddeleni.nazev = knihovna.Nazev;
                    DetailOddeleni.odd = knihovna;
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

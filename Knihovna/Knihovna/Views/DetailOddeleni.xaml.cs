using Knihovna.Model;
using Knihovna.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Knihovna.Views
{
    /// <summary>
    /// Interaction logic for DetailOddeleni.xaml
    /// </summary>
    public partial class DetailOddeleni : UserControl
    {
        public static string nazev;
        public static Knihovny odd;
        public DetailOddeleni()
        {
            InitializeComponent();
            foreach (var item in KnihovnaViewModel.Knihovny)
            {
                CB.Items.Add(item.Nazev);
            }
            CB.SelectedIndex = odd.Id;
            lv1.ItemsSource = Knihovna.ViewModel.ZakazniciViewModel.Zakaznici;
            lv2.ItemsSource = Knihovna.ViewModel.KnihaViewModel.Knihy;
        }

        public bool FilterZakaznik(object obj)
        {
            Zakaznik k = (Zakaznik)obj;
            if (k.KnihovnaId == odd.Id) return true;
            return false;
        }
        public bool FilterKniha(object obj)
        {
            Kniha k = (Kniha)obj;
            if (k.knId == odd.Id) return true;
            return false;
        }
        private void addKniha(object sender, RoutedEventArgs e)
        {
            AddKniha.kniha = null;
            AddKnihaW page = new AddKnihaW();
            page.Show();
            
           
        }

        private void openZakaznik(object sender, MouseButtonEventArgs e)
        {
            if (lv1.SelectedItems.Count > 0)
            {
                Vypujcka.zak = (Zakaznik)lv1.SelectedItem;

                VypujckyW page = new();
                page.ShowDialog();
                lv2.Items.Filter = FilterKniha;
            }else
            {
                MessageBox.Show("Není vybrán zákazník", "Chyba");
            }
            //Seznam vypůjčených knih
        }

        private void OpenKniha(object sender, MouseButtonEventArgs e)
        {
            if (lv2.SelectedItems.Count > 0)
            {
                AddKniha.kniha = (Kniha)lv2.SelectedItem;
                AddKnihaW page = new AddKnihaW();
                page.ShowDialog();
            }
            else
            {
                MessageBox.Show("Není vybrána kniha", "Chyba");
            }
            //v menu vypůjčit
        }

        private void JineOddeleni(object sender, SelectionChangedEventArgs e)
        {
            odd = KnihovnaViewModel.Knihovny[CB.SelectedIndex];
            lv1.Items.Filter = FilterZakaznik;

            lv2.Items.Filter = FilterKniha;
        }

        private void addZakaznik(object sender, RoutedEventArgs e)
        {
            AddZakaznik.zakaznik = null;
            Knihovna.AddZakaznik page = new Knihovna.AddZakaznik();
            page.Show();
        }
        private void editKniha(object sender, RoutedEventArgs e)
        {
            if (lv2.SelectedItems.Count > 0)
            {
                AddKniha.kniha = (Kniha)lv2.SelectedItem;
                AddKnihaW page = new AddKnihaW();
                page.ShowDialog();
            }
            else
            {
                MessageBox.Show("Není vybrána kniha", "Chyba");
            }

        }

        private void editZakaznik(object sender, RoutedEventArgs e)
        {
            if (lv1.SelectedItems.Count > 0)
            {
                AddZakaznik.zakaznik = (Zakaznik)lv1.SelectedItem;
                Knihovna.AddZakaznik page = new Knihovna.AddZakaznik();
                page.ShowDialog();
                lv1.Items.Refresh();

            }
            else
            {
                MessageBox.Show("Není vybrán zákazník", "Chyba");
            }

        }

        private void delKniha(object sender, RoutedEventArgs e)
        {
            if (lv2.SelectedItems.Count > 0)
            {
                KnihaViewModel.Knihy.Remove((Kniha)lv2.SelectedItem);
            }
            else
            {
                MessageBox.Show("Není vybrána kniha", "Chyba");
            }
        }

        private void delZakaznik(object sender, RoutedEventArgs e)
        {
            if (lv1.SelectedItems.Count > 0)
            {
                ZakazniciViewModel.Zakaznici.Remove((Zakaznik)lv1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Není vybrán zákazník", "Chyba");
            }
        }


    }
}

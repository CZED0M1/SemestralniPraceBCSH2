using Knihovna.Model;
using Knihovna.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Vypujcka.xaml
    /// </summary>
    public partial class Vypujcka : UserControl
    {
        public static Zakaznik zak=null;
        public Vypujcka()
        {
            InitializeComponent();
            lv1.Items.Filter = FilterAll;
            lv1.Items.Refresh();
            foreach (var item in ZakazniciViewModel.Zakaznici)
            {
                CB.Items.Add(item.JmenoPr);
            }
            CB.SelectedItem = zak.JmenoPr;

            lv1.ItemsSource = KnihaViewModel.Knihy;
            lv2.ItemsSource = VypujckyViewModel.Vypujcky;

        }

        private void JinyZakaznik(object sender, SelectionChangedEventArgs e)
        {
            if (ZakazniciViewModel.Zakaznici.Where(z => z.JmenoPr == CB.SelectedItem.ToString()).Any())
            {
                zak = ZakazniciViewModel.Zakaznici.Where(z => z.JmenoPr == CB.SelectedItem.ToString()).First();
                lv2.Items.Filter = FilterVypujcky;
            }
        }
        public bool FilterAll(object obj)
        {
            return true;
        }
        public bool FilterVypujcky(object obj)
        {
            Model.Vypujcka vypujcka = (Model.Vypujcka)obj;
            if (vypujcka.Zakaznik.Equals(zak))
            {
                return true;
            }
            return false;
        }



        private void VratitKnihu(object sender, RoutedEventArgs e)
        {
            if (lv2.SelectedItems.Count > 0)
            {
                Model.Vypujcka vyp = (Model.Vypujcka)lv2.SelectedItem;
                Kniha k = vyp.Kniha;
                KnihaViewModel.Knihy.Add(k);
                VypujckyViewModel.Vypujcky.Remove(vyp);
                zak = ZakazniciViewModel.Zakaznici.Where(z => z.JmenoPr == CB.SelectedItem.ToString()).First();
                zak.Vypujceno = zak.Vypujceno - 1;
            }else
            {
                MessageBox.Show("Není vybrána vypůjčená kniha", "Chyba");
            }
            

        }

        private void VypujcitKnihu(object sender, RoutedEventArgs e)
        {
            if (lv1.SelectedItems.Count > 0)
            {
                Kniha k =(Kniha)lv1.SelectedItem;
                zak = ZakazniciViewModel.Zakaznici.Where(z => z.JmenoPr == CB.SelectedItem.ToString()).First();
                Model.Vypujcka vyp = new Model.Vypujcka { Kniha = k, Zakaznik=zak };
                KnihaViewModel.Knihy.Remove(k);
                VypujckyViewModel.Vypujcky.Add(vyp);
                zak.Vypujceno = zak.Vypujceno +1;
            }
            else
            {
                MessageBox.Show("Není vybrána kniha", "Chyba");
            }


}
    }
}

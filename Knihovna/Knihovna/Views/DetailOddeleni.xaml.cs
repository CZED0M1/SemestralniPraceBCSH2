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
        public ObservableCollection<Knihovny> odd;
        public DetailOddeleni()
        {
            InitializeComponent();

            odd = KnihovnaViewModel.Knihovny;
            lv1.ItemsSource= odd[0].Knihy;
        }

        private void addKniha(object sender, RoutedEventArgs e)
        {
            Kniha k = new Kniha { Nazev = "A", Autor = "B", ISBN = "C", Vypujcena = false };
            odd[0].Knihy.Add(k);
            MessageBox.Show(odd[0].Knihy[0].Nazev);
            lv1.Items.Refresh();
        }
    }
}

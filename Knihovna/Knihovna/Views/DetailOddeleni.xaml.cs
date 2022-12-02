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
        public DetailOddeleni()
        {
            InitializeComponent();
            Knihovna.ViewModel.ZakazniciViewModel studentViewModelObject2 =
               new Knihovna.ViewModel.ZakazniciViewModel();
            studentViewModelObject2.LoadZakaznici();
            lv1.DataContext = studentViewModelObject2;
            jmenoOd.Content = "Oddělení " + nazev;

        }

        private void addKniha(object sender, RoutedEventArgs e)
        {
            Zakaznik z = new Zakaznik { Jmeno="A", Prijmeni="A" };
            Kniha k = new Kniha { Nazev = "A", Autor = "B", ISBN = "C", Vypujcena = false };
            KnihaViewModel.Knihy.Add(k);
            ZakazniciViewModel.Zakaznici.Add(z);
        }
    }
}

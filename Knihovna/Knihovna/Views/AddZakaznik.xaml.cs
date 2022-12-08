using Knihovna.Model;
using Knihovna.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddZakaznik.xaml
    /// </summary>
    public partial class AddZakaznik : UserControl
    {
        public static Zakaznik zakaznik=null;
        public AddZakaznik()
        {
            InitializeComponent();
            if (zakaznik !=null)
            {
                Name.Text = zakaznik.Jmeno;
                Surr.Text = zakaznik.Prijmeni;
                Pridat.Content = "Editovat";
            }
        }

        private void addZakaznik(object sender, RoutedEventArgs e)
        {
            if (zakaznik != null)
            {
                Zakaznik a = ZakazniciViewModel.Zakaznici.Where(x => x == zakaznik).First();
                a.Jmeno = Name.Text;
                a.Prijmeni = Surr.Text;
                a.JmenoPr = a.Jmeno + " " + a.Prijmeni;
                Knihovna.AddZakaznik.GetWindow(this).Close();
            }

            else
            {
                if (Name.Text.Length != 0 && Surr.Text.Length != 0)
                {
                    ZakazniciViewModel.Zakaznici.Add(new Model.Zakaznik { Jmeno = Name.Text, Prijmeni = Surr.Text, KnihovnaId = DetailOddeleni.odd.Id, Vypujceno = 0 });
                    Knihovna.AddZakaznik.GetWindow(this).Close();
                }
                else
                {
                    MessageBox.Show("Nejsou vyplněny všechny položky", "Chyba");
                }
            }
            
        }
    }
}

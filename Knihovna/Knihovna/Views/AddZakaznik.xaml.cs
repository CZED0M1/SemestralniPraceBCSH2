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
            Thread threadAdd = new Thread(() =>
            {
                if (zakaznik != null)
            {
                Zakaznik a = ZakazniciViewModel.Zakaznici.Where(x => x == zakaznik).First();
                    Dispatcher.Invoke(() => a.Jmeno = Name.Text);
                    Dispatcher.Invoke(() => a.Prijmeni = Surr.Text);
                    Dispatcher.Invoke(() => Knihovna.AddZakaznik.GetWindow(this).Close());
                    using (var db = new LiteDatabase(@"C:\Users\st64521\Documents\GitHub\SemestralniPraceBCSH2\Knihovna\Db\MyDb.db"))
                    {
                        var col = db.GetCollection<Zakaznik>("zakaznik");
                        {
                            col.Update(a);
                        }
                    }
                }

            else
            {
                if (Dispatcher.Invoke(() => Name.Text.Length != 0 && Surr.Text.Length != 0))
                {
                        Zakaznik a=null;
                        Dispatcher.Invoke(() => a = new Model.Zakaznik { Jmeno = Name.Text, Prijmeni = Surr.Text, KnihovnaId = DetailOddeleni.odd.Id - 1, Vypujceno = 0 });
                        Dispatcher.Invoke(() => ZakazniciViewModel.Zakaznici.Add(a));
                        using (var db = new LiteDatabase(@"C:\Users\st64521\Documents\GitHub\SemestralniPraceBCSH2\Knihovna\Db\MyDb.db"))
                        {
                            var col = db.GetCollection<Zakaznik>("zakaznik");
                            {
                                Dispatcher.Invoke(() => col.Insert(new Model.Zakaznik { Jmeno = Name.Text, Prijmeni = Surr.Text, KnihovnaId = DetailOddeleni.odd.Id - 1, Vypujceno = 0 }));
                            }
                        }

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

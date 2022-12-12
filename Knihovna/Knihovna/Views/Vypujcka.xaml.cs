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
    /// Interaction logic for Vypujcka.xaml
    /// </summary>
    public partial class Vypujcka : UserControl
    {
        public static Zakaznik zak=null;
        public Vypujcka()
        {
            InitializeComponent();
            Thread threadAdd = new Thread(() =>
            {
                lv1.Items.Filter = FilterAll;
            lv1.Items.Refresh();
            foreach (var item in ZakazniciViewModel.Zakaznici)
            {
                    Dispatcher.Invoke(() => CB.Items.Add(item.JmenoPr));
            }
                Dispatcher.Invoke(() => CB.SelectedItem = zak.JmenoPr);

                Dispatcher.Invoke(() => lv1.ItemsSource = KnihaViewModel.Knihy);
                Dispatcher.Invoke(() => lv2.ItemsSource = VypujckyViewModel.Vypujcky);
            });
            threadAdd.Start();
        }

        private void JinyZakaznik(object sender, SelectionChangedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                
                if (Dispatcher.Invoke(() => ZakazniciViewModel.Zakaznici.Where(z => z.JmenoPr == CB.SelectedItem.ToString()).Any()))
            {
                zak = Dispatcher.Invoke(() => ZakazniciViewModel.Zakaznici.Where(z => z.JmenoPr == CB.SelectedItem.ToString()).First());
                    Dispatcher.Invoke(() => lv2.Items.Filter = FilterVypujcky);
            }
            });
            threadAdd.Start();
        }
        public bool FilterAll(object obj)
        {
            return true;
        }
        public bool FilterVypujcky(object obj)
        {
            Model.Vypujcka vypujcka = (Model.Vypujcka)obj;
            if (vypujcka.Zakaznik.JmenoPr.Equals(zak.JmenoPr))
            {
                return true;
            }
            return false;
        }



        private void VratitKnihu(object sender, RoutedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                if (Dispatcher.Invoke(() => lv2.SelectedItems.Count > 0))
            {
                Model.Vypujcka vyp = Dispatcher.Invoke(() => (Model.Vypujcka)lv2.SelectedItem);
                Kniha k = vyp.Kniha;
                    Dispatcher.Invoke(() => KnihaViewModel.Knihy.Add(k));
                    using (var db = new LiteDatabase(@"E:\c#2\semestralka\Knihovna\Db\Knihy.db"))
                    {
                        var col = db.GetCollection<Kniha>("knihy");
                        {
                            col.Insert(k);
                        }
                    }
                    using (var db = new LiteDatabase(@"E:\c#2\semestralka\Knihovna\Db\Vypujcky.db"))
                    {
                        var col = db.GetCollection<Vypujcka>("vypujcky");
                        {
                            var value = Dispatcher.Invoke(() => new LiteDB.BsonValue(vyp.Id));
                            col.Delete(value);
                        }
                    }
                    Dispatcher.Invoke(() => VypujckyViewModel.Vypujcky.Remove(vyp));

                    


                    Dispatcher.Invoke(() => zak = ZakazniciViewModel.Zakaznici.Where(z => z.JmenoPr == CB.SelectedItem.ToString()).First());
                    Dispatcher.Invoke(() => zak.Vypujceno = zak.Vypujceno - 1);
                    using (var db = new LiteDatabase(@"E:\c#2\semestralka\Knihovna\Db\Zakaznici.db"))
                    {
                        var col = db.GetCollection<Zakaznik>("zakaznik");
                        {
                            col.Update(zak);
                        }
                    }
                }
                else
            {
                MessageBox.Show("Není vybrána vypůjčená kniha", "Chyba");
            }
            });
            threadAdd.Start();


        }

        private void VypujcitKnihu(object sender, RoutedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                if (Dispatcher.Invoke(() => lv1.SelectedItems.Count > 0))
            {
                Kniha k = Dispatcher.Invoke(() => (Kniha)lv1.SelectedItem);
                zak = Dispatcher.Invoke(() => ZakazniciViewModel.Zakaznici.Where(z => z.JmenoPr == CB.SelectedItem.ToString()).First());
                Model.Vypujcka vyp = new Model.Vypujcka { Kniha = k, Zakaznik=zak };
                    using (var db = new LiteDatabase(@"E:\c#2\semestralka\Knihovna\Db\Knihy.db"))
                    {
                        var col = db.GetCollection<Kniha>("knihy");
                        {
                            var value = Dispatcher.Invoke(() => new LiteDB.BsonValue(k.Id));
                            col.Delete(value);
                        }
                    }
                    using (var db = new LiteDatabase(@"E:\c#2\semestralka\Knihovna\Db\Vypujcky.db"))
                    {
                        var col = db.GetCollection<Model.Vypujcka>("vypujcky");
                        {
                            col.Insert(vyp);
                        }
                    }
                    Dispatcher.Invoke(() => KnihaViewModel.Knihy.Remove(k));
                    Dispatcher.Invoke(() => VypujckyViewModel.Vypujcky.Add(vyp));
                    Dispatcher.Invoke(() => zak.Vypujceno = zak.Vypujceno +1);
                    using (var db = new LiteDatabase(@"E:\c#2\semestralka\Knihovna\Db\Zakaznici.db"))
                    {
                        var col = db.GetCollection<Zakaznik>("zakaznik");
                        {
                            col.Update(zak);
                        }
                    }
                }
            else
            {
                MessageBox.Show("Není vybrána kniha", "Chyba");
            }
            });
            threadAdd.Start();


        }
    }
}

using Knihovna.Model;
using Knihovna.ViewModel;
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
    /// Interaction logic for AddKniha.xaml
    /// </summary>
    public partial class AddKniha : UserControl
    {
        public static Kniha kniha = null;
        public AddKniha()
        {
            InitializeComponent();
            Thread threadAdd = new Thread(() =>
            {
                if (kniha!= null)
            {
                    Dispatcher.Invoke(() => Name.Text = kniha.Nazev);
                    Dispatcher.Invoke(() => auth.Text = kniha.Autor);
                    Dispatcher.Invoke(() => isbn.Text = kniha.ISBN);
                    Dispatcher.Invoke(() => Pridat.Content = "Editovat");
            }
            });
            threadAdd.Start();
        }


        private void addKniha(object sender, RoutedEventArgs e)
        {
            Thread threadAdd = new Thread(() =>
            {
                if (kniha != null)
            {
                Kniha a = KnihaViewModel.Knihy.Where(x => x == kniha).First();
                    Dispatcher.Invoke(() => a.Nazev = Name.Text);
                    Dispatcher.Invoke(() => a.Autor = auth.Text);
                    Dispatcher.Invoke(() => a.ISBN = isbn.Text);
                    Dispatcher.Invoke(() => AddKnihaW.GetWindow(this).Close());
            }
            else
            {


                if (Dispatcher.Invoke(() => Name.Text.Length != 0  && auth.Text.Length != 0 && isbn.Text.Length != 0))
                {
                        Dispatcher.Invoke(() => KnihaViewModel.Knihy.Add(new Model.Kniha { Nazev = Name.Text, Autor = auth.Text, ISBN = isbn.Text, knId = DetailOddeleni.odd.Id}));
                        Dispatcher.Invoke(()=> AddKnihaW.GetWindow(this).Close());
                    }
                else
                {
                    MessageBox.Show("Nejsou vyplněny všechny položky", "Chyba");
                }
                kniha = null;
            }
            });
            threadAdd.Start();
        }
    }
}

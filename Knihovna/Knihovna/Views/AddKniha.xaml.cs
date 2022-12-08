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
    /// Interaction logic for AddKniha.xaml
    /// </summary>
    public partial class AddKniha : UserControl
    {
        public static Kniha kniha = null;
        public AddKniha()
        {
            InitializeComponent();
            if (kniha!= null)
            {
                Name.Text = kniha.Nazev;
                auth.Text = kniha.Autor;
                isbn.Text = kniha.ISBN;
                Pridat.Content = "Editovat";
            }
        }


        private void addKniha(object sender, RoutedEventArgs e)
        {
            if (kniha != null)
            {
                Kniha a = KnihaViewModel.Knihy.Where(x => x == kniha).First();
                a.Nazev = Name.Text;
                a.Autor = auth.Text;
                a.ISBN = isbn.Text;
                AddKnihaW.GetWindow(this).Close();
            }
            else
            {


                if (Name.Text.Length != 0 && auth.Text.Length != 0 && isbn.Text.Length != 0)
                {
                    KnihaViewModel.Knihy.Add(new Model.Kniha { Nazev = Name.Text, Autor = auth.Text, ISBN = isbn.Text, knId = DetailOddeleni.odd.Id});
                    AddKnihaW.GetWindow(this).Close();
                }
                else
                {
                    MessageBox.Show("Nejsou vyplněny všechny položky", "Chyba");
                }
                kniha = null;
            }
        }
    }
}

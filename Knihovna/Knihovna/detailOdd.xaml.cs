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
using System.Windows.Shapes;

namespace Knihovna
{
    /// <summary>
    /// Interaction logic for detailOdd.xaml
    /// </summary>
    public partial class detailOdd : Window
    {
        public detailOdd()
        {
            InitializeComponent();
        }
        private void Knihy_Loaded(object sender, RoutedEventArgs e)
        {
            Knihovna.ViewModel.KnihaViewModel studentViewModelObject =
               new Knihovna.ViewModel.KnihaViewModel();
            studentViewModelObject.LoadKnihy();

            DetailOdd.DataContext = KnihovnaViewModel.Knihovny[0].Knihy;

        }
    }
}

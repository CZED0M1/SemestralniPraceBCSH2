using Knihovna.Model;
using Knihovna.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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
    /// Interaction logic for KnihovnaControl.xaml
    /// </summary>
    public partial class KnihovnaControl : UserControl
    {
        public KnihovnaControl()
        {
            InitializeComponent();
        }

        //ADD
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add page = new Add();
            page.Show();
        }

        //DELETE
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            KnihovnaViewModel.removeKnihovny((Knihovny)lv1.SelectedItem);
        }

        //EDIT
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Knihovny knihovna = (Knihovny)lv1.SelectedItem;
            Add page = new Add(knihovna);
            page.Show();
        }
    }
}

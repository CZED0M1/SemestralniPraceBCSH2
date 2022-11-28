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
    /// Interaction logic for AddEditControl.xaml
    /// </summary>
    public partial class AddEditControl : UserControl
    {
        public AddEditControl()
        {
            InitializeComponent();
            if (Add.knihovna!=null)OddName.Text = Add.knihovna.Nazev;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //thread a dispatcher + bool open
            if (Add.knihovna == null)
            {
                Knihovny a = new Knihovny { Nazev = OddName.Text };
                KnihovnaViewModel.addKnihovny(a);
                Add.GetWindow(this).Close();
                Add.knihovna = null;
            } else
            {
                Add.knihovna.Nazev = OddName.Text;
                Add.GetWindow(this).Close();
            }
        }
    }
}

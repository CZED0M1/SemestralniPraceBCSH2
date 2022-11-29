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
    /// Interaction logic for AddEditControl.xaml
    /// </summary>
    public partial class AddEditControl : UserControl
    {
        public static string nazev="";
        public AddEditControl()
        {
            
            InitializeComponent();

                OddName.Text = nazev;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Thread uselessThreadExample = new Thread(() =>
                {
                    Knihovny? a = null;
                    //thread a dispatcher + bool open
                    if (KnihovnaViewModel.Knihovny.Where(x => x.Nazev == nazev).Any())
                        a = KnihovnaViewModel.Knihovny.Where(x => x.Nazev == nazev).First();

                    if (a == null)
                    {
                        a =  new Knihovny { Nazev = OddName.Text };
                        KnihovnaViewModel.addKnihovny(a);
                        //Add.GetWindow(this).Close();

                    }
                    else
                    {
                        a.Nazev = OddName.Text;
                        //Add.GetWindow(this).Close();
                        nazev = "";
                    }
                    Dispatcher.Invoke(() => Add.GetWindow(this).Close());
                });
                uselessThreadExample.Start();
            }catch(Exception)
            {

            }
        }
    }
}

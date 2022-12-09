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
    /// Interaction logic for AddEditControl.xaml
    /// </summary>
    public partial class AddEditControl : UserControl
    {
        public static string nazev="";
        public AddEditControl()
        {
            
            InitializeComponent();
            Thread threadAdd = new Thread(() =>
            {
                Dispatcher.Invoke(() => OddName.Text = nazev);
            if(nazev!="")
            {
                    Dispatcher.Invoke(() => Pridat.Content = "Editovat");
            }
            });
            threadAdd.Start();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Thread threadAdd = new Thread(() =>
                {
                Knihovny? a = null;
                //thread a dispatcher + bool open
                if (KnihovnaViewModel.Knihovny.Where(x => x.Nazev == nazev).Any())
                    a = KnihovnaViewModel.Knihovny.Where(x => x.Nazev == nazev).First();

                if (a == null)
                {


                    Dispatcher.Invoke(() => KnihovnaViewModel.addKnihovny(new Knihovny { Nazev = OddName.Text }));
                    using (var db = new LiteDatabase(@"E:\c#2\semestralka\Knihovna\Db\Oddeleni.db"))
                    {
                        var col = db.GetCollection<Knihovny>("knihovny");
                            col.Insert(KnihovnaViewModel.Knihovny[KnihovnaViewModel.Knihovny.Count-1]);
                        }
                    }
                    else
                    {
                        Dispatcher.Invoke(() => a.Nazev = OddName.Text);
                        nazev = "";
                        using (var db = new LiteDatabase(@"E:\c#2\semestralka\Knihovna\Db\Oddeleni.db"))
                        {
                            var col = db.GetCollection<Knihovny>("knihovny");
                            col.Update(a);
                        }
                    }
                    Dispatcher.Invoke(() => Add.GetWindow(this).Close());
                });
                threadAdd.Start();
            }catch(Exception)
            {

            }
        }
    }
}

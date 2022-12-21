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
        public static string name="";
        public AddEditControl()
        {
            
            InitializeComponent();
            Thread threadAdd = new Thread(() =>
            {
                Dispatcher.Invoke(() => OddName.Text = name);
            if(name!="")
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
                Library? a = null;
                if (LibraryViewModel.Libraries.Where(x => x.Name == name).Any())
                    a = LibraryViewModel.Libraries.Where(x => x.Name == name).First();

                    if (a == null)
                    {


                        Dispatcher.Invoke(() => LibraryViewModel.addLibrary(new Library { Name = OddName.Text }));

                        LibraryViewModel.LibraryManager.addLibrary(LibraryViewModel.Libraries[LibraryViewModel.Libraries.Count - 1]);
                    }
                    else
                    {
                        Dispatcher.Invoke(() => a.Name = OddName.Text);
                        name = "";

                        LibraryViewModel.LibraryManager.editLibrary(a);
                    
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

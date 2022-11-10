using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.Model
{
    internal class KnihovnaModel
    {
    }
    public class Knihovny : INotifyPropertyChanged
    {
        private string nazev;
        private ObservableCollection<Kniha>? knihy;
        private ObservableCollection<Vypujcka>? vypujceneKnihy;
        private ObservableCollection<Zakaznik>? zakaznici;


        public ObservableCollection<Zakaznik> Zakaznici
        {
            get { return zakaznici; }

            set
            {
                zakaznici = value;
                RaisePropertyChanged("zakaznici");
            }
        }
        public string Nazev
        {
            get
            {
                return nazev;
            }
            set
            {
                if (nazev != value)
                {
                    nazev = value;
                    RaisePropertyChanged("nazev");
                }
            }
        }
        public ObservableCollection<Kniha> Knihy
        {
            get { return knihy; }

            set
            {
                knihy = value;
                RaisePropertyChanged("isbn");
            }
        }
        public ObservableCollection<Vypujcka> VypujceneKnihy
        {
            get { return vypujceneKnihy; }

            set
            {
                vypujceneKnihy = value;
                RaisePropertyChanged("autor");
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}



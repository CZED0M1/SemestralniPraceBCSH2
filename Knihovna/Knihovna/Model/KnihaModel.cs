using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Knihovna.Model
{
    internal class KnihaModel {}
    public class Kniha : INotifyPropertyChanged
    {
        private string nazev;
        private bool vypujcena;
        private string isbn;
        private string autor;
        private int knihovnaId;

        public int knId
        {
            get
            {
                return knihovnaId;
            }
            set
            {
                    knihovnaId =value;
                    RaisePropertyChanged("knihovnaId");
                
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
        public string ISBN
        {
            get { return isbn; }

            set
            {
                isbn = value;
                    RaisePropertyChanged("isbn");
                }
            }
        public string Autor
        {
            get { return autor; }

            set
            {
                autor = value;
                RaisePropertyChanged("autor");
            }
        }
        public bool Vypujcena
        {
            get { return vypujcena; }

            set
            {
                vypujcena = value;
                RaisePropertyChanged("vypujcena");
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

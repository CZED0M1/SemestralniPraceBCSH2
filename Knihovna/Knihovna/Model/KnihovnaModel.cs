using Knihovna.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private int id;

        public Knihovny()
        {
        }

        public Knihovny(string nazev, int id)
        {
            Nazev = nazev;
            this.id = id;
        }

        public Knihovny(string nazev)
        {
            id = KnihovnaViewModel.Knihovny.Count();
            Nazev = nazev;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("id");
                }
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



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.Model
{
    public class VypujckyModel
    {
    }
    public class Vypujcka : INotifyPropertyChanged
    {
        private Kniha kniha;
        private Zakaznik zakaznik;
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }


        public Zakaznik Zakaznik
        {
            get
            {
                return zakaznik;
            }
            set
            {
                if (zakaznik != value)
                {
                    zakaznik = value;
                    RaisePropertyChanged("zakaznik");
                }
            }
        }
        public Kniha Kniha
        {
            get { return kniha; }

            set
            {
                if (kniha != value)
                {
                    kniha = value;
                    RaisePropertyChanged("kniha");
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



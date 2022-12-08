using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.Model
{
    public class ZakazniciModel
    {
    }
    public class Zakaznik : INotifyPropertyChanged
    {
        private string jmeno;
        private string prijmeni;
        private int vypujceno;
        private int knihovnaId;

        public int KnihovnaId
        {
            get
            {
                return knihovnaId;
            }
            set
            {
                knihovnaId = value;
                RaisePropertyChanged("knihovna");

            }
        }

        public int Vypujceno
        {
            get
            {
                return vypujceno;
            }
            set
            {
                    vypujceno = value;
                    RaisePropertyChanged("vypujceno");
                
            }
        }
        public string JmenoPr
        {
            get
            {
                return jmeno + " " + prijmeni;
            }
            set
            {
                if (JmenoPr != value)
                {
                    JmenoPr = value;
                    RaisePropertyChanged("jmenoPr");
                }
            }
        }
        public string Jmeno
        {
            get
            {
                return jmeno;
            }
            set
            {
                if (jmeno != value)
                {
                    jmeno = value;
                    RaisePropertyChanged("jmeno");
                }
            }
        }
        public string Prijmeni
        {
            get { return prijmeni; }

            set
            {
                if (prijmeni != value)
                {
                    prijmeni = value;
                    RaisePropertyChanged("prijmeni");
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



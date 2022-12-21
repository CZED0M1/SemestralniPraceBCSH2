using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.Model
{
    public class CustomerModel
    {
    }
    public class Customer : INotifyPropertyChanged
    {
        private string name;
        private string surrname;
        private int borrowed;
        private int libraryId;
        private int id;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }

        public int LibraryId
        {
            get
            {
                return libraryId;
            }
            set
            {
                libraryId = value;
                RaisePropertyChanged("knihovna");

            }
        }

        public int Borrowed
        {
            get
            {
                return borrowed;
            }
            set
            {
                    borrowed = value;
                    RaisePropertyChanged("borrowed");
                
            }
        }
        public string NameSur
        {
            get
            {
                return name + " " + surrname;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("name");
                }
            }
        }
        public string Surrname
        {
            get { return surrname; }

            set
            {
                if (surrname != value)
                {
                    surrname = value;
                    RaisePropertyChanged("surrname");
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



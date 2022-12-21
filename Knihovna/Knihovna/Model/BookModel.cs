using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Knihovna.Model
{
    internal class BookModel {}
    public class Book : INotifyPropertyChanged
    {
        private string nazev;
        private string isbn;
        private string autor;
        private int knihovnaId;
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

        public int lbId
        {
            get
            {
                return knihovnaId;
            }
            set
            {
                    knihovnaId =value;
                    RaisePropertyChanged("libraryId");
                
            }
        }

        public string Name
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
                    RaisePropertyChanged("name");
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
        public string Author
        {
            get { return autor; }

            set
            {
                autor = value;
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

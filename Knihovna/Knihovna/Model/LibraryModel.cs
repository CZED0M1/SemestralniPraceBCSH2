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
    internal class LibraryModel
    {
    }

    public class Library : INotifyPropertyChanged
    {
        private string name;
        private int id;

        public Library()
        {
        }

        public Library(string nazev, int id)
        {
            Name = nazev;
            this.id = id;
        }

        public Library(string nazev)
        {
            id = LibraryViewModel.Libraries.Count();
            Name = nazev;
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



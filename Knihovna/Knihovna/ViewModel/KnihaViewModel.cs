using Knihovna.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Knihovna.ViewModel
{
    public class KnihaViewModel
    {
        public ObservableCollection<Kniha> Knihy
        {
            get;
            set;
        }
        public void LoadKnihy()
        {
            ObservableCollection<Kniha> knihy = new ObservableCollection<Kniha>();

            knihy.Add(new Kniha {Nazev= "RUR", ISBN = "AB", Autor = "KA" });
            knihy.Add(new Kniha { Nazev = "RUdag", ISBN = "CD", Autor = "Ks" });
            knihy.Add(new Kniha { Nazev = "RUadgs", ISBN = "EF", Autor = "asgd" });
            KnihovnaViewModel.Knihovny[0].Knihy = knihy;
        }
    }
}

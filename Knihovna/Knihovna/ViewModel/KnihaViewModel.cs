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
        public static ObservableCollection<Kniha> Knihy
        {
            get;
            set;
        }
        public static void LoadKnihy()
        {

            Knihy.Add(new Kniha {Nazev= "RUR", ISBN = "AB", Autor = "KA",knId = 0 });
            Knihy.Add(new Kniha { Nazev = "RUdag", ISBN = "CD", Autor = "Ks",knId=1 });
            Knihy.Add(new Kniha { Nazev = "RUadgs", ISBN = "EF", Autor = "asgd", knId = 0 });
        }
    }
}

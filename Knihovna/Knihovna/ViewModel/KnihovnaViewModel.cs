using Knihovna.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.ViewModel
{
    public class KnihovnaViewModel
    {
        public static ObservableCollection<Knihovny>? Knihovny
        {
            get;
            set;
        }
        public void LoadKnihovny()
        {
            ObservableCollection<Knihovny> knihovny = new ObservableCollection<Knihovny>();

            knihovny.Add(new Knihovny { Nazev = "A"});
            knihovny.Add(new Knihovny { Nazev = "B" });
            knihovny.Add(new Knihovny { Nazev = "C" });

            Knihovny = knihovny;
        }
    }
}

using Knihovna.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.ViewModel
{
    public class VypujckyViewModel
    {
        public ObservableCollection<Vypujcka> Vypujcky
        {
            get;
            set;
        }
        public void LoadVypujcky()
        {
            ObservableCollection<Vypujcka> vypujcky = new ObservableCollection<Vypujcka>();
            Kniha kn = new Kniha { Nazev = "Tricky", Autor = " DL", ISBN = "AGAFDG" };
            Kniha kn2 = new Kniha { Nazev = "IdontKnow", Autor = " asdg", ISBN = "Aadg" };
            Kniha kn3 = new Kniha { Nazev = "Trickyadsg", Autor = " DagdsL", ISBN = "AGAagdsFDG" };
            vypujcky.Add(new Vypujcka {Kniha=kn,Zakaznik= KnihovnaViewModel.Knihovny[0].Zakaznici[0]});
            vypujcky.Add(new Vypujcka { Kniha = kn2, Zakaznik = KnihovnaViewModel.Knihovny[0].Zakaznici[1] });
            vypujcky.Add(new Vypujcka { Kniha = kn3, Zakaznik = KnihovnaViewModel.Knihovny[0].Zakaznici[0] });

            KnihovnaViewModel.Knihovny[0].VypujceneKnihy = vypujcky;
        }
    }
}

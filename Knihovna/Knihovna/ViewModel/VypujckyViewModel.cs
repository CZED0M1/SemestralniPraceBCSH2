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
        public static ObservableCollection<Vypujcka> Vypujcky
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
            vypujcky.Add(new Vypujcka {Kniha=kn,Zakaznik= ZakazniciViewModel.Zakaznici[0] });
            vypujcky.Add(new Vypujcka { Kniha = kn2, Zakaznik = ZakazniciViewModel.Zakaznici[1] });
            vypujcky.Add(new Vypujcka { Kniha = kn3, Zakaznik = ZakazniciViewModel.Zakaznici[0] });

            VypujckyViewModel.Vypujcky = vypujcky;
        }
    }
}

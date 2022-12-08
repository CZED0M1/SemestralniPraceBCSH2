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
        public static void LoadVypujcky()
        {
            Kniha kn = new Kniha { Nazev = "Tricky", Autor = " DL", ISBN = "AGAFDG",knId=0 };
            Kniha kn2 = new Kniha { Nazev = "IdontKnow", Autor = " asdg", ISBN = "Aadg", knId = 1 };
            Kniha kn3 = new Kniha { Nazev = "Trickyadsg", Autor = " DagdsL", ISBN = "AGAagdsFDG", knId = 0 };
            Vypujcky.Add(new Vypujcka {Kniha=kn,Zakaznik= ZakazniciViewModel.Zakaznici[0] });
            Vypujcky.Add(new Vypujcka { Kniha = kn2, Zakaznik = ZakazniciViewModel.Zakaznici[1] });
            Vypujcky.Add(new Vypujcka { Kniha = kn3, Zakaznik = ZakazniciViewModel.Zakaznici[0] });
            ZakazniciViewModel.Zakaznici[0].Vypujceno = 2;
            ZakazniciViewModel.Zakaznici[1].Vypujceno = 1;

        }
    }
}

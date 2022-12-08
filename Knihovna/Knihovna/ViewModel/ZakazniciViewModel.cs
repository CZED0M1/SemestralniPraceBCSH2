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
    public class ZakazniciViewModel
    {
        public static ObservableCollection<Zakaznik>? Zakaznici
        {
            get;
            set;
        }
        public static void LoadZakaznici()
        {

            Zakaznici.Add(new Zakaznik { Jmeno="Dominik", Prijmeni="Lopauer", KnihovnaId=0});
            Zakaznici.Add(new Zakaznik { Jmeno = "Pavel", Prijmeni = "Horňak", KnihovnaId = 1 });
            Zakaznici.Add(new Zakaznik { Jmeno = "Petr", Prijmeni = "Dolňak", KnihovnaId = 1 });
        }
    }
}

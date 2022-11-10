using Knihovna.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.ViewModel
{
    public class ZakazniciViewModel
    {
        public ObservableCollection<Zakaznik>? Zakaznici
        {
            get;
            set;
        }
        public void LoadZakaznici()
        {
            ObservableCollection<Zakaznik> zakaznici = new ObservableCollection<Zakaznik>();

            zakaznici.Add(new Zakaznik { Jmeno="Dominik", Prijmeni="Lopauer"});
            zakaznici.Add(new Zakaznik { Jmeno = "Pavel", Prijmeni = "Horňak" });
            zakaznici.Add(new Zakaznik { Jmeno = "Petr", Prijmeni = "Dolňak" });

            KnihovnaViewModel.Knihovny[0].Zakaznici = zakaznici;
        }
    }
}

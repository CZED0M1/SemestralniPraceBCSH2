using Knihovna.Managers;
using Knihovna.Model;
using Knihovna.Views;
using LiteDB;
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
        public static ZakaznikManager Zakaznik_Manager { get; set; }
        public static void LoadZakaznici(Repository repository)
        {



            ZakaznikManager zakaznikManager = new(repository);
            Zakaznik_Manager = zakaznikManager;
            if (zakaznikManager.get_Zakaznik().Count() == 0)
            {
                Zakaznici.Add(new Zakaznik { Jmeno = "Dominik", Prijmeni = "Lopauer", KnihovnaId = 0 });
                Zakaznici.Add(new Zakaznik { Jmeno = "Pavel", Prijmeni = "Horňak", KnihovnaId = 1 });
                Zakaznici.Add(new Zakaznik { Jmeno = "Petr", Prijmeni = "Dolňak", KnihovnaId = 1 });
                ZakazniciViewModel.Zakaznici[0].Vypujceno = 2;
                ZakazniciViewModel.Zakaznici[1].Vypujceno = 1;

                foreach (var item in Zakaznici)
                {
                    zakaznikManager.add_Zakaznik(item);
                }
            }
            else
            {

                IEnumerable<Zakaznik> Kn = zakaznikManager.get_Zakaznik();
                foreach (var item in Kn)
                {
                    Zakaznici.Add(item);
                }
            }
        }
    }
}
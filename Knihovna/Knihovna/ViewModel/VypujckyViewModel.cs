using Knihovna.Managers;
using Knihovna.Model;
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
    public class VypujckyViewModel
    {
        public static ObservableCollection<Vypujcka> Vypujcky
        {
            get;
            set;
        }
        public static VypujckaManager Vypujcka_Manager { get; set; }
        public static void LoadVypujcky(Repository repository)
        {


            VypujckaManager vypujckaManager = new(repository);
            Vypujcka_Manager = vypujckaManager;
            if (vypujckaManager.get_Vypujcka().Count() == 0)
            {
                Kniha kn = new Kniha { Nazev = "S kouzelnickou hůlkou", Autor = "Felton Tom", ISBN = "263236236", knId = 4 };
                Kniha kn2 = new Kniha { Nazev = "Aristokratka pod palbou lásky", Autor = " Evžen Boček", ISBN = "8935882", knId = 4 };
                Kniha kn3 = new Kniha { Nazev = "Přátelé, lásky a ten ohromný průšvih", Autor = "Perry Matthew", ISBN = "53158923", knId = 4 };
                Vypujcky.Add(new Vypujcka { Kniha = kn, Zakaznik = ZakazniciViewModel.Zakaznici[0] });
                Vypujcky.Add(new Vypujcka { Kniha = kn2, Zakaznik = ZakazniciViewModel.Zakaznici[1] });
                Vypujcky.Add(new Vypujcka { Kniha = kn3, Zakaznik = ZakazniciViewModel.Zakaznici[0] });

                foreach (var item in Vypujcky)
                {
                    vypujckaManager.add_Vypujcka(item);
                }
            }
            else
            {

                IEnumerable<Vypujcka> Kn = vypujckaManager.get_Vypujcka();
                foreach (var item in Kn)
                {
                    Vypujcky.Add(item);
                }
            }
        }
    }
}
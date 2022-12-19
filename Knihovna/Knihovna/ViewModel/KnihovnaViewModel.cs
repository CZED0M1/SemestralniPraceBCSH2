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
    public class KnihovnaViewModel
    {
        public static ObservableCollection<Knihovny> Knihovny
        {
            get;
            set;
        }
        public static KnihovnaManager Knihovna_Manager { get; set; }
        public static void LoadKnihovny(Repository repo)
        {
            KnihovnaManager knihovnaManager = new(repo);
            Knihovna_Manager= knihovnaManager;
            if (knihovnaManager.get_Knihovny().Count() == 0)
            {
                Knihovny.Add(new Knihovny { Nazev = "A", Id = 1 });
                Knihovny.Add(new Knihovny { Nazev = "B", Id = 2 });
                Knihovny.Add(new Knihovny { Nazev = "C", Id = 3 });
                Knihovny.Add(new Knihovny { Nazev = "D", Id = 4 });
                Knihovny.Add(new Knihovny { Nazev = "E", Id = 5 });
                Knihovny.Add(new Knihovny { Nazev = "F", Id = 6 });

                foreach (var item in Knihovny)
                {
                    knihovnaManager.add_Knihovna(item);
                }

            }
            else
            {

                    IEnumerable<Knihovny> Kn = knihovnaManager.get_Knihovny();
                    foreach (var item in Kn)
                    {
                        Knihovny.Add(item);
                    }
                }
            }
        
        
        public static void addKnihovny(Knihovny knihovna)
        {
            
            Knihovny.Add(knihovna);
        }

        public static void removeKnihovny(Knihovny knihovna)
        {
            var bookToDelete = KnihaViewModel.Knihy.Where(k => k.knId == knihovna.Id).ToList();
            var CustToDelete = ZakazniciViewModel.Zakaznici.Where(z => z.KnihovnaId == knihovna.Id).ToList();
            foreach (var book in bookToDelete)
            {
                KnihaViewModel.Knihy.Remove(book);
                KnihaViewModel.Kniha_Manager.remove_Kniha(book);
            }
            foreach (var zak in CustToDelete)
            {
                ZakazniciViewModel.Zakaznici.Remove(zak);
                ZakazniciViewModel.Zakaznik_Manager.remove_Zakaznik(zak);
            }

                Knihovna_Manager.remove_Knihovna(knihovna);
                Knihovny.Remove(knihovna);
        }
    }
}

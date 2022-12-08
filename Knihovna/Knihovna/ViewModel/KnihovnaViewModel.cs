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
    public class KnihovnaViewModel
    {
        public static ObservableCollection<Knihovny> Knihovny
        {
            get;
            set;
        }
        public static void LoadKnihovny()
        {
            Knihovny = new ObservableCollection<Knihovny>();
            Knihovny.Add(new Knihovny { Nazev = "A", Id=0});
            Knihovny.Add(new Knihovny { Nazev = "B", Id = 1 });
            Knihovny.Add(new Knihovny { Nazev = "C",Id = 2 });
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
            }
            foreach (var zak in CustToDelete)
            {
                ZakazniciViewModel.Zakaznici.Remove(zak);
            }
            
            Knihovny.Remove(knihovna);
        }
    }
}

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
    public class ZakazniciViewModel
    {
        public static ObservableCollection<Zakaznik>? Zakaznici
        {
            get;
            set;
        }
        public static void LoadZakaznici()
        {

            //Zakaznici.Add(new Zakaznik { Jmeno = "Dominik", Prijmeni = "Lopauer", KnihovnaId = 0 });
            //Zakaznici.Add(new Zakaznik { Jmeno = "Pavel", Prijmeni = "Horňak", KnihovnaId = 1 });
            //Zakaznici.Add(new Zakaznik { Jmeno = "Petr", Prijmeni = "Dolňak", KnihovnaId = 1 });
            //ZakazniciViewModel.Zakaznici[0].Vypujceno = 2;
            //ZakazniciViewModel.Zakaznici[1].Vypujceno = 1;

            //using (var db = new LiteDatabase(@"E:\c#2\semestralka\Knihovna\Db\Zakaznici.db"))
            //{
            //    var col = db.GetCollection<Zakaznik>("zakaznik");
            //    foreach (var item in Zakaznici)
            //    {
            //        col.Insert(item);
            //    }
            //}


            using (var db = new LiteDatabase(@"E:\c#2\semestralka\Knihovna\Db\Zakaznici.db"))
            {
                var col = db.GetCollection<Zakaznik>("zakaznik");
                {
                    IEnumerable<Zakaznik> Kn = col.FindAll();
                    foreach (var item in Kn)
                    {
                        Zakaznici.Add(item);
                    }
                }
            }
        }
    }
}
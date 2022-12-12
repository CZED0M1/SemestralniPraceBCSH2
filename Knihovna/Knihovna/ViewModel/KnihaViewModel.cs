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
    public class KnihaViewModel
    {
        public static ObservableCollection<Kniha> Knihy
        {
            get;
            set;
        }
        public static void LoadKnihy()
        {

            //Knihy.Add(new Kniha { Nazev = "Harry Potter", ISBN = "1241241", Autor = "J.K. Rowlingová", knId = 1 });
            //Knihy.Add(new Kniha { Nazev = "RUR", ISBN = "1251361", Autor = "Karel Čapek", knId = 1 });
            //Knihy.Add(new Kniha { Nazev = "Osudné svědectví", ISBN = "4276247", Autor = "Robert Bryndza", knId = 2 });
            //Knihy.Add(new Kniha { Nazev = "Pavouk", ISBN = "4213247", Autor = "Lars Kepler", knId = 2 });
            //Knihy.Add(new Kniha { Nazev = "Znamenitá mrtvola", ISBN = "2351356", Autor = "Agustina Bazterrica", knId = 2 });
            //Knihy.Add(new Kniha { Nazev = "Čarodějnictví pro každý den", ISBN = "672175798", Autor = "Deborah Blake", knId = 5 });
            //Knihy.Add(new Kniha { Nazev = "Nové Pohledy", ISBN = "99129351", Autor = "Alastair Bonnett", knId = 6 });
            //using (var db = new LiteDatabase(@"C:\Users\st64521\Documents\GitHub\SemestralniPraceBCSH2\Knihovna\Db\MyDb.db"))
            //{
            //    var col = db.GetCollection<Kniha>("knihy");
            //    foreach (var item in Knihy)
            //    {
            //        col.Insert(item);
            //    }
            //}
            // Databaze trida - jednou vytvorit litedabatabase
            //db repository manager



            using (var db = new LiteDatabase(@"C:\Users\st64521\Documents\GitHub\SemestralniPraceBCSH2\Knihovna\Db\MyDb.db"))
            {
                var col = db.GetCollection<Kniha>("knihy");
                {

                    IEnumerable<Kniha> Kn = col.FindAll();
                    foreach (var item in Kn)
                    {
                        Knihy.Add(item);
                    }
                }
            }
        }
    }
}



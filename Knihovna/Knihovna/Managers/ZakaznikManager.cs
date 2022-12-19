using Knihovna.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.Managers
{
   public class ZakaznikManager
    {
        Repo<Zakaznik>  Zakaznik_Repository
        {
            get; set;
        }

        public ZakaznikManager(Repository repo)
        {
            Zakaznik_Repository = new();
            Zakaznik_Repository.col = repo.GetInstance().GetCollection<Zakaznik>("zakaznik");
        }

        public void add_Zakaznik(Zakaznik zakaznik)
        {
            Zakaznik_Repository.Add(zakaznik);
        }
        public void remove_Zakaznik(Zakaznik zakaznik)
        {
            Zakaznik_Repository.RemoveById(zakaznik.Id);
        }
        public void edit_Zakaznik(Zakaznik zakaznik)
        {
            Zakaznik_Repository.UpdateById(zakaznik);
        }
        public ObservableCollection<Zakaznik> get_Zakaznik()
        {

            return Zakaznik_Repository.GetAll();
        }
        public Zakaznik get_Zakaznik_By_Id(int id)
        {
            return Zakaznik_Repository.GetById(id);
        }
    }
}

using Knihovna.Model;
using Knihovna.ViewModel;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.Managers
{
    internal class KnihovnaManager
    {
        Repo<Knihovny> Knihovna_Repository 
        {
            get ; set;
        }

        public KnihovnaManager(Repository repo)
        {
            Knihovna_Repository = new();
            Knihovna_Repository.col = repo.GetInstance().GetCollection<Knihovny>("knihovna");
        }

        public void add_Knihovna(Knihovny knihovna)
        {
            Knihovna_Repository.Add(knihovna);
        }
        public void remove_Knihovna(Knihovny knihovna)
        {
            Knihovna_Repository.RemoveById(knihovna);
        }
        public void edit_Knihovna(Knihovny knihovna)
        {
            Knihovna_Repository.RemoveById(knihovna);
        }
        public ObservableCollection<Knihovny> get_Knihovny()
        {
           
            return Knihovna_Repository.GetAll();
        }
        public Knihovny get_Knihovna_By_Id(int id)
        {
           return Knihovna_Repository.GetById(id);
        }
    }
}

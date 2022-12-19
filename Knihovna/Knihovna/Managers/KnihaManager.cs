using Knihovna.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.Managers
{
    public  class KnihaManager
    {
       Repo<Kniha> Kniha_Repository
        {
            get; set;
        }

        public KnihaManager(Repository repo)
        {
            Kniha_Repository = new();
            Kniha_Repository.col = repo.GetInstance().GetCollection<Kniha>("kniha");
        }

        public void add_Kniha(Kniha kniha)
        {
            Kniha_Repository.Add(kniha);
        }
        public void remove_Kniha(Kniha kniha)
        {
            Kniha_Repository.RemoveById(kniha.Id);
        }
        public void edit_Kniha(Kniha kniha)
        {
            Kniha_Repository.UpdateById(kniha);
        }
        public ObservableCollection<Kniha> get_Kniha()
        {

            return Kniha_Repository.GetAll();
        }
        public Kniha get_Kniha_By_Id(int id)
        {
            return Kniha_Repository.GetById(id);
        }
    }
}

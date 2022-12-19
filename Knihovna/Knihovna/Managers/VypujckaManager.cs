using Knihovna.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.Managers
{
    public class VypujckaManager
    {
        Repo<Vypujcka> Vypujcka_Repository
        {
            get; set;
        }

        public VypujckaManager(Repository repo)
        {
            Vypujcka_Repository = new();
            Vypujcka_Repository.col = repo.GetInstance().GetCollection<Vypujcka>("vypujcka");
        }

        public void add_Vypujcka(Vypujcka vypujcka)
        {
            Vypujcka_Repository.Add(vypujcka);
        }
        public void remove_Vypujcka(Vypujcka vypujcka)
        {
            Vypujcka_Repository.RemoveById(vypujcka.Id);
        }
        public void edit_Vypujcka(Vypujcka vypujcka)
        {
            Vypujcka_Repository.UpdateById(vypujcka);
        }
        public ObservableCollection<Vypujcka> get_Vypujcka()
        {

            return Vypujcka_Repository.GetAll();
        }
        public Vypujcka get_Vypujcka_By_Id(int id)
        {
            return Vypujcka_Repository.GetById(id);
        }
    }
}

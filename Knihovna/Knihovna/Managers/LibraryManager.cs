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
    public class LibraryManager
    {
        Repo<Knihovny> LibraryRepository 
        {
            get ; set;
        }

        public LibraryManager(Repository repo)
        {
            LibraryRepository = new();
            LibraryRepository.col = repo.GetInstance().GetCollection<Knihovny>("knihovna");
        }

        public void addLibrary(Knihovny knihovna)
        {
            LibraryRepository.Add(knihovna);
        }
        public void removeLibrary(Knihovny knihovna)
        {
            LibraryRepository.RemoveById(knihovna.Id);
        }
        public void editLibrary(Knihovny knihovna)
        {
            LibraryRepository.UpdateById(knihovna);
        }
        public ObservableCollection<Knihovny> getLibrary()
        {
           
            return LibraryRepository.GetAll();
        }
        public Knihovny getLibraryById(int id)
        {
           return LibraryRepository.GetById(id);
        }
    }
}

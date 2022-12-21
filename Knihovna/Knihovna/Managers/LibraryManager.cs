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
        Repo<Library> LibraryRepository 
        {
            get ; set;
        }

        public LibraryManager(Repository repo)
        {
            LibraryRepository = new();
            LibraryRepository.col = repo.GetInstance().GetCollection<Library>("knihovna");
        }

        public void addLibrary(Library knihovna)
        {
            LibraryRepository.Add(knihovna);
        }
        public void removeLibrary(Library knihovna)
        {
            LibraryRepository.RemoveById(knihovna.Id);
        }
        public void editLibrary(Library knihovna)
        {
            LibraryRepository.UpdateById(knihovna);
        }
        public ObservableCollection<Library> getLibrary()
        {
           
            return LibraryRepository.GetAll();
        }
        public Library getLibraryById(int id)
        {
           return LibraryRepository.GetById(id);
        }
    }
}

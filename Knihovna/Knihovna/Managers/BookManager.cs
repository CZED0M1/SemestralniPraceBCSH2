using Knihovna.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.Managers
{
    public  class BookManager
    {
       Repo<Kniha> BookRepository
        {
            get; set;
        }

        public BookManager(Repository repo)
        {
            BookRepository = new();
            BookRepository.col = repo.GetInstance().GetCollection<Kniha>("kniha");
        }

        public void addBook(Kniha kniha)
        {
            BookRepository.Add(kniha);
        }
        public void removeKniha(Kniha kniha)
        {
            BookRepository.RemoveById(kniha.Id);
        }
        public void editKniha(Kniha kniha)
        {
            BookRepository.UpdateById(kniha);
        }
        public ObservableCollection<Kniha> getKniha()
        {

            return BookRepository.GetAll();
        }
        public Kniha getKnihaById(int id)
        {
            return BookRepository.GetById(id);
        }
    }
}

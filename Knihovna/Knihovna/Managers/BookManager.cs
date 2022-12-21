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
       Repo<Book> BookRepository
        {
            get; set;
        }

        public BookManager(Repository repo)
        {
            BookRepository = new();
            BookRepository.col = repo.GetInstance().GetCollection<Book>("book");
        }

        public void addBook(Book kniha)
        {
            BookRepository.Add(kniha);
        }
        public void removeBook(Book kniha)
        {
            BookRepository.RemoveById(kniha.Id);
        }
        public void editKniha(Book kniha)
        {
            BookRepository.UpdateById(kniha);
        }
        public ObservableCollection<Book> getKniha()
        {

            return BookRepository.GetAll();
        }
        public Book getKnihaById(int id)
        {
            return BookRepository.GetById(id);
        }
    }
}

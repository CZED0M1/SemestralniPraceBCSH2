using Knihovna.Managers;
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
    public class BookViewModel
    {
        public static ObservableCollection<Book> Books
        {
            get;
            set;
        }
        public static BookManager BookManager { get; set; }
        public static void LoadBook(Repository repository)
        {
            

            BookManager bookManager = new(repository);
            BookManager = bookManager;
            if (bookManager.getKniha().Count() == 0)
            {
                Books.Add(new Book { Name = "Harry Potter", ISBN = "1241241", Author = "J.K. Rowlingová", lbId = 1 });
                Books.Add(new Book { Name = "RUR", ISBN = "1251361", Author = "Karel Čapek", lbId = 1 });
                Books.Add(new Book { Name = "Osudné svědectví", ISBN = "4276247", Author = "Robert Bryndza", lbId = 2 });
                Books.Add(new Book { Name = "Pavouk", ISBN = "4213247", Author = "Lars Kepler", lbId = 2 });
                Books.Add(new Book { Name = "Znamenitá mrtvola", ISBN = "2351356", Author = "Agustina Bazterrica", lbId = 2 });
                Books.Add(new Book { Name = "Čarodějnictví pro každý den", ISBN = "672175798", Author = "Deborah Blake", lbId = 5 });
                Books.Add(new Book { Name = "Nové Pohledy", ISBN = "99129351", Author = "Alastair Bonnett", lbId = 6 });
                foreach (var item in Books)
                {
                    bookManager.addBook(item);
                }
            }
            else
            {

                IEnumerable<Book> Kn = bookManager.getKniha();
                foreach (var item in Kn)
                {
                    Books.Add(item);
                }
            }
        }
    }
}

            





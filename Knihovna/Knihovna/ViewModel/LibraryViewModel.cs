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
    public class LibraryViewModel
    {
        public static ObservableCollection<Library> Libraries
        {
            get;
            set;
        }
        public static LibraryManager LibraryManager { get; set; }
        public static void LoadLibrary(Repository repo)
        {
            LibraryManager libraryManager = new(repo);
            LibraryManager= libraryManager;
            if (libraryManager.getLibrary().Count() == 0)
            {
                Libraries.Add(new Library { Name = "A", Id = 1 });
                Libraries.Add(new Library { Name = "B", Id = 2 });
                Libraries.Add(new Library { Name = "C", Id = 3 });
                Libraries.Add(new Library { Name = "D", Id = 4 });
                Libraries.Add(new Library { Name = "E", Id = 5 });
                Libraries.Add(new Library { Name = "F", Id = 6 });

                foreach (var item in Libraries)
                {
                    libraryManager.addLibrary(item);
                }

            }
            else
            {

                    IEnumerable<Library> Kn = libraryManager.getLibrary();
                    foreach (var item in Kn)
                    {
                        Libraries.Add(item);
                    }
                }
            }
        
        
        public static void addLibrary(Library library)
        {
            
            Libraries.Add(library);
        }

        public static void removeLibrary(Library library)
        {
            var bookToDelete = BookViewModel.Books.Where(k => k.lbId == library.Id).ToList();
            var CustToDelete = CustomerViewModel.Customers.Where(z => z.LibraryId == library.Id).ToList();
            foreach (var book in bookToDelete)
            {
                BookViewModel.Books.Remove(book);
                BookViewModel.BookManager.removeBook(book);
            }
            foreach (var zak in CustToDelete)
            {
                CustomerViewModel.Customers.Remove(zak);
                CustomerViewModel.CustomerManager.removeCustomer(zak);
            }

                LibraryManager.removeLibrary(library);
                Libraries.Remove(library);
        }
    }
}

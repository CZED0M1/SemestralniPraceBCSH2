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
    public class BorrowingsViewModel
    {
        public static ObservableCollection<Borrowing> Borrowings
        {
            get;
            set;
        }
        public static BorrowingManager BorrowingManager { get; set; }
        public static void LoadBorrows(Repository repository)
        {


            BorrowingManager borrowManager = new(repository);
            BorrowingManager = borrowManager;
            if (borrowManager.getBorrowing().Count() == 0)
            {
                Book bo = new Book { Name = "S kouzelnickou hůlkou", Author = "Felton Tom", ISBN = "263236236", lbId = 4 };
                Book bo2 = new Book { Name = "Aristokratka pod palbou lásky", Author = " Evžen Boček", ISBN = "8935882", lbId = 4 };
                Book bo3 = new Book { Name = "Přátelé, lásky a ten ohromný průšvih", Author = "Perry Matthew", ISBN = "53158923", lbId = 4 };
                Borrowings.Add(new Borrowing { Book = bo, Customer = CustomerViewModel.Customers[0] });
                Borrowings.Add(new Borrowing { Book = bo2, Customer = CustomerViewModel.Customers[1] });
                Borrowings.Add(new Borrowing { Book = bo3, Customer = CustomerViewModel.Customers[0] });

                foreach (var item in Borrowings)
                {
                    borrowManager.addBorrowing(item);
                }
            }
            else
            {

                IEnumerable<Borrowing> Kn = borrowManager.getBorrowing();
                foreach (var item in Kn)
                {
                    Borrowings.Add(item);
                }
            }
        }
    }
}
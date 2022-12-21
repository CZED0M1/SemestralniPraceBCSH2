using Knihovna.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna.Managers
{
    public class BorrowingManager
    {
        Repo<Borrowing> BorrowingRepository
        {
            get; set;
        }

        public BorrowingManager(Repository repo)
        {
            BorrowingRepository = new();
            BorrowingRepository.col = repo.GetInstance().GetCollection<Borrowing>("vypujcka");
        }

        public void addBorrowing(Borrowing vypujcka)
        {
            BorrowingRepository.Add(vypujcka);
        }
        public void removeBorrowing(Borrowing vypujcka)
        {
            BorrowingRepository.RemoveById(vypujcka.Id);
        }
        public void editBorrowing(Borrowing vypujcka)
        {
            BorrowingRepository.UpdateById(vypujcka);
        }
        public ObservableCollection<Borrowing> getBorrowing()
        {

            return BorrowingRepository.GetAll();
        }
        public Borrowing getBorrowingById(int id)
        {
            return BorrowingRepository.GetById(id);
        }
    }
}

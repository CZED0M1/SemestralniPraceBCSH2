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
        Repo<Vypujcka> BorrowingRepository
        {
            get; set;
        }

        public BorrowingManager(Repository repo)
        {
            BorrowingRepository = new();
            BorrowingRepository.col = repo.GetInstance().GetCollection<Vypujcka>("vypujcka");
        }

        public void addBorrowing(Vypujcka vypujcka)
        {
            BorrowingRepository.Add(vypujcka);
        }
        public void removeBorrowing(Vypujcka vypujcka)
        {
            BorrowingRepository.RemoveById(vypujcka.Id);
        }
        public void editBorrowing(Vypujcka vypujcka)
        {
            BorrowingRepository.UpdateById(vypujcka);
        }
        public ObservableCollection<Vypujcka> getBorrowing()
        {

            return BorrowingRepository.GetAll();
        }
        public Vypujcka getBorrowingById(int id)
        {
            return BorrowingRepository.GetById(id);
        }
    }
}
